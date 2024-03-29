﻿using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System;

namespace Data
{

	public class SqlDataAccess
	{
		
		private readonly string _connStr;
		/*
		 * specialize to only exec sp, can remove load and save
		 *	can make more generic to execute any db operation
		 *	
		 *	Environment variable - can set on server and use in C# for connstr
		 */
		public SqlDataAccess()
        {
			//_connStr = ConfigurationManager.ConnectionStrings["RDS"].ConnectionString;
			_connStr = "Data Source=homeviewdb.cotk9avwlowj.us-west-1.rds.amazonaws.com,1433;Initial Catalog=homeviewdb;User ID=awshomeviewadmin;Password=homeviewCSULB90807";
		}

		/*
		 * can make param type for every feature/param type
		 */
		public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
		{
            using IDbConnection conn = new SqlConnection(_connStr);
			return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

		public async Task<int> SaveData<T>(string storedProcedure, T parameters)
		{
			// Differentiate between line 45 and 49
			using IDbConnection conn = new SqlConnection(_connStr);
			try
			{
				var affectedRows = await conn.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
				return affectedRows;
			}
			catch (Exception dbError)
            {
				return 0;
            }
        }
	}
}