using IST.SpacePlanning.Data.EntityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IST.SpacePlanning.IntegrationTest.Logic.Authentication
{
    public class SignInManagerTest<TUser> : SignInManager<TUser> where TUser : User
    {
        public SignInManagerTest(UserManager<TUser> userManager, IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<TUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, 
            ILogger<SignInManager<TUser>> logger, IAuthenticationSchemeProvider schemes) : 
            base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
                
        }

        public SignInManagerTest():base(null, null, null, null,null,null)
        {

        }

        /// <summary>
        /// Checks if the username and password exists.
        /// </summary>
        /// <param name="userName">user name </param>
        /// <param name="password">password of user name</param>
        /// <param name="isPersistent">flag to persist the session</param>
        /// <param name="lockoutOnFailure">flag to lockout the user</param>
        /// <returns></returns>
        public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return base.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }
    }
}
