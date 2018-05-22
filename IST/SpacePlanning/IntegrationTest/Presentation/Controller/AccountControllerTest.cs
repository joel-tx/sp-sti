using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using IST.SpacePlanning.IntegrationTest.Logic.Authentication;
using IST.SpacePlanning.Logic.Logging;
using IST.SpacePlanning.Presentation.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Presentation.Controllers;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestSupport.EfHelpers;
using Xunit;

namespace IST.SpacePlanning.IntegrationTest.Presentation.Controller
{
    public class AccountControllerTest
    {  
        private ISTSpacePlanningContext _spacePlanningContext;
        protected DbContextOptions<ISTSpacePlanningContext> _dbOptions;
        private UnitOfWork _unitOfWork;
        private User _newUser;
        private LoginViewModel _userModel;
        private AccountController accountController;
        
        private Mock<IUserLockoutStore<User>> lockoutUserStore;
        private Mock<IAuditLogLevelManager> _AuditLogLevelManager;

        public AccountControllerTest()
        {
            _newUser = new User() { UserId = Guid.NewGuid(), Username = "user1", Password = "password" };
            _userModel = new LoginViewModel() { UserName = _newUser.Username, Password = _newUser.Password };
            _dbOptions = SqliteInMemory.CreateOptions<ISTSpacePlanningContext>();
            _spacePlanningContext = new ISTSpacePlanningContext(_dbOptions);
            _unitOfWork = new UnitOfWork(_spacePlanningContext);
            _spacePlanningContext.Database.EnsureCreated();
            _AuditLogLevelManager = new Mock<IAuditLogLevelManager>();
            _AuditLogLevelManager.Setup(t =>
            t.SaveLogEntry(It.IsAny<string>(), It.IsAny<LogLevelCodes>(), It.IsAny<Guid>()));           
            _unitOfWork.UserRepository.Add(_newUser);
            _unitOfWork.Save();
            lockoutUserStore = new Mock<IUserLockoutStore<User>>();
        }

        [Fact]
        public void ShouldAllowInitSessionWhenCredentialsAreCorrect()
        {
            
            lockoutUserStore.Setup(t => t.FindByNameAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).
                Returns(Task.FromResult(_newUser));
            accountController = new AccountController(new FakeUserManager(lockoutUserStore.Object), 
                new FakeSignInManager(_unitOfWork), _AuditLogLevelManager.Object);
            RedirectToActionResult loginView = accountController.InitSession(_userModel) as RedirectToActionResult;
            Assert.True("index".Equals(loginView.ActionName, StringComparison.CurrentCultureIgnoreCase));
            Assert.True("Home".Equals(loginView.ControllerName, StringComparison.CurrentCultureIgnoreCase));
        }

        [Fact]
        public void ShouldRedirectToLoginPageWhenAccountIsNotCorrect()
        {
            accountController = new AccountController(new FakeUserManager(), 
                new FakeSignInManager(_unitOfWork), _AuditLogLevelManager.Object);
            ViewResult loginView = accountController.InitSession(_userModel) as ViewResult;
            Assert.True("login".Equals(loginView.ViewName, StringComparison.CurrentCultureIgnoreCase));
            var model = loginView.Model as LoginViewModel;
            Assert.Equal("Your UserName or Password is incorrect. Please try again.", model.ErrorMessage);
        }

        [Fact]
        public void ShouldRedirectToLoginPageWhenPassworIsNotCorrect()
        {
            lockoutUserStore.Setup(t => t.FindByNameAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).
                Returns(Task.FromResult(_newUser));
            accountController = new AccountController(new FakeUserManager(lockoutUserStore.Object),
                new FakeSignInManager(_unitOfWork), _AuditLogLevelManager.Object);
            _userModel.Password = "invalid Password";
            ViewResult loginView = accountController.InitSession(_userModel) as ViewResult;
            Assert.True("login".Equals(loginView.ViewName, StringComparison.CurrentCultureIgnoreCase));
            var model = loginView.Model as LoginViewModel;
            Assert.Contains("Your UserName or Password is incorrect. This was attempt", model.ErrorMessage);
        }

        [Fact]
        public void ShouldRedirectToLoginPageAndLockoutAccountWhenPasswordIsInvalidwithTreeFailedAttempts()
        {
            _userModel.Password = "invalid Password";
            _newUser.LockoutCount = 3;
            _unitOfWork.UserRepository.Update(_newUser);
            _unitOfWork.Save();
            lockoutUserStore.Setup(t => t.FindByNameAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).
               Returns(Task.FromResult(_newUser));
            accountController = new AccountController(new FakeUserManager(lockoutUserStore.Object),
                new FakeSignInManager(_unitOfWork), _AuditLogLevelManager.Object);
            _userModel.Password = "invalid Password";
            ViewResult loginView = accountController.InitSession(_userModel) as ViewResult;
            Assert.True("login".Equals(loginView.ViewName, StringComparison.CurrentCultureIgnoreCase));
            var model = loginView.Model as LoginViewModel;
            Assert.Contains("Three unsuccessful login attempts. For security reasons your user account wil be locked for 15 minutes", model.ErrorMessage);

        }

        ~AccountControllerTest()
        {
            accountController.Dispose();
            _spacePlanningContext.Dispose();
        }

    }
}
