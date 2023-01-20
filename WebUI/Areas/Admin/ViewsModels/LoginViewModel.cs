using System;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.ViewsModels
{
	public class LoginViewModel
	{
		[Required]
		public string? UsernameOrEmail { get; set; }
		[Required, DataType(DataType.Password)]
		public string? Password { get; set; }
		public bool RememberMe { get; set; }
	}
}

