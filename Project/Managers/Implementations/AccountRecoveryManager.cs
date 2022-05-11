using Services.Contracts;
using Services.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.User;
using Managers.Contracts;

namespace Managers.Implementations
{
    public class AccountRecoveryManager : IAccountRecoveryManager
    {
        private readonly IEmailManager _emailManager;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        /*
         * Constructor utilizing dependency injection
         */
        public AccountRecoveryManager()
        {
            _emailManager = new EmailManager();
            _userService = new UserService();
            _authenticationService = new AuthenticationService();
        }

        /* NOTE: Add attempts attribute in class
         * Checks account recovery fields to make sure it is a valid user inputted and has not exceeded attempts
         * @returns null if fields are invalid (invalid user credentials), or returns the user if found/valid
         */
        public async Task<bool> AsyncCheckValidRecovery(User recoverUser)
        {
            if (recoverUser != null)
            {
                User fetchUser = await _userService.GetUserAsync(recoverUser.Email);
                if (fetchUser != null)
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * Calls recovery validation fields method, then sends recovery email if valid user
         */
        public async Task<string> AsyncSendRecoveryEmail(User recoverUser)
        {
            if (AsyncCheckValidRecovery(recoverUser).Result == true)
            {
                string recoverOtp = _authenticationService.GenerateOTP();
                bool isSent = await _emailManager.AsyncSendRecoveryEmail(recoverUser.Email, recoverOtp);
                if (isSent)
                {
                    return "Recovery email sent.";
                }
            }
            return null;
        }

        /*
         * Calls recovery validation fields method, then sends recovery email if valid user
         */
        public async Task<string> AsyncModifyUserAccount(User recoverUser)
        {
            
            if (AsyncCheckValidRecovery(recoverUser).Result == true)
            {
                string recoverOtp = _authenticationService.GenerateOTP();
                bool isSent = await _emailManager.AsyncSendRecoveryEmail(recoverUser.Email, recoverOtp);
                if (isSent)
                {
                    return "User updated";
                }
            }
            return null;
        }

    }
}



