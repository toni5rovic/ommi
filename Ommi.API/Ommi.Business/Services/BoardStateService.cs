using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ommi.Business.DB;
using Ommi.Business.DB.Entities;
using Ommi.Business.DTOs;
using Ommi.Business.Services.Interfaces;

namespace Ommi.Business.Services
{
	public class BoardStateService : IBoardStateService
	{
		private OmmiDbContext dbContext;
		private IMapper autoMapper;
		public BoardStateService(OmmiDbContext dbContext, IMapper autoMapper)
		{
			this.dbContext = dbContext;
			this.autoMapper = autoMapper;
		}

		public async Task CreateAsync(BoardStateDTO boardStateDTO)
		{
			if (boardStateDTO == null)
				throw new ArgumentNullException($"Argument boardStateDTO is null.");

			BoardState boardState = autoMapper.Map<BoardState>(boardStateDTO);
			boardState.Id = Guid.NewGuid().ToString();
			dbContext.BoardStates.Add(boardState);
			await dbContext.SaveChangesAsync();
		}

		public async Task CreateInitialAsync(string roomName)
		{
			Room room = await dbContext.Rooms
				.Where(r => r.Name == roomName)
				.FirstOrDefaultAsync();
			if (room == null)
				throw new Exception($"Room with name: {roomName} doesn't exist.");

			BoardState newBoardState = new BoardState()
			{ 
				Id = Guid.NewGuid().ToString(),
				Volume = 50,
				TempoBPM = 90,
				NumberOfSteps = 16,
				Tracks = GetTracks(),
				RoomId = room.Id
			};

			dbContext.BoardStates.Add(newBoardState);
			await dbContext.SaveChangesAsync();
		}

		public async Task<BoardStateDTO> GetCurrentStateAsync(string roomName)
		{
			BoardState boardState = await dbContext.BoardStates
				.Include(bs => bs.Tracks)
				.Where(bs => bs.Room.Name == roomName)
				.FirstOrDefaultAsync();

			if (boardState == null)
				return null;

			return autoMapper.Map<BoardStateDTO>(boardState);
		}

		public async Task UpdateAsync(BoardStateDTO boardStateDTO, string roomName)
		{
			Room room = await dbContext.Rooms
				.Where(r => r.Name == roomName)
				.FirstOrDefaultAsync();
			if (room == null)
				throw new Exception($"Room with name: {roomName} doesn't exist.");

			BoardState existingBoardState = await dbContext.BoardStates
				.Where(bs => bs.Room.Name == roomName)
				.FirstOrDefaultAsync();
			if (existingBoardState == null)
				throw new Exception($"BoardState for room {roomName} not found.");

			BoardState updatedBoardState = autoMapper.Map<BoardState>(boardStateDTO);
			updatedBoardState.RoomId = existingBoardState.RoomId;

			dbContext.Entry(existingBoardState).CurrentValues.SetValues(updatedBoardState);
			await dbContext.SaveChangesAsync();
		}

		private List<Track> GetTracks()
		{
			List<Track> list = new List<Track>();
			list.Add(new Track
			{
				Id = Guid.NewGuid().ToString(),
				InstrumentName = "kick",
				Steps = "0000000000000000",
				Volume = 100
			});

			list.Add(new Track
			{
				Id = Guid.NewGuid().ToString(),
				InstrumentName = "sub",
				Steps = "0000000000000000",
				Volume = 100
			});

			list.Add(new Track
			{
				Id = Guid.NewGuid().ToString(),
				InstrumentName = "clap",
				Steps = "0000000000000000",
				Volume = 100
			});
			
			list.Add(new Track
			{
				Id = Guid.NewGuid().ToString(),
				InstrumentName = "hihat",
				Steps = "0000000000000000",
				Volume = 100
			});

			list.Add(new Track
			{
				Id = Guid.NewGuid().ToString(),
				InstrumentName = "openhihat",
				Steps = "0000000000000000",
				Volume = 100
			});

			return list;
		}
	}
}
