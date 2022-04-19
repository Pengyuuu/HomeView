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
		private readonly IConfiguration _configuration;
		private string _connStr;
		public string ConnectionStr { get; set; }

		public SqlDataAccess()
        {
			var tests = ConfigurationManager.ConnectionStrings[0].ConnectionString;


		}
		/**
		public SqlDataAccess(IConfiguration config)
		{
			_configuration = config;
			//_connStr = _configuration.GetSection("ConnectionStrings:ConnectionStr").Value;
			//_connStr = ConnectionStr;
			//_connStr = ConfigurationExtensions.
			var c = config.GetSection("ConnectionStrings");

			// To get the value configA
			var value = c["ConnectionStr"];

		}**/


		public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
		{
			using (IDbConnection conn = new SqlConnection(ConnectionStr))
			{
				//return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
				return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public async Task SaveData<T>(string storedProcedure, T parameters)
		{
		using (IDbConnection conn = new SqlConnection(ConnectionStr))
		{
			await conn.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);


		}
		}

	}
}