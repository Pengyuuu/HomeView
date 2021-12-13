using System;

namespace Unite.HomeView.User
{
	class UMService
	{
		private UserDAO userdao;

		public UMService()
		{
			userdao = new UserDAO();
		}

		public Boolean UMServiceCreateUser(User u)
		{
			return userdao.createUser(u);

		}

		public Boolean UMServiceModifyUser(User u, int mode)
		{
			return userdao.modifyUser(u, mode);

		}

	}

}