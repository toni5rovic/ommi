using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ommi.Business.DTOs;

namespace Ommi.Business.Services.Interfaces
{
	public interface IRoomService
	{
		Task CreateRoom(RoomDTO room);
		Task RemoveRoom(RoomDTO room);
		Task<List<RoomDTO>> GetAll();
		Task<RoomDTO> GetByName(string roomName);
	}
}
