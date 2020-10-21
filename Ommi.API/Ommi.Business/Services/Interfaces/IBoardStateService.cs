using System.Threading.Tasks;
using Ommi.Business.DTOs;

namespace Ommi.Business.Services.Interfaces
{
	public interface IBoardStateService
	{
		Task<BoardStateDTO> GetCurrentStateAsync(string roomName);
		Task CreateAsync(BoardStateDTO boardStateDTO);
		Task CreateInitialAsync(string roomName);
		Task UpdateAsync(BoardStateDTO boardStateDTO, string roomName);
	}
}
