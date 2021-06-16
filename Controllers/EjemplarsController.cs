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
    public class EjemplarsController : Controller
    {
        private BIBLIOTECA db = new BIBLIOTECA();

        // GET: Ejemplars
        public ActionResult Index()
        {
            return View(db.Ejemplars.ToList());
        }

        // GET: Ejemplars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplar ejemplar = db.Ejemplars.Find(id);
            if (ejemplar == null)
            {
                return HttpNotFound();
            }
            return View(ejemplar);
        }

        // GET: Ejemplars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejemplars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEjemplar,ISBN,descripcionEjem,estatus")] Ejemplar ejemplar)
        {
            if (ModelState.IsValid)
            {
                db.Ejemplars.Add(ejemplar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ejemplar);
        }

        // GET: Ejemplars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplar ejemplar = db.Ejemplars.Find(id);
            if (ejemplar == null)
            {
                return HttpNotFound();
            }
            return View(ejemplar);
        }

        // POST: Ejemplars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEjemplar,ISBN,descripcionEjem,estatus")] Ejemplar ejemplar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ejemplar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ejemplar);
        }

        // GET: Ejemplars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplar ejemplar = db.Ejemplars.Find(id);
            if (ejemplar == null)
            {
                return HttpNotFound();
            }
            return View(ejemplar);
        }

        // POST: Ejemplars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ejemplar ejemplar = db.Ejemplars.Find(id);
            db.Ejemplars.Remove(ejemplar);
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
