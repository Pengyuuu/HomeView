using Xunit;
using System;
using User;
using System.IO;


namespace UMTests
{
    public class UserTests
    {
         
        static string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
        static string path = Path.GetFullPath(Path.Combine((System.IO.Path.GetDirectoryName(executable)), "@\\..\\..\\..\\..\\..\\..\\Project\\Testing\\BulkOpCreateUsers.csv"));

        // Not sure how this will run when tested
        // Requires user input into console to verify if Admin
        [Fact]
        public void UserManager_VerifyAdminShouldVerifyIfAdmin()
        {
            Boolean expected = true;

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManagerTest = new UserManager(adminInput, pw);
            Boolean actual = userManagerTest.IsVerifiedAdmin(adminInput, pw);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserManager_CheckNewUserShouldCheckIfUserEnteredValidArguements()
        {
            Boolean expected = true;

            string adminInput = "TeamUnite";
            string pw = "Testing";
            DateTime actualDate = new DateTime(2011, 6, 10);
            User actualUser = new User("John", "Smith", "JohnSmith@gmail.com", "Password1234!", actualDate, dName: "JSmith", 0, Role.User);

            UserManager userManager = new UserManager(adminInput, pw);
            Boolean actual = userManager.IsNewUser(actualUser);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserManager_CreateUserShouldDisplayUserCreationSuccess()
        {
            DateTime actualDate = new DateTime(2011, 6, 10);
            User newUser = new User("Hank", "Hill", "HankHill@yahoo.com", "Password1234!", actualDate, dName: "PropaneHank", 0, Role.User);
            string expected = "User account record creation successful.";
            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);
            // delete user first in case it already exists
            userManager.ModifyUser(newUser.UserEmail, 2, null);
            String actual = userManager.ModifyUser(newUser.UserEmail, 5, newUser);

            Assert.Equal(expected, actual);


        }

        // USER SHOULD BE IN DATABASE FOR THIS TEST
        [Fact]
        public void UserManager_CreationUserShouldDisplayUserCreactionUnsuccessful()
        {
            string expected = "Account creation unsuccessful. Account already exists in system. ";
            string adminInput = "TeamUnite";
            string pw = "Testing";

            User testUser = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "mWallace", 0, Role.User);

            UserManager userManager = new UserManager(adminInput, pw);
            String actual = userManager.ModifyUser(testUser.UserEmail, 5,testUser);

            Assert.Equal(expected, actual);
        }

        // User modifyUser = new User("Modify", "Andy", "ModifyAndy@gmail.com", "Password1234!", actualDate, dName: "MAndy", Role.User);
        [Fact]
        public void UserManager_ModifyUserMode1ModifyShouldBeSuccessful()
        {

            User modifyUser = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "mWallace", 0, Role.User);

            string expected = "User account modification successful.";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);
            userManager.ModifyUser(modifyUser.UserEmail, 1, modifyUser);
            string actual = userManager.ModifyUser(modifyUser.UserEmail, 1, modifyUser);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_ModifyUserMode2ModifyShouldBeSuccessful()
        {

            User modifyUser = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "mWallace", 0, Role.User);

            string expected = "User account modification successful.";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.ModifyUser(modifyUser.UserEmail, 2, modifyUser);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_ModifyUserMode3ModifyShouldBeSuccessful()
        {

            User modifyUser = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "mWallace", 0, Role.User);

            string expected = "User account modification successful.";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);
            userManager.ModifyUser(modifyUser.UserEmail, 3, modifyUser);
            string actual = userManager.ModifyUser(modifyUser.UserEmail, 3, modifyUser);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_ModifyUserMode4ModifyShouldBeSuccessful()
        {

            User modifyUser = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "mWallace", 0, Role.User);

            string expected = "User account modification successful.";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);
            userManager.ModifyUser(modifyUser.UserEmail, 4, modifyUser);
            string actual = userManager.ModifyUser(modifyUser.UserEmail, 4, modifyUser);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_BulkOpsModifyUsers()
        {

            string filepath = path;
            int insertedUsers = 1000;
            int failedInsert = 0;
            string expected = "Successfully inserted " + insertedUsers + ".\n Failed to insert: " + failedInsert + ".\n";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.ModifyUsers(filepath);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_exportAllUsers()
        {

            string expected = "User data successfully exported to .csv file";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.ExportAllUsers();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_getAllUsers()   // needs all users inside first to get expected
        {

            string expected = "";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.GetAllUsers();

            Assert.True(!String.IsNullOrEmpty(actual));

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
