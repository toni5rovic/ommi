using System.Collections.Generic;

namespace Ommi.Business.DTOs
{
	public class BoardStateDTO
	{
		public string Id { get; set; }
		public int Volume { get; set; }
		public int TempoBPM { get; set; }
		public int NumberOfSteps { get; set; }

		public List<TrackDTO> Tracks { get; set; } = new List<TrackDTO>();

		public string RoomId { get; set; }
		public RoomDTO Room { get; set; }
	}
}
