using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SurowiecsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Surowiecs
        public ActionResult Index()
        {
            var surowiecs = db.Surowiecs.Include(s => s.Wspolczynnik);
            return View(surowiecs.ToList());
        }

        // GET: Surowiecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surowiec surowiec = db.Surowiecs.Find(id);
            if (surowiec == null)
            {
                return HttpNotFound();
            }
            return View(surowiec);
        }

        // GET: Surowiecs/Create
        public ActionResult Create()
        {
            ViewBag.WspolczynnikID = new SelectList(db.Wspolczynniks, "Id", "Id");
            return View();
        }

        // POST: Surowiecs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Opis,WspolczynnikID")] Surowiec surowiec)
        {
            if (ModelState.IsValid)
            {
                db.Surowiecs.Add(surowiec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WspolczynnikID = new SelectList(db.Wspolczynniks, "Id", "Id", surowiec.WspolczynnikID);
            return View(surowiec);
        }

        // GET: Surowiecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surowiec surowiec = db.Surowiecs.Find(id);
            if (surowiec == null)
            {
                return HttpNotFound();
            }
            ViewBag.WspolczynnikID = new SelectList(db.Wspolczynniks, "Id", "Id", surowiec.WspolczynnikID);
            return View(surowiec);
        }

        // POST: Surowiecs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Opis,WspolczynnikID")] Surowiec surowiec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surowiec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WspolczynnikID = new SelectList(db.Wspolczynniks, "Id", "Id", surowiec.WspolczynnikID);
            return View(surowiec);
        }

        // GET: Surowiecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surowiec surowiec = db.Surowiecs.Find(id);
            if (surowiec == null)
            {
                return HttpNotFound();
            }
            return View(surowiec);
        }

        // POST: Surowiecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Surowiec surowiec = db.Surowiecs.Find(id);
            db.Surowiecs.Remove(surowiec);
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
