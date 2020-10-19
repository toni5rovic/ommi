using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ommi.Business.DB;
using Ommi.Business.DTOs;
using Ommi.Business.Services.Interfaces;

namespace Ommi.Business.Services
{
	public class RoomService : IRoomService
	{
		private OmmiDbContext dbContext;
		private IMapper autoMapper;
		public RoomService(OmmiDbContext dbContext, IMapper autoMapper)
		{
			this.dbContext = dbContext;
			this.autoMapper = autoMapper;
		}

		public async Task CreateRoom(RoomDTO room)
		{
			if (dbContext.Rooms.Find(room.Id) != null)
				return;

			Room roomEntity = autoMapper.Map<Room>(room);
			roomEntity.Id = Guid.NewGuid().ToString();
			dbContext.Rooms.Add(roomEntity);
			await dbContext.SaveChangesAsync();
		}

		public async Task<List<RoomDTO>> GetAll()
		{
			List<Room> roomList = dbContext.Rooms.ToList();
			List<RoomDTO> roomDTOList = autoMapper.Map<List<RoomDTO>>(roomList);
			return roomDTOList;
		}

		public async Task RemoveRoom(RoomDTO room)
		{
			var roomFromDb = dbContext.Rooms.Find(room.Id);
			if (roomFromDb == null)
				return;

			dbContext.Rooms.Remove(roomFromDb);
			await dbContext.SaveChangesAsync();
		}

		public async Task<RoomDTO> GetByName(string roomName)
		{
			Room room = await dbContext.Rooms
				.Where(r => r.Name == roomName)
				.FirstOrDefaultAsync();

			if (room == null)
				return null;

			return autoMapper.Map<RoomDTO>(room);
		}
	}
}
