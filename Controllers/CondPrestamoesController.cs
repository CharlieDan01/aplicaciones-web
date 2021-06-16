using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BIBLIOTECATEC.Models;

namespace BIBLIOTECATEC.Controllers
{
    public class CondPrestamoesController : Controller
    {
        private BIBLIOTECA db = new BIBLIOTECA();

        // GET: CondPrestamoes
        public ActionResult Index()
        {
            return View(db.CondPrestamoes.ToList());
        }

        // GET: CondPrestamoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondPrestamo condPrestamo = db.CondPrestamoes.Find(id);
            if (condPrestamo == null)
            {
                return HttpNotFound();
            }
            return View(condPrestamo);
        }

        // GET: CondPrestamoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondPrestamoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCondicion,limitePrestamos,limiteRenovaciones,estatus")] CondPrestamo condPrestamo)
        {
            if (ModelState.IsValid)
            {
                db.CondPrestamoes.Add(condPrestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condPrestamo);
        }

        // GET: CondPrestamoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondPrestamo condPrestamo = db.CondPrestamoes.Find(id);
            if (condPrestamo == null)
            {
                return HttpNotFound();
            }
            return View(condPrestamo);
        }

        // POST: CondPrestamoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCondicion,limitePrestamos,limiteRenovaciones,estatus")] CondPrestamo condPrestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condPrestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condPrestamo);
        }

        // GET: CondPrestamoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondPrestamo condPrestamo = db.CondPrestamoes.Find(id);
            if (condPrestamo == null)
            {
                return HttpNotFound();
            }
            return View(condPrestamo);
        }

        // POST: CondPrestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CondPrestamo condPrestamo = db.CondPrestamoes.Find(id);
            db.CondPrestamoes.Remove(condPrestamo);
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
