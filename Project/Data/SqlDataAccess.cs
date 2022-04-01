using Dapper;
//using System;
using System.Data;
using System.Threading.Tasks;
//using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;



namespace Data
{

	public class SqlDataAccess
	{
		public SqlDataAccess()
		{
		}

		public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
		{
			using (IDbConnection conn = new SqlConnection(Data.ConnectionString.getConnectionString()))
			{
				//return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
				return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public async Task SaveData<T>(string storedProcedure, T parameters)
		{
			using (IDbConnection conn = new SqlConnection(Data.ConnectionString.getConnectionString()))
			{
				await conn.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);


			}
		}


	}
}