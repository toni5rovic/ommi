using Microsoft.AspNetCore.Identity;
using Ommi.Business.DB.Entities;
using Ommi.Business.DTOs.Extensions;

namespace Ommi.Business.DTOs
{
	public static class MapExtensions
	{
		public static void AddBusinessLayerMaps(this AutoMapper.Profile profile)
		{
			profile.CreateMap<UserDTO, IdentityUser>();
			profile.CreateMap<IdentityUser, UserDTO>();
			profile.CreateMap<RoomDTO, Room>();
			profile.CreateMap<Room, RoomDTO>();
			profile.CreateMap<BoardStateDTO, BoardState>();
			profile.CreateMap<BoardState, BoardStateDTO>();
			profile.CreateMap<TrackDTO, Track>()
				.ForMember(track => track.Steps,
							opt => opt.MapFrom(s => s.Steps.ConvertToString()));

			profile.CreateMap<Track, TrackDTO>()
				.ForMember(trackDTO => trackDTO.Steps,
							opt => opt.MapFrom(track => track.Steps.ConvertToBoolList()));
		}
	}
}
