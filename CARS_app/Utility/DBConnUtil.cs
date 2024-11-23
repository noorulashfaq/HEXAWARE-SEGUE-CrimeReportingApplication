﻿
using Microsoft.Extensions.Configuration;

namespace CARS_app.Utility
{
	internal static class DBConnUtil
	{
		private static IConfiguration _iconfiguration;

		static DBConnUtil()
		{
			GetAppSettingsFile();
		}

		private static void GetAppSettingsFile()
		{
			var builder = new ConfigurationBuilder()
						.SetBasePath(Directory.GetCurrentDirectory())
						.AddJsonFile("appsettings.json");
			_iconfiguration = builder.Build();
		}

		public static string GetConnectionString()
		{
			return _iconfiguration.GetConnectionString("LocalConnectionString");
		}
	}
}
