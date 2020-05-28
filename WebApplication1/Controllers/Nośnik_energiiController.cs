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
    public class Nośnik_energiiController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Nośnik_energii
        public ActionResult Index()
        {
            var nośnik_Energiis = db.Nośnik_Energiis.Include(n => n.Jednostka).Include(n => n.Nazwa_Nośnika);
            return View(nośnik_Energiis.ToList());
        }

        // GET: Nośnik_energii/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nośnik_energii nośnik_energii = db.Nośnik_Energiis.Find(id);
            if (nośnik_energii == null)
            {
                return HttpNotFound();
            }
            return View(nośnik_energii);
        }

        // GET: Nośnik_energii/Create
        public ActionResult Create()
        {
            ViewBag.JednostkaID = new SelectList(db.Jednostkas, "Id", "Nazwa");
            ViewBag.Nazwa_nośnikaID = new SelectList(db.Nazwa_Nośnikas, "Id", "Nosnik");
            return View();
        }

        // POST: Nośnik_energii/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa_nośnikaID,Nazwa,EqivCO2,JednostkaID,NCV,WE")] Nośnik_energii nośnik_energii)
        {
            if (ModelState.IsValid)
            {
                db.Nośnik_Energiis.Add(nośnik_energii);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JednostkaID = new SelectList(db.Jednostkas, "Id", "Nazwa", nośnik_energii.JednostkaID);
            ViewBag.Nazwa_nośnikaID = new SelectList(db.Nazwa_Nośnikas, "Id", "Nosnik", nośnik_energii.Nazwa_nośnikaID);
            return View(nośnik_energii);
        }

        // GET: Nośnik_energii/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nośnik_energii nośnik_energii = db.Nośnik_Energiis.Find(id);
            if (nośnik_energii == null)
            {
                return HttpNotFound();
            }
            ViewBag.JednostkaID = new SelectList(db.Jednostkas, "Id", "Nazwa", nośnik_energii.JednostkaID);
            ViewBag.Nazwa_nośnikaID = new SelectList(db.Nazwa_Nośnikas, "Id", "Nosnik", nośnik_energii.Nazwa_nośnikaID);
            return View(nośnik_energii);
        }

        // POST: Nośnik_energii/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa_nośnikaID,Nazwa,EqivCO2,JednostkaID,NCV,WE")] Nośnik_energii nośnik_energii)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nośnik_energii).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JednostkaID = new SelectList(db.Jednostkas, "Id", "Nazwa", nośnik_energii.JednostkaID);
            ViewBag.Nazwa_nośnikaID = new SelectList(db.Nazwa_Nośnikas, "Id", "Nosnik", nośnik_energii.Nazwa_nośnikaID);
            return View(nośnik_energii);
        }

        // GET: Nośnik_energii/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nośnik_energii nośnik_energii = db.Nośnik_Energiis.Find(id);
            if (nośnik_energii == null)
            {
                return HttpNotFound();
            }
            return View(nośnik_energii);
        }

        // POST: Nośnik_energii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nośnik_energii nośnik_energii = db.Nośnik_Energiis.Find(id);
            db.Nośnik_Energiis.Remove(nośnik_energii);
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
