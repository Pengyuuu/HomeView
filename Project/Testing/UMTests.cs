using Xunit;
using System;
using UM.User;


namespace UMTests
{
    public class UserTests
    {
        //12 characters, 1 uppercase, 1 nonalpha numeric
        private static System.DateTime actualDate = new DateTime(2011, 6, 10);
        private User actualUser = new User("John", "Smith", "JohnSmith@gmail.com", "Password1234!", actualDate, dName: "JSmith", Role.User);


        [Fact]
        public void User_UserUpdateUserShouldUpdateUserGivenArguments()
        {
            Boolean expected = true;
            Boolean actual = false;

            DateTime testDate = new DateTime(2021, 1, 1);
            User testUser = new User("Bob", "Bob", "Bobbob@gmail.com", "Password123456!", testDate, dName: "BigBob", Role.User);

            Role test = Role.Admin;
            DateTime newDate = new DateTime(2000, 2, 2);
            testUser.updateUser("NotBob", "BobNot", "NotBobbob@gmail.com", "Updatepassword!!", newDate, dName: "SmallBob", 0, Role.Admin);

            if (testUser.getfirst() == "NotBob" && testUser.getlast() == "BobNot" && testUser.getemail() == "NotBobbob@gmail.com"
                && testUser.getpw() == "Updatepassword!!" && testUser.getdob() == newDate && testUser.getdisp() == "SmallBob" && testUser.getstatus() == 0
                && testUser.getrole() == Role.Admin)
            {
                actual = true;
            }

                Assert.Equal(expected, actual);

        }

        [Fact]
        public void User_UserUpdateUserShouldUpdateUserGivenUser()
        {
            Boolean expected = true;
            Boolean actual = false;

            DateTime testDate = new DateTime(2021, 1, 1);
            User testUser = new User("Bob", "Bob", "Bobbob@gmail.com", "Password123456!", testDate, dName: "BigBob", Role.User);

            DateTime newDate = new DateTime(2000, 2, 2);
            User updatedUser = new User("NotBob", "BobNot", "NotBobbob@gmail.com", "Updatepassword!!", newDate, dName: "SmallBob", Role.Admin);
            testUser.updateUser(updatedUser);

            if (testUser.getfirst() == "NotBob" && testUser.getlast() == "BobNot" && testUser.getemail() == "NotBobbob@gmail.com"
                && testUser.getpw() == "Updatepassword!!" && testUser.getdob() == newDate && testUser.getdisp() == "SmallBob" && testUser.getrole() == Role.Admin)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void User_GetFirstShouldReturnFirstName()
        {
            // Arrange
            String expected = "John";

            User actual = actualUser;

            // Assert
            Assert.Equal(expected, actual.getfirst());

        }

        [Fact]
        public void User_GetLastShouldReturnLastName()
        {
            // Arrange
            String expected = "Smith";

            User actual = actualUser;

            // Assert
            Assert.Equal(expected, actual.getlast());
        }

        [Fact]
        public void User_GetEmailShouldReturnEmail()
        {
            // Arrange
            String expected = "JohnSmith@gmail.com";

            User actual = actualUser;

            // Assert
            Assert.Equal(expected, actual.getemail());
        }

        [Fact]
        public void User_GetPWShouldReturnPassword()
        {
            // Arrange
            String expected = "Password1234!";

            User actual = actualUser;

            // Assert
            Assert.Equal(expected, actual.getpw());
        }


        // Compares DateTime to the dot, need to compare just day
        [Fact]
        public void User_GetDOBShouldReturnDateOfBirth()
        {
            // Arrange
            System.DateTime expected = new DateTime(2011, 6, 10);

            User actual = actualUser;

            // Assert
            Assert.Equal(expected.ToString(), actual.getdob().ToString());
        }

        [Fact]
        public void User_GetDispShouldReturnDisplayName()
        {
            // Arrange
            String expected = "JSmith";

            User actual = actualUser;

            // Assert
            Assert.Equal(expected, actual.getdisp());
        }

        // May or may not work... 
        // Maybe access database to get reg time to verify.
        [Fact]
        public void User_GetRegShouldReturnRegistrationDate()
        {
            // Arrange
            System.DateTime expected = DateTime.UtcNow;

            User actual = actualUser;

            // Assert
            Assert.Equal(expected.ToString(), actual.getreg().ToString());
        }

        // Not sure how this will run when tested
        // Requires user input into console to verify if Admin
        [Fact]
        public void UserManager_VerifyAdminShouldVerifyIfAdmin()
        {
            Boolean expected = true;

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManagerTest = new UserManager(adminInput, pw);
            Boolean actual = userManagerTest.verifyAdmin(adminInput, pw);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserManager_CheckNewUserShouldCheckIfUserEnteredValidArguements()
        {
            Boolean expected = true;

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);
            Boolean actual = userManager.checkNewUser(actualUser);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserManager_CreateUserShouldDisplayUserCreationSuccess()
        {
            User newUser = new User("Hank", "Hill", "HankHill@yahoo.com", "Password1234!", actualDate, dName: "PropaneHank", Role.User);
            string expected = "User account record creation successful.";
            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);
            String actual = userManager.UserManagerCreateUser(newUser);

            Assert.Equal(expected, actual);


        }

        // USER SHOULD BE IN DATABASE FOR THIS TEST
        [Fact]
        public void UserManager_CreationUserShouldDisplayUserCreactionUnsuccessful()
        {
            string expected = "Account creation unsuccessful. Account already exists in system. ";
            string adminInput = "TeamUnite";
            string pw = "Testing";

            User testUser = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "mWallace", Role.User);

            UserManager userManager = new UserManager(adminInput, pw);
            string actual = userManager.UserManagerCreateUser(testUser);

            Assert.Equal(expected, actual);
        }

