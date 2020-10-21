using System.Collections.Generic;

namespace Ommi.Business.DTOs
{
	public class TrackDTO
	{
		public string Id { get; set; }
		public List<bool> Steps { get; set; } = new List<bool>();
		public string InstrumentName { get; set; }
		public int Volume { get; set; }
		public string SoundName { get; set; }

		public string BoardStateId { get; set; }
		public BoardStateDTO BoardState { get; set; }
	}
}
