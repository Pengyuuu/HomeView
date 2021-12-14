using System;

namespace UM.User 
{
	class UMService
	{
		// User DAO
		private UserDAO userdao;

		public UMService()
		{
			userdao = new UserDAO();
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
		public Boolean UMServiceModifyUser(int id, int mode, User userMod)
		{
			return userdao.modifyUser(id, mode, userMod);

		}

		public Boolean UMServiceCheckUser(int id)
		{
			
			return userdao.checkUser(id);

		}

		// gets user
		public User UMServiceGetUser(int id)
		{
			User fetchedUser = new User();
			fetchedUser = fetchedUser.getUser(userdao.getUser(id));

			return userdao.getUser(id);

		}

	}

}
