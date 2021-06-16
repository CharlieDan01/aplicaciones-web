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
    public class TipoSociosController : Controller
    {
        private BIBLIOTECA db = new BIBLIOTECA();

        // GET: TipoSocios
        public ActionResult Index()
        {
            return View(db.TipoSocios.ToList());
        }

        // GET: TipoSocios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSocio tipoSocio = db.TipoSocios.Find(id);
            if (tipoSocio == null)
            {
                return HttpNotFound();
            }
            return View(tipoSocio);
        }

        // GET: TipoSocios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoSocios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoSocio,descripcion,maximoMultas,estatus")] TipoSocio tipoSocio)
        {
            if (ModelState.IsValid)
            {
                db.TipoSocios.Add(tipoSocio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoSocio);
        }

        // GET: TipoSocios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSocio tipoSocio = db.TipoSocios.Find(id);
            if (tipoSocio == null)
            {
                return HttpNotFound();
            }
            return View(tipoSocio);
        }

        // POST: TipoSocios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoSocio,descripcion,maximoMultas,estatus")] TipoSocio tipoSocio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoSocio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoSocio);
        }

        // GET: TipoSocios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSocio tipoSocio = db.TipoSocios.Find(id);
            if (tipoSocio == null)
            {
                return HttpNotFound();
            }
            return View(tipoSocio);
        }

        // POST: TipoSocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoSocio tipoSocio = db.TipoSocios.Find(id);
            db.TipoSocios.Remove(tipoSocio);
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
