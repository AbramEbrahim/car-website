using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using car_web.Data;
using car_web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using car_web.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace car_web.Controllers
{
    [Authorize]
    public class CarController(ApplicationDbContext _db) : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult ContactUs() {
            
            return View("ContactUs"); 
        
        }

		public IActionResult Search()
		{
            var cars = _db.Cars.Include(x=>x.Combany).ToList(); 
			return View(cars);
		}


	}
}
