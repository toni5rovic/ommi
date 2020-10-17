using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ommi.Web.Models.Requests
{
	public class RegisterRequest
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
	}
}
