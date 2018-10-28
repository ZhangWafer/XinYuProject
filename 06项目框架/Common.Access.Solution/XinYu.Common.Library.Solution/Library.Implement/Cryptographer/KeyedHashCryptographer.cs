using System;
using System.Security.Cryptography;
using System.Text;

namespace XinYu.Framework.Library.Implement.Cryptographer
{
    /// <summary>
    /// Represents basic cryptography services for a HashAlgorithm using key.</para>
    /// </summary>
    public class KeyedHashCryptographer : AbstractHashCryptographer
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="algorithmType">HASH加密算法类型.</param>
        /// <param name="key">HASH密钥. 可选.</param>
        public KeyedHashCryptographer(string algorithmTypeName, string algorithmKeyString)
            : this(algorithmTypeName, algorithmKeyString, false)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="algorithmType">HASH加密算法类型.</param>
        /// <param name="key">HASH密钥. 可选.</param>
        /// <param name="saltEnabled">在HASH加密过程中, 是否采用加盐(Salt)处理. </param>
        public KeyedHashCryptographer(string algorithmTypeName, string algorithmKeyString, bool saltEnabled)
            : this(algorithmTypeName, algorithmKeyString, false, DefaultSaltLength)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="algorithmType">HASH加密算法类型.</param>
        /// <param name="key">HASH密钥. 可选.</param>
        /// <param name="saltEnabled">在HASH加密过程中, 是否采用加盐(Salt)处理. </param>
        /// <param name="saltLength">盐(Salt)的长度.</param>
        public KeyedHashCryptographer(string algorithmTypeName, string algorithmKeyString, bool saltEnabled, int saltLength)
        {
            Type algorithmType = Type.GetType(algorithmTypeName);

            //byte[] byteKey = Convert.FromBase64String(algorithmKeyString);
            byte[] byteKey = UnicodeEncoding.Unicode.GetBytes(algorithmKeyString);
            ProtectedKey key = ProtectedKey.CreateFromPlaintextKey(byteKey, DataProtectionScope.CurrentUser);

            base.initialize(algorithmType, key, saltEnabled, saltLength);
        }
    }
}
