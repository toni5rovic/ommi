namespace Ommi.Business.DB.Entities
{
	public class Track
	{
		public string Id { get; set; }
		public string Steps { get; set; }
		public string InstrumentName { get; set; }
		public string SoundName { get; set; }
		public int Volume { get; set; }

		public string BoardStateId { get; set; }
		public BoardState BoardState { get; set; }
	}
}
