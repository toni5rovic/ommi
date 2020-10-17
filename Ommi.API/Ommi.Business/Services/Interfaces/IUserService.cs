using System.Threading.Tasks;
using Ommi.Business.DTOs;

namespace Ommi.Business.Services.Interfaces
{
	public interface IUserService
	{
		Task<string> LogInAsync(string username, string password);
		Task<UserDTO> RegisterAsync(UserDTO userRegisterModel);
	}
}
