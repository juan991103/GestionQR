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
    public class UsuariosReclamacionesController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: UsuariosReclamaciones
        public ActionResult Index()
        {
            var usuarios_reclamaciones = db.Usuarios_reclamaciones.Include(u => u.Departamentos).Include(u => u.Puesto1).Include(u => u.Rol1);
            return View(usuarios_reclamaciones.ToList());
        }

        // GET: UsuariosReclamaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_reclamaciones usuarios_reclamaciones = db.Usuarios_reclamaciones.Find(id);
            if (usuarios_reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_reclamaciones);
        }

        // GET: UsuariosReclamaciones/Create
        public ActionResult Create()
        {
            ViewBag.Departamento = new SelectList(db.Departamentos, "id", "Nombre_departamento");
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion");
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol");
            return View();
        }

        // POST: UsuariosReclamaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Usuario_reclamo,Clave,Departamento,Rol,Puesto")] Usuarios_reclamaciones usuarios_reclamaciones)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios_reclamaciones.Add(usuarios_reclamaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departamento = new SelectList(db.Departamentos, "id", "Nombre_departamento", usuarios_reclamaciones.Departamento);
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion", usuarios_reclamaciones.Puesto);
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol", usuarios_reclamaciones.Rol);
            return View(usuarios_reclamaciones);
        }

        // GET: UsuariosReclamaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_reclamaciones usuarios_reclamaciones = db.Usuarios_reclamaciones.Find(id);
            if (usuarios_reclamaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Departamento = new SelectList(db.Departamentos, "id", "Nombre_departamento", usuarios_reclamaciones.Departamento);
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion", usuarios_reclamaciones.Puesto);
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol", usuarios_reclamaciones.Rol);
            return View(usuarios_reclamaciones);
        }

        // POST: UsuariosReclamaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Usuario_reclamo,Clave,Departamento,Rol,Puesto")] Usuarios_reclamaciones usuarios_reclamaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios_reclamaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departamento = new SelectList(db.Departamentos, "id", "Nombre_departamento", usuarios_reclamaciones.Departamento);
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion", usuarios_reclamaciones.Puesto);
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol", usuarios_reclamaciones.Rol);
            return View(usuarios_reclamaciones);
        }

        // GET: UsuariosReclamaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_reclamaciones usuarios_reclamaciones = db.Usuarios_reclamaciones.Find(id);
            if (usuarios_reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_reclamaciones);
        }

        // POST: UsuariosReclamaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios_reclamaciones usuarios_reclamaciones = db.Usuarios_reclamaciones.Find(id);
            db.Usuarios_reclamaciones.Remove(usuarios_reclamaciones);
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
