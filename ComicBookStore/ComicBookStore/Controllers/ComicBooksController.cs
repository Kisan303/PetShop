using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComicBookStore.Data;
using ComicBookStore.Models;

namespace ComicBookStore.Controllers
{
    public class ComicBooksController : Controller
    {
        private ComicBookStoreContext db = new ComicBookStoreContext();

        // GET: ComicBooks
        public ActionResult Index()
        {
            var comicBooks = db.ComicBooks.Include(c => c.Publisher);
            return View(comicBooks.ToList());
        }

        // GET: ComicBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicBook comicBook = db.ComicBooks.Find(id);
            if (comicBook == null)
            {
                return HttpNotFound();
            }
            return View(comicBook);
        }

        // GET: ComicBooks/Create
        public ActionResult Create()
        {
            ViewBag.PublisherPublisherId = new SelectList(db.Publishers, "PublisherId", "Name");
            return View();
        }

        // POST: ComicBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComicBookId,Title,Published,PublisherPublisherId")] ComicBook comicBook)
        {
            if (ModelState.IsValid)
            {
                db.ComicBooks.Add(comicBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PublisherPublisherId = new SelectList(db.Publishers, "PublisherId", "Name", comicBook.PublisherPublisherId);
            return View(comicBook);
        }

        // GET: ComicBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicBook comicBook = db.ComicBooks.Find(id);
            if (comicBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.PublisherPublisherId = new SelectList(db.Publishers, "PublisherId", "Name", comicBook.PublisherPublisherId);
            return View(comicBook);
        }

        // POST: ComicBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComicBookId,Title,Published,PublisherPublisherId")] ComicBook comicBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comicBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PublisherPublisherId = new SelectList(db.Publishers, "PublisherId", "Name", comicBook.PublisherPublisherId);
            return View(comicBook);
        }

        // GET: ComicBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComicBook comicBook = db.ComicBooks.Find(id);
            if (comicBook == null)
            {
                return HttpNotFound();
            }
            return View(comicBook);
        }

        // POST: ComicBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComicBook comicBook = db.ComicBooks.Find(id);
            db.ComicBooks.Remove(comicBook);
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
    }
}
