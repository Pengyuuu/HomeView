using System;
using System.Data.SqlClient;
using System.Data;

namespace UM.User
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

            SqlCommand command = new SqlCommand("InsertUser", connection);
            try
            {
                connection.Open();

                // Insert New User Recor Stored Procedure
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = u.getid();
                command.Parameters.AddWithValue("@firstName", SqlDbType.NVarChar).Value = u.getfirst();
                command.Parameters.AddWithValue("@lastName", SqlDbType.NVarChar).Value = u.getlast();
                command.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = u.getemail();
                command.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = u.getpw();
                command.Parameters.AddWithValue("@dob", SqlDbType.DateTime).Value = u.getdob();
                command.Parameters.AddWithValue("@dispName", SqlDbType.NVarChar).Value = u.getdisp();
                command.Parameters.AddWithValue("@regDate", SqlDbType.DateTime).Value = u.getreg();
                command.Parameters.AddWithValue("@status", SqlDbType.Bit).Value = u.getstatus();

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
        public Boolean modifyUser(User u, int mode, User userMod)
        {
            Boolean success = true;
            SqlConnection connection = new SqlConnection(@connectionString);
     
            // Update
            if (mode == 1)
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateUser", connection);
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = u.getid();
                    command.Parameters.AddWithValue("@firstName", SqlDbType.NVarChar).Value = userMod.getfirst();
                    command.Parameters.AddWithValue("@lastName", SqlDbType.NVarChar).Value = userMod.getlast();
                    command.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = userMod.getemail();
                    command.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = userMod.getpw();
                    command.Parameters.AddWithValue("@dob", SqlDbType.DateTime).Value = userMod.getdob();
                    command.Parameters.AddWithValue("@dispName", SqlDbType.NVarChar).Value = userMod.getdisp();
                    command.Parameters.AddWithValue("@regDate", SqlDbType.DateTime).Value = userMod.getreg();
                    command.Parameters.AddWithValue("@status", SqlDbType.Bit).Value = userMod.getstatus();
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
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = u.getid();
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
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DisableUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = u.getid();
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
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("EnableUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = u.getid();
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