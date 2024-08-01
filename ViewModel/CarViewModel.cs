using Microsoft.AspNetCore.Mvc.Rendering;
using car_web.Models;

namespace car_web.ViewModel
{
    public class CarViewModel
    {
        public  Car car { get; set; }
        public  List<Car> cars { get; set; }

        public List<Combany> combanies { get; set; }
    }
}
