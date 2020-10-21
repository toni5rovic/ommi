using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ommi.Business.DTOs;
using Ommi.Business.Services.Interfaces;
using Ommi.Web.Models.Requests;
using Ommi.Web.Models.Responses;

namespace Ommi.Web.Controllers
{
	[Authorize]
	[Route("[controller]")]
	public class TracksController : ControllerBase
	{
		private readonly ITrackService trackService;
		private readonly IMapper autoMapper;

		public TracksController(ITrackService trackService, IMapper autoMapper)
		{
			this.trackService = trackService;
			this.autoMapper = autoMapper;
		}

		// POST /tracks
		[HttpPost]
		public async Task<TrackResponse> Create(TrackRequest newTrackRequest)
		{
			TrackDTO trackDTO = autoMapper.Map<TrackDTO>(newTrackRequest);
			TrackDTO createdTrackDTO = await trackService.CreateTrack(trackDTO);
			return autoMapper.Map<TrackResponse>(createdTrackDTO);
		}
	}
}
