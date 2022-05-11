using Core.User;
using Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
using Managers.Implementations;

namespace HomeView_API.Controllers
{
    [Route("api/account-recovery")]
    [ApiController]
    public class AccountRecoveryController : ControllerBase
    {
        private readonly IAccountRecoveryManager _accountRecoveryManager;

        public AccountRecoveryController()
        {
            _accountRecoveryManager = new AccountRecoveryManager();
        }

        [Route("post/{email}/{username}")]
        [HttpPost]
        public ActionResult<string> SendRecovery(string email, string username)
        {
            User u = new User();
            u.Email = email;
            u.DispName = username;
            var result = _accountRecoveryManager.AsyncSendRecoveryEmail(u).Result;
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to send recovery email.");
        }

        /**
        // when user clicks registration link from email -> authenticates user
        [Route("confirmRecoveryLink/{userOtp}/{email}")]
        //[AllowAnonymous]
        [HttpPost]
        public ActionResult<string> UpdateAccount(string email, string pw)
        {

            bool result = _accountRecoveryManager.(email, pw);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest("Invalid confirmation.");


        }**/
    }
}
