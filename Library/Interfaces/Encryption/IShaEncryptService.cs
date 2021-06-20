namespace Library.Interfaces.Encryption
{
    public interface IShaEncryptService
    {
        /// <summary>
        /// 字串轉SHA1
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns>SHA512字串</returns>
        string SHA1Encrypt(string value);

        /// <summary>
        /// 字串轉SHA256
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns>SHA512字串</returns>
        string SHA256Encrypt(string value);

        /// <summary>
        /// 字串轉SHA384
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns>SHA512字串</returns>
        string SHA384Encrypt(string value);

        /// <summary>
        /// 字串轉SHA512
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns>SHA512字串</returns>
        string SHA512Encrypt(string value);
    }
}
