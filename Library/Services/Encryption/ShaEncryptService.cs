using Library.Interfaces.Encryption;
using System.Security.Cryptography;
using System.Text;

namespace Library.Services.Encryption
{
    /// <summary>
    /// SHA加密技術
    /// </summary>
    public class ShaEncryptService : IShaEncryptService
    {
        /// <summary>
        /// 字串轉SHA1
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns>SHA512字串</returns>
        public string SHA1Encrypt(string value)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA1Managed sha1hasher = new SHA1Managed();
            byte[] hashedDataBytes = sha1hasher.ComputeHash(encoder.GetBytes(value));
            return this.ByteArrayToString(hashedDataBytes);
        }

        /// <summary>
        /// 字串轉SHA256
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns>SHA512字串</returns>
        public string SHA256Encrypt(string value)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(value));
            return this.ByteArrayToString(hashedDataBytes);
        }

        /// <summary>
        /// 字串轉SHA384
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns>SHA512字串</returns>
        public string SHA384Encrypt(string value)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA384Managed sha384hasher = new SHA384Managed();
            byte[] hashedDataBytes = sha384hasher.ComputeHash(encoder.GetBytes(value));
            return this.ByteArrayToString(hashedDataBytes);
        }

        /// <summary>
        /// 字串轉SHA512
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns>SHA512字串</returns>
        public string SHA512Encrypt(string value)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA512Managed sha512hasher = new SHA512Managed();
            byte[] hashedDataBytes = sha512hasher.ComputeHash(encoder.GetBytes(value));
            return this.ByteArrayToString(hashedDataBytes);
        }

        /// <summary>
        /// Byte陣列轉String
        /// </summary>
        /// <param name="inputArray">輸入Byte陣列</param>
        /// <returns></returns>
        private string ByteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i <= inputArray.Length - 1; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }
            return output.ToString();
        }
    }
}
