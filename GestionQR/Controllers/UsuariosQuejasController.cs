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
    public class UsuariosQuejasController : Controller
    {
        private GestionQREntities2 db = new GestionQREntities2();

        // GET: UsuariosQuejas
        public ActionResult Index()
        {
            return View(db.Usuarios_de_quejas.ToList());
        }

        // GET: UsuariosQuejas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_de_quejas usuarios_de_quejas = db.Usuarios_de_quejas.Find(id);
            if (usuarios_de_quejas == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_de_quejas);
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
        public ActionResult Create([Bind(Include = "Id,Usuario_quejas,Clave,Departamento_Queja,Fecha_Queja,Hora_Queja,Rol,Puesto,Cliente,Producto,Estado")] Usuarios_de_quejas usuarios_de_quejas)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios_de_quejas.Add(usuarios_de_quejas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarios_de_quejas);
        }

        // GET: UsuariosQuejas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_de_quejas usuarios_de_quejas = db.Usuarios_de_quejas.Find(id);
            if (usuarios_de_quejas == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_de_quejas);
        }

        // POST: UsuariosQuejas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Usuario_quejas,Clave,Departamento_Queja,Fecha_Queja,Hora_Queja,Rol,Puesto,Cliente,Producto,Estado")] Usuarios_de_quejas usuarios_de_quejas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios_de_quejas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarios_de_quejas);
        }

        // GET: UsuariosQuejas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_de_quejas usuarios_de_quejas = db.Usuarios_de_quejas.Find(id);
            if (usuarios_de_quejas == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_de_quejas);
        }

        // POST: UsuariosQuejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios_de_quejas usuarios_de_quejas = db.Usuarios_de_quejas.Find(id);
            db.Usuarios_de_quejas.Remove(usuarios_de_quejas);
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
