using IST.SpacePlanning.Data.EntityModel;
using IST.SpacePlanning.Logic.Logging;
using IST.SpacePlanning.Presentation.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signManager;
        private IAuditLogLevelManager _auditLogLevelManager;
        private const string invalidUserNameMessage = "Your UserName or Password is incorrect. Please try again.";
        private const string invalidPasswordMessage = "Your UserName or Password is incorrect. This was attempt {0} of 3.";
        private const string lockoutAccountMessage = "Three unsuccessful login attempts. For security reasons your user account wil be locked for 15 minutes";

        public AccountController(UserManager<User> userManager, 
            SignInManager<User> signManager, 
            IAuditLogLevelManager auditLogLevelManager)
        {
            _userManager = userManager;
            _signManager = signManager;
            _auditLogLevelManager = auditLogLevelManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult InitSession(LoginViewModel loginViewModel)
        {
            var user = _userManager.FindByNameAsync(loginViewModel.UserName).Result;
            if (user == null)
            { 
                _auditLogLevelManager.SaveLogEntry(invalidUserNameMessage, LogLevelCodes.InvalidUserName, Guid.Empty);
                loginViewModel.ErrorMessage = invalidUserNameMessage;
                return View("login", loginViewModel);
            }
            else
            {  
                if (user.LockoutCount == 3 && user.ActiveDate.HasValue && DateTime.UtcNow > user.ActiveDate.Value)
                {
                    _userManager.ResetAccessFailedCountAsync(user);
                }

                var loginResult = _signManager.PasswordSignInAsync(loginViewModel.UserName,
                loginViewModel.Password, true, true).Result;
                if (loginResult.Succeeded)
                {
                    _auditLogLevelManager.SaveLogEntry("LoginSuccessful", LogLevelCodes.LoginSuccessful, user.UserId);
                    return RedirectToAction("index", "home");
                }
                else if (loginResult.Equals(Microsoft.AspNetCore.Identity.SignInResult.Failed))
                {
                    _auditLogLevelManager.SaveLogEntry(invalidPasswordMessage, LogLevelCodes.InvalidUserName, user.UserId);
                    loginViewModel.ErrorMessage = string.Format(invalidPasswordMessage, user.LockoutCount);
                    return View("login", loginViewModel);
                }          
                
                loginViewModel.ErrorMessage = lockoutAccountMessage;
                _auditLogLevelManager.SaveLogEntry(lockoutAccountMessage, LogLevelCodes.InvalidUserName, user.UserId);
                return View("login", loginViewModel);
                
            }
        }

        [AllowAnonymous]
        public ActionResult TermAndConditions(int Id)
        {
            ViewBag.Id = Id;
            var closeModal = new EulaViewModel();
            var owners = System.IO.File.ReadAllText("../Presentation/wwwroot/content/IST_services_EULA.html", Encoding.GetEncoding("iso-8859-1"));
            closeModal.HtmlRaw = string.Join("", owners);

            return PartialView("TermAndConditions", closeModal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostModal()
        {
            var closeModal = new EulaViewModel
            {
                ShouldClose = true,
                FetchData = true,
                Destination = Url.Action("List"),
                Target = "list",
                OnSuccess = "success"
            };

            return PartialView("CloseModal", closeModal);
        }
    }
}