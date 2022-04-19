using Dapper;
//using System;
using System.Data;
using System.Threading.Tasks;
//using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Data
{

	public class SqlDataAccess
	{
		//private readonly string _connStr;
		//private readonly IConfiguration _configuration;
		private readonly string _connStr;

		public SqlDataAccess()
        {
			this._connStr = ConfigurationManager.ConnectionStrings[1].ConnectionString;
		}



		public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
		{
			using (IDbConnection conn = new SqlConnection(_connStr))
			{
				//return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
				return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public async Task SaveData<T>(string storedProcedure, T parameters)
		{
		using (IDbConnection conn = new SqlConnection(_connStr))
		{
			await conn.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);


		}
		}

	}
}