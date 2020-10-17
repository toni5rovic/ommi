using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ommi.Business.DTOs;
using Ommi.Business.Services.Interfaces;
using Ommi.Web.Models.Requests;
using Ommi.Web.Models.Responses;

namespace Ommi.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IUserService userService;
		private readonly IMapper autoMapper;
		
		public AuthController(IUserService userService, IMapper autoMapper)
		{
			this.userService = userService;
			this.autoMapper = autoMapper;
		}

		// POST /auth/login
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LogInRequest logInRequest)
		{
			string token = await userService.LogInAsync(logInRequest.Username, logInRequest.Password);

			var logInResponse = new LogInResponse() 
			{ 
				Token = token,
				Username = logInRequest.Username
			};

			return Ok(logInResponse);
		}

		// POST /auth/register
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
		{
			var registerModel = this.autoMapper.Map<UserDTO>(registerRequest);
			var dtoRes = await userService.RegisterAsync(registerModel);
			var response = this.autoMapper.Map<RegisterResponse>(dtoRes);
			
			return Ok(response);
		}
	}
}
