using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ommi.Business.Services.Interfaces;
using Ommi.Web.Models.Responses;

namespace Ommi.Web.Controllers
{
	[Authorize]
	[Route("[controller]")]
	public class RoomsController : ControllerBase
	{
		private readonly IRoomService roomService;
		private readonly IMapper autoMapper;

		public RoomsController(IRoomService roomService, IMapper autoMapper)
		{
			this.roomService = roomService;
			this.autoMapper = autoMapper;
		}

		// GET /rooms
		[HttpGet]
		public async Task<List<RoomResponse>> Get()
		{
			Console.WriteLine("Get rooms!");
			var rooms = await roomService.GetAll();
			var roomResponses = autoMapper.Map<List<RoomResponse>>(rooms);
			return roomResponses;
		}

		// GET /rooms/{roomName}
		[HttpGet("{roomName}")]
		public async Task<RoomResponse> GetByName(string roomName)
		{
			var roomDTO = await roomService.GetByName(roomName);
			if (roomDTO != null)
				return autoMapper.Map<RoomResponse>(roomDTO);

			return null;
		}
	}
}
