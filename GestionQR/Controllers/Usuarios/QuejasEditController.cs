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
    public class QuejasEditController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: QuejasEdit
        public ActionResult Index()
        {
            var quejas = db.Quejas.Include(q => q.Clientes).Include(q => q.Departamentos).Include(q => q.Estado).Include(q => q.Producto).Include(q => q.Tipo_quejas1).Include(q => q.Usuarios_quejas);
            return View(quejas.ToList());
        }

        // GET: QuejasEdit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quejas quejas = db.Quejas.Find(id);
            if (quejas == null)
            {
                return HttpNotFound();
            }
            return View(quejas);
        }

        // GET: QuejasEdit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quejas quejas = db.Quejas.Find(id);
            if (quejas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nombre_Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente", quejas.Nombre_Cliente);
            ViewBag.Departamento_a_Queja = new SelectList(db.Departamentos, "id", "encargado_departamento", quejas.Departamento_a_Queja);
            ViewBag.Estado_Quejas = new SelectList(db.Estado, "Id", "Descripcion", quejas.Estado_Quejas);
            ViewBag.Tipo_Producto = new SelectList(db.Producto, "Id", "Tipo_Producto", quejas.Tipo_Producto);
            ViewBag.Tipo_Quejas = new SelectList(db.Tipo_quejas, "Id", "Descripción", quejas.Tipo_Quejas);
            ViewBag.Usuario_Quejas_Atendido = new SelectList(db.Usuarios_quejas, "Id", "Usuario_quejas", quejas.Usuario_Quejas_Atendido);
            return View(quejas);
        }

        // POST: QuejasEdit/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre_Cliente,Tipo_Quejas,Tipo_Producto,Departamento_a_Queja,Usuario_Quejas_Atendido,Fecha_Queja,Hora_Queja,Departamento_Respuesta,Fecha_Respuesta,Estado_Quejas,Comentarios_Queja")] Quejas quejas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quejas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nombre_Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente", quejas.Nombre_Cliente);
            ViewBag.Departamento_a_Queja = new SelectList(db.Departamentos, "id", "encargado_departamento", quejas.Departamento_a_Queja);
            ViewBag.Estado_Quejas = new SelectList(db.Estado, "Id", "Descripcion", quejas.Estado_Quejas);
            ViewBag.Tipo_Producto = new SelectList(db.Producto, "Id", "Tipo_Producto", quejas.Tipo_Producto);
            ViewBag.Tipo_Quejas = new SelectList(db.Tipo_quejas, "Id", "Descripción", quejas.Tipo_Quejas);
            ViewBag.Usuario_Quejas_Atendido = new SelectList(db.Usuarios_quejas, "Id", "Usuario_quejas", quejas.Usuario_Quejas_Atendido);
            return View(quejas);
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
