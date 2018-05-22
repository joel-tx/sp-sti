using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using STP.SpacePlanning.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IST.SpacePlanning.Logic.Administration
{
    public class UserManagerSP : UserManager<User>
    {

        public UserManagerSP(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, 
            IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, 
            ILogger<UserManager<User>> logger) : 
            base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            
        }

        /// <summary>
        /// Verifies if the user and password are the same.
        /// TODO implement IUserPasswordStore and IPasswordHasher
        /// </summary>
        /// <param name="user">a valid user instance </param>
        /// <param name="password">password of user</param>
        /// <returns>True if the password belongs of user in otherwise return false</returns>
        public override Task<bool> CheckPasswordAsync(User user, string password)
        {
            return Task.FromResult(user.Password.Equals(password));
        }
    }
}
