using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ommi.Business.DB
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OmmiDbContext>
	{
		public OmmiDbContext CreateDbContext(string connectionString)
		{
			var optionsBuilder = new DbContextOptionsBuilder<OmmiDbContext>();
			optionsBuilder.UseSqlServer(connectionString);
			return new OmmiDbContext(optionsBuilder.Options);
		}

		public OmmiDbContext CreateDbContext(string[] args)
		{
			//var jsonBytes = File.ReadAllBytes(@"..\Ommi.Web\appsettings.Development.json");
			string jsonContent = File.ReadAllText(@"..\Ommi.Web\appsettings.Development.json");
			var jsonDoc = JsonDocument.Parse(jsonContent);
			var root = jsonDoc.RootElement;
			string conString = root.GetProperty("ConnectionStrings").GetProperty("OmmiDbConnectionString").GetString();

			return CreateDbContext(conString);
		}
	}
}
