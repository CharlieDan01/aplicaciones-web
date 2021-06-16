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
    public class TipoEjemplarsController : Controller
    {
        private BIBLIOTECA db = new BIBLIOTECA();

        // GET: TipoEjemplars
        public ActionResult Index()
        {
            return View(db.TipoEjemplars.ToList());
        }

        // GET: TipoEjemplars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEjemplar tipoEjemplar = db.TipoEjemplars.Find(id);
            if (tipoEjemplar == null)
            {
                return HttpNotFound();
            }
            return View(tipoEjemplar);
        }

        // GET: TipoEjemplars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEjemplars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoEjemplar,descripcion,ImagenFile,estatus")] TipoEjemplar tipoEjemplar)
        {
            if (ModelState.IsValid)
            {
                db.TipoEjemplars.Add(tipoEjemplar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEjemplar);
        }

        // GET: TipoEjemplars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEjemplar tipoEjemplar = db.TipoEjemplars.Find(id);
            if (tipoEjemplar == null)
            {
                return HttpNotFound();
            }
            return View(tipoEjemplar);
        }

        // POST: TipoEjemplars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoEjemplar,descripcion,ImagenFile,estatus")] TipoEjemplar tipoEjemplar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEjemplar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEjemplar);
        }

        // GET: TipoEjemplars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEjemplar tipoEjemplar = db.TipoEjemplars.Find(id);
            if (tipoEjemplar == null)
            {
                return HttpNotFound();
            }
            return View(tipoEjemplar);
        }

        // POST: TipoEjemplars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEjemplar tipoEjemplar = db.TipoEjemplars.Find(id);
            db.TipoEjemplars.Remove(tipoEjemplar);
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
