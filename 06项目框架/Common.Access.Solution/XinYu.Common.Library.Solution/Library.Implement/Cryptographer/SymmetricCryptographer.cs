using System;
using System.Security.Cryptography;
using System.Text;

namespace XinYu.Framework.Library.Implement.Cryptographer
{
    /// <summary>
    /// Symmetric cryptographer.
    /// </summary>
    public class SymmetricCryptographer : AbstractSymmetricCryptographer
    {   
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="algorithmType">�ԳƼ����㷨����.</param>
        /// <param name="key">�ԳƼ�����Կ.</param>
        public SymmetricCryptographer(string algorithmTypeName, string algorithmKeyString)
        {
            Type algorithmType = Type.GetType(algorithmTypeName);

            //byte[] byteKey = Convert.FromBase64String(algorithmKeyString);
            //byte[] byteKey = System.Text.Encoding.ASCII.GetBytes(algorithmKeyString);
            byte[] byteKey = UnicodeEncoding.Unicode.GetBytes(algorithmKeyString);
            ProtectedKey key = ProtectedKey.CreateFromPlaintextKey(byteKey, DataProtectionScope.CurrentUser);

            base.initialize(algorithmType, key);
        }
    }
}
