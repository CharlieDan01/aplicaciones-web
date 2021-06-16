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
    public class BibliotecaasController : Controller
    {
        private BIBLIOTECA db = new BIBLIOTECA();

        // GET: Bibliotecaas
        public ActionResult Index()
        {
            return View(db.Bibliotecaas.ToList());
        }

        // GET: Bibliotecaas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliotecaa bibliotecaa = db.Bibliotecaas.Find(id);
            if (bibliotecaa == null)
            {
                return HttpNotFound();
            }
            return View(bibliotecaa);
        }

        // GET: Bibliotecaas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bibliotecaas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBiblioteca,imagenFile,horario,telefono")] Bibliotecaa bibliotecaa)
        {
            if (ModelState.IsValid)
            {
                db.Bibliotecaas.Add(bibliotecaa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bibliotecaa);
        }

        // GET: Bibliotecaas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliotecaa bibliotecaa = db.Bibliotecaas.Find(id);
            if (bibliotecaa == null)
            {
                return HttpNotFound();
            }
            return View(bibliotecaa);
        }

        // POST: Bibliotecaas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBiblioteca,imagenFile,horario,telefono")] Bibliotecaa bibliotecaa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bibliotecaa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bibliotecaa);
        }

        // GET: Bibliotecaas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliotecaa bibliotecaa = db.Bibliotecaas.Find(id);
            if (bibliotecaa == null)
            {
                return HttpNotFound();
            }
            return View(bibliotecaa);
        }

        // POST: Bibliotecaas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bibliotecaa bibliotecaa = db.Bibliotecaas.Find(id);
            db.Bibliotecaas.Remove(bibliotecaa);
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
