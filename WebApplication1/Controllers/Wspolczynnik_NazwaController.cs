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
    public class Wspolczynnik_NazwaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wspolczynnik_Nazwa
        public ActionResult Index()
        {
            return View(db.współczynnik_Nazwas.ToList());
        }

        // GET: Wspolczynnik_Nazwa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wspolczynnik_Nazwa wspolczynnik_Nazwa = db.współczynnik_Nazwas.Find(id);
            if (wspolczynnik_Nazwa == null)
            {
                return HttpNotFound();
            }
            return View(wspolczynnik_Nazwa);
        }

        // GET: Wspolczynnik_Nazwa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wspolczynnik_Nazwa/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Skrot,Opis")] Wspolczynnik_Nazwa wspolczynnik_Nazwa)
        {
            if (ModelState.IsValid)
            {
                db.współczynnik_Nazwas.Add(wspolczynnik_Nazwa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wspolczynnik_Nazwa);
        }

        // GET: Wspolczynnik_Nazwa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wspolczynnik_Nazwa wspolczynnik_Nazwa = db.współczynnik_Nazwas.Find(id);
            if (wspolczynnik_Nazwa == null)
            {
                return HttpNotFound();
            }
            return View(wspolczynnik_Nazwa);
        }

        // POST: Wspolczynnik_Nazwa/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Skrot,Opis")] Wspolczynnik_Nazwa wspolczynnik_Nazwa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wspolczynnik_Nazwa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wspolczynnik_Nazwa);
        }

        // GET: Wspolczynnik_Nazwa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wspolczynnik_Nazwa wspolczynnik_Nazwa = db.współczynnik_Nazwas.Find(id);
            if (wspolczynnik_Nazwa == null)
            {
                return HttpNotFound();
            }
            return View(wspolczynnik_Nazwa);
        }

        // POST: Wspolczynnik_Nazwa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wspolczynnik_Nazwa wspolczynnik_Nazwa = db.współczynnik_Nazwas.Find(id);
            db.współczynnik_Nazwas.Remove(wspolczynnik_Nazwa);
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
