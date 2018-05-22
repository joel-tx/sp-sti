using IST.SpacePlanning.Data.EntityModel;
using Microsoft.AspNetCore.Identity;
using STP.SpacePlanning.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IST.SpacePlanning.Logic.Security
{
    public class SHA256Encryptation : IPasswordHasher<User>
    {
        /// <summary>
        /// Encrypts password of specific user
        /// </summary>
        /// <param name="user">user with password</param>
        /// <param name="password">password to encrypt</param>
        /// <returns></returns>
        public string HashPassword(User user, string password)
        {
            return Encryption.Encrypt(password);
        }

        /// <summary>
        /// Checks if the hashedPassword is equals to providedPassword
        /// </summary>
        /// <param name="user">user owner of the password</param>
        /// <param name="hashedPassword">hashed password of user</param>
        /// <param name="providedPassword">hashed password sended by UI</param>
        /// <returns></returns>
        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            if (user != null && hashedPassword.Equals(HashPassword(user, providedPassword)))
            {
                return PasswordVerificationResult.Success;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
}
