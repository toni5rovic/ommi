using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ommi.Business.DB
{
	public class OmmiDbContext : IdentityDbContext
	{
		public DbSet<Room> Rooms { get; set; }

		public OmmiDbContext(DbContextOptions<OmmiDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(OmmiDbContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
