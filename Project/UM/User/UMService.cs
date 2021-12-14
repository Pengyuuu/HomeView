﻿using System;

namespace UM.User 
{
	public class UMService
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
		public Boolean UMServiceModifyUser(User u, int mode, User userMod)
		{
			return userdao.modifyUser(u, mode, userMod);

		}

		public Boolean UMServiceCheckUser(int id)
		{
			
			return userdao.checkUser(id);

		}

		public User UMServiceGetUser(int id)
		{
			if (!this.UMServiceCheckUser(id))
            {
				return null;
            }

			User fetchedUser = new User();
			fetchedUser = fetchedUser.getUser(userdao.getUser(id));

			return userdao.getUser(id);

		}

	}

}
