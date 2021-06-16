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
    public class SubclasificacionsController : Controller
    {
        private BIBLIOTECA db = new BIBLIOTECA();

        // GET: Subclasificacions
        public ActionResult Index()
        {
            return View(db.Subclasificacions.ToList());
        }

        // GET: Subclasificacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subclasificacion subclasificacion = db.Subclasificacions.Find(id);
            if (subclasificacion == null)
            {
                return HttpNotFound();
            }
            return View(subclasificacion);
        }

        // GET: Subclasificacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subclasificacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSubclasficacion,nombre,descripcion,estatus")] Subclasificacion subclasificacion)
        {
            if (ModelState.IsValid)
            {
                db.Subclasificacions.Add(subclasificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subclasificacion);
        }

        // GET: Subclasificacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subclasificacion subclasificacion = db.Subclasificacions.Find(id);
            if (subclasificacion == null)
            {
                return HttpNotFound();
            }
            return View(subclasificacion);
        }

        // POST: Subclasificacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSubclasficacion,nombre,descripcion,estatus")] Subclasificacion subclasificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subclasificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subclasificacion);
        }

        // GET: Subclasificacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subclasificacion subclasificacion = db.Subclasificacions.Find(id);
            if (subclasificacion == null)
            {
                return HttpNotFound();
            }
            return View(subclasificacion);
        }

        // POST: Subclasificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subclasificacion subclasificacion = db.Subclasificacions.Find(id);
            db.Subclasificacions.Remove(subclasificacion);
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
