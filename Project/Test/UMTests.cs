using Xunit;
using System;
using Core.User;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace UMTests
{
    public class UserTests
    {
         
        static string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
        static string path = Path.GetFullPath(Path.Combine((System.IO.Path.GetDirectoryName(executable)), "@\\..\\..\\..\\..\\..\\..\\Project\\Test\\UMBulkOp.csv"));



        [Fact]
        public void UserManager_CreateUserShouldCreateNewUser()
        {
            User newUser = new User("Hank", "Hill", "HankHill@yahoo.com", "Password1234!", new DateTime(2011, 6, 10), "PropaneHank", Role.User);

            UserManager userManager = new UserManager();

            // delete user first in case it already exists
            userManager.DeleteUser(newUser.Email);

            userManager.CreateUser(newUser);

            String actual = userManager.GetUser(newUser.Email).Email;

            String expected = newUser.Email;

            Assert.Equal(expected, actual);

        }

        // USER SHOULD BE IN DATABASE FOR THIS TEST
        [Fact]
        public void UserManager_CreationUserShouldDisplayNotCreateExistingUser()
        {
            bool expected = false;

            User existingUser = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "mWallace");

            UserManager userManager = new UserManager();

            bool actual = userManager.CreateUser(existingUser);

            Assert.Equal(expected, actual);
        }

        
        public void UserManager_BulkOpsModifyUsers()
        {

            string filepath = path;
            int insertedUsers = 1000;
            int failedInsert = 0;
            string expected = "Successfully inserted " + insertedUsers + ".\n Failed to insert: " + failedInsert + ".\n";

            UserManager userManager = new UserManager();

            string actual = userManager.DoBulkOp(filepath);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_Demo()
        {

            UserManager userManager = new UserManager();

            userManager.CreateUser(new User("firsasdft", "last", "emai23423l@me.com", "pwajsh23@#4", DateTime.Now, "supername"));

        }

        [Fact]
        public void UserManager_ExportAllUsers()
        {

            string expected = "User data successfully exported to .csv file";

            UserManager userManager = new UserManager();

            string actual = userManager.ExportAllUsers();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_GetAllUsers()   // needs all users inside first to get expected
        {

            UserManager userManager = new UserManager();

            List<User> actual = userManager.GetAllUsers();

            Assert.True(actual.Any());
        }

        [Fact]
        public void UserManager_GetUser()   // needs all users inside first to get expected
        {

            string expected = "Hill";

            UserManager userManager = new UserManager();

            User actual = userManager.GetUser("HankHill@yahoo.com");

            Assert.True(expected == actual.LastName);

        }

        [Fact]
        public void UserManager_DeleteUserSuccesssful()
        {
            bool expected = true;

            User newUser = new User("hanna", "lin", "hLin@balls.com", "dogsRcool1234!", new DateTime(2000, 12, 12), "hLin");

            UserManager userManager = new UserManager();

            userManager.CreateUser(newUser);

            bool actual = userManager.DeleteUser(newUser.Email);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserManager_DeleteUserUnSucessful()
        {
            bool expected = false;

            User nonExistingUser = new User("hanna", "lin", "hLin@balls.com", "dogsRcool1234!", new DateTime(2000, 12, 12), "hLin");

            UserManager userManager = new UserManager();

            // delete twice just in case
            userManager.DeleteUser(nonExistingUser.Email);
            bool actual = userManager.DeleteUser(nonExistingUser.Email);

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
