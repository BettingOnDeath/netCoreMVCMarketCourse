using Microsoft.AspNetCore.Mvc;
using MVCMarketCourse.Models;

namespace MVCMarketCourse.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        } 
        public IActionResult Edit(int? id)
        {
            //if (id.HasValue)
            //{
            //    return new ContentResult { Content = "null content" };
            //}   
            //return new ContentResult { Content = id.ToString() };

            //var category = new Category { CategoryId = id.HasValue?id.Value : 0 };
            ViewBag.Action = "edit";
            var category = CategoriesRepository.GetCategoryById(id.HasValue? id.Value : 0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            ViewBag.Action = "edit";
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            CategoriesRepository.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            var category = new Category();
            category.CategoryId = 1;
            return View(nameof(Add));
        }
        [HttpPost]
        public IActionResult Add([FromForm] Category category)
        {
            ViewBag.Action = "add";
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
