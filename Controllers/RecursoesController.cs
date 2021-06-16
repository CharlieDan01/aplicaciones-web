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
    public class RecursoesController : Controller
    {
        private BIBLIOTECA db = new BIBLIOTECA();

        // GET: Recursoes
        public ActionResult Index()
        {
            return View(db.Recursoes.ToList());
        }

        // GET: Recursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.Recursoes.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // GET: Recursoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recursoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRecurso,titulo,descripcion,estatus,precio")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                db.Recursoes.Add(recurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recurso);
        }

        // GET: Recursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.Recursoes.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // POST: Recursoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRecurso,titulo,descripcion,estatus,precio")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recurso);
        }

        // GET: Recursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.Recursoes.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // POST: Recursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recurso recurso = db.Recursoes.Find(id);
            db.Recursoes.Remove(recurso);
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
