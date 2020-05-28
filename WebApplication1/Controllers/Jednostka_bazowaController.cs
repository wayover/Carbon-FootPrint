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
    public class Jednostka_bazowaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jednostka_bazowa
        public ActionResult Index()
        {
            return View(db.Jednostka_Bazowas.ToList());
        }

        // GET: Jednostka_bazowa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jednostka_bazowa jednostka_bazowa = db.Jednostka_Bazowas.Find(id);
            if (jednostka_bazowa == null)
            {
                return HttpNotFound();
            }
            return View(jednostka_bazowa);
        }

        // GET: Jednostka_bazowa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jednostka_bazowa/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Skrot")] Jednostka_bazowa jednostka_bazowa)
        {
            if (ModelState.IsValid)
            {
                db.Jednostka_Bazowas.Add(jednostka_bazowa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jednostka_bazowa);
        }

        // GET: Jednostka_bazowa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jednostka_bazowa jednostka_bazowa = db.Jednostka_Bazowas.Find(id);
            if (jednostka_bazowa == null)
            {
                return HttpNotFound();
            }
            return View(jednostka_bazowa);
        }

        // POST: Jednostka_bazowa/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Skrot")] Jednostka_bazowa jednostka_bazowa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jednostka_bazowa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jednostka_bazowa);
        }

        // GET: Jednostka_bazowa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jednostka_bazowa jednostka_bazowa = db.Jednostka_Bazowas.Find(id);
            if (jednostka_bazowa == null)
            {
                return HttpNotFound();
            }
            return View(jednostka_bazowa);
        }

        // POST: Jednostka_bazowa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jednostka_bazowa jednostka_bazowa = db.Jednostka_Bazowas.Find(id);
            db.Jednostka_Bazowas.Remove(jednostka_bazowa);
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
