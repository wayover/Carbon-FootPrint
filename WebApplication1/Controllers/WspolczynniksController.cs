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
    public class WspolczynniksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wspolczynniks
        public ActionResult Index()
        {
            var wspolczynniks = db.Wspolczynniks.Include(w => w.Wspolczynnik_Nazwa).Include(w => w.Zrodlo);
            return View(wspolczynniks.ToList());
        }

        // GET: Wspolczynniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wspolczynnik wspolczynnik = db.Wspolczynniks.Find(id);
            if (wspolczynnik == null)
            {
                return HttpNotFound();
            }
            return View(wspolczynnik);
        }

        // GET: Wspolczynniks/Create
        public ActionResult Create()
        {
            ViewBag.Wspolczynnik_NazwaID = new SelectList(db.współczynnik_Nazwas, "Id", "Nazwa");
            ViewBag.ZrodloID = new SelectList(db.Zrodlos, "Id", "Doi");
            return View();
        }

        // POST: Wspolczynniks/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Wspolczynnik_NazwaID,ZrodloID,Wartosc,Niepewnosc")] Wspolczynnik wspolczynnik)
        {
            if (ModelState.IsValid)
            {
                db.Wspolczynniks.Add(wspolczynnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Wspolczynnik_NazwaID = new SelectList(db.współczynnik_Nazwas, "Id", "Nazwa", wspolczynnik.Wspolczynnik_NazwaID);
            ViewBag.ZrodloID = new SelectList(db.Zrodlos, "Id", "Doi", wspolczynnik.ZrodloID);
            return View(wspolczynnik);
        }

        // GET: Wspolczynniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wspolczynnik wspolczynnik = db.Wspolczynniks.Find(id);
            if (wspolczynnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.Wspolczynnik_NazwaID = new SelectList(db.współczynnik_Nazwas, "Id", "Nazwa", wspolczynnik.Wspolczynnik_NazwaID);
            ViewBag.ZrodloID = new SelectList(db.Zrodlos, "Id", "Doi", wspolczynnik.ZrodloID);
            return View(wspolczynnik);
        }

        // POST: Wspolczynniks/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Wspolczynnik_NazwaID,ZrodloID,Wartosc,Niepewnosc")] Wspolczynnik wspolczynnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wspolczynnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Wspolczynnik_NazwaID = new SelectList(db.współczynnik_Nazwas, "Id", "Nazwa", wspolczynnik.Wspolczynnik_NazwaID);
            ViewBag.ZrodloID = new SelectList(db.Zrodlos, "Id", "Doi", wspolczynnik.ZrodloID);
            return View(wspolczynnik);
        }

        // GET: Wspolczynniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wspolczynnik wspolczynnik = db.Wspolczynniks.Find(id);
            if (wspolczynnik == null)
            {
                return HttpNotFound();
            }
            return View(wspolczynnik);
        }

        // POST: Wspolczynniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wspolczynnik wspolczynnik = db.Wspolczynniks.Find(id);
            db.Wspolczynniks.Remove(wspolczynnik);
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
