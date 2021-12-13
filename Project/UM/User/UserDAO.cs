using System;
using System.Data.SqlClient;
// nu
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

 
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                // Insert New User Recor Stored Procedure
                SqlCommand command = new SqlCommand("InsertUser", sqlCon);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", SqlDbType.int).Value = u.getid());
                command.Parameters.AddWithValue("@firstName", SqlDbType.NVarChar).Value = u.getfirst());
                command.Parameters.AddWithValue("@lastName", SqlDbType.NVarChar).Value = u.getlast());
                command.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = u.getemail());
                command.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = u.getpw());
                command.Parameters.AddWithValue("@dob", SqlDbType.DateTime).Value = u.getdob());
                command.Parameters.AddWithValue("@dispName", SqlDbType.NVarChar).Value = u.getdisp());
                command.Parameters.AddWithValue("@regDate", SqlDbType.DateTime).Value = u.getreg());
       
                command.ExecuteNonQuery();
                Console.WriteLine("User record inserted successfully");
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
                
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteUser", sqlCon);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", SqlDbType.int).Value = u.getid());
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