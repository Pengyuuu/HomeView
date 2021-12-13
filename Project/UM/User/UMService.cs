﻿using System;

namespace UM.User 
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

		public Boolean UMServiceModifyUser(User u, int mode, User userMod)
		{
			return userdao.modifyUser(u, mode, userMod);

		}

	}

}
