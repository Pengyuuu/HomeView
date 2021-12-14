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
        private static User modifyUser = new User("Modify", "Andy", "ModifyAndy@gmail.com", "Password1234!", actualDate, dName: "MAndy", Role.User);
        public void User_UserShouldBeCreatedAndAddedToDatabase()
        {
            // Arrange
            // String expected = "JSmith";

            // Act
            // System.DateTime actualDate = new DateTime(2011, 6, 10);
            // User actual = new User("John", "Smith", "JohnSmith@gmail.com", "abc123", actualDate, dName: "JSmith");

            // Assert
            // Connect to DB and query to find "JSmith" Display Name

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

        public void UserDAO_CreateUserShouldCreateUserAndSaveToDatabase()
        {

        }

        // Probably add separate test for each modify mode later
        public void UserDAO_ModifyUserShouldModifyUserAndSaveToDatabase()
        {

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

            UserManager userManager = new UserManager(adminInput, pw);
            String actual = userManager.UserManagerCreateUser(actualUser);

            Assert.Equal(expected, actual);
        }

        
        //[Theory]
        //[InlineData("TeamUnite", "Testing", modifyUser, 1, modifyUser)]
        public void UserManager_ModifyUserModifyShouldBeSuccessful(string adminInput, string pw, User u, int mode, User userMod)
        {
            string expected = "User account record creation successful.";


        }

        public void UserManager_ModifyUserModifyShouldBeUnSuccessful()
        {
            string expected = "Account creation unsuccessful. Account already exists in system. ";


        }
        
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

        [Theory]
        [InlineData()]
        public void UMService_ModifyUserShouldCheckForUserModifyDatabaseSuccess(User u, int mode, User userMod)
        {
            Boolean expected = true;

            UMService uMService = new UMService();
            Boolean actual = uMService.UMServiceModifyUser(u, mode, userMod);

            Assert.Equal(expected, actual);
        }
    }
}
