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
    public class QuejasController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: Quejas
        public ActionResult Index()
        {
            var quejas = db.Quejas.Include(q => q.Estado).Include(q => q.Tipo_quejas1);
            return View(quejas.ToList());
        }

        // GET: Quejas/Details/5
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

        // GET: Quejas/Create
        public ActionResult Create()
        {
            ViewBag.Estado_Quejas = new SelectList(db.Estado, "Id", "Descripcion");
            ViewBag.Tipo_Quejas = new SelectList(db.Tipo_quejas, "Id", "Descripción");
            return View();
        }

        // POST: Quejas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Cliente,Usuario_Quejas,Tipo_Quejas,Departamento_Queja,Encargado_Queja,Fecha_Queja,Hora_Queja,Departamento_Respuesta,Fecha_Respuesta,Estado_Quejas,Comentarios_Queja")] Quejas quejas)
        {
            if (ModelState.IsValid)
            {
                db.Quejas.Add(quejas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado_Quejas = new SelectList(db.Estado, "Id", "Descripcion", quejas.Estado_Quejas);
            ViewBag.Tipo_Quejas = new SelectList(db.Tipo_quejas, "Id", "Descripción", quejas.Tipo_Quejas);
            return View(quejas);
        }

        // GET: Quejas/Edit/5
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
            ViewBag.Estado_Quejas = new SelectList(db.Estado, "Id", "Descripcion", quejas.Estado_Quejas);
            ViewBag.Tipo_Quejas = new SelectList(db.Tipo_quejas, "Id", "Descripción", quejas.Tipo_Quejas);
            return View(quejas);
        }

        // POST: Quejas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Cliente,Usuario_Quejas,Tipo_Quejas,Departamento_Queja,Encargado_Queja,Fecha_Queja,Hora_Queja,Departamento_Respuesta,Fecha_Respuesta,Estado_Quejas,Comentarios_Queja")] Quejas quejas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quejas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado_Quejas = new SelectList(db.Estado, "Id", "Descripcion", quejas.Estado_Quejas);
            ViewBag.Tipo_Quejas = new SelectList(db.Tipo_quejas, "Id", "Descripción", quejas.Tipo_Quejas);
            return View(quejas);
        }

        // GET: Quejas/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Quejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quejas quejas = db.Quejas.Find(id);
            db.Quejas.Remove(quejas);
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
