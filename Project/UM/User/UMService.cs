using System;

namespace UM.User 
{
	public class UMService
	{
		// User DAO
		private UserDAO userdao;

		public UMService(UserManager manager)
		{
			userdao = new UserDAO(this);
		}

		/* Calls UM DAO to create user given new user
		 * Returns True is successful, false if unsuccessful
		 */
		public Boolean UMServiceCreateUser(User u)
		{
			return userdao.createUser(u);

		}

		/* Calls UM DAO to modify user, given User to modify, mode (delete, update, disable, enable), and user modifications
		 * Returns True is successful, false if unsuccessful
		 */
		public Boolean UMServiceModifyUser(string email, int mode, User userMod)
		{
			return userdao.modifyUser(email, mode, userMod);

		}

		public Boolean UMServiceCheckUser(string email)
		{
			return userdao.checkUser(email);
		}
		 
		public User UMServiceGetUser(string email)
		{
			User fetchedUser = new User();
			fetchedUser = fetchedUser.getUser(userdao.getUser(email));
			return fetchedUser;
		}

		public String UMServiceGetAllUsers()
		{
			return userdao.getAllUsers();
		}

		public Boolean UMServiceExportAllUsers()
		{

			return userdao.exportAllUsers();

		}



	}

}
