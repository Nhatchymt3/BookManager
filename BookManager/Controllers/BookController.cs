using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        Model1 contex = new Model1();
        public ActionResult Index()
        {
            var listbook = contex.Book.ToList();
            return View(listbook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            Book book = contex.Book.SingleOrDefault(c => c.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost,ActionName("Create")]
        public ActionResult Create(Book book)
        {
            if(ModelState.IsValid)
            {
                contex.Book.Add(book);
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var db = contex.Book.FirstOrDefault(c => c.ID == id);
            return View(db);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            Book dbUpdate = contex.Book.FirstOrDefault(p => p.ID == book.ID);
            if (dbUpdate != null)
            {
                contex.Book.AddOrUpdate(book);
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
                return View();
            
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var db = contex.Book.FirstOrDefault(c => c.ID == id);
            return View(db);
        }
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            Book dbDelete = contex.Book.FirstOrDefault(p => p.ID == book.ID);
            if (dbDelete != null)
            {
                contex.Book.Remove(dbDelete);
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}