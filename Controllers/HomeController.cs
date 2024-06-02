using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
namespace MVCMarketCourse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public string Error()
        {
            return "Il y a un error ici.";
        }

        public IActionResult Edit(int id)
        {
            return View(id);
        }
    }
}
