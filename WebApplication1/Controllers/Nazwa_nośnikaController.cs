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
    public class Nazwa_nośnikaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Nazwa_nośnika
        public ActionResult Index()
        {
            return View(db.Nazwa_Nośnikas.ToList());
        }

        // GET: Nazwa_nośnika/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nazwa_nośnika nazwa_nośnika = db.Nazwa_Nośnikas.Find(id);
            if (nazwa_nośnika == null)
            {
                return HttpNotFound();
            }
            return View(nazwa_nośnika);
        }

        // GET: Nazwa_nośnika/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nazwa_nośnika/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nosnik,Kod_GUS")] Nazwa_nośnika nazwa_nośnika)
        {
            if (ModelState.IsValid)
            {
                db.Nazwa_Nośnikas.Add(nazwa_nośnika);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nazwa_nośnika);
        }

        // GET: Nazwa_nośnika/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nazwa_nośnika nazwa_nośnika = db.Nazwa_Nośnikas.Find(id);
            if (nazwa_nośnika == null)
            {
                return HttpNotFound();
            }
            return View(nazwa_nośnika);
        }

        // POST: Nazwa_nośnika/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nosnik,Kod_GUS")] Nazwa_nośnika nazwa_nośnika)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nazwa_nośnika).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nazwa_nośnika);
        }

        // GET: Nazwa_nośnika/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nazwa_nośnika nazwa_nośnika = db.Nazwa_Nośnikas.Find(id);
            if (nazwa_nośnika == null)
            {
                return HttpNotFound();
            }
            return View(nazwa_nośnika);
        }

        // POST: Nazwa_nośnika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nazwa_nośnika nazwa_nośnika = db.Nazwa_Nośnikas.Find(id);
            db.Nazwa_Nośnikas.Remove(nazwa_nośnika);
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
