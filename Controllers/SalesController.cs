using Microsoft.AspNetCore.Mvc;
using MVCMarketCourse.Models;
using MVCMarketCourse.ViewModels;

namespace MVCMarketCourse.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories(),
            };
            return View(salesViewModel);
        }
    }
}
