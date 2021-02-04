using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BooksOnline.Common;
using BooksOnline.DAL;
using BooksOnline.Helpers;
using BooksOnline.Models;

namespace BooksOnline.Controllers
{
    public class BooksController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Books

        public ActionResult Home()
        {
            return View("~/Views/Home/Home.cshtml");

        }
        public ActionResult Index(string search, string filter)
        {

            var books = from b in db.Books
                        select b;

            if (!String.IsNullOrEmpty(search))
            {
                switch (filter)
                {
                    case "title":
                        books = books.Where(b => b.Title.Contains(search));
                        break;
                    case "subject":
                        books = books.Where(b => b.Subject.Contains(search));
                        break;
                    case "author":
                        books = books.Where(b => b.Author.Contains(search));
                        break;
                    case "price":
                        double number = Convert.ToDouble(search);
                        books = books.Where(b => b.Price < number);
                        break;
                    case "availability":
                        books = books.Where(b => b.Availability.Contains(search));
                        break;
                    default:
                        break;
                }
            }
            //return View(db.Books.ToList());
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,Subject,Count,Author,Price,Format,Publisher,Pubdate,Edition,Pages,Synopsis,Availability")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,Subject,Count,Author,Price,Format,Publisher,Pubdate,Edition,Pages,Synopsis,Availability")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //Wishlist

        // GET: Books/DeleteFromWishlist

        public ActionResult DeleteFromWishlist(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wishlist book = db.Wishlists.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                Wishlist wishlist = db.Wishlists.Find(id);
                db.Wishlists.Remove(wishlist);
                db.SaveChanges();
                return RedirectToAction("Wishlist");
            }
        }
        // POST: Books/DeleteFromWishlist/5
        [HttpPost, ActionName("DeleteFromWishlist")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFromWishlistConfirmed(int id)
        {
            Wishlist book = db.Wishlists.Find(id);
            db.Wishlists.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Wishlist");
        }

        // GET: Wishlist
        public ActionResult Wishlist()
        {
            var uid = Convert.ToInt32(Session["id"]);
            if (uid.ToString() != null)
            {
                var wishlist = db.Wishlists.Where(s => s.UserID.Equals(uid)).ToList();

                var c = (from a in db.Books
                         join b in db.Wishlists
                         on a.ID equals b.BookID
                         where b.UserID == uid
                         select a);
                List<Book> data = c.ToList();
                ViewBag.Data = data;
                return View("Wishlist", wishlist);
            }
            else
            {
                ViewBag.error = "Unable to show Wishlist. Please try Again";
                return RedirectToAction("Home");
            }
        }

        // GET: Books/Wishlist Wishlist_Add
        public ActionResult AddToWishlist(int? bookID)
        {
            if (bookID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                if (Session["id"] == null)
                {
                    return RedirectToAction("Login", "Users");
                }
                else
                {
                    var uid = Session["id"].ToString();
                    int userid = Convert.ToInt32(uid);
                    int bookid = Convert.ToInt32(bookID);
                    Wishlist book = new Wishlist();
                    book.BookID = bookid;
                    book.UserID = userid;

                    var c = (from a in db.Books
                             where a.ID == bookID
                             select a);
                    List<Book> data = c.ToList();
                    ViewBag.Data = data;

                    var wishlist = db.Wishlists.FirstOrDefault(s => s.UserID.Equals(userid) && s.BookID.Equals(bookid));
                    if (wishlist == null)
                    {
                        return View(book);
                    }
                    else
                    {
                        ViewBag.error = "Book already in your wishlist";
                        return RedirectToAction("AddToWishlist", book);
                    }
                }
            }
        }

        // POST: Books/Wishlist_Add

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToWishlist([Bind(Include = "ID,BookID,UserID,Notification")] Wishlist book)
        {

            if (ModelState.IsValid)
            {

                db.Wishlists.Add(book);
                db.SaveChanges();
                return RedirectToAction("Wishlist");

            }
            else
            {
                ViewBag.Error = "Error adding book to wishlist";

            }
            return View(book);
        }
        public ActionResult WishlistAlert(int ? sucess)
        {
            if (sucess != null)
            {
                ViewBag.Message = "Wishlist emails were sent to users sucessfully.";
            }           
                var wishlist = from w in db.Wishlists
                               where w.Notification == "Yes"
                               select w;
                var users = from u in db.Users
                            select u;
                ViewBag.Wishlist = wishlist.ToList();
                ViewBag.Users = users.ToList();          
            return View("WishlistAlert");
        }
        public ActionResult SendWishlistEmail()
        {
            var wishlist = from w in db.Wishlists           
                           join u in db.Users on w.UserID equals u.id
                           where w.Notification == "Yes"
                           select new { uid = u.id, email = u.Email, bookid = w.BookID };
            
            var user = from h in db.Users
                       select h;
            List<Book> list = new List<Book>();
            string uemail = "";
            foreach (var value in user.ToList())
            {
                int uid = value.id;
                foreach (var item in wishlist.ToList())
                {
                    if (item.uid.Equals(uid))
                    {
                        uemail = item.email;
                        var book = (from b in db.Books
                                    where b.ID == item.bookid && b.Availability == "Available"
                                    select b).First();
                        if (book != null)
                        {
                            list.Add(book);
                        }
                    }
                }
                var user1 = (from j in db.Users
                            where j.Email == uemail
                            select j).First();
                if (list.Count != 0)
                {
                    Email.WishlistAlert(list, user1);
                    list.Clear();
                }              
            }                
                return RedirectToAction("WishlistAlert", new { sucess = 1 });
        }
          
        }
    }



