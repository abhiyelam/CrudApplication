using CrudApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class BookController : Controller
    {
        BookCrud crud;
        private readonly IConfiguration configuration;
        public BookController(IConfiguration configuration) 
        { 
            this.configuration=configuration;
            crud=new BookCrud(this.configuration);
        }
        // GET: BookController
        public ActionResult Index()
        {
            var list=crud.GetAllBooks();
            return View(list);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = crud.GetBookById(id);
            return View(book);
            
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                int result=crud.AddBook(book);
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

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book=crud.GetBookById(id);
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int result=crud.UpdateBook(book);
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

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book= crud.GetBookById(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result= crud.DeleteBook(id);
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
    }
}
