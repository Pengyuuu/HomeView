using System;
using System.Data.SqlClient;
// need nuget

namespace Unite.HomeView.User
{
    class UserDAO
    {
        public UserDAO()
        {

            string connectionString = "";

        }

        public Boolean createUser(User u)
        {
            Boolean success = true;
            SqlConnection connection = new SqlConnection(@connectionString);



            string first = u.getfirst();
            string last = u.getlast();
            string email = u.getemail();
            string disp = u.getdisp();
            string pw = u.getpw();
            string dob = u.getdob() + "";
            string reg = u.getreg() + "";

            string query1 = "INSERT INTO Users (firstName, lastName, email, password, dob, dispName, regDate) VALUES('";
            string query2 = first + "','" + last + "','" + email + "','" + pw + "','" + dob + "','" + disp + "','" + reg + "')";
            string query = query1 + query1;

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

            return success;
        }

        public Boolean modifyUser(User u)
        {
            Boolean success = true;
            SqlConnection connection = new SqlConnection(@connectionString);



            string first = u.getfirst();
            string last = u.getlast();
            string email = u.getemail();
            string disp = u.getdisp();
            string pw = u.getpw();
            string dob = u.getdob() + "";
            string reg = u.getreg() + "";

            string query1 = "INSERT INTO Users (firstName, lastName, email, password, dob, dispName, regDate) VALUES('";
            string query2 = first + "','" + last + "','" + email + "','" + pw + "','" + dob + "','" + disp + "','" + reg + "')";
            string query = query1 + query1;

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

            return success;
        }
    }
}