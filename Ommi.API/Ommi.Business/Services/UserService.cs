using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Ommi.Business.DB;
using Ommi.Business.DTOs;
using Ommi.Business.Services.Interfaces;

namespace Ommi.Business.Services
{
	public class UserService : IUserService
	{
		private readonly OmmiDbContext context;
		private readonly SignInManager<IdentityUser> signInManager;
		private readonly UserManager<IdentityUser> userManager;
		private readonly IConfiguration configuration;
		private readonly IMapper mapper;

		public UserService(OmmiDbContext dbContext,
			SignInManager<IdentityUser> signInManager,
			UserManager<IdentityUser> userManager,
			IConfiguration configuration,
			IMapper mapper)
		{
			this.context = dbContext;
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.configuration = configuration;
			this.mapper = mapper;
		}

		public async Task<string> LogInAsync(string username, string password)
		{
			if (string.IsNullOrWhiteSpace(username))
				throw new Exception("Invalid LogIn credentials. Username must not be null.");
			if (string.IsNullOrWhiteSpace(password))
				throw new Exception("Invalid LogIn credentials. Password must not be null.");

			var user = await context.Users
				.Where(user => user.UserName == username)
				.FirstOrDefaultAsync();

			if (user == null)
			{
				throw new Exception($"User with username {username} not found.");
			}

			var result = await signInManager.PasswordSignInAsync(user, password, true, false);
			if (!result.Succeeded)
			{
				throw new Exception("Wrong credentials.");
			}

			
			var claims = GetJwtClaims(user);
			var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:SecretKey").Value)),
													 SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: configuration.GetSection("Jwt:Issuer").Value,
				audience: configuration.GetSection("Jwt:Audience").Value,
				claims: claims,
				expires: DateTime.Now.AddHours(1),
				signingCredentials: credentials);

			var jwtTokenHandler = new JwtSecurityTokenHandler();
			string tokenString = jwtTokenHandler.WriteToken(token);
			
			return tokenString;
		}

		public async Task<UserDTO> RegisterAsync(UserDTO model)
		{
			IdentityUser user = mapper.Map<IdentityUser>(model);
			user.Id = Guid.NewGuid().ToString();

			var result = await userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				throw new Exception("Registration failed.");
			}

			var dtoResult = mapper.Map<UserDTO>(user);
			return dtoResult;
		}

		private Claim[] GetJwtClaims(IdentityUser user)
		{
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
			};

			return claims;
		}
	}
}
