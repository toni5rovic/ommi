﻿using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ommi.Business;
using Ommi.Business.DB;
using Ommi.Business.Services;
using Ommi.Business.Services.Interfaces;
using Ommi.Web.Models;
using Ommi.Web.SignalR;

namespace Ommi.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			string[] origins = new string[]
			{
				"http://localhost:8080",
				"https://ommi-ui.azurewebsites.net"
			};

			services.AddCors(options =>
			{
				options.AddDefaultPolicy(policy =>
				{
					policy.AllowAnyOrigin()
						.AllowAnyHeader()
						.AllowAnyMethod();
				});

				options.AddPolicy("CorsPolicy", builder => builder.WithOrigins(origins)
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowCredentials()
					.SetIsOriginAllowed((host) => true));
			});

			services.AddControllers();

			// Add Db Context
			string connectionString = Configuration.GetConnectionString("OmmiDbConnectionString");
			services.AddOmmiDbContext(connectionString);

			// Apply migrations if needed
			AutoMigrator.ApplyMigrations(connectionString);

			services.AddSignalR();

			// Add AspNetCore Identity
			services.AddAspNetCoreIdentity();
			
			// Add Service classes
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IRoomService, RoomService>();
			services.AddScoped<IBoardStateService, BoardStateService>();
			services.AddScoped<ITrackService, TrackService>();

			// Add AutoMapper
			services.AddAutoMapper(typeof(AutoMapperProfile));

			// Add Authentication with JsonWebTokens
			AddJwt(services);
			services.AddAuthorization();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors("CorsPolicy");

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHub<OmmiHub>("/ommiHub");
				endpoints.MapControllers();
			});
		}

		private IServiceCollection AddJwt(IServiceCollection services)
		{
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = true,
						ValidateLifetime = true,
						ValidateAudience = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = Configuration["Jwt:Issuer"],
						ValidAudience = Configuration["Jwt:Audience"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
					};
					options.Validate();
				});

			return services;
		}
	}
}
