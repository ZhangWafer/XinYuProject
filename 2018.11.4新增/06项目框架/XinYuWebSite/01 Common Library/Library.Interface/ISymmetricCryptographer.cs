// ============================================================================
// Author:         赵劼
// Create Date:    2018-05-08
// Description:    企业库加密模块接口
// Modify History: 
// ============================================================================

namespace XinYu.Framework.Library.Interface
{
    /// <summary>
    /// Represents a symmetric cryptographer.
    /// </summary>
    public interface ISymmetricCryptographer
    {
        /// <summary>
        /// Encrypts a secret using a specified symmetric cryptography provider.
        /// </summary>
        /// <param name="symmetricInstance">A symmetric instance from configuration.</param>
        /// <param name="plaintext">The input for which you want to encrypt.</param>
        /// <returns>The resulting cipher text.</returns>
        byte[] Encrypt(byte[] plaintext);

        /// <summary>
        /// Encrypts a secret using a specified symmetric cryptography provider.
        /// </summary>
        /// <param name="symmetricInstance">A symmetric instance from configuration.</param>
        /// <param name="plaintext">The input as a base64 encoded string for which you want to encrypt.</param>
        /// <returns>The resulting cipher text as a base64 encoded string.</returns>
        string Encrypt(string plaintext);

        /// <summary>
        /// Decrypts a cipher text using a specified symmetric cryptography provider.
        /// </summary>
        /// <param name="symmetricInstance">A symmetric instance from configuration.</param>
        /// <param name="ciphertext">The cipher text for which you want to decrypt.</param>
        /// <returns>The resulting plain text.</returns>
        byte[] Decrypt(byte[] encryptedText);

        /// <summary>
        /// Decrypts a cipher text using a specified symmetric cryptography provider.
        /// </summary>
        /// <param name="symmetricInstance">A symmetric instance from configuration.</param>
        /// <param name="ciphertextBase64">The cipher text as a base64 encoded string for which you want to decrypt.</param>
        /// <returns>The resulting plain text as a string.</returns>
        string Decrypt(string ciphertextBase64);
    }
}
