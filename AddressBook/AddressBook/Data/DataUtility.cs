using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data
{
	public static class DataUtility
	{
		public static string GetConnectionString(IConfiguration configuration)
		{
			//getting connection string from appSettings 
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			//overwritte connection string if running on Heroku
			var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

			return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
		}

		public static string BuildConnectionString(string databaseUrl)
		{
			//provides and object representation of a uniform resource identifier (URI)and easy access to the parameters  
			var databaseUri = new Uri(databaseUrl);
			var userInfo = databaseUri.UserInfo.Split(':');


			//Provides a simple and easy way to create and manage the contents of the connection strings used by the NpgsqlConnection on Heroku
			var builder = new NpgsqlConnectionStringBuilder
			{
				Host = databaseUri.Host,
				Port = databaseUri.Port,
				Username = userInfo[0],
				Password = userInfo[1],
				Database = databaseUri.LocalPath.Trim('/'),
				SslMode = SslMode.Prefer,
				TrustServerCertificate = true,
			};

			return builder.ToString();
		}

	}
}
