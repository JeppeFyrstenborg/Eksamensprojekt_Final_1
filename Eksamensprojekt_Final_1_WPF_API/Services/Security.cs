using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Eksamensprojekt_Final_1_WPF_API.Services
{
    public class Security
    {
        public Tuple<string, string> GetHashedPasswordAndSaltFrom(SecureString password)
        {
            // Generate a random salt value
            byte[] salt = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Convert the SecureString password to a byte array
            byte[] passwordBytes = ConvertSecureStringToByteArray(password);

            // Concatenate the password and salt
            byte[] passwordWithSalt = new byte[passwordBytes.Length + salt.Length];
            Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, passwordWithSalt, passwordBytes.Length, salt.Length);

            // Compute the hash of the password + salt
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(passwordWithSalt);

            // Convert the hash and salt to strings for storage
            string hashString = Convert.ToBase64String(hash);
            string saltString = Convert.ToBase64String(salt);

            return Tuple.Create(hashString, saltString);
        }

        private byte[] ConvertSecureStringToByteArray(SecureString secureString)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                // Decrypt the SecureString into an unmanaged BSTR
                valuePtr = Marshal.SecureStringToBSTR(secureString);

                // Copy the unmanaged BSTR to a managed byte array
                int length = Marshal.ReadInt32(valuePtr, -4);
                byte[] byteArray = new byte[length];
                Marshal.Copy(valuePtr, byteArray, 0, length);

                return byteArray;
            }
            finally
            {
                // Free the unmanaged BSTR
                Marshal.ZeroFreeBSTR(valuePtr);
            }
        }

        public bool AreSecureStringsEqual(SecureString secureString1, SecureString secureString2)
        {
            string stringPass1 = new NetworkCredential("", secureString1).Password;
            string stringPass2 = new NetworkCredential("", secureString2).Password;

            return string.Equals(stringPass1, stringPass2);
        }
    }
}
