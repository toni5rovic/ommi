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

		public OmmiHub(IRoomService roomService)
		{
			this.roomService = roomService;
		}

		public override Task OnConnectedAsync()
		{
			Console.WriteLine("Connected!");
			return base.OnConnectedAsync();
		}

		public async Task ActivateSignalR()
		{
			Console.WriteLine("Invoked!");
			await Clients.All.SendAsync("receiveMessage", "This is a message.");
		}

		public override Task OnDisconnectedAsync(Exception exception)
		{
			Console.WriteLine("Disconnected!");
			return base.OnDisconnectedAsync(exception);
		}

		public async Task CreateAndJoinGroupAsync(string groupName)
		{
			await roomService.CreateRoom(new RoomDTO() { Name = groupName });
			Console.WriteLine($"Room {groupName} created.");
			await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

			await Clients.Caller.SendAsync("roomCreated");
		}

		public async Task JoinGroupAsync(string groupName)
		{
			Console.WriteLine($"Join group {groupName}");
			
			await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
			await Clients.Caller.SendAsync("joinedToTheRoom");
		}

		public Task SendMessageToGroupAsync(string groupName, string message)
		{
			return Clients.Group(groupName).SendAsync("receiveMessage", message);
		}
	}
}
