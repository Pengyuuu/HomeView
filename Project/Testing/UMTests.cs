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
        // user to be modified
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

        [Fact]
        public void BulkOp_CreateUsersShouldBeCreatedAndAddedToDatabase()
        {
            string filepath = "";
            UserManager uManager = new UserManager("TeamUnite", "Testing");
            string message = uManager.BulkOperationCreateUsers(filepath);
            Console.WriteLine(message);
        }

        

        
    }
}
