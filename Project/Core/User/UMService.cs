using System;

namespace UM.User 
{
	public class UMService
	{
		// User DAO
		private UserDAO _userDao;

		public UMService(UserManager manager)
		{
			_userDao = new UserDAO(this);
		}

		/* Calls UM DAO to create user given new user
		 * Returns True is successful, false if unsuccessful
		 */
		public Boolean CanCreateUser(User userSelected)
		{
			return _userDao.CreateUser(userSelected);

		}

		/* Calls UM DAO to modify user, given User to modify, mode (delete, update, disable, enable), and user modifications
		 * Returns True is successful, false if unsuccessful
		 */
		public Boolean CanModifyUser(string userEmail, int mode, User userMod)
		{
			return _userDao.ModifyUser(userEmail, mode, userMod);

		}

		public Boolean IsUser(string userEmail)
		{
			return _userDao.IsUser(userEmail);
		}
		 
		public User UMServiceGetUser(string userEmail)
		{
			User fetchedUser = new User();
			fetchedUser = fetchedUser.GetUser(_userDao.GetUser(userEmail));
			return fetchedUser;
		}

		public String GetAllUsers()
		{
			return _userDao.GetAllUsers();
		}

		public Boolean ExportAllUsers()
		{
			return _userDao.ExportAllUsers();
		}



	}

}
