using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionQR.Models;

namespace GestionQR.Controllers.Administrador
{
    public class TipoReclamacionController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: TipoReclamacion
        public ActionResult Index()
        {
            var tipo_reclamacion = db.Tipo_reclamacion.Include(t => t.Estado1);
            return View(tipo_reclamacion.ToList());
        }

        // GET: TipoReclamacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_reclamacion tipo_reclamacion = db.Tipo_reclamacion.Find(id);
            if (tipo_reclamacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_reclamacion);
        }

        // GET: TipoReclamacion/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion");
            return View();
        }

        // POST: TipoReclamacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripción,Estado")] Tipo_reclamacion tipo_reclamacion)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_reclamacion.Add(tipo_reclamacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", tipo_reclamacion.Estado);
            return View(tipo_reclamacion);
        }

        // GET: TipoReclamacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_reclamacion tipo_reclamacion = db.Tipo_reclamacion.Find(id);
            if (tipo_reclamacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", tipo_reclamacion.Estado);
            return View(tipo_reclamacion);
        }

        // POST: TipoReclamacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripción,Estado")] Tipo_reclamacion tipo_reclamacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_reclamacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", tipo_reclamacion.Estado);
            return View(tipo_reclamacion);
        }

        // GET: TipoReclamacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_reclamacion tipo_reclamacion = db.Tipo_reclamacion.Find(id);
            if (tipo_reclamacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_reclamacion);
        }

        // POST: TipoReclamacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_reclamacion tipo_reclamacion = db.Tipo_reclamacion.Find(id);
            db.Tipo_reclamacion.Remove(tipo_reclamacion);
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
