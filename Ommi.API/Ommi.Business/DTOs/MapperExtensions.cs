using Microsoft.AspNetCore.Identity;
using Ommi.Business.DB;

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
		}
	}
}
