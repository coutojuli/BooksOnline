using BooksOnline.Common;
using BooksOnline.DAL;
using BooksOnline.Helpers;
using BooksOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BooksOnline.Controllers
{
    public class HomeController : Controller
    {
        private BookContext db = new BookContext();
        
        public ActionResult Home()
        {
            int num;
            List<int> listR = new List<int>();
            List<int> listB = new List<int>();
            Random random = new Random();

            var books = (from b in db.Books
                         where b.Availability == "Available"
                         select b);

            var count = books.ToList().Count();
            for (int i = 0; i < 8; i++)
            {
                do
                {
                    num = random.Next(1, count);
                    if (!(listR.Contains(num)))
                    {
                        listR.Add(num);
                        break;
                    }
                } while (true);  
            }
            for (int j = 0; j < 6; j++)
            {
                do
                {
                    num = random.Next(1, count);
                    if (!(listB.Contains(num)))
                    {
                        listB.Add(num);
                        break;
                    }
                } while (true);
            }

            ViewBag.RandomReserve = listR;
            ViewBag.RandomBuy = listB;

            var pics = from c in db.Pictures
                       select c;
            List<string> listr = new List<string>() { "Store Choice", "Week", "Month", "Year", "Decade" };
            var res = from r in db.Recommendations
                      select r;
            res = res.Where(b => listr.Contains(b.Category));


            ViewBag.Recommendations = res.ToList();
            ViewBag.Pictures = pics.ToList();
            return View("~/Views/Home/Home.cshtml", books);
        }
        
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //GET: Register
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == user.Email);
                if (check == null)
                {
                    user.Password = Password.GetHashValue(user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists. Please choose another email.";
                    return View();
                }


            }
            return View();
        }
        //GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            
            if (ModelState.IsValid)
            {
                var p = Password.GetHashValue(password);
                var user = db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(p)).ToList();
                if (user.Count() > 0)
                {
                    //Generate Session for that user
                    Session["FullName"] = user.FirstOrDefault().FirstName + " " + user.FirstOrDefault().LastName;
                    Session["Email"] = user.FirstOrDefault().Email;
                    Session["Role"] = user.FirstOrDefault().Role;
                    Session["id"] = user.FirstOrDefault().id;
                    //Session["dob"] = user.FirstOrDefault().DOB;
                    //Session["phone"] = user.FirstOrDefault().Phone;
                   // Session["address"] = user.FirstOrDefault().Address;
                    return RedirectToAction("Home");
                }
                else
                {
                    ViewBag.error = "Login failed. Please try again.";
                    return View();
                }
            }
            return View();
        }


        //GET: Logout
        public ActionResult Logout()
        {
            //In order to logout remove session
            Session.Clear();
            return RedirectToAction("Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}