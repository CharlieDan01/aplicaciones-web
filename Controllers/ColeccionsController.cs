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
    public class ColeccionsController : Controller
    {
        private BIBLIOTECA db = new BIBLIOTECA();

        // GET: Coleccions
        public ActionResult Index()
        {
            return View(db.Coleccions.ToList());
        }

        // GET: Coleccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coleccion coleccion = db.Coleccions.Find(id);
            if (coleccion == null)
            {
                return HttpNotFound();
            }
            return View(coleccion);
        }

        // GET: Coleccions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coleccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idColeccion,descripcion")] Coleccion coleccion)
        {
            if (ModelState.IsValid)
            {
                db.Coleccions.Add(coleccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coleccion);
        }

        // GET: Coleccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coleccion coleccion = db.Coleccions.Find(id);
            if (coleccion == null)
            {
                return HttpNotFound();
            }
            return View(coleccion);
        }

        // POST: Coleccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idColeccion,descripcion")] Coleccion coleccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coleccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coleccion);
        }

        // GET: Coleccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coleccion coleccion = db.Coleccions.Find(id);
            if (coleccion == null)
            {
                return HttpNotFound();
            }
            return View(coleccion);
        }

        // POST: Coleccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coleccion coleccion = db.Coleccions.Find(id);
            db.Coleccions.Remove(coleccion);
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
