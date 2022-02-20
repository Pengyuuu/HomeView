using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core.User
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
		public Boolean HasCreateUser(User userSelected)
		{
			var result = _userDao.ReadUser(userSelected);
			return result == null ? false : true;
			

		}

		/* Calls UM DAO to modify user, given User to modify, mode (delete, update, disable, enable), and user modifications
		 * Returns True is successful, false if unsuccessful
		 */
		public Boolean HasModifyUser(User userMod)
		{
			var result = _userDao.UpdateUser(userMod);
			return result == null ? false : true;


		}

		public Boolean HasDeleteUser(User userMod)
		{
			var result = _userDao.DeleteUser(userMod);
			return result == null ? false : true;
		}

		public Boolean IsUser(User user)
		{
			var result = _userDao.ReadUser(user);
			return result == null ? false : true;

		}

		public Task<IEnumerable<User>> GetUser(User user)
		{
			return _userDao.ReadUser(user);
		}

		public Task<IEnumerable<User>> GetAllUsers()
		{
			var results = _userDao.ReadUser();
			return results == null ? null : results;
		}
	}

}
