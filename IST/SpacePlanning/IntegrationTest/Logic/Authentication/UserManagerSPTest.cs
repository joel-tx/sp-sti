using Castle.Core.Logging;
using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using IST.SpacePlanning.Logic.Administration;
using IST.SpacePlanning.Logic.Services;
using IST.SpacePlanning.UnitTest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestSupport.EfHelpers;
using Xunit;

namespace IST.SpacePlanning.IntegrationTest.Logic.Authentication
{
    public class UserManagerSPTest
    {
        
        protected UnitOfWork _spacePlanningUnitOfWork;
        protected DbContextOptions<ISTSpacePlanningContext> _dbOptions;
        protected ISTSpacePlanningContext _context;
         
       
        public UserManagerSPTest()
        {
            _dbOptions = SqliteInMemory.CreateOptions<ISTSpacePlanningContext>();
            _context = new ISTSpacePlanningContext(_dbOptions);
            _spacePlanningUnitOfWork = new UnitOfWork(_context);
            
            _context.Database.EnsureCreated();
        }

        [Fact]
        public void ShouldValidateSessionWhenDBContextIsValid()
        {
            User existingUser = FactoryUser.RandomCreate();
            User invalidUser = FactoryUser.RandomCreate();
            invalidUser.Password = "invalid Password";
            _spacePlanningUnitOfWork.UserRepository.Add(existingUser);
            _spacePlanningUnitOfWork.Save();
            var store = new Mock<IUserStore<User>>();
           
            UserLockoutStoreSP lockout = new UserLockoutStoreSP(_spacePlanningUnitOfWork);
            var _userManager = new UserManagerSP(lockout, null, null, null, null, null, null, null, null);
            Assert.True(_userManager.CheckPasswordAsync(existingUser, existingUser.Password).Result);
            Assert.False(_userManager.CheckPasswordAsync(existingUser, invalidUser.Password).Result);
        }

        ~UserManagerSPTest()
        {
            _spacePlanningUnitOfWork.Dispose();
        }
    }
}
