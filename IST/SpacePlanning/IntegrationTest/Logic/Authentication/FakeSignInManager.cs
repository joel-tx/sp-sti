using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace IST.SpacePlanning.IntegrationTest.Logic.Authentication
{
    public class FakeSignInManager : SignInManager<User>
    {
        private UnitOfWork _unitOfWork;
        public FakeSignInManager(UnitOfWork unitOfWork)
            : base(new Mock<FakeUserManager>().Object,
                  new HttpContextAccessor(),
                  new Mock<IUserClaimsPrincipalFactory<User>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<ILogger<SignInManager<User>>>().Object, null)
        {
            _unitOfWork = unitOfWork;

        }

        public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            User user = _unitOfWork.UserRepository.GetAll().SingleOrDefault(u => u.Username.Equals(userName));
            if (user != null && user.Password.Equals(password))
            {
                return Task.FromResult(SignInResult.Success);
            }
            else if (user != null && user.LockoutCount >= 3)
            {
                return Task.FromResult(SignInResult.LockedOut);
            }
            else
            {
                return Task.FromResult(SignInResult.Failed);
            }
        }
    }
}
