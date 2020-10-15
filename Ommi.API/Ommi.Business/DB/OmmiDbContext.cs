using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ommi.Business.DB
{
	public class OmmiDbContext : IdentityDbContext
	{
		public OmmiDbContext(DbContextOptions<OmmiDbContext> options) : base(options) { }
	}
}
