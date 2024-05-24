using BookTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookTemplate.Controllers
{
    public class HomeController : Controller
    {
        private List<Book> _Books
        {
            get
            {
                if (Session["Books"] == null)
                {
                    Session["Books"] = new List<Book>()
                    {
                        new Book() {
                            Id = 1, 
                            BookName = "malemale", 
                            Type="Tieu thuyet", 
                            Price = 100000, 
                            Date = new DateTime(), 
                            Condition = new List<string>{"No box", "rách một ít"} 
                        }
                    };
                }
                return (List<Book>)Session["Books"];
            }
            set
            {
                Session["Books"] = value;
            }
        }


        public ActionResult Index()
        {
            
            return View(_Books);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _Books.Add(book);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}