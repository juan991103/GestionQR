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
    public class GestorUsuariosQuejasController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: GestorUsuariosQuejas
        public ActionResult Index()
        {
            var gestor_usuarios_quejas = db.Gestor_usuarios_quejas.Include(g => g.Estado1).Include(g => g.Quejas).Include(g => g.Quejas1).Include(g => g.Puesto1).Include(g => g.Usuarios_quejas).Include(g => g.Rol1);
            return View(gestor_usuarios_quejas.ToList());
        }

        // GET: GestorUsuariosQuejas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestor_usuarios_quejas gestor_usuarios_quejas = db.Gestor_usuarios_quejas.Find(id);
            if (gestor_usuarios_quejas == null)
            {
                return HttpNotFound();
            }
            return View(gestor_usuarios_quejas);
        }

        // GET: GestorUsuariosQuejas/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion");
            ViewBag.Departamento_Queja = new SelectList(db.Quejas, "Id", "Departamento_Respuesta");
            ViewBag.Nombre_Cliente = new SelectList(db.Quejas, "Id", "Departamento_Respuesta");
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion");
            ViewBag.Usuario_quejas = new SelectList(db.Usuarios_quejas, "Id", "Usuario_quejas");
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol");
            return View();
        }

        // POST: GestorUsuariosQuejas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Usuario_quejas,Nombre_Cliente,Departamento_Queja,Rol,Puesto,Estado")] Gestor_usuarios_quejas gestor_usuarios_quejas)
        {
            if (ModelState.IsValid)
            {
                db.Gestor_usuarios_quejas.Add(gestor_usuarios_quejas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", gestor_usuarios_quejas.Estado);
            ViewBag.Departamento_Queja = new SelectList(db.Quejas, "Id", "Departamento_Respuesta", gestor_usuarios_quejas.Departamento_Queja);
            ViewBag.Nombre_Cliente = new SelectList(db.Quejas, "Id", "Departamento_Respuesta", gestor_usuarios_quejas.Nombre_Cliente);
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion", gestor_usuarios_quejas.Puesto);
            ViewBag.Usuario_quejas = new SelectList(db.Usuarios_quejas, "Id", "Usuario_quejas", gestor_usuarios_quejas.Usuario_quejas);
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol", gestor_usuarios_quejas.Rol);
            return View(gestor_usuarios_quejas);
        }

        // GET: GestorUsuariosQuejas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestor_usuarios_quejas gestor_usuarios_quejas = db.Gestor_usuarios_quejas.Find(id);
            if (gestor_usuarios_quejas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", gestor_usuarios_quejas.Estado);
            ViewBag.Departamento_Queja = new SelectList(db.Quejas, "Id", "Departamento_Respuesta", gestor_usuarios_quejas.Departamento_Queja);
            ViewBag.Nombre_Cliente = new SelectList(db.Quejas, "Id", "Departamento_Respuesta", gestor_usuarios_quejas.Nombre_Cliente);
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion", gestor_usuarios_quejas.Puesto);
            ViewBag.Usuario_quejas = new SelectList(db.Usuarios_quejas, "Id", "Usuario_quejas", gestor_usuarios_quejas.Usuario_quejas);
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol", gestor_usuarios_quejas.Rol);
            return View(gestor_usuarios_quejas);
        }

        // POST: GestorUsuariosQuejas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Usuario_quejas,Nombre_Cliente,Departamento_Queja,Rol,Puesto,Estado")] Gestor_usuarios_quejas gestor_usuarios_quejas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestor_usuarios_quejas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", gestor_usuarios_quejas.Estado);
            ViewBag.Departamento_Queja = new SelectList(db.Quejas, "Id", "Departamento_Respuesta", gestor_usuarios_quejas.Departamento_Queja);
            ViewBag.Nombre_Cliente = new SelectList(db.Quejas, "Id", "Departamento_Respuesta", gestor_usuarios_quejas.Nombre_Cliente);
            ViewBag.Puesto = new SelectList(db.Puesto, "Id", "Descripcion", gestor_usuarios_quejas.Puesto);
            ViewBag.Usuario_quejas = new SelectList(db.Usuarios_quejas, "Id", "Usuario_quejas", gestor_usuarios_quejas.Usuario_quejas);
            ViewBag.Rol = new SelectList(db.Rol, "Id", "Descripcion_Rol", gestor_usuarios_quejas.Rol);
            return View(gestor_usuarios_quejas);
        }

        // GET: GestorUsuariosQuejas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestor_usuarios_quejas gestor_usuarios_quejas = db.Gestor_usuarios_quejas.Find(id);
            if (gestor_usuarios_quejas == null)
            {
                return HttpNotFound();
            }
            return View(gestor_usuarios_quejas);
        }

        // POST: GestorUsuariosQuejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gestor_usuarios_quejas gestor_usuarios_quejas = db.Gestor_usuarios_quejas.Find(id);
            db.Gestor_usuarios_quejas.Remove(gestor_usuarios_quejas);
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
