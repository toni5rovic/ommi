using AutoMapper;
using Ommi.Business.DTOs;
using Ommi.Web.Models.Requests;
using Ommi.Web.Models.Responses;

namespace Ommi.Web.Models
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<RegisterRequest, UserDTO>();
			CreateMap<UserDTO, RegisterResponse>();

			this.AddBusinessLayerMaps();
		}
	}
}
