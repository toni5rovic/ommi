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
	public class BoardStateController : ControllerBase
	{
		private readonly IBoardStateService boardStateService;
		private readonly IMapper autoMapper;

		public BoardStateController(IBoardStateService boardStateService, IMapper autoMapper)
		{
			this.boardStateService = boardStateService;
			this.autoMapper = autoMapper;
		}

		// GET /boardstate/{roomName}
		[HttpGet("{roomName}")]
		public async Task<BoardStateResponse> GetByName(string roomName)
		{
			var boardStateDTO = await boardStateService.GetCurrentStateAsync(roomName);
			if (boardStateDTO != null)
				return autoMapper.Map<BoardStateResponse>(boardStateDTO);

			return null;
		}
	}
}
