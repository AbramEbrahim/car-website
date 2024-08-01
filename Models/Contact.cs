using System.ComponentModel.DataAnnotations;

namespace car_web.Models
{
	public class Contact
	{

		[Key]
		[Required]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Subject { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Message { get; set; }
	}
}
