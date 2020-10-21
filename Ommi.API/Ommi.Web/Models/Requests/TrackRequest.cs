using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ommi.Web.Models.Requests
{
	public class TrackRequest
	{
		public string Id { get; set; }
		public List<bool> Steps { get; set; } = new List<bool>();
		public string InstrumentName { get; set; }
		public int Volume { get; set; }
		public string SoundName { get; set; }

		public string BoardStateId { get; set; }
	}
}
