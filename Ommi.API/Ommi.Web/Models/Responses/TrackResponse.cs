using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ommi.Web.Models.Responses
{
	public class TrackResponse
	{
		public string Id { get; set; }
		public List<bool> Steps { get; set; } = new List<bool>();
		public string InstrumentName { get; set; }
		public int Volume { get; set; }
	}
}
