using System.Threading.Tasks;
using Ommi.Business.DTOs;

namespace Ommi.Business.Services.Interfaces
{
	public interface ITrackService
	{
		Task<TrackDTO> CreateAsync(TrackDTO track);
		Task DeleteAsync(string trackId);
	}
}
