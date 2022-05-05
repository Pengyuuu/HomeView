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

        public async Task<int> AsyncCreateUser(User userCreate, int CREATION_MODE)
        {
            return await _userService.AsyncCreateUser(userCreate, CREATION_MODE);
           
        }
    }
}
