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
    public class JednostkasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jednostkas
        public ActionResult Index()
        {
            var jednostkas = db.Jednostkas.Include(j => j.Wielkosc_Fizyczna);
            return View(jednostkas.ToList());
        }

        // GET: Jednostkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jednostka jednostka = db.Jednostkas.Find(id);
            if (jednostka == null)
            {
                return HttpNotFound();
            }
            return View(jednostka);
        }

        // GET: Jednostkas/Create
        public ActionResult Create()
        {
            ViewBag.Wielkosc_fizycznaID = new SelectList(db.Wielkosc_Fizycznas, "Id", "Nazwa");
            return View();
        }

        // POST: Jednostkas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Skrot,Wielkosc_fizycznaID,Przelicznik")] Jednostka jednostka)
        {
            if (ModelState.IsValid)
            {
                db.Jednostkas.Add(jednostka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Wielkosc_fizycznaID = new SelectList(db.Wielkosc_Fizycznas, "Id", "Nazwa", jednostka.Wielkosc_fizycznaID);
            return View(jednostka);
        }

        // GET: Jednostkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jednostka jednostka = db.Jednostkas.Find(id);
            if (jednostka == null)
            {
                return HttpNotFound();
            }
            ViewBag.Wielkosc_fizycznaID = new SelectList(db.Wielkosc_Fizycznas, "Id", "Nazwa", jednostka.Wielkosc_fizycznaID);
            return View(jednostka);
        }

        // POST: Jednostkas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Skrot,Wielkosc_fizycznaID,Przelicznik")] Jednostka jednostka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jednostka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Wielkosc_fizycznaID = new SelectList(db.Wielkosc_Fizycznas, "Id", "Nazwa", jednostka.Wielkosc_fizycznaID);
            return View(jednostka);
        }

        // GET: Jednostkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jednostka jednostka = db.Jednostkas.Find(id);
            if (jednostka == null)
            {
                return HttpNotFound();
            }
            return View(jednostka);
        }

        // POST: Jednostkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jednostka jednostka = db.Jednostkas.Find(id);
            db.Jednostkas.Remove(jednostka);
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
