using System.Collections.Generic;

namespace Ommi.Business.DB.Entities
{
	public class BoardState
	{
		public string Id { get; set; }
		public int Volume { get; set; }
		public int TempoBPM { get; set; }
		public int NumberOfSteps { get; set; }
		
		public List<Track> Tracks { get; set; } = new List<Track>();

		public string RoomId { get; set; }
		public Room Room { get; set; }
	}
}
