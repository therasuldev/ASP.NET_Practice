using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
	public class AppUser:IdentityUser
	{
		public bool IsActive { get; set; }
		public string? Fullname { get; set; }
	}
}

