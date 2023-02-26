using CrudApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeCrud crud;
        DepartmentCrud dcrud;
        private readonly IConfiguration configuration;
        public EmployeeController( IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new EmployeeCrud(this.configuration);
            dcrud= new DepartmentCrud(this.configuration);
        }
        // GET: EmoloyeeController
        public ActionResult Index()
        {
            var list = crud.GetAllEmployess();
            return View(list);
        }

        // GET: EmoloyeeController/Details/5
        public ActionResult Details(int id)
        {
            var emp = crud.GetEmployeeById(id);
            return View(emp);
        }

        // GET: EmoloyeeController/Create
       
        public ActionResult Create()
        {
            var deptlist=dcrud.DeptList();
           ViewBag.DeptList = deptlist;
                return View();
        }

        // POST: EmoloyeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int result = crud.AddEmployee(emp);
                if(result==1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmoloyeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var deptlist = dcrud.DeptList();
            ViewBag.DeptList = deptlist;
            var emp=crud.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmoloyeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result = crud.UpdateEmployee(emp);
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

        // GET: EmoloyeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = crud.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmoloyeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteEmployee(id);
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
    }
}
