using car_web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using car_web.ViewModel;
using car_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using car_web.Utility;

namespace car_web.Controllers
{
    [Authorize]
	public class DashBoardController : Controller
	{

        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment hosting;

        public DashBoardController(ApplicationDbContext db, IHostingEnvironment hosting)
        {

            _db = db;
            this.hosting = hosting;
        }

        #region index
        [Authorize(Roles =( RL.RoleAdmin +","+ RL.RoleEmployee))]
        public IActionResult Index()
		{
			var message = _db.contacts.ToList();
			return View(message);
		}
        #endregion

        #region add car
        [Authorize(Roles = RL.RoleAdmin  +","+ RL.RoleEmployee)]
        public IActionResult AddCar()
        {
            
            var car = new CarViewModel();

            car.combanies = _db.Combanies.ToList();
                
            return View(car);
        }

        [HttpPost]
		[Authorize(Roles = RL.RoleAdmin)]

		public IActionResult AddCar(Car car)
        {

            if (car.CarImg!=null)
            {
                string ImgFolder = Path.Combine(hosting.WebRootPath , "assets") ;
                String ImagePath = Path.Combine(ImgFolder , car.CarImg.FileName);
                car.CarImg.CopyTo(new FileStream(ImagePath, FileMode.Create));
                car.Img = car.CarImg.FileName;

            }

            _db.Cars.Add(car);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
		#endregion

		#region GetCar

		[Authorize(Roles = RL.RoleAdmin  +","+ RL.RoleEmployee)]
		 
		public IActionResult GetCar()
        {
            var car = _db.Cars.Include(p => p.Combany).ToList();
            return View(car);
        }

        #endregion

        #region DeletCar

        [Authorize(Roles = RL.RoleAdmin)]
        public IActionResult DeleteCar(int id)
        {
            Car? car = _db.Cars.Find(id);
            if (car != null)
            {
                _db.Cars.Remove(car);
                _db.SaveChanges();
                return RedirectToAction("GetCar");
            }
            return RedirectToAction("GetCar");
        }

        #endregion

        #region EditCar
        [Authorize(Roles = RL.RoleAdmin  +","+ RL.RoleEmployee)]
        public IActionResult EditCar(int? id)
        {
            CarViewModel? carv =new CarViewModel();
                 
            carv.car = _db.Cars.SingleOrDefault(p => p.Id == id);
            carv.combanies = _db.Combanies.ToList();

            return View(carv);
        }
        [HttpPost]
        public IActionResult EditCar(CarViewModel model)
        {
             
            Car? car = _db.Cars.SingleOrDefault(p => p.Id == model.car.Id);

            if (model.car.CarImg != null)
            {
                string ImgFolder = Path.Combine(hosting.WebRootPath, "assets");
                String ImagePath = Path.Combine(ImgFolder, model.car.CarImg.FileName);
                model.car.CarImg.CopyTo(new FileStream(ImagePath, FileMode.Create));
                car.Img = model.car.CarImg.FileName;

            }
            

            car.CarModel = model.car.CarModel;
            car.Price = model.car.Price;
            car.BodyStyle = model.car.BodyStyle;
            car.Name = model.car.Name;
            car.combanyId = model.car.combanyId;

            _db.Cars.Update(car);
            _db.SaveChanges();
            return RedirectToAction("Getcar");
        }
        #endregion


        #region contact

        [Authorize(Roles = RL.RoleAdmin)]

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);
            _db.contacts.Add(contact);
            _db.SaveChanges();
            return View();
        }
        #endregion




        #region car with category

        public IActionResult CarWithCompany(int id)
        {
           
            var c = _db.Cars.Where(x=> x.combanyId==id).ToList();
            var companies = _db.Combanies.ToList();
            var carwithcompany = new CarViewModel()
            {
                cars = c,
                combanies = companies,
            };
            return View(carwithcompany);
        }






		#endregion




		#region company

		#region GetCompany
		[Authorize(Roles = RL.RoleAdmin  +","+ RL.RoleEmployee)]
		public IActionResult GetCompany()
        {
            var company = _db.Combanies.ToList();
            return View(company);
        }
        #endregion


        #region DeletCompany
        [Authorize(Roles = RL.RoleAdmin )]

        public IActionResult DeleteCompany(int id)
        {
            Combany? comp = _db.Combanies.Find(id);
            if (comp != null)
            {
                _db.Combanies.Remove(comp);
                _db.SaveChanges();
                return RedirectToAction("GetCompany");
            }
            return RedirectToAction("GetCompany");
        }

		#endregion


		#region add company
		[Authorize(Roles = RL.RoleAdmin  +","+ RL.RoleEmployee) ]
		public IActionResult AddCompany()
        {
                        
            return View();
        }

        [HttpPost]

        [Authorize(Roles = RL.RoleAdmin  +","+ RL.RoleEmployee)]

        public IActionResult AddCompany(Combany comp)
        {
             
            _db.Combanies.Add(comp);
            _db.SaveChanges();
            return RedirectToAction("GetCompany");

        }
        #endregion


        #region Edit Company
        [Authorize(Roles = RL.RoleAdmin  +","+ RL.RoleEmployee)]

        public IActionResult EditCompany(int? id)
        {
            Combany? comp = new Combany();

            comp = _db.Combanies.SingleOrDefault(p => p.Id == id);

            return View(comp);
        }
        [HttpPost]
        [Authorize(Roles = RL.RoleAdmin  +","+ RL.RoleEmployee)]

        public IActionResult EditCompany(Combany company)
        {

            Combany? comp = _db.Combanies.SingleOrDefault(p => p.Id == company.Id);
 
            comp.Name = company.Name; 

            _db.Combanies.Update(comp);
            _db.SaveChanges();
            return RedirectToAction("GetCompany");
        }
        #endregion

        #endregion
    }

}
