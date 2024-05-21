﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Account
{
	public class RegisterDto
	{
		[Required]
		public required string UserName { get; set; }
		[Required]
		[EmailAddress]
		public required string Email { get; set; }
		[Required]
		public required string Password { get; set; }
	}
}
