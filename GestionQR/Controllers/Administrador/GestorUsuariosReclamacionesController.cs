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
    public class GestorUsuariosReclamacionesController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: GestorUsuariosReclamaciones
        public ActionResult Index()
        {
            var gestor_usuarios_reclamaciones = db.Gestor_usuarios_reclamaciones.Include(g => g.Estado1).Include(g => g.Reclamaciones).Include(g => g.Reclamaciones1).Include(g => g.Puesto1).Include(g => g.Usuarios_reclamaciones).Include(g => g.Rol1);
            return View(gestor_usuarios_reclamaciones.ToList());
        }

        // GET: GestorUsuariosReclamaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestor_usuarios_reclamaciones gestor_usuarios_reclamaciones = db.Gestor_usuarios_reclamaciones.Find(id);
            if (gestor_usuarios_reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(gestor_usuarios_reclamaciones);
        }

        // GET: GestorUsuariosReclamaciones/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion");
            ViewBag.Departamento_Reclamacion = new SelectList(db.Reclamaciones, "Id", "Departamento_Respuesta");
            ViewBag.Nombre_Cliente = new SelectList(db.Reclamaciones, "Id", "Departamento_Respuesta");
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion");
            ViewBag.Usuario_reclamo_ = new SelectList(db.Usuarios_reclamaciones, "Id", "Usuario_reclamo");
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol");
            return View();
        }

        // POST: GestorUsuariosReclamaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Usuario_reclamo_,Nombre_Cliente,Departamento_Reclamacion,Rol,Puesto,Estado")] Gestor_usuarios_reclamaciones gestor_usuarios_reclamaciones)
        {
            if (ModelState.IsValid)
            {
                db.Gestor_usuarios_reclamaciones.Add(gestor_usuarios_reclamaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", gestor_usuarios_reclamaciones.Estado);
            ViewBag.Departamento_Reclamacion = new SelectList(db.Reclamaciones, "Id", "Departamento_Respuesta", gestor_usuarios_reclamaciones.Departamento_Reclamacion);
            ViewBag.Nombre_Cliente = new SelectList(db.Reclamaciones, "Id", "Departamento_Respuesta", gestor_usuarios_reclamaciones.Nombre_Cliente);
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion", gestor_usuarios_reclamaciones.Puesto);
            ViewBag.Usuario_reclamo_ = new SelectList(db.Usuarios_reclamaciones, "Id", "Usuario_reclamo", gestor_usuarios_reclamaciones.Usuario_reclamo_);
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol", gestor_usuarios_reclamaciones.Rol);
            return View(gestor_usuarios_reclamaciones);
        }

        // GET: GestorUsuariosReclamaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestor_usuarios_reclamaciones gestor_usuarios_reclamaciones = db.Gestor_usuarios_reclamaciones.Find(id);
            if (gestor_usuarios_reclamaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", gestor_usuarios_reclamaciones.Estado);
            ViewBag.Departamento_Reclamacion = new SelectList(db.Reclamaciones, "Id", "Departamento_Respuesta", gestor_usuarios_reclamaciones.Departamento_Reclamacion);
            ViewBag.Nombre_Cliente = new SelectList(db.Reclamaciones, "Id", "Departamento_Respuesta", gestor_usuarios_reclamaciones.Nombre_Cliente);
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion", gestor_usuarios_reclamaciones.Puesto);
            ViewBag.Usuario_reclamo_ = new SelectList(db.Usuarios_reclamaciones, "Id", "Usuario_reclamo", gestor_usuarios_reclamaciones.Usuario_reclamo_);
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol", gestor_usuarios_reclamaciones.Rol);
            return View(gestor_usuarios_reclamaciones);
        }

        // POST: GestorUsuariosReclamaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Usuario_reclamo_,Nombre_Cliente,Departamento_Reclamacion,Rol,Puesto,Estado")] Gestor_usuarios_reclamaciones gestor_usuarios_reclamaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestor_usuarios_reclamaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", gestor_usuarios_reclamaciones.Estado);
            ViewBag.Departamento_Reclamacion = new SelectList(db.Reclamaciones, "Id", "Departamento_Respuesta", gestor_usuarios_reclamaciones.Departamento_Reclamacion);
            ViewBag.Nombre_Cliente = new SelectList(db.Reclamaciones, "Id", "Departamento_Respuesta", gestor_usuarios_reclamaciones.Nombre_Cliente);
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion", gestor_usuarios_reclamaciones.Puesto);
            ViewBag.Usuario_reclamo_ = new SelectList(db.Usuarios_reclamaciones, "Id", "Usuario_reclamo", gestor_usuarios_reclamaciones.Usuario_reclamo_);
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol", gestor_usuarios_reclamaciones.Rol);
            return View(gestor_usuarios_reclamaciones);
        }

        // GET: GestorUsuariosReclamaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestor_usuarios_reclamaciones gestor_usuarios_reclamaciones = db.Gestor_usuarios_reclamaciones.Find(id);
            if (gestor_usuarios_reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(gestor_usuarios_reclamaciones);
        }

        // POST: GestorUsuariosReclamaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gestor_usuarios_reclamaciones gestor_usuarios_reclamaciones = db.Gestor_usuarios_reclamaciones.Find(id);
            db.Gestor_usuarios_reclamaciones.Remove(gestor_usuarios_reclamaciones);
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
