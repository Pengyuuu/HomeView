using Dapper;
using System;
using System.Data;
using MySqlConnector;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Data.Odbc;
//using MySql.Data;
//using MySql.Data.MySqlClient;
using Dapper.Extensions.Odbc;


namespace Data
{

	public class SqlDataAccess
	{
		public SqlDataAccess()
		{
		}

		public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
		{

			using (IDbConnection conn = new OdbcConnection(Data.ConnectionString.getConnectionString()))
			{
				//return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

				return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public async Task SaveData<T>(string storedProcedure, T parameters)
		{
			using (OdbcConnection conn = new OdbcConnection(Data.ConnectionString.getConnectionString()))
			{
				await conn.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

				//await conn.ExecuteAsync("Users_CreateUser ?firstName?,?lastName?,?email?,?password?,?dob?,?dispName?,?status?,?regDate?,?role?,?token?", parameters, commandType: CommandType.StoredProcedure);

			}
		}


	}
}