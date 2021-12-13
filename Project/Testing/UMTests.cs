using Xunit;
using System;
using UM.User;


namespace UMTests
{
    public class UserTests
    {
        //12 characters, 1 uppercase, 1 nonalpha numeric
        private static System.DateTime actualDate = new DateTime(2011, 6, 10);
        private User actualUser = new User("John", "Smith", "JohnSmith@gmail.com", "Password1234!", actualDate, dName: "JSmith");
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
            String expected = "abc123";

            User actual = actualUser;

            // Assert
            Assert.Equal(expected, actual.getpw());
        }

        [Fact]
        public void User_GetDOBShouldReturnDateOfBirth()
        {
            // Arrange
            System.DateTime expected = new DateTime(2011, 6, 10);

            User actual = actualUser;

            // Assert
            Assert.Equal(expected, actual.getdob());
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
            Assert.Equal(expected, actual.getreg());
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
            
            UserManager userManagerTest = new UserManager();
            Boolean actual = userManagerTest.verifyAdmin();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserManager_CheckNewUserShouldCheckIfUserEnteredValidArguements()
        {
            Boolean expected = true;

            
            UserManager userManager = new UserManager();
            Boolean actual = userManager.checkNewUser(actualUser);

            Assert.Equal(expected, actual);
        }

        public void UserManager_CreateUserShouldDisplayUserCreationSuccess()
        {


        }

        // Probably add separate test for each modify mode later
        public void UserManager_ModifyUserShouldDisplayUserModifySuccess()
        {

        }

        public void UMService_CreateUserShouldCheckForUserCreationDatabaseSuccess()
        {

        }

        public void UMService_ModifyUserShouldCheckForUserModifyDatabaseSuccess()
        {

        }
    }
}
