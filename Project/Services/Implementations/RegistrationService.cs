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
        private IUserService _userService;

        public RegistrationService()
        {
        }

        public bool CreateUser(User userCreate)
        {
            bool isCreated = false;
            try
            {
                isCreated = _userService.CreateUser(userCreate);
            }
            catch
            {
                return false;
            }
            return isCreated;
        }
    }
}
