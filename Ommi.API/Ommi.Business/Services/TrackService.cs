using System;
using System.Threading.Tasks;
using AutoMapper;
using Ommi.Business.DB;
using Ommi.Business.DB.Entities;
using Ommi.Business.DTOs;
using Ommi.Business.Services.Interfaces;

namespace Ommi.Business.Services
{
	public class TrackService : ITrackService
	{
		private OmmiDbContext dbContext;
		private IMapper autoMapper;
		public TrackService(OmmiDbContext dbContext, IMapper autoMapper)
		{
			this.dbContext = dbContext;
			this.autoMapper = autoMapper;
		}

		public async Task<TrackDTO> CreateAsync(TrackDTO trackDTO)
		{
			if (trackDTO == null)
				throw new ArgumentNullException("TrackDTO is null.");

			Track track = autoMapper.Map<Track>(trackDTO);
			track.Id = Guid.NewGuid().ToString();

			dbContext.Tracks.Add(track);
			await dbContext.SaveChangesAsync();

			return autoMapper.Map<TrackDTO>(track);
		}

		public async Task DeleteAsync(string trackId)
		{
			if (string.IsNullOrEmpty(trackId))
				throw new ArgumentNullException("TrackId is null or empty.");

			Track existingTrack = await dbContext.Tracks.FindAsync(trackId);
			dbContext.Tracks.Remove(existingTrack);

			await dbContext.SaveChangesAsync();
		}
	}
}
