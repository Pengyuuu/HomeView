using Xunit;
using System;
using Unite.HomeView.User;
namespace UMTests
{
    public class UserTests
    {
        
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

            // Arrange
            System.DateTime actualDate = new DateTime(2011, 6, 10);
            User actual = new User("John", "Smith", "JohnSmith@gmail.com", "abc123", actualDate, dName: "JSmith");


            // Assert
            Assert.Equal(expected, actual.getfirst());

        }

        [Fact]
        public void User_GetLastShouldReturnLastName()
        {
            // Arrange
            String expected = "Smith";

            // Arrange
            System.DateTime actualDate = new DateTime(2011, 6, 10);
            User actual = new User("John", "Smith", "JohnSmith@gmail.com", "abc123", actualDate, dName: "JSmith");


            // Assert
            Assert.Equal(expected, actual.getlast());
        }

        [Fact]
        public void User_GetEmailShouldReturnEmail()
        {
            // Arrange
            String expected = "JohnSmith@gmail.com";

            // Arrange
            System.DateTime actualDate = new DateTime(2011, 6, 10);
            User actual = new User("John", "Smith", "JohnSmith@gmail.com", "abc123", actualDate, dName: "JSmith");


            // Assert
            Assert.Equal(expected, actual.getemail());
        }

        [Fact]
        public void User_GetPWShouldReturnPassword()
        {
            // Arrange
            String expected = "abc123";

            // Arrange
            System.DateTime actualDate = new DateTime(2011, 6, 10);
            User actual = new User("John", "Smith", "JohnSmith@gmail.com", "abc123", actualDate, dName: "JSmith");


            // Assert
            Assert.Equal(expected, actual.getpw());
        }

        [Fact]
        public void User_GetDOBShouldReturnDateOfBirth()
        {
            // Arrange
            System.DateTime expected = new DateTime(2011, 6, 10);

            // Arrange
            System.DateTime actualDate = new DateTime(2011, 6, 10);
            User actual = new User("John", "Smith", "JohnSmith@gmail.com", "abc123", actualDate, dName: "JSmith");


            // Assert
            Assert.Equal(expected, actual.getdob());
        }

        [Fact]
        public void User_GetDispShouldReturnDisplayName()
        {
            // Arrange
            String expected = "JSmith";

            // Arrange
            System.DateTime actualDate = new DateTime(2011, 6, 10);
            User actual = new User("John", "Smith", "JohnSmith@gmail.com", "abc123", actualDate, dName: "JSmith");


            // Assert
            Assert.Equal(expected, actual.getdisp());
        }

        [Fact]
        public void User_GetRegShouldReturnRegistrationDate()
        {
            // Arrange
            System.DateTime expected = DateTime.UtcNow;

            // Arrange
            System.DateTime actualDate = new DateTime(2011, 6, 10);
            User actual = new User("John", "Smith", "JohnSmith@gmail.com", "abc123", actualDate, dName: "JSmith");


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

        public void UserManager_VerifyAdminShouldVerifyIfAdmin()
        {

        }

        public void UserManager_CheckNewUserShouldCheckIfUserEnteredValidArguements()
        {

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
