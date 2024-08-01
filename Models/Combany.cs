using System.ComponentModel.DataAnnotations;

namespace car_web.Models
{
	public class Combany
	{
		[Key]
        [Required]

        public int Id { get; set; }
		[Required]
		public string Name { get; set; }

	}
}
