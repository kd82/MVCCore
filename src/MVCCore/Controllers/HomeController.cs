using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCoreApplication.Entities;
using MvcCoreApplication.Services;
using MvcCoreApplication.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcCoreApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;

        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();

            return View(model);
        }


        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant.Name = model.Name;
                newRestaurant = _restaurantData.Add(newRestaurant);
                _restaurantData.commit();
                return RedirectToAction("Details", new { id = newRestaurant.Id });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantEditViewModel model)
        {
            var newRestaurant = _restaurantData.Get(id);
            if (ModelState.IsValid)
            {
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant.Name = model.Name;
                _restaurantData.commit();
                return RedirectToAction("Details", new { id = newRestaurant.Id });
            }
            return View(newRestaurant);
        }
    }
}
