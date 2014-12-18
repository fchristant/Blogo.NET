using System;
using System.Web.Security;
using System.Web.Configuration;
using System.Security.Cryptography;

namespace Blogo.NET.Utils
{

    /// <summary>
    /// Utility class to hash passwords and generate salts
    /// </summary>


    public static class Hash
    {

        /// <summary>
        /// Hashed the specified password using the specified salt
        /// </summary>
        /// <param name="password">
        /// the password to hash
        /// </param>
        /// <param name="salt">
        /// the salt to use to hash the password
        /// </param>
        /// <returns>
        /// returns a hashed password
        /// </returns>

        public static string HashPassword(string password, string salt)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(salt + password, FormsAuthPasswordFormat.SHA1.ToString());
        }

        /// <summary>
        /// Generates a salt value given a specified size
        /// </summary>
        /// <param name="size">
        /// the size to use for the hash
        /// </param>
        /// <returns>
        /// returns a salt value
        /// </returns>

        public static string GenerateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
    }
}
