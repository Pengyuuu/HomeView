using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using System;

namespace UMTests
{
    [TestClass]
    public class UserTests
    {
        [Theory]
        public void User_UserShouldBeCreatedAndAddedToDatabase()
        {
            // Arrange more testing


            // Act
            System.DateTime actualDate = new DateTime(2011, 6, 10);
            Unite.HomeView.User.User actual = new Unite.HomeView.User.User("John", "Smith", "JohnSmith@gmail.com", "abc123", actualDate, "JSmith");

            // Assert
            string query = 
            SqlConnection connection = new SqlConnection(@connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
                success = false;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
