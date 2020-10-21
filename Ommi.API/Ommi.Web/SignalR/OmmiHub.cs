using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Ommi.Business.DTOs;
using Ommi.Business.Services.Interfaces;

namespace Ommi.Web.SignalR
{
	public class OmmiHub : Hub
	{
		private IRoomService roomService;
		private IBoardStateService boardStateService;

		public OmmiHub(IRoomService roomService, IBoardStateService boardStateService)
		{
			this.roomService = roomService;
			this.boardStateService = boardStateService;
		}

		#region Connect/Disconnect
		public override Task OnConnectedAsync()
		{
			Console.WriteLine("Connected!");
			return base.OnConnectedAsync();
		}

		public override Task OnDisconnectedAsync(Exception exception)
		{
			Console.WriteLine("Disconnected!");
			return base.OnDisconnectedAsync(exception);
		}
		#endregion

		#region Groups
		public async Task CreateAndJoinGroupAsync(string groupName)
		{
			await roomService.CreateRoom(new RoomDTO() { Name = groupName });
			Console.WriteLine($"Room {groupName} created.");
			await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

			await boardStateService.CreateInitialAsync(groupName);

			await Clients.Caller.SendAsync("roomCreated", groupName);
		}

		public async Task JoinGroupAsync(string groupName)
		{
			Console.WriteLine($"Join group {groupName}");
			
			await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
			await Clients.Caller.SendAsync("joinedToTheRoom", groupName);
		}
		#endregion

		#region BoardStates
		public async Task UpdateBoardStateAsync(BoardStateDTO newBoardState, string groupName)
		{
			Console.WriteLine($"{groupName}: Updating board state...");
			await boardStateService.UpdateAsync(newBoardState, groupName);
			Console.WriteLine($"{groupName}: Board state update.");
			await Clients.OthersInGroup(groupName).SendAsync("updateBoardState", newBoardState);
			Console.WriteLine($"{groupName}: New board state sent to other clients in the group.");
		}
		#endregion
	}
}
