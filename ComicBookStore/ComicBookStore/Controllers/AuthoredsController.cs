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
    public class AuthoredsController : Controller
    {
        private ComicBookStoreContext db = new ComicBookStoreContext();

        // GET: Authoreds
        public ActionResult Index()
        {
            var authoreds = db.Authoreds.Include(a => a.ComicBook).Include(a => a.Writer);
            return View(authoreds.ToList());
        }

        // GET: Authoreds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authored authored = db.Authoreds.Find(id);
            if (authored == null)
            {
                return HttpNotFound();
            }
            return View(authored);
        }

        // GET: Authoreds/Create
        public ActionResult Create()
        {
            ViewBag.ComicBookComicBookId = new SelectList(db.ComicBooks, "ComicBookId", "Title");
            ViewBag.WriterWriterId = new SelectList(db.Writers, "WriterId", "Name");
            return View();
        }

        // POST: Authoreds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthoredId,WriterId,ComicBookId,WriterWriterId,ComicBookComicBookId")] Authored authored)
        {
            if (ModelState.IsValid)
            {
                db.Authoreds.Add(authored);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComicBookComicBookId = new SelectList(db.ComicBooks, "ComicBookId", "Title", authored.ComicBookComicBookId);
            ViewBag.WriterWriterId = new SelectList(db.Writers, "WriterId", "Name", authored.WriterWriterId);
            return View(authored);
        }

        // GET: Authoreds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authored authored = db.Authoreds.Find(id);
            if (authored == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComicBookComicBookId = new SelectList(db.ComicBooks, "ComicBookId", "Title", authored.ComicBookComicBookId);
            ViewBag.WriterWriterId = new SelectList(db.Writers, "WriterId", "Name", authored.WriterWriterId);
            return View(authored);
        }

        // POST: Authoreds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthoredId,WriterId,ComicBookId,WriterWriterId,ComicBookComicBookId")] Authored authored)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authored).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComicBookComicBookId = new SelectList(db.ComicBooks, "ComicBookId", "Title", authored.ComicBookComicBookId);
            ViewBag.WriterWriterId = new SelectList(db.Writers, "WriterId", "Name", authored.WriterWriterId);
            return View(authored);
        }

        // GET: Authoreds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authored authored = db.Authoreds.Find(id);
            if (authored == null)
            {
                return HttpNotFound();
            }
            return View(authored);
        }

        // POST: Authoreds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Authored authored = db.Authoreds.Find(id);
            db.Authoreds.Remove(authored);
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
