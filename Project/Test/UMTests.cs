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
            User newUser = new User("Hank", "Hill", "HankHill@yahoo.com", hashedPw, new DateTime(2011, 6, 10), "PropaneHank", salt);
            string email = newUser.Email;

            // delete user first in case it already exists
            bool isDeleted = userManager.DeleteVerifiedUser(newUser.Email);


            bool isCreated = userManager.CreateVerifiedUser("HankHill@yahoo.com", new DateTime(2011, 6, 10), hashedPw );
            string actual = "";
            try
            {
                User result = userManager.GetUser(newUser.Email);
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
            bool expected = false;
            var salt = authenticationManager.GetSalt();
            var hashedPw = authenticationManager.HashPassword("iL0vem1@12345", salt);
            User existingUser = new User("marsellus", "wallace", "mWallace@pulp.com", hashedPw, new DateTime(2000, 12, 12), "mWallace", salt);


            bool actual = userManager.CreateVerifiedUser("mWallace@pulp.com", new DateTime(2000,12,12), "iL0vem1@12345");

            Assert.Equal(expected, actual);
        }

        public void UserManager_BulkOpsModifyUsers()
        {

            string filepath = path;
            int insertedUsers = 1000;
            int failedInsert = 0;
            string expected = "Successfully inserted " + insertedUsers + ".\n Failed to insert: " + failedInsert + ".\n";


            string actual = userManager.DoBulkOp(filepath);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_Demo()
        {


            userManager.CreateVerifiedUser("emai23423l@me.com",new DateTime(2020,03,09), "pwajsh23@#4");

        }

        [Fact]
        public void UserManager_ExportAllUsers()
        {

            string expected = "User data successfully exported to .csv file";


            string actual = userManager.ExportAllUsers();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_GetAllUsers()   // needs all users inside first to get expected
        {

            List<User> actual = userManager.GetAllUsers();

            Assert.True(actual.Any());
        }

        [Fact]
        public void UserManager_GetUser()   // needs all users inside first to get expected
        {

            string expected = "HankHill@yahoo.com";


            User actual = userManager.GetUser("HankHill@yahoo.com");

            Assert.True(expected == actual.Email);

        }

        [Fact]
        public void UserManager_DeleteUserSuccesssful()
        {
            bool expected = true;
            var salt = authenticationManager.GetSalt();
            var hashedPw = authenticationManager.HashPassword("dogsRcool1234!", salt);
            User newUser = new User("hanna", "lin", "hLin@balls.com", hashedPw, new DateTime(2000, 12, 12), "hLin", salt);


            bool isCreated = userManager.CreateVerifiedUser("hLin@balls.com", new DateTime(2000,12,12), "dogsRcool1234!");

            bool actual = userManager.DeleteVerifiedUser(newUser.Email);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserManager_DeleteUserUnSucessful()
        {
            bool expected = false;
            var salt = authenticationManager.GetSalt();
            var hashedPw = authenticationManager.HashPassword("dogsRcool1234!", salt);
            User nonExistingUser = new User("hanna", "lin", "hLin@balls.com", hashedPw, new DateTime(2000, 12, 12), "hLin", salt);


            // delete twice just in case
            userManager.DeleteVerifiedUser(nonExistingUser.Email);
            bool actual = userManager.DeleteVerifiedUser(nonExistingUser.Email);

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
