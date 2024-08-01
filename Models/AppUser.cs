using Microsoft.AspNetCore.Identity;
namespace car_web.Models
{
	public class AppUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
