// ============================================================================
// Author:         赵劼
// Create Date:    2018-05-08
// Description:    企业库加密接口
// Modify History: 
// ============================================================================

namespace XinYu.Framework.Library.Interface
{
    /// <summary>
    /// Represents a hash cryptographer.
    /// </summary>
    public interface IHashCryptographer
    {
        /// <overrides>
        /// Computes the hash value of plain text using the given hash provider instance
        /// </overrides>
        /// <summary>
        /// Computes the hash value of plain text using the given hash provider instance
        /// </summary>
        /// <param name="hashInstance">A hash instance from configuration.</param>
        /// <param name="plaintext">The input for which to compute the hash.</param>
        /// <returns>The computed hash code.</returns>
        byte[] CreateHash(byte[] plaintext);

        /// <summary>
        /// Computes the hash value of plain text using the given hash provider instance
        /// </summary>
        /// <param name="hashInstance">A hash instance from configuration.</param>
        /// <param name="plaintext">The input for which to compute the hash.</param>
        /// <returns>The computed hash code.</returns>
        string CreateHash(string plaintext);

        /// <overrides>
        /// Compares plain text input with a computed hash using the given hash provider instance.
        /// </overrides>
        /// <summary>
        /// Compares plain text input with a computed hash using the given hash provider instance.
        /// </summary>
        /// <remarks>
        /// Use this method to compare hash values. Since hashes may contain a random "salt" value, two seperately generated
        /// hashes of the same plain text may result in different values. 
        /// </remarks>
        /// <param name="hashInstance">A hash instance from configuration.</param>
        /// <param name="plaintext">The input for which you want to compare the hash to.</param>
        /// <param name="hashedText">The hash value for which you want to compare the input to.</param>
        /// <returns><c>true</c> if plainText hashed is equal to the hashedText. Otherwise, <c>false</c>.</returns>
        bool CompareHash(byte[] plaintext, byte[] hashedText);

        /// <summary>
        /// Compares plain text input with a computed hash using the given hash provider instance.
        /// </summary>
        /// <remarks>
        /// Use this method to compare hash values. Since hashes contain a random "salt" value, two seperately generated
        /// hashes of the same plain text will result in different values. 
        /// </remarks>
        /// <param name="hashInstance">A hash instance from configuration.</param>
        /// <param name="plaintext">The input as a string for which you want to compare the hash to.</param>
        /// <param name="hashedText">The hash as a string for which you want to compare the input to.</param>
        /// <returns><c>true</c> if plainText hashed is equal to the hashedText. Otherwise, <c>false</c>.</returns>
        bool CompareHash(string plaintext, string hashedText);
    }
}
