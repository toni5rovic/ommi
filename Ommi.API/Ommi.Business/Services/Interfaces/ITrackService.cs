using System.Threading.Tasks;
using Ommi.Business.DTOs;

namespace Ommi.Business.Services.Interfaces
{
	public interface ITrackService
	{
		Task<TrackDTO> CreateTrack(TrackDTO track);
	}
}
