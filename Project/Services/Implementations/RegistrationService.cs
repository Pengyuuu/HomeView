using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts;
using Core.User;

namespace Services.Implementations
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserService _userService;
        //private readonly IEmailService _emailService;

        public RegistrationService()
        {
            _userService = new UserService();
            //_emailService = new EmailService();
        }

        public bool CreateUser(User userCreate, int CREATION_MODE)
        {
            bool isCreated = false;
            try
            {
                isCreated = _userService.CreateUser(userCreate, CREATION_MODE);
            }
            catch
            {
                // user is already in database
                return false;
            }
            return isCreated;
        }
    }
}
