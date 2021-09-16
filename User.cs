

namespace Lab1
{
    /// <summary>
    /// Abstract class user
    /// </summary>
    public abstract class User
    {
        /// <summary>
        /// User login
        /// </summary>
        public string Login { get; private set; }
        /// <summary>
        /// Salt to user password
        /// </summary>
        public string Salt { get; private set; }
        /// <summary>
        /// User password
        /// </summary>
        public byte[] Password { get; private set; }
        /// <summary>
        /// New user creation.
        /// </summary>
        /// <param name="login">Login to users account</param>
        /// <param name="password">Password to user account</param>
        public User(string login, string password,string salt) 
        {
            Login = login;
            Salt = salt;
            Password = GetHash(password);
        }
        /// <summary>
        /// Abstract method to check entered password
        /// </summary>
        /// <param name="password">Inputed password</param>
        /// <returns>Returns true if password correct, returns false in other cases.</returns>
        abstract public bool PassCheck(string attemptedPassword);

        abstract public byte[] GetHash(string password);

    }
}
