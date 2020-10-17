using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ommi.Business.DB;

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

		public static IServiceCollection AddAspNetCoreIdentity(this IServiceCollection services)
		{
			services.AddIdentity<IdentityUser, IdentityRole>(options =>
				{
					options.Password.RequireDigit = true;
					options.Password.RequiredLength = 8;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireUppercase = false;
				})
				.AddEntityFrameworkStores<OmmiDbContext>();

			return services;
		}
	}
}
