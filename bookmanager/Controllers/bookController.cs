using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookmanager.Models;
namespace bookmanager.Controllers
{
    public class bookController : Controller
    {
        // GET: book
        BookManagerContext context = new BookManagerContext();
        public ActionResult Listbook()
        {
            
            var listbook = context.books.ToList();
            return View(listbook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            
            book Book = context.books.SingleOrDefault(p => p.Id == id);
            if (Book == null)
            {
                return HttpNotFound();
            }
            return View(Book);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection books)
        {
            var Book = new book();
            
            Book.Title = books["Title"];
            Book.Author = books["Author"];
            Book.Description = books["Description"];
            Book.Images = books["Images"];
            Book.Price = Int32.Parse(books["Price"]);
            context.books.Add(Book);
            context.SaveChanges();
            return RedirectToAction("Listbook");
            
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var Book = context.books.Find(id);
            return View(Book);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection books,int id)
        {
            
            var Book = context.books.Find(id);
            Book.Title = books["Title"];
            Book.Author = books["Author"];
            Book.Description = books["Description"];
            Book.Images = books["Images"];
            Book.Price = Int32.Parse(books["Price"]);
            context.SaveChanges();
            return RedirectToAction("Listbook");
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            book Book = context.books.Find(id);
            return View(Book);
        }
        [HttpPost]
        public ActionResult Deletebook(int id)
        {
            book Book = context.books.Find(id);
            if (Book != null)
            {
                context.books.Remove(Book);
                context.SaveChanges();
            }
            return RedirectToAction("Listbook");
        }
    }
}