

using System;
using System.Security.Cryptography;
using System.Text;
using XinYu.Framework.Library.Interface;

namespace XinYu.Framework.Library.Implement.Cryptographer
{
    /// <summary>
    /// Abstract Symmetric Cryptographer.
    /// </summary>
    public abstract class AbstractSymmetricCryptographer : ISymmetricCryptographer
    {
        private SymmetricAlgorithm algorithm;
        private ProtectedKey key;

        /// <summary>
        /// 加密密钥.
        /// </summary>
        private byte[] Key
        {
            get { return key.DecryptedKey; }
        }

        /// <summary>
        /// 对称算法的初始化向量长度.
        /// </summary>
        private int IVLength
        {
            get
            {
                if (this.algorithm.IV == null)
                {
                    this.algorithm.GenerateIV();
                }
                return this.algorithm.IV.Length;
            }
        }

        #region Constructor & Deconstructor.

        /// <summary>
        /// 初始实例对象.
        /// </summary>
        /// <param name="algorithmType">对称加密算法类型.</param>
        /// <param name="key">对称加密密钥.</param>
        protected void initialize(Type algorithmType, ProtectedKey key)
        {
            if (algorithmType == null) throw new ArgumentNullException("algorithmType");
            if (!typeof(SymmetricAlgorithm).IsAssignableFrom(algorithmType)) throw new ArgumentException(Properties.Resources.ExceptionCreatingSymmetricAlgorithmInstance, "algorithmType");
            if (key == null) throw new ArgumentNullException("key");

            this.key = key;
            this.algorithm = this.GetSymmetricAlgorithm(algorithmType);
        }

        /// <summary>
        /// Finalizer for <see cref="SymmetricCryptographer"/>
        /// </summary>
        ~AbstractSymmetricCryptographer()
        {
            Dispose(false);
        }

        /// <summary>
        /// Override to customize resources to be disposed.
        /// </summary>
        /// <param name="disposing">Unused.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (algorithm != null)
            {
                algorithm.Clear();
                algorithm = null;
            }
            System.GC.SuppressFinalize(this);
        }
        #endregion

        #region ISymmetricCryptographer elements.

        /// <summary>
        /// <para>Encrypts bytes with the initialized algorithm and key.</para>
        /// </summary>
        /// <param name="plaintext"><para>The plaintext in which you wish to encrypt.</para></param>
        /// <returns><para>The resulting ciphertext.</para></returns>
        public virtual byte[] Encrypt(byte[] plaintext)
        {
            byte[] output = null;
            byte[] cipherText = null;

            this.algorithm.Key = Key;

            using (ICryptoTransform transform = this.algorithm.CreateEncryptor())
            {
                //cipherText = this.Transform(transform, plaintext);
                cipherText = CryptographyUtility.Transform(transform, plaintext);

            }

            output = new byte[IVLength + cipherText.Length];
            Buffer.BlockCopy(this.algorithm.IV, 0, output, 0, IVLength);
            Buffer.BlockCopy(cipherText, 0, output, IVLength, cipherText.Length);

            CryptographyUtility.ZeroOutBytes(this.algorithm.Key);

            return output;
        }

        public virtual string Encrypt(string plaintext)
        {
            byte[] plainTextBytes = UnicodeEncoding.Unicode.GetBytes(plaintext);

            byte[] cipherTextBytes = this.Encrypt(plainTextBytes);

            CryptographyUtility.GetRandomBytes(plainTextBytes);

            return Convert.ToBase64String(cipherTextBytes);
        }

        /// <summary>
        /// <para>Decrypts bytes with the initialized algorithm and key.</para>
        /// </summary>
        /// <param name="encryptedText"><para>The text which you wish to decrypt.</para></param>
        /// <returns><para>The resulting plaintext.</para></returns>
        public virtual byte[] Decrypt(byte[] encryptedText)
        {
            byte[] output = null;
            byte[] data = this.ExtractIV(encryptedText);

            this.algorithm.Key = Key;

            using (ICryptoTransform transform = this.algorithm.CreateDecryptor())
            {
                //output = this.Transform(transform, data);
                output = CryptographyUtility.Transform(transform, data);
            }

            CryptographyUtility.ZeroOutBytes(this.algorithm.Key);

            return output;
        }

        public virtual string Decrypt(string ciphertextBase64)
        {
            if (string.IsNullOrEmpty(ciphertextBase64)) throw new ArgumentException(Properties.Resources.ExceptionNullOrEmptyString, "ciphertextBase64");

            byte[] cipherTextBytes = Convert.FromBase64String(ciphertextBase64);
            byte[] decryptedBytes = this.Decrypt(cipherTextBytes);

            string decryptedString = UnicodeEncoding.Unicode.GetString(decryptedBytes);
            CryptographyUtility.GetRandomBytes(decryptedBytes);

            return decryptedString;
        }
        #endregion

        private byte[] ExtractIV(byte[] encryptedText)
        {
            byte[] initVector = new byte[IVLength];

            if (encryptedText.Length < IVLength + 1)
            {
                throw new CryptographicException(Properties.Resources.ExceptionDecrypting);
            }

            byte[] data = new byte[encryptedText.Length - IVLength];

            Buffer.BlockCopy(encryptedText, 0, initVector, 0, IVLength);
            Buffer.BlockCopy(encryptedText, IVLength, data, 0, data.Length);

            this.algorithm.IV = initVector;

            return data;
        }

        /// <summary>
        /// 反射创建对称加密算法实例对象.
        /// </summary>
        /// <param name="algorithmType">加密算法对象类型.</param>
        /// <returns>加密算法实例对象.</returns>
        private SymmetricAlgorithm GetSymmetricAlgorithm(Type algorithmType)
        {
            SymmetricAlgorithm symmetricAlgorithm = Activator.CreateInstance(algorithmType) as SymmetricAlgorithm;
            return symmetricAlgorithm;
        }
    }
}
