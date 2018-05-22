using IST.SpacePlanning.Data.EntityModel;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IST.SpacePlanning.Logic.Session
{
    public class UserClaimsPrincipalSP : IUserClaimsPrincipalFactory<User>
    {
        /// <summary>
        /// Creates the session values like Name, Role.
        /// </summary>
        /// <param name="user">valid user instance</param>
        /// <returns>Sessiong values </returns>
        public Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var userClaims = new List<Claim>();
            userClaims.Add(new Claim(ClaimTypes.Name, user.Username, ClaimValueTypes.String));
            userClaims.Add(new Claim(ClaimTypes.Role, user.UserRole.First().Role.Name, ClaimValueTypes.String));
            var userIdentity = new ClaimsIdentity("ISTSession");
            userIdentity.AddClaims(userClaims);
            var userSP = new ClaimsPrincipal(userIdentity);
            return Task.FromResult(userSP);
        }
    }
}
