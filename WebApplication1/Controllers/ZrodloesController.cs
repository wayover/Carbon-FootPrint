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
    public class ZrodloesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Zrodloes
        public ActionResult Index()
        {
            return View(db.Zrodlos.ToList());
        }

        // GET: Zrodloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zrodlo zrodlo = db.Zrodlos.Find(id);
            if (zrodlo == null)
            {
                return HttpNotFound();
            }
            return View(zrodlo);
        }

        // GET: Zrodloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zrodloes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,Doi,Opis")] Zrodlo zrodlo)
        {
            if (ModelState.IsValid)
            {
                db.Zrodlos.Add(zrodlo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zrodlo);
        }

        // GET: Zrodloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zrodlo zrodlo = db.Zrodlos.Find(id);
            if (zrodlo == null)
            {
                return HttpNotFound();
            }
            return View(zrodlo);
        }

        // POST: Zrodloes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,Doi,Opis")] Zrodlo zrodlo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zrodlo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zrodlo);
        }

        // GET: Zrodloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zrodlo zrodlo = db.Zrodlos.Find(id);
            if (zrodlo == null)
            {
                return HttpNotFound();
            }
            return View(zrodlo);
        }

        // POST: Zrodloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zrodlo zrodlo = db.Zrodlos.Find(id);
            db.Zrodlos.Remove(zrodlo);
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
