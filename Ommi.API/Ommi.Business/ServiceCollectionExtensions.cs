using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ommi.Business.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ommi.Business
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddOmmiDbContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<OmmiDbContext>(options =>
			{
				options.UseSqlServer(connectionString, sqlServerOptions =>
				{
					sqlServerOptions.CommandTimeout(60);
					sqlServerOptions.MigrationsAssembly("Ommi.Business");
				});
			});

			return services;
		}
	}
}
