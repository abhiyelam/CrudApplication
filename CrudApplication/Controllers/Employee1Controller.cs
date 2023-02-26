using CrudApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class Employee1Controller : Controller

    {
        EmpCrud crud;
        private IConfiguration configuration;
        public Employee1Controller(IConfiguration configuration) 
        {
            this.configuration = configuration;
            crud=new EmpCrud(this.configuration);
        }
        // GET: Employee1Controller
        public ActionResult Index()
        {
            var list=crud.GetList();
            return View(list);
        }

        // GET: Employee1Controller/Details/5
        public ActionResult Details(int id)
        {
            var emp=crud.GetEmployeeById(id);
            return View(emp);
        }

        // GET: Employee1Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee1 emp)
        {
            try
            {
                int result = crud.AddEmp(emp);
                if (result == 1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Employee1Controller/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = crud.GetEmployeeById(id);
            return View(emp);
        }

        // POST: Employee1Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee1 emp)
        {
            try
            {
                int result=crud.UpdateEmployee(emp);
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

        // GET: Employee1Controller/Delete/5
        public ActionResult Delete(int id)
        {
            var emp= crud.GetEmployeeById(id);
            return View(emp);
        }

        // POST: Employee1Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result=crud.DeleteEmployee(id);
                if(result == 1)
                return RedirectToAction(nameof(Index));
                else 
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
