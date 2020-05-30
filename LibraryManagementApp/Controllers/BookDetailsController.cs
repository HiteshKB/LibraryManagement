using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using LibraryManagementApp.Models;

namespace LibraryManagementApp.Controllers
{
    public class BookDetailsController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: BookDetails
        public ActionResult Index()
        {
            return View(db.BookDetails.ToList());
        }

        // GET: BookDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDetails bookDetails = db.BookDetails.Find(id);
            if (bookDetails == null)
            {
                return HttpNotFound();
            }
            return View(bookDetails);
        }

        // GET: BookDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Author,ISBN,Publisher,Year")] BookDetails bookDetails)
        {
            if (ModelState.IsValid)
            {
                db.BookDetails.Add(bookDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookDetails);
        }

        // GET: BookDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDetails bookDetails = db.BookDetails.Find(id);
            if (bookDetails == null)
            {
                return HttpNotFound();
            }
            return View(bookDetails);
        }

        // POST: BookDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,ISBN,Publisher,Year")] BookDetails bookDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookDetails);
        }

        // GET: BookDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDetails bookDetails = db.BookDetails.Find(id);
            if (bookDetails == null)
            {
                return HttpNotFound();
            }
            return View(bookDetails);
        }

        // POST: BookDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookDetails bookDetails = db.BookDetails.Find(id);
            db.BookDetails.Remove(bookDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult SearchTitle(string tit)
        {
            db.BookDetails.Where(x => x.Title == tit);
            return null;
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
