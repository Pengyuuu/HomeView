using System;

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


}

