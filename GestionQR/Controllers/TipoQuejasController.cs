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
        private GestionQREntities2 db = new GestionQREntities2();

        // GET: TipoQuejas
        public ActionResult Index()
        {
            return View(db.Tipo_de_quejas.ToList());
        }

        // GET: TipoQuejas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_quejas tipo_de_quejas = db.Tipo_de_quejas.Find(id);
            if (tipo_de_quejas == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_quejas);
        }

        // GET: TipoQuejas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoQuejas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripción,Estado")] Tipo_de_quejas tipo_de_quejas)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_de_quejas.Add(tipo_de_quejas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_de_quejas);
        }

        // GET: TipoQuejas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_quejas tipo_de_quejas = db.Tipo_de_quejas.Find(id);
            if (tipo_de_quejas == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_quejas);
        }

        // POST: TipoQuejas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripción,Estado")] Tipo_de_quejas tipo_de_quejas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_de_quejas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_de_quejas);
        }

        // GET: TipoQuejas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_quejas tipo_de_quejas = db.Tipo_de_quejas.Find(id);
            if (tipo_de_quejas == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_quejas);
        }

        // POST: TipoQuejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_de_quejas tipo_de_quejas = db.Tipo_de_quejas.Find(id);
            db.Tipo_de_quejas.Remove(tipo_de_quejas);
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
