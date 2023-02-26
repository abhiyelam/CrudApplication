using CrudApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class CategoryController : Controller
    {
        CategoryCrud crud;
        private readonly IConfiguration configuration;
        public CategoryController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new CategoryCrud(this.configuration);
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var list = crud.GetAllCategory();
            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var ct = crud.GetCategoryById(id);
            return View(ct);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category ct)
        {
            try
            {
                int result = crud.AddCategory(ct);
                if(result == 1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var ct=crud.GetCategoryById(id);
            return View(ct);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category ct)
        {
            try
            {
                int result=crud.UpdateCategory(ct);
                if(result == 1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var ct= crud.GetCategoryById(id);
            return View(ct);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result= crud.DeleteCategory(id);
                if(result == 1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
