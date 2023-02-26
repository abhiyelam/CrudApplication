using CrudApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using.System.Data.SqlClient;
namespace CrudApplication.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentCrud crud;
        private readonly IConfiguration configuration;
        public DepartmentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new DepartmentCrud(this.configuration);
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var list = crud.DeptList();
            return View(list);
            
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var dept = crud.GetDeptById(id);
            return View(dept);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dept)
        {
            try
            {
                int result = crud.AddDept(dept);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var dept = crud.GetDeptById(id);
            return View(dept);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dept)
        {
            try
            {
                int result = crud.UpdateDept(dept);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var dept=crud.GetDeptById(id);
            return View(dept);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
