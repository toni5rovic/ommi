using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ommi.Web.Models.Responses
{
	public class BoardStateResponse
	{
		public string Id { get; set; }
		public int Volume { get; set; }
		public int TempoBPM { get; set; }
		public int NumberOfSteps { get; set; }

		public List<TrackResponse> Tracks { get; set; } = new List<TrackResponse>();
	}
}
