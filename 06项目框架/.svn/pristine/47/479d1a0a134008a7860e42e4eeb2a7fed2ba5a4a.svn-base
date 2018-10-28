using System;
using System.Security.Cryptography;

namespace XinYu.Framework.Library.Implement.Cryptographer
{
    /// <summary>
    /// <para>Represents basic cryptography services for a <see cref="HashAlgorithm"/>.</para>
    /// </summary>
    public class HashCryptographer : AbstractHashCryptographer
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="algorithmTypeName">HASH加密算法类型.</param>
        public HashCryptographer(string algorithmTypeName)
            : this(algorithmTypeName, false)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="algorithmTypeName">HASH加密算法类型.</param>
        /// <param name="saltEnabled">HASH加密过程中是否采用加盐(Salt)处理.</param>
        public HashCryptographer(string algorithmTypeName, bool saltEnabled)
            : this(algorithmTypeName, saltEnabled, DefaultSaltLength)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="algorithmTypeName">HASH加密算法类型.</param>
        /// <param name="saltEnabled">HASH加密过程中是否采用加盐(Salt)处理.</param>
        /// <param name="saltLength">盐(Salt)的长度.</param>
        public HashCryptographer(string algorithmTypeName, bool saltEnabled, int saltLength)
        {
            Type algorithmType = Type.GetType(algorithmTypeName);
            base.initialize(algorithmType, null, saltEnabled, saltLength);
        }
    }
}
