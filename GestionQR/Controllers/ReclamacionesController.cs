using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionQR.Models;

namespace GestionQR.Controllers
{
    public class ReclamacionesController : Controller
    {
        private GestionQREntities2 db = new GestionQREntities2();

        // GET: Reclamaciones
        public ActionResult Index()
        {
            return View(db.Reclamaciones.ToList());
        }

        // GET: Reclamaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamaciones reclamaciones = db.Reclamaciones.Find(id);
            if (reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(reclamaciones);
        }

        // GET: Reclamaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reclamaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cliente,Usuario_Reclamo,Tipo_Reclamacion,Departamento_Reclamacion,Encargado_Reclamacion,Fecha_Reclamacion,Hora_Reclamacion,Departamento_Respuesta,Fecha_Respuesta,Estatus_Reclamacion,Comentarios_Reclamaciones")] Reclamaciones reclamaciones)
        {
            if (ModelState.IsValid)
            {
                db.Reclamaciones.Add(reclamaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reclamaciones);
        }

        // GET: Reclamaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamaciones reclamaciones = db.Reclamaciones.Find(id);
            if (reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(reclamaciones);
        }

        // POST: Reclamaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cliente,Usuario_Reclamo,Tipo_Reclamacion,Departamento_Reclamacion,Encargado_Reclamacion,Fecha_Reclamacion,Hora_Reclamacion,Departamento_Respuesta,Fecha_Respuesta,Estatus_Reclamacion,Comentarios_Reclamaciones")] Reclamaciones reclamaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclamaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reclamaciones);
        }

        // GET: Reclamaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamaciones reclamaciones = db.Reclamaciones.Find(id);
            if (reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(reclamaciones);
        }

        // POST: Reclamaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reclamaciones reclamaciones = db.Reclamaciones.Find(id);
            db.Reclamaciones.Remove(reclamaciones);
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
