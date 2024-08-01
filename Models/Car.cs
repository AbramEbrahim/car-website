using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace car_web.Models
{
	public class Car
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string BodyStyle { get; set; }
		public string CarModel { get; set; }
		public float Price { get; set; }
		public string Img { get; set; }
		[NotMapped]
		public IFormFile CarImg { get; set; }
		public int combanyId { get; set; }
		[ForeignKey("combanyId")]
		public Combany Combany { get; set; }

	}
}
