using Xunit;
using System;
using Core.User;
using Managers.Contracts;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Managers.Implementations;

namespace UMTests
{
    public class UserTests
    {

        static string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
        static string path = Path.GetFullPath(Path.Combine((System.IO.Path.GetDirectoryName(executable)), "@\\..\\..\\..\\..\\..\\..\\Project\\Test\\UMBulkOp.csv"));
        IUserManager userManager = new UserManager();
        IAuthenticationManager authenticationManager = new AuthenticationManager();



        [Fact]
        public void UserManager_CreateUserShouldCreateNewUser()
        {
            var salt = authenticationManager.GetSalt();
            var hashedPw = authenticationManager.HashPassword("Password1234!", salt);
            User newUser = new User("May", "User", "may@yahoo.com", hashedPw, new DateTime(2011, 6, 10), "Mayo", salt);
            string email = newUser.Email;

            // delete user first in case it already exists
            int deleted = userManager.AsyncDeleteVerifiedUser(newUser.Email).Result;


            int isCreated = userManager.AsyncCreateVerifiedUser("may@yahoo.com", new DateTime(2011, 6, 10), hashedPw).Result;
            string actual = "";
            try
            {
                User result = userManager.AsyncGetUser(newUser.Email).Result;
                actual = result.Email;
            }
            catch
            {
                actual = "null";
            }
            string expected = newUser.Email;

            Assert.Equal(expected, actual);

        }

        // USER SHOULD BE IN DATABASE FOR THIS TEST
        [Fact]
        public void UserManager_CreationUserShouldDisplayNotCreateExistingUser()
        {
            int expected = 0;
            var salt = authenticationManager.GetSalt();
            var hashedPw = authenticationManager.HashPassword("iL0vem1@12345", salt);
            User existingUser = new User("marsellus", "wallace", "mWallace@pulp.com", hashedPw, new DateTime(2000, 12, 12), "mWallace", salt);


            int actual = userManager.AsyncCreateVerifiedUser("mWallace@pulp.com", new DateTime(2000, 12, 12), "iL0vem1@12345").Result;

            Assert.Equal(expected, actual);
        }

        public void UserManager_BulkOpsModifyUsers()
        {

            string filepath = path;
            int insertedUsers = 1000;
            int failedInsert = 0;
            string expected = "Successfully inserted " + insertedUsers + ".\n Failed to insert: " + failedInsert + ".\n";


            string actual = userManager.AsyncDoBulkOp(filepath).Result;

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_Demo()
        {
            userManager.AsyncCreateVerifiedUser("may@me.com", new DateTime(2007, 03, 09), "password@123");
        }

        [Fact]
        public void UserManager_ExportAllUsers()
        {
            string expected = "User data successfully exported to .csv file";
            string actual = userManager.AsyncExportAllUsers().Result;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserManager_GetAllUsers()   // needs all users inside first to get expected
        {

            List<User> actual = userManager.AsyncGetAllUsers().Result;
            Assert.True(actual.Any());
        }

        [Fact]
        public void UserManager_GetUser()   // needs all users inside first to get expected
        {

            string expected = "testing@gmail.com";
            User actual = userManager.AsyncGetUser(expected).Result;
            Assert.True(expected == actual.Email);

        }

        [Fact]
        public void UserManager_DeleteUserSuccesssful()
        {
            int expected = 1;
            var salt = authenticationManager.GetSalt();
            var hashedPw = authenticationManager.HashPassword("dogsRcool1234!", salt);
            User newUser = new User("hanna", "lin", "hLin@balls.com", hashedPw, new DateTime(2000, 12, 12), "hLin", salt);
            int isCreated = userManager.AsyncCreateVerifiedUser("hLin@balls.com", new DateTime(2000, 12, 12), "dogsRcool1234!").Result;
            int actual = userManager.AsyncDeleteVerifiedUser(newUser.Email).Result;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserManager_DeleteUserUnSucessful()
        {
            int expected = 0;
            var salt = authenticationManager.GetSalt();
            var hashedPw = authenticationManager.HashPassword("dogsRcool1234!", salt);
            User nonExistingUser = new User("hanna", "lin", "hLin@balls.com", hashedPw, new DateTime(2000, 12, 12), "hLin", salt);
            int actual = userManager.AsyncDeleteVerifiedUser(nonExistingUser.Email).Result;
            Assert.Equal(expected, actual);
        }

        /*
        // Need to remove UMService User Test after, else test may fail
        [Fact]
        public void UMService_CreateUserShouldCheckForUserCreationDatabaseSuccess()
        {
            Boolean expected = true;

            User u = new User("UMService", "CreateUserTest", "Test@gmail.com", "Password1234!", actualDate, dName: "UMServiceCreateUserTest", Role.User);
            UMService uMService = new UMService();

            Boolean actual = uMService.UMServiceCreateUser(u);

            Assert.Equal(expected, actual);
        }
        */

        /*
        public void UMService_ModifyUserShouldCheckForUserModifyDatabaseSuccess(User u, int mode, User userMod)
        {
            Boolean expected = true;

            UMService uMService = new UMService();
            Boolean actual = uMService.UMServiceModifyUser(u, mode, userMod);

            Assert.Equal(expected, actual);
        }
        */

    }
}
