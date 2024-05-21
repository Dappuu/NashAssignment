using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Account
{
	public class NewUserDto
	{
		public required string UserName { get; set; }
		public required string Email { get; set; }
		public required string Token { get; set; }
	}
}
