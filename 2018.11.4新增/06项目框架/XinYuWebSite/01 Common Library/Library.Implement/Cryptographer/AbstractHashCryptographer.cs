

using System;
using System.Security.Cryptography;
using System.Text;
using XinYu.Framework.Library.Interface;

namespace XinYu.Framework.Library.Implement.Cryptographer
{
    /// <summary>
    /// Abstract hasher.
    /// </summary>
    public abstract class AbstractHashCryptographer : IHashCryptographer
    {
        protected const int DefaultSaltLength = 16;

        protected Type algorithmType;
        protected ProtectedKey key;
        protected bool saltEnabled;
        protected int saltLength;

        /// <summary>
        /// 初始化HASH加密器.
        /// </summary>
        /// <param name="algorithmType">HASH加密算法类型.</param>
        /// <param name="key">HASH密钥. 可选.</param>
        /// <param name="saltEnabled">在HASH加密过程中, 是否采用加盐(Salt)处理. </param>
        /// <param name="saltLength">盐(Salt)的长度.</param>
        protected void initialize(Type algorithmType, ProtectedKey key, bool saltEnabled, int saltLength)
        {
            if (algorithmType == null)
                throw new ArgumentNullException("algorithmType");
            if (!typeof(HashAlgorithm).IsAssignableFrom(algorithmType))
                throw new ArgumentException(Properties.Resources.ExceptionCreatingHashAlgorithmInstance, "algorithmType");

            this.algorithmType = algorithmType;
            this.key = key;
            this.saltEnabled = saltEnabled;
            this.saltLength = saltLength;
        }

        #region IHashCryptographer element.

        /// <summary>
        /// <para>Computes the hash value of the plaintext.</para>
        /// </summary>
        /// <param name="plaintext"><para>The plaintext in which you wish to hash.</para></param>
        /// <returns><para>The resulting hash.</para></returns>
        public virtual byte[] CreateHash(byte[] plaintext)
        {
            return this.CreateHashWithSalt(plaintext, null);
        }

        public virtual string CreateHash(string plaintext)
        {
            byte[] plainTextBytes = UnicodeEncoding.Unicode.GetBytes(plaintext);
            byte[] resultBytes = this.CreateHash(plainTextBytes);

            // 清空该字节数组.
            CryptographyUtility.GetRandomBytes(plainTextBytes);

            return Convert.ToBase64String(resultBytes);
        }

        public virtual bool CompareHash(byte[] plaintext, byte[] hashedText)
        {
            if (plaintext == null) throw new ArgumentNullException("plainText");
            if (hashedText == null) throw new ArgumentNullException("hashedText");
            if (hashedText.Length == 0) throw new ArgumentException(Properties.Resources.ExceptionByteArrayValueMustBeGreaterThanZeroBytes, "hashedText");

            bool result = false;
            byte[] hashedPlainText = null;
            byte[] salt = null;
            try
            {
                salt = this.ExtractSalt(hashedText);
                hashedPlainText = this.CreateHashWithSalt(plaintext, salt);
            }
            finally
            {
                CryptographyUtility.ZeroOutBytes(salt);
            }
            result = CryptographyUtility.CompareBytes(hashedPlainText, hashedText);

            return result;
        }

        public virtual bool CompareHash(string plaintext, string hashedText)
        {
            byte[] plainTextBytes = UnicodeEncoding.Unicode.GetBytes(plaintext);
            byte[] hashedTextBytes = Convert.FromBase64String(hashedText);

            bool result = this.CompareHash(plainTextBytes, hashedTextBytes);

            CryptographyUtility.GetRandomBytes(plainTextBytes);

            return result;
        }
        #endregion

        #region Protected motheds.

        /// <summary>
        /// 反射创建HASH算法实例.
        /// </summary>
        /// <returns>HASH算法实例</returns>
        protected HashAlgorithm GetHashAlgorithm()
        {
            HashAlgorithm algorithm = Activator.CreateInstance(this.algorithmType, true) as HashAlgorithm;

            KeyedHashAlgorithm keyedHashAlgorithm = algorithm as KeyedHashAlgorithm;
            if (null != keyedHashAlgorithm && this.key != null)
            {
                keyedHashAlgorithm.Key = this.key.DecryptedKey;
            }

            return algorithm;
        }

        /// <summary>
        /// <para>Computes the hash value of the plaintext.</para>
        /// </summary>
        /// <param name="plaintext"><para>The plaintext in which you wish to hash.</para></param>
        /// <returns><para>The resulting hash.</para></returns>
        protected byte[] ComputeHash(byte[] plaintext)
        {
            byte[] hash = null;

            using (HashAlgorithm algorithm = this.GetHashAlgorithm())
            {
                hash = algorithm.ComputeHash(plaintext);
            }

            return hash;
        }

        /// <summary>
        /// Creates a hash with a specified salt.
        /// </summary>
        /// <param name="plaintext">The plaintext to hash.</param>
        /// <param name="salt">The hash salt.</param>
        /// <returns>The computed hash.</returns>
        protected byte[] CreateHashWithSalt(byte[] plaintext, byte[] salt)
        {
            this.AddSaltToPlainText(ref salt, ref plaintext);

            byte[] hash = this.ComputeHash(plaintext);

            this.AddSaltToHash(salt, ref hash);

            return hash;
        }

        /// <summary>
        /// Extracts the salt from the hashedText.
        /// </summary>
        /// <param name="hashedtext">The hash in which to extract the salt.</param>
        /// <returns>The extracted salt.</returns>
        protected byte[] ExtractSalt(byte[] hashedtext)
        {
            if (!this.saltEnabled)
                return null;

            byte[] salt = null;
            if (hashedtext.Length > this.saltLength)
            {
                salt = new byte[this.saltLength];
                Buffer.BlockCopy(hashedtext, 0, salt, 0, this.saltLength);
            }
            return salt;
        }

        protected void AddSaltToHash(byte[] salt, ref byte[] hash)
        {
            if (!this.saltEnabled)
                return;

            hash = CryptographyUtility.CombineBytes(salt, hash);
        }

        protected void AddSaltToPlainText(ref byte[] salt, ref byte[] plaintext)
        {
            if (!this.saltEnabled)
                return;

            if (salt == null)
                salt = CryptographyUtility.GetRandomBytes(this.saltLength);

            plaintext = CryptographyUtility.CombineBytes(salt, plaintext);
        }
        #endregion
    }
}
