using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BooksOnline.DAL;
using BooksOnline.Helpers;
using BooksOnline.Models;

namespace BooksOnline.Controllers
{
    public class UsersController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Users
        public ActionResult List()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (User user)
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
                    return RedirectToAction("List","Users");
                }
                else
                {
                    ViewBag.error = "Email already exists. Please choose another email.";
                    return View();
                }

            }
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Password,ConfirmPassword,Email,Role,FirstName,LastName,DOB,Phone,Address")]User user)
        {
            if (ModelState.IsValid)
            {
                
                var previous = db.Users.FirstOrDefault(p => p.id == user.id);
                db.Entry(previous).State = EntityState.Detached;
                if (user.Email != previous.Email)
                {
                    var check = db.Users.FirstOrDefault(s => s.Email == user.Email);
                    if (check == null)
                    {
                        user.Password = Password.GetHashValue(user.Password);
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Details", "Details", user);
                    }
                    else
                    {
                        ViewBag.error = "Error editing user. Email already exists in database.";
                    }
                }
                else
                {
                    user.Password = Password.GetHashValue(user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details", user);
                }
            }
            else
            {
                ViewBag.error = "Error editing user. Please try again.";
                return View();
            }

            return View(user);

        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Logout","Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
