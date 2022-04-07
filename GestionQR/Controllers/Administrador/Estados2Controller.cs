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
    public class Estados2Controller : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: Estados2
        public ActionResult Index()
        {
            return View(db.Estado2.ToList());
        }

        // GET: Estados2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado2 estado2 = db.Estado2.Find(id);
            if (estado2 == null)
            {
                return HttpNotFound();
            }
            return View(estado2);
        }

        // GET: Estados2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estados2/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] Estado2 estado2)
        {
            if (ModelState.IsValid)
            {
                db.Estado2.Add(estado2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado2);
        }

        // GET: Estados2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado2 estado2 = db.Estado2.Find(id);
            if (estado2 == null)
            {
                return HttpNotFound();
            }
            return View(estado2);
        }

        // POST: Estados2/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Estado2 estado2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado2);
        }

        // GET: Estados2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado2 estado2 = db.Estado2.Find(id);
            if (estado2 == null)
            {
                return HttpNotFound();
            }
            return View(estado2);
        }

        // POST: Estados2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado2 estado2 = db.Estado2.Find(id);
            db.Estado2.Remove(estado2);
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
