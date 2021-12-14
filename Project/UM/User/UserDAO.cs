using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace UM.User
{
    class UserDAO
    {
        // SQL connection strings
        private static string connectionString;

        public UserDAO()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\Data\Database\Homeview.mdf"));
            //connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\danny\\Source\\Repos\\HomeView\\Project\\Data\\Database\\Homeview.mdf;Integrated Security=True";
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
        }

        /* Creates a new user record in system */
        public Boolean createUser(User u)
        {
            Boolean success = true;
            
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("InsertUser", connection);
            try
            {
                connection.Open();

                // Insert New User Record Stored Procedure
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = u.getid();
                command.Parameters.AddWithValue("@firstN", SqlDbType.NVarChar).Value = u.getfirst();
                command.Parameters.AddWithValue("@lastN", SqlDbType.NVarChar).Value = u.getlast();
                command.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = u.getemail();
                command.Parameters.AddWithValue("@pw", SqlDbType.NVarChar).Value = u.getpw();
                command.Parameters.AddWithValue("@dob", SqlDbType.DateTime).Value = u.getdob();
                command.Parameters.AddWithValue("@dispN", SqlDbType.NVarChar).Value = u.getdisp();
                command.Parameters.AddWithValue("@regDate", SqlDbType.DateTime).Value = u.getreg();
                command.Parameters.AddWithValue("@status", SqlDbType.Bit).Value = u.getstatus();
                command.Parameters.AddWithValue("@role", SqlDbType.Int).Value = ((int)u.getrole());

                command.ExecuteNonQuery();
                Console.WriteLine("User record inserted successfully");
            }
            catch (SqlException e)
            {
                // Unable to insert new user record
                Console.WriteLine("Error Generated. Details: " + e.ToString());
                success = false;
            }
            finally
            {
                // closes sql connection
                connection.Close();
            }

            return success;
        }


        /* Modifies a user record in the system 
		 * 1 = Update information
		 * 2 = Delete account
		 * 3 = Disable
		 * 4 = Enable
		 * Returns true if successful, false if unsuccessful
		 */
        public Boolean modifyUser(User u, int mode, User userMod)
        {
            Boolean success = true;
            SqlConnection connection = new SqlConnection(connectionString);
     
            // Update user record information
            if (mode == 1)
            {
                try
                {
                    // opens sql connection
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateUser", connection);
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = u.getid();
                    command.Parameters.AddWithValue("@firstN", SqlDbType.NVarChar).Value = userMod.getfirst();
                    command.Parameters.AddWithValue("@lastN", SqlDbType.NVarChar).Value = userMod.getlast();
                    command.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = userMod.getemail();
                    command.Parameters.AddWithValue("@pw", SqlDbType.NVarChar).Value = userMod.getpw();
                    command.Parameters.AddWithValue("@dob", SqlDbType.DateTime).Value = userMod.getdob();
                    command.Parameters.AddWithValue("@dispN", SqlDbType.NVarChar).Value = userMod.getdisp();
                    command.Parameters.AddWithValue("@regDate", SqlDbType.DateTime).Value = userMod.getreg();
                    command.Parameters.AddWithValue("@status", SqlDbType.Bit).Value = userMod.getstatus();
                    command.Parameters.AddWithValue("@role", SqlDbType.Int).Value = ((int)userMod.getrole());

                    command.ExecuteNonQuery();
                    Console.WriteLine("User record updated successfully");
                }
                catch (SqlException e)
                {
                    // unable to update user record
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                    success = false;
                }
                finally
                {
                    // closes sql connection
                    connection.Close();
                }
            }

            // Delete user record
            else if (mode == 2)
            {
                try
                {
                    // opens sql connection
                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = u.getid();
                    command.ExecuteNonQuery();
                    Console.WriteLine("User record removed successfully");
                }
                catch (SqlException e)
                {
                    // unable to delete user record
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                    success = false;
                }
                finally
                {
                    // closes sql connection
                    connection.Close();
                }
            }

            // Disable a user record
            else if (mode == 3)
            {
                try
                {
                    // connects to sql
                    connection.Open();
                    SqlCommand command = new SqlCommand("DisableUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = u.getid();
                    command.ExecuteNonQuery();
                    Console.WriteLine("User record disabled successfully");
                }
                catch (SqlException e)
                {
                    // unable to disable user record
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                    success = false;
                }
                finally
                {
                    // closes sql connetion
                    connection.Close();
                }
            }

            // Enable
            else if (mode == 4)
            {
                try
                {   // connects to sql
                    connection.Open();
                    SqlCommand command = new SqlCommand("EnableUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = u.getid();
                    command.ExecuteNonQuery();
                    Console.WriteLine("User record enabled successfully");
                }
                catch (SqlException e)
                {
                    // unable to enable user record
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                    success = false;
                }
                finally
                {
                    // closes sql connection
                    connection.Close();
                }
            }

            return success;
        }
    }
}