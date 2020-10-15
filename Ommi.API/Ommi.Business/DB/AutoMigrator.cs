using Microsoft.EntityFrameworkCore;

namespace Ommi.Business.DB
{
	public static class AutoMigrator
	{
		public static void ApplyMigrations(string connectionString)
		{
			var contextFactory = new DesignTimeDbContextFactory();
			using (var context = contextFactory.CreateDbContext(connectionString))
			{
				context.Database.Migrate();
			}
		}
	}
}
