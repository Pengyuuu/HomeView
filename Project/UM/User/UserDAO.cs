using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace UM.User
{

    public class UserDAO
    {   
        

        /* Singleton
		private static UserManager instance = null;

		public static UserManager GetInstance
        {
            get
            {
				if (GetInstance == null)
                {
					instance = new UserManager();
                }
            }
        }*/
        
        
        
        public UserDAO()
        {

        }

        // Gets all users in db
        public String getAllUsers()
        {
            string result = "";
           
            SqlConnection connection = new SqlConnection(Data.ConnectionString.getConnectionString());

            try
            {   // connects to sql
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetAllUsers", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader read = command.ExecuteReader();

                    //command.ExecuteNonQuery();
             
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            string uid = read.GetInt32(0) + ",";
                            string first = read.GetString(1) + ",";
                            string last = read.GetString(2) + ",";
                            string email = read.GetString(3) + ",";
                            string pw = read.GetString(4) + ",";
                            string dob = read.GetString(5) + ",";
                            string dname = read.GetString(6) + ",";
                            string regd = read.GetString(7) + ",";
                            string status = read.GetString(8) + ",";
                            string role = read.GetString(9);
                            

                            result += uid+first+last+email+pw+dob+dname+regd+status+role + '\n';
                        }
                    }
                    else
                    {
                        result = "No records found.";
                    }
                    read.Close();
                    
            }
            catch (SqlException e)
            {
                // unable to enable user record
                Console.WriteLine("Error Generated. Details: " + e.ToString());
                result = "Unable to get all records";
            }

            finally
            {
                // closes sql connection
                connection.Close();
            }

            return result;
        }
        
        // Gets all users in db
        public Boolean exportAllUsers(string filepath)
        {
            string result = "";
            Boolean success = true;
            SqlConnection connection = new SqlConnection(Data.ConnectionString.getConnectionString());

            try
            {   // connects to sql
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetAllUsers", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader read = command.ExecuteReader();

                    //command.ExecuteNonQuery();
             
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            string uid = read.GetInt32(0) + ",";
                            string first = read.GetString(1) + ",";
                            string last = read.GetString(2) + ",";
                            string email = read.GetString(3) + ",";
                            string pw = read.GetString(4) + ",";
                            string dob = read.GetString(5) + ",";
                            string dname = read.GetString(6) + ",";
                            string regd = read.GetString(7) + ",";
                            string status = read.GetString(8) + ",";
                            string role = read.GetString(9);
                            
                            
                            result += uid+first+last+email+pw+dob+dname+regd+status+role + '\n';
                        }
                    }
                    else
                    {
                        success = false;
                    }
                    read.Close();
                    
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
            
            File.WriteAllText(filepath, result);
            return success;
        }

        // gets user
        public String getUser(int id)
        {
            string result = "";
           
            SqlConnection connection = new SqlConnection(Data.ConnectionString.getConnectionString());

            try
            {   // connects to sql
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    SqlDataReader read = command.ExecuteReader();

                    //command.ExecuteNonQuery();
             
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            string uid = read.GetInt32(0) + ",";
                            string first = read.GetString(1) + ",";
                            string last = read.GetString(2) + ",";
                            string email = read.GetString(3) + ",";
                            string pw = read.GetString(4) + ",";
                            string dob = read.GetString(5) + ",";
                            string dname = read.GetString(6) + ",";
                            string regd = read.GetString(7) + ",";
                            string status = read.GetString(8) + ",";
                            string role = read.GetString(9);
                            

                            result += uid+first+last+email+pw+dob+dname+regd+status+role + '\n';
                        }
                    }
                    else
                    {
                        result = "No record found.";
                    }
                    read.Close();
                    
            }
            catch (SqlException e)
            {
                // unable to enable user record
                Console.WriteLine("Error Generated. Details: " + e.ToString());
                result = "Unable to get user id: " + id;
            }

            finally
            {
                // closes sql connection
                connection.Close();
            }

            return result;
        }            

        /* Checks if user is in database*/
        public Boolean checkUser(int id)
        {
            Boolean result = false;
            SqlConnection connection = new SqlConnection(Data.ConnectionString.getConnectionString());

            try
            {   // connects to sql
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    SqlDataReader read = command.ExecuteReader();

                    //command.ExecuteNonQuery();
             
                    if (read.HasRows)
                    {
                        result = true;
                    }

                    else
                    {
                        result = false;
                    }
                    read.Close();
                    
            }
            catch (SqlException e)
            {
                // unable to enable user record
                Console.WriteLine("Error Generated. Details: " + e.ToString());
                result = false;
            }

            finally
            {
                // closes sql connection
                connection.Close();
            }

            return result;
        }            
        
        /* Creates a new user record in system */
        public Boolean createUser(User u)
        {
            Boolean success = true;
            
            SqlConnection connection = new SqlConnection(Data.ConnectionString.getConnectionString());

            SqlCommand command = new SqlCommand("InsertUser", connection);
            try
            {
                connection.Open();

                // Insert New User Record Stored Procedure
                command.CommandType = CommandType.StoredProcedure;

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
		 * Returns true if successful, false if unsuccessful*/
		 
        public Boolean modifyUser(int id, int mode, User userMod)
        {
            Boolean success = true;
            SqlConnection connection = new SqlConnection(Data.ConnectionString.getConnectionString());
     
            // Update user record information
            if (mode == 1)
            {
                try
                {
                    // opens sql connection
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateUser", connection);
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    command.Parameters.AddWithValue("@firstN", SqlDbType.NVarChar).Value = userMod.getfirst();
                    command.Parameters.AddWithValue("@lastN", SqlDbType.NVarChar).Value = userMod.getlast();
                    command.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = userMod.getemail();
                    command.Parameters.AddWithValue("@pw", SqlDbType.NVarChar).Value = userMod.getpw();
                    command.Parameters.AddWithValue("@dob", SqlDbType.DateTime).Value = userMod.getdob();
                    command.Parameters.AddWithValue("@dispN", SqlDbType.NVarChar).Value = userMod.getdisp();
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
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
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
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
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
                    command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
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