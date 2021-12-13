using System;
using System.Data.SqlClient;

namespace Unite.HomeView.User
{
    class UserDAO
    {
        public UserDAO()
        {

            string connectionString = "";

        }

        /* Creates a new user record in system */
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


        /* Modifies a user record in the system 
		 * 1 = Update information
		 * 2 = Delete account
		 * 3 = Disable
		 * 4 = Enable
		 */
        public Boolean modifyUser(User u, int mode)
        {
            Boolean success = true;
            SqlConnection connection = new SqlConnection(@connectionString);
            string query = "";
     
            // Update
            if (mode == 1)
            {
                string query1 = "INSERT INTO Users (firstName, lastName, email, password, dob, dispName, regDate) VALUES('";
                string query2 = first + "','" + last + "','" + email + "','" + pw + "','" + dob + "','" + disp + "','" + reg + "')";
                query = query1 + query1;

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("User record updated successfully");
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

            // Delete
            else if (mode == 2)
            {
                
                query = "DELETE FROM Users WHERE email = " + u.getemail();

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("User record removed successfully");
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

            // Disable
            else if (mode == 3)
            {
                string query1 = "INSERT INTO Users (firstName, lastName, email, password, dob, dispName, regDate) VALUES('";
                string query2 = first + "','" + last + "','" + email + "','" + pw + "','" + dob + "','" + disp + "','" + reg + "')";
                query = query1 + query1;

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("User record disabled successfully");
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

            // Enable
            else if (mode == 4)
            {
                string query1 = "INSERT INTO Users (firstName, lastName, email, password, dob, dispName, regDate) VALUES('";
                string query2 = first + "','" + last + "','" + email + "','" + pw + "','" + dob + "','" + disp + "','" + reg + "')";
                query = query1 + query1;

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("User record enabled successfully");
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

            return success;
        }
    }
}