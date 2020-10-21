namespace Ommi.Business.DB.Entities
{
	public class Room
	{
		public string Id { get; set; }
		public string Name { get; set; }

		public BoardState BoardState { get; set; }
		public string BoardStateId { get; set; }
	}
}
