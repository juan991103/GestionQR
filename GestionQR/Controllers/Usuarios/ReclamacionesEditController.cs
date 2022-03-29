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
    public class ReclamacionesEditController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: ReclamacionesEdit
        public ActionResult Index()
        {
            if (Session["Id"] != null)
            {
                var reclamaciones = db.Reclamaciones.Include(r => r.Clientes).Include(r => r.Departamentos).Include(r => r.Estado).Include(r => r.Producto).Include(r => r.Tipo_reclamacion1).Include(r => r.Usuarios_reclamaciones);
                return View(reclamaciones.ToList());
            }
            else
            {
                return RedirectToAction("LoginReclamaciones", "Login");
            }
        }

        // GET: ReclamacionesEdit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamaciones reclamaciones = db.Reclamaciones.Find(id);
            if (reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(reclamaciones);
        }

        // GET: ReclamacionesEdit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamaciones reclamaciones = db.Reclamaciones.Find(id);
            if (reclamaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nombre_Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente", reclamaciones.Nombre_Cliente);
            ViewBag.Departamento_a_Reclamacion = new SelectList(db.Departamentos, "id", "encargado_departamento", reclamaciones.Departamento_a_Reclamacion);
            ViewBag.Estado_Reclamacion = new SelectList(db.Estado, "Id", "Descripcion", reclamaciones.Estado_Reclamacion);
            ViewBag.Tipo_Producto = new SelectList(db.Producto, "Id", "Tipo_Producto", reclamaciones.Tipo_Producto);
            ViewBag.Tipo_Reclamacion = new SelectList(db.Tipo_reclamacion, "Id", "Descripción", reclamaciones.Tipo_Reclamacion);
            ViewBag.Usuario_Reclamo_Atendido = new SelectList(db.Usuarios_reclamaciones, "Id", "Usuario_reclamo", reclamaciones.Usuario_Reclamo_Atendido);
            return View(reclamaciones);
        }

        // POST: ReclamacionesEdit/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre_Cliente,Tipo_Reclamacion,Tipo_Producto,Departamento_a_Reclamacion,Usuario_Reclamo_Atendido,Fecha_Reclamacion,Hora_Reclamacion,Departamento_Respuesta,Fecha_Respuesta,Estado_Reclamacion,Comentarios_Reclamaciones")] Reclamaciones reclamaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclamaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nombre_Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente", reclamaciones.Nombre_Cliente);
            ViewBag.Departamento_a_Reclamacion = new SelectList(db.Departamentos, "id", "encargado_departamento", reclamaciones.Departamento_a_Reclamacion);
            ViewBag.Estado_Reclamacion = new SelectList(db.Estado, "Id", "Descripcion", reclamaciones.Estado_Reclamacion);
            ViewBag.Tipo_Producto = new SelectList(db.Producto, "Id", "Tipo_Producto", reclamaciones.Tipo_Producto);
            ViewBag.Tipo_Reclamacion = new SelectList(db.Tipo_reclamacion, "Id", "Descripción", reclamaciones.Tipo_Reclamacion);
            ViewBag.Usuario_Reclamo_Atendido = new SelectList(db.Usuarios_reclamaciones, "Id", "Usuario_reclamo", reclamaciones.Usuario_Reclamo_Atendido);
            return View(reclamaciones);
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
