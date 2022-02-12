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
    public class TipoReclamacionController : Controller
    {
        private GestionQREntities2 db = new GestionQREntities2();

        // GET: TipoReclamacion
        public ActionResult Index()
        {
            return View(db.Tipo_de_reclamación.ToList());
        }

        // GET: TipoReclamacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_reclamación tipo_de_reclamación = db.Tipo_de_reclamación.Find(id);
            if (tipo_de_reclamación == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_reclamación);
        }

        // GET: TipoReclamacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoReclamacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripción,Estado")] Tipo_de_reclamación tipo_de_reclamación)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_de_reclamación.Add(tipo_de_reclamación);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_de_reclamación);
        }

        // GET: TipoReclamacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_reclamación tipo_de_reclamación = db.Tipo_de_reclamación.Find(id);
            if (tipo_de_reclamación == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_reclamación);
        }

        // POST: TipoReclamacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripción,Estado")] Tipo_de_reclamación tipo_de_reclamación)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_de_reclamación).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_de_reclamación);
        }

        // GET: TipoReclamacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_reclamación tipo_de_reclamación = db.Tipo_de_reclamación.Find(id);
            if (tipo_de_reclamación == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_reclamación);
        }

        // POST: TipoReclamacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_de_reclamación tipo_de_reclamación = db.Tipo_de_reclamación.Find(id);
            db.Tipo_de_reclamación.Remove(tipo_de_reclamación);
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
