
using System;
using System.Security.Cryptography;
using System.Text;

namespace Lab1
{
    public class Admin : User
    {
        /// <summary>
        /// Count of wrong password inputs.
        /// </summary>
        public int PasswordInputCount { get; private set; }
        /// <summary>
        /// State of users account. True means blocked.
        /// </summary>
        public bool Blocked { get; private set; }

        /// <summary>
        /// New administrator creation.
        /// </summary>
        /// <param name="login">Login to account</param>
        /// <param name="password">Password to account</param>
       
        public Admin(string login, string password, string salt) : base(login, password, salt) 
        {
            PasswordInputCount = 0;
            Blocked = false;
        }

        public override byte[] GetHash(string password)
        {
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(Salt, password));

            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);

            return hashedBytes;
        }

        public override bool PassCheck(string attemptedPassword)
        {
            string base64Hash = Convert.ToBase64String(Password);
            string base64AttemptedHash = Convert.ToBase64String(GetHash(attemptedPassword));

            if (base64Hash == base64AttemptedHash) 
            {
                PasswordInputCount = 0;
                return true;
            }
            else
            {
                PasswordInputCount++;
                if (PasswordInputCount == 3)
                {
                    Blocked = true;
                }

                return false;
            }
        }
    }
}
