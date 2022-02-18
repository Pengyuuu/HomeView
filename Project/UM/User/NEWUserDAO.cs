using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace UM.User
{
    public class NEWUserDAO
    {
        public NEWUserDAO(UMService service)
        {
        }

        // Gets all users in db
        public String GetAllUsers()
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
                    Role _userRole;
                    while (read.Read())
                    {
                        string uid = read.GetInt32(0) + ",";
                        string first = read.GetString(1) + ",";
                        string last = read.GetString(2) + ",";
                        string userEmail = read.GetString(3) + ",";
                        string userPass = read.GetString(4) + ",";
                        string dob = read.GetDateTime(5) + ",";
                        string dname = read.GetString(6) + ",";
                        string regd = read.GetDateTime(7) + ",";
                        string _userStatus = read.GetBoolean(8) + ",";
                        string roleStr = read.GetInt32(9).ToString();


                        result += uid + first + last + userEmail + userPass + dob + dname + regd + _userStatus + roleStr + '\n';
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
        public Boolean ExportAllUsers()
        {
            string filePath = Path.GetFullPath("@\\..\\..\\..\\..\\..\\..\\Project\\Data\\ExportedUserData.csv");
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
                        string userEmail = read.GetString(3) + ",";
                        string userPass = read.GetString(4) + ",";
                        string dob = read.GetDateTime(5) + ",";
                        string dname = read.GetString(6) + ",";
                        string regd = read.GetDateTime(7) + ",";
                        string _userStatus = read.GetBoolean(8) + ",";
                        string _userRole = read.GetInt32(9).ToString();


                        result += uid + first + last + userEmail + userPass + dob + dname + regd + _userStatus + _userRole + '\n';
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
                success = false;
            }

            finally
            {
                // closes sql connection
                connection.Close();
            }

            File.WriteAllText(filePath, result);
            return success;
        }

        // gets user
        public String GetUser(string userEmail)
        {
            string result = "";

            SqlConnection connection = new SqlConnection(Data.ConnectionString.getConnectionString());

            try
            {   // connects to sql
                connection.Open();
                SqlCommand command = new SqlCommand("GetUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userEmail", SqlDbType.NChar).Value = userEmail;
                SqlDataReader read = command.ExecuteReader();

                //command.ExecuteNonQuery();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        string uid = read.GetInt32(0) + ",";
                        string first = read.GetString(1) + ",";
                        string last = read.GetString(2) + ",";
                        string userPass = read.GetString(4) + ",";
                        string dob = read.GetString(5) + ",";
                        string dname = read.GetString(6) + ",";
                        string regd = read.GetString(7) + ",";
                        string _userStatus = read.GetString(8) + ",";
                        string _userRole = read.GetString(9);


                        result += uid + first + last + userEmail + userPass + dob + dname + regd + _userStatus + _userRole + '\n';
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
                result = "Unable to get user: " + userEmail;
            }

            finally
            {
                // closes sql connection
                connection.Close();
            }

            return result;
        }

        /* Checks if user is in database*/
        public Boolean IsUser(string userEmail)
        {
            Boolean result = true;
            SqlConnection connection = new SqlConnection(Data.ConnectionString.getConnectionString());

            try
            {   // connects to sql
                connection.Open();
                SqlCommand command = new SqlCommand("GetUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userEmail", SqlDbType.NChar).Value = userEmail;
                SqlDataReader read = command.ExecuteReader();

                //command.ExecuteNonQuery();

                if (!read.HasRows)
                {
                    result = false;
                }
                read.Close();

            }
            catch (SqlException e)
            {
                // unable to enable user record
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
        public Boolean CreateUser(User u)
        {
            Boolean success = true;

            SqlConnection connection = new SqlConnection(Data.ConnectionString.getConnectionString());

            SqlCommand command = new SqlCommand("InsertUser", connection);
            try
            {
                connection.Open();

                // Insert New User Record Stored Procedure
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@firstN", SqlDbType.NVarChar).Value = u.FirstName;
                command.Parameters.AddWithValue("@lastN", SqlDbType.NVarChar).Value = u.LastName;
                command.Parameters.AddWithValue("@userEmail", SqlDbType.NVarChar).Value = u.UserEmail;
                command.Parameters.AddWithValue("@userPass", SqlDbType.NVarChar).Value = u.UserPassword;
                command.Parameters.AddWithValue("@dob", SqlDbType.DateTime).Value = u.UserDob;
                command.Parameters.AddWithValue("@dispN", SqlDbType.NVarChar).Value = u.DispName;
                command.Parameters.AddWithValue("@_regDate", SqlDbType.DateTime).Value = u.RegDate;
                command.Parameters.AddWithValue("@_userStatus", SqlDbType.Int).Value = u.UserStatus;
                command.Parameters.AddWithValue("@_userRole", SqlDbType.Int).Value = ((int)u.UserRole);

                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                // Unable to insert new user record
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

        public Boolean ModifyUser(string userEmail, int mode, User userMod)
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
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@firstN", SqlDbType.NVarChar).Value = userMod.FirstName;
                    command.Parameters.AddWithValue("@lastN", SqlDbType.NVarChar).Value = userMod.LastName;
                    command.Parameters.AddWithValue("@userEmail", SqlDbType.NVarChar).Value = userMod.UserEmail;
                    command.Parameters.AddWithValue("@userPass", SqlDbType.NVarChar).Value = userMod.UserPassword;
                    command.Parameters.AddWithValue("@dob", SqlDbType.DateTime).Value = userMod.UserDob;
                    command.Parameters.AddWithValue("@dispN", SqlDbType.NVarChar).Value = userMod.DispName;
                    command.Parameters.AddWithValue("@_userStatus", SqlDbType.Int).Value = userMod.UserStatus;
                    command.Parameters.AddWithValue("@_regDate", SqlDbType.Int).Value = userMod.RegDate;
                    command.Parameters.AddWithValue("@_userRole", SqlDbType.Int).Value = ((int)userMod.UserRole);

                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    // unable to update user record
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
                    command.Parameters.AddWithValue("@userEmail", SqlDbType.NChar).Value = userEmail;
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    // unable to delete user record
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
                    command.Parameters.AddWithValue("@userEmail", SqlDbType.NChar).Value = userEmail;
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    // unable to disable user record
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
                    command.Parameters.AddWithValue("@userEmail", SqlDbType.NChar).Value = userEmail;
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    // unable to enable user record
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