        // User modifyUser = new User("Modify", "Andy", "ModifyAndy@gmail.com", "Password1234!", actualDate, dName: "MAndy", Role.User);
        [Fact]
        public void UserManager_ModifyUserMode1ModifyShouldBeSuccessful()
        {

            User modifyUser = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "mWallace", Role.User);
            // UserManager, getID to get user in DB and then modify
            string expected = "User account record creation successful.";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.UserManagerModifyUser(1, 1, modifyUser);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_ModifyUserMode2ModifyShouldBeSuccessful()
        {

            User modifyUser = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "mWallace", Role.User);

            string expected = "User account record creation successful.";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.UserManagerModifyUser(modifyUser.getid(), 2, modifyUser);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_ModifyUserMode3ModifyShouldBeSuccessful()
        {

            User modifyUser = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "mWallace", Role.User);

            string expected = "User account record creation successful.";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.UserManagerModifyUser(modifyUser.getid(), 3, modifyUser);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_ModifyUserMode4ModifyShouldBeSuccessful()
        {

            User modifyUser = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "mWallace", Role.User);

            string expected = "User account record creation successful.";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.UserManagerModifyUser(modifyUser.getid(), 4, modifyUser);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_BulkOpsCreateUsers()
        {

            string filepath = @".csv";
            int insertedUsers = 10;
            int failedInsert = 0;
            string expected = "Successfully inserted " + insertedUsers + ".\n Failed to insert: " + failedInsert + ".\n";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.BulkOperationModifyUsers(filepath);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_BulkOpsModifyUsers()
        {

            string filepath = @".csv";
            int successMods = 10;
            int failedMods = 0;
            string expected = "Successfully modified " + successMods + ".\n Failed to insert: " + failedMods + ".\n";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.BulkOperationModifyUsers(filepath);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_exportAllUsers()
        {
            string filepath = @".csv";

            string expected = "User data successfully exported to.csv file in: " + filepath;

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.UserManagerExportAllUsers(filepath);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void UserManager_getAllUsers()   // needs all users inside first to get expected
        {

            string expected = "";

            string adminInput = "TeamUnite";
            string pw = "Testing";

            UserManager userManager = new UserManager(adminInput, pw);

            string actual = userManager.UserManagerGetAllUsers();

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
