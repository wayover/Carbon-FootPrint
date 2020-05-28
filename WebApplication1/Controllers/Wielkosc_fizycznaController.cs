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
    public class Wielkosc_fizycznaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wielkosc_fizyczna
        public ActionResult Index()
        {
            var wielkosc_Fizycznas = db.Wielkosc_Fizycznas.Include(w => w.Jednostka_Bazowa);
            return View(wielkosc_Fizycznas.ToList());
        }

        // GET: Wielkosc_fizyczna/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wielkosc_fizyczna wielkosc_fizyczna = db.Wielkosc_Fizycznas.Find(id);
            if (wielkosc_fizyczna == null)
            {
                return HttpNotFound();
            }
            return View(wielkosc_fizyczna);
        }

        // GET: Wielkosc_fizyczna/Create
        public ActionResult Create()
        {
            ViewBag.Jednostka_bazowaID = new SelectList(db.Jednostka_Bazowas, "Id", "Nazwa");
            return View();
        }

        // POST: Wielkosc_fizyczna/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Jednostka_bazowaID")] Wielkosc_fizyczna wielkosc_fizyczna)
        {
            if (ModelState.IsValid)
            {
                db.Wielkosc_Fizycznas.Add(wielkosc_fizyczna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Jednostka_bazowaID = new SelectList(db.Jednostka_Bazowas, "Id", "Nazwa", wielkosc_fizyczna.Jednostka_bazowaID);
            return View(wielkosc_fizyczna);
        }

        // GET: Wielkosc_fizyczna/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wielkosc_fizyczna wielkosc_fizyczna = db.Wielkosc_Fizycznas.Find(id);
            if (wielkosc_fizyczna == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jednostka_bazowaID = new SelectList(db.Jednostka_Bazowas, "Id", "Nazwa", wielkosc_fizyczna.Jednostka_bazowaID);
            return View(wielkosc_fizyczna);
        }

        // POST: Wielkosc_fizyczna/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Jednostka_bazowaID")] Wielkosc_fizyczna wielkosc_fizyczna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wielkosc_fizyczna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Jednostka_bazowaID = new SelectList(db.Jednostka_Bazowas, "Id", "Nazwa", wielkosc_fizyczna.Jednostka_bazowaID);
            return View(wielkosc_fizyczna);
        }

        // GET: Wielkosc_fizyczna/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wielkosc_fizyczna wielkosc_fizyczna = db.Wielkosc_Fizycznas.Find(id);
            if (wielkosc_fizyczna == null)
            {
                return HttpNotFound();
            }
            return View(wielkosc_fizyczna);
        }

        // POST: Wielkosc_fizyczna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wielkosc_fizyczna wielkosc_fizyczna = db.Wielkosc_Fizycznas.Find(id);
            db.Wielkosc_Fizycznas.Remove(wielkosc_fizyczna);
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
