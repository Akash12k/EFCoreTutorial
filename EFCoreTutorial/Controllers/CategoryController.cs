using EFCoreTutorial.Models;
using EFCoreTutorial.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTutorial.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DatabaseContext _ctx;
        public CategoryController(DatabaseContext ctx)
        {
                _ctx = ctx;
        }
        public IActionResult Add()
        {
            try
            {
                var category = new Category
                {
                    Name = "Category 1"
                };
                _ctx.Category.Add(category);
                _ctx.SaveChanges();//For Reflecting Changes in a Database
                return Content("Saved Successfully");
            }
            catch (Exception ex) { 
            return Content(ex.Message);
            }
        }

        public IActionResult Update()
        {
            try
            {
                var category = new Category
                {
                    Id = 4,
                    Name = "Category 8"
                }; 
                _ctx.Category.Update(category);
                _ctx.SaveChanges();//For Reflecting Changes in a Database
                return Content("Saved Successfully");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }


        public IActionResult GetById(int id) {
            var category = _ctx.Category.Find(id);
            return Json(category);
        }
        public IActionResult GetAll(int id)
        {

            var categories = _ctx.Category.ToList();
            return Json(categories);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var Category = _ctx.Category.Find(id);
                if (Category == null)
                    return Content("error");
                _ctx.Category.Remove(Category);
                _ctx.SaveChanges();
                return Content("Deleted");
            }
            catch (Exception ex) { 
            return Content(ex.Message);
            }
           

        }

        public IActionResult GetProduct()
        {
            
                var products = (from p in _ctx.Product
                                join c in _ctx.Category
                                on p.CategoryId equals c.Id
                                select new
                                {
                                    Id = p.Id,
                                    ProductName = p.ProductName,
                                    CategoryId = p.CategoryId,
                                    Cost = p.Cost,
                                    CategoryName = c.Name
                                }).ToList();

                return Json(products);
            
        }


    }
}
