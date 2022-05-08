using Core.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(User userCreate, int CREATION_MODE);
        Task<int> CreateUserSessionAsync(User user, string jwtToken);
        Task<int> DeleteUserAsync(string email, int DELETION_MODE);
        Task<User> DisplayGetUserAsync(string display);
        Task<string> DoBulkOpAsync(string file);
        Task<string> ExportAllUsersAsync();
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetRegisteredUserAsync(string email);
        Task<User> GetUserAsync(string email);
        Task<int> ModifyUserAsync(User user);
        Task<int> GetRegistrationCountAsync(DateTime date);

    }
}