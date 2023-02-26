using CrudApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class StudentController : Controller
    {
        StudentCrud crud;
        private readonly IConfiguration configuration;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new StudentCrud(this.configuration);
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var list = crud.GetAllStudent();
            return View(list);
            
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var s = crud.GetStudentById(id);
            return View(s);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student s)
        {
            try
            {
                int result = crud.AddStudent(s);
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

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var s = crud.GetStudentById(id);
            return View(s);

        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student s)
        {
            try
            {
                int result = crud.UpdateStudent(s);
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var s = crud.GetStudentById(id);
            return View(s);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteStudent(id);
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
