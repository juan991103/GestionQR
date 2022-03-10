using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionQR.Models;

namespace GestionQR.Controllers.Usuarios
{
    public class UsuariosQuejasController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: UsuariosQuejas
        public ActionResult Index()
        {
            return View(db.Usuarios_quejas.ToList());
        }

        // GET: UsuariosQuejas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_quejas usuarios_quejas = db.Usuarios_quejas.Find(id);
            if (usuarios_quejas == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_quejas);
        }

        // GET: UsuariosQuejas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosQuejas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Usuario_quejas,Clave")] Usuarios_quejas usuarios_quejas)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios_quejas.Add(usuarios_quejas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarios_quejas);
        }

        // GET: UsuariosQuejas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_quejas usuarios_quejas = db.Usuarios_quejas.Find(id);
            if (usuarios_quejas == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_quejas);
        }

        // POST: UsuariosQuejas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Usuario_quejas,Clave")] Usuarios_quejas usuarios_quejas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios_quejas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarios_quejas);
        }

        // GET: UsuariosQuejas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_quejas usuarios_quejas = db.Usuarios_quejas.Find(id);
            if (usuarios_quejas == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_quejas);
        }

        // POST: UsuariosQuejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios_quejas usuarios_quejas = db.Usuarios_quejas.Find(id);
            db.Usuarios_quejas.Remove(usuarios_quejas);
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
