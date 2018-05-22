
using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using IST.SpacePlanning.Data.Repository;
using Microsoft.AspNetCore.Identity;
using STP.SpacePlanning.Utilities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IST.SpacePlanning.Logic.Services
{
    public class UserLockoutStoreSP : IUserLockoutStore<User>, IUserPasswordStore<User>
    {
        private UnitOfWork _unitOfWork;
        private IRepository<User> _userRepository;
        private IRepository<UserRole> _userRoleRepository;
        private IRepository<Role> _roleRepository;        
        private LogLevelRepository _logLevelRepository;        

        public UserLockoutStoreSP(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Setup(_unitOfWork);
        }

        public UserLockoutStoreSP()
        {
            _unitOfWork = new UnitOfWork();
            Setup(_unitOfWork);
        }

        private void Setup(UnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.UserRepository;
            _userRoleRepository = unitOfWork.UserRoleRepository;
            _roleRepository = unitOfWork.RoleRepository;
            _logLevelRepository = unitOfWork.LogLevelRepository;
        }

        #region
        /// <summary>
        /// Saves user into Space Planning DB.
        /// </summary>
        /// <param name="user">user instance</param>
        /// <param name="cancellationToken">cancellation token to interrup the operation</param>
        /// <returns>Success</returns>
        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            _userRepository.Add(user);
            _unitOfWork.Save();
            return Task.FromResult(IdentityResult.Success);
        }

        /// <summary>
        /// Deletes User of the Space Planning DB
        /// </summary>
        /// <param name="user">user isntance</param>
        /// <param name="cancellationToken">cancellation token to interrup the operation</param>
        /// <returns></returns>
        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            _userRepository.Delete(user);
            _unitOfWork.Save();
            return Task.FromResult(IdentityResult.Success);
        }

        /// <summary>
        /// Finds by user by userId.
        /// 
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <param name="cancellationToken">cancellation token to interrrup the process</param>
        /// <returns>User if the userId exists in the User Table in otherwise return null</returns>
        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.GetAll().SingleOrDefault(u => u.UserId.Equals(new Guid(userId))));
        }

        /// <summary> //TOD add loading reference to Repository
        /// Returs the user based in the user Name, if the userName does not exits it returns null.
        /// </summary>
        /// <param name="userName">user Name to find</param>
        /// <param name="cancellationToken">cancellation toke instance</param>
        /// <returns></returns>
        public Task<User> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            Ensure.ArgumentNotNull(userName, "userName", "User Name is required.");
            User user = _userRepository.GetAll().SingleOrDefault(u => u.Username.Equals(userName, StringComparison.CurrentCultureIgnoreCase));
            if (user != null)
            {
                UserRole userRole = _userRoleRepository.GetAll().SingleOrDefault(r => r.UserId.Equals(user.UserId));
                Role role = _roleRepository.GetAll().SingleOrDefault(r => r.RoleId.Equals(userRole.RoleId));
                userRole.Role = role;
                user.UserRole.Add(userRole);
            }

            return Task.FromResult(user);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sets UserName of specific User instance.
        /// </summary>
        /// <param name="user">source of user instance</param>
        /// <param name="userName">new user name </param>
        /// <param name="cancellationToken">cancellation token to interrupt the action.</param>
        /// <returns></returns>
        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.Username = userName;
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {   
            try
            {
                _userRepository.Update(user);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                IdentityError error = new IdentityError();
                error.Description = string.Format("Unexpected error occurred " +
                    "while updating user information. Error={0}", ex.ToString());
                Task.FromResult(IdentityResult.Failed(error));
            }

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        /// <summary>
        /// Gets user identifier
        /// </summary>
        /// <param name="user">source of user instance</param>
        /// <param name="cancellationToken"></param>
        /// <returns>user identifier in otherwise return null</returns>
        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserId.ToString());
        }

        /// <summary>
        /// Gets the UserName of the user instance.
        /// </summary>
        /// <param name="user">source of user instance</param>
        /// <param name="cancellationToken">cancellation instance to interrupt the action.</param>
        /// <returns></returns>
        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }
        #endregion
      
        public Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.LockoutCount);
        }
        
        public Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.ActiveDate > DateTime.UtcNow); 
        }
       
        /// <summary>
        /// Gets DateTime where the user was blocked.
        /// </summary>
        /// <param name="user">user to retrieve lockout information</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Return null If user is not locked in otherwise it returns Duration of lockout</returns>
        public Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancellationToken)
        {
            DateTimeOffset? inactiveDate = null;
            if (user.ActiveDate.HasValue && user.ActiveDate.Value > DateTime.UtcNow)
            {
                inactiveDate = new DateTimeOffset(user.ActiveDate.Value);
            }

            return Task.FromResult(inactiveDate);
        }
       
        /// <summary>
        /// Increments failes of the specific user
        /// </summary>
        /// <param name="user">user instance to increase the failed login</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Number of access failed of specific user</returns>
        public Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            int failedAccessAttempt = user.LockoutCount + 1;
            user.LockoutCount = failedAccessAttempt;
            _userRepository.Update(user);
            _unitOfWork.Save();
            return Task.FromResult(failedAccessAttempt);
        }
        
        /// <summary>
        /// Resets the Access failed of specific user
        /// </summary>
        /// <param name="user">user to reset the access failed</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task ResetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            if (DateTime.UtcNow > user.ActiveDate)
            {
                user.LockoutCount = 0;
                user.ActiveDate = DateTime.UtcNow;
                _userRepository.Update(user);
                _unitOfWork.Save();
            }            
            return Task.CompletedTask;
        }
        
        /// <summary>
        /// Blocks or Unblock the specific user based in the enabled flag.
        /// </summary>
        /// <param name="user">specific user to lock or unlock </param>
        /// <param name="enabled">flag to lock or unlock the user</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            if (enabled)
            {
                SetLockoutEndDateAsync(user, DateTime.UtcNow.AddMinutes(15), cancellationToken);
            }
            else
            {
                ResetAccessFailedCountAsync(user, cancellationToken);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Sets the lockout date to specific user
        /// </summary>
        /// <param name="user">specific user to set the lockout date.</param>
        /// <param name="lockoutEnd">duration of lockout</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            if (lockoutEnd.HasValue)
            {
                user.ActiveDate = new DateTime(lockoutEnd.Value.Ticks);
                
                user.LockoutCount = 3;
                _userRepository.Update(user);
                _unitOfWork.Save();
            }

            return Task.CompletedTask;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && _unitOfWork != null)
                {
                    _unitOfWork.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// TODO add implement to update password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passwordHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            _userRepository.Update(user);
            _unitOfWork.Save();
            return Task.FromResult(Task.CompletedTask);
        }

        /// <summary>
        /// TODO add implementation to get Password encrypted
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        /// <summary>
        /// TODO check if the user has password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passwordHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(string.IsNullOrEmpty(user.Password));
        }
        #endregion
    }
}
