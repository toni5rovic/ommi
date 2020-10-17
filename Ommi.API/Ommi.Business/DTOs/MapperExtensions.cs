using Microsoft.AspNetCore.Identity;

namespace Ommi.Business.DTOs
{
	public static class MapExtensions
	{
		public static void AddBusinessLayerMaps(this AutoMapper.Profile profile)
		{
			profile.CreateMap<UserDTO, IdentityUser>();
			profile.CreateMap<IdentityUser, UserDTO>();
		}
	}
}
