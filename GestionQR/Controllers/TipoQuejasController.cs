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
    public class TipoQuejasController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: TipoQuejas
        public ActionResult Index()
        {
            var tipo_quejas = db.Tipo_quejas.Include(t => t.Estado1);
            return View(tipo_quejas.ToList());
        }

        // GET: TipoQuejas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_quejas tipo_quejas = db.Tipo_quejas.Find(id);
            if (tipo_quejas == null)
            {
                return HttpNotFound();
            }
            return View(tipo_quejas);
        }

        // GET: TipoQuejas/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion");
            return View();
        }

        // POST: TipoQuejas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripción,Estado")] Tipo_quejas tipo_quejas)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_quejas.Add(tipo_quejas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", tipo_quejas.Estado);
            return View(tipo_quejas);
        }

        // GET: TipoQuejas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_quejas tipo_quejas = db.Tipo_quejas.Find(id);
            if (tipo_quejas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", tipo_quejas.Estado);
            return View(tipo_quejas);
        }

        // POST: TipoQuejas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripción,Estado")] Tipo_quejas tipo_quejas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_quejas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", tipo_quejas.Estado);
            return View(tipo_quejas);
        }

        // GET: TipoQuejas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_quejas tipo_quejas = db.Tipo_quejas.Find(id);
            if (tipo_quejas == null)
            {
                return HttpNotFound();
            }
            return View(tipo_quejas);
        }

        // POST: TipoQuejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_quejas tipo_quejas = db.Tipo_quejas.Find(id);
            db.Tipo_quejas.Remove(tipo_quejas);
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
