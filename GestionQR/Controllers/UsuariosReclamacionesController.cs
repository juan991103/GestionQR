
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
    public class UsuariosReclamacionesController : Controller
    {
        private GestionQREntities2 db = new GestionQREntities2();

        // GET: UsuariosReclamaciones
        public ActionResult Index()
        {
            return View(db.Usuarios_de_reclamaciones.ToList());
        }

        // GET: UsuariosReclamaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_de_reclamaciones usuarios_de_reclamaciones = db.Usuarios_de_reclamaciones.Find(id);
            if (usuarios_de_reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_de_reclamaciones);
        }

        // GET: UsuariosReclamaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosReclamaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Usuario_reclamo,Clave,Departamento_Reclamacion,Fecha_Reclamacion,Hora_Reclamacion,Rol,Puesto,Cliente,Producto,Estado")] Usuarios_de_reclamaciones usuarios_de_reclamaciones)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios_de_reclamaciones.Add(usuarios_de_reclamaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarios_de_reclamaciones);
        }

        // GET: UsuariosReclamaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_de_reclamaciones usuarios_de_reclamaciones = db.Usuarios_de_reclamaciones.Find(id);
            if (usuarios_de_reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_de_reclamaciones);
        }

        // POST: UsuariosReclamaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Usuario_reclamo,Clave,Departamento_Reclamacion,Fecha_Reclamacion,Hora_Reclamacion,Rol,Puesto,Cliente,Producto,Estado")] Usuarios_de_reclamaciones usuarios_de_reclamaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios_de_reclamaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarios_de_reclamaciones);
        }

        // GET: UsuariosReclamaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_de_reclamaciones usuarios_de_reclamaciones = db.Usuarios_de_reclamaciones.Find(id);
            if (usuarios_de_reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_de_reclamaciones);
        }

        // POST: UsuariosReclamaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios_de_reclamaciones usuarios_de_reclamaciones = db.Usuarios_de_reclamaciones.Find(id);
            db.Usuarios_de_reclamaciones.Remove(usuarios_de_reclamaciones);
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
