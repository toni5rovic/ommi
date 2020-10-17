using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ommi.Web.Models.Responses
{
	public class LogInResponse
	{
		public string Username { get; set; }
		public string Token { get; set; }
	}
}
