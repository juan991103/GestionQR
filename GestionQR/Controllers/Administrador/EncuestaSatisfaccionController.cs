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
    public class EncuestaSatisfaccionController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: EncuestaSatisfaccion
        public ActionResult Index()
        {
            var encuestaSatisfaccion1 = db.EncuestaSatisfaccion1.Include(e => e.Clientes).Include(e => e.Estado2).Include(e => e.Estado21).Include(e => e.Estado22).Include(e => e.Estado23).Include(e => e.Estado24).Include(e => e.Estado25);
            return View(encuestaSatisfaccion1.ToList());
        }

        // GET: EncuestaSatisfaccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncuestaSatisfaccion1 encuestaSatisfaccion1 = db.EncuestaSatisfaccion1.Find(id);
            if (encuestaSatisfaccion1 == null)
            {
                return HttpNotFound();
            }
            return View(encuestaSatisfaccion1);
        }

        // GET: EncuestaSatisfaccion/Create
        public ActionResult Create()
        {
            ViewBag.Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente");
            ViewBag.Pregunta1 = new SelectList(db.Estado2, "Id", "Descripcion");
            ViewBag.Pregunta2 = new SelectList(db.Estado2, "Id", "Descripcion");
            ViewBag.Pregunta3 = new SelectList(db.Estado2, "Id", "Descripcion");
            ViewBag.Pregunta4 = new SelectList(db.Estado2, "Id", "Descripcion");
            ViewBag.Pregunta5 = new SelectList(db.Estado2, "Id", "Descripcion");
            ViewBag.Pregunta6 = new SelectList(db.Estado2, "Id", "Descripcion");
            return View();
        }

        // POST: EncuestaSatisfaccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pregunta1,Pregunta2,Pregunta3,Pregunta4,Pregunta5,Pregunta6,Cliente")] EncuestaSatisfaccion1 encuestaSatisfaccion1)
        {
            if (ModelState.IsValid)
            {
                db.EncuestaSatisfaccion1.Add(encuestaSatisfaccion1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente", encuestaSatisfaccion1.Cliente);
            ViewBag.Pregunta1 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta1);
            ViewBag.Pregunta2 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta2);
            ViewBag.Pregunta3 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta3);
            ViewBag.Pregunta4 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta4);
            ViewBag.Pregunta5 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta5);
            ViewBag.Pregunta6 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta6);
            return View(encuestaSatisfaccion1);
        }

        // GET: EncuestaSatisfaccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncuestaSatisfaccion1 encuestaSatisfaccion1 = db.EncuestaSatisfaccion1.Find(id);
            if (encuestaSatisfaccion1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente", encuestaSatisfaccion1.Cliente);
            ViewBag.Pregunta1 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta1);
            ViewBag.Pregunta2 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta2);
            ViewBag.Pregunta3 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta3);
            ViewBag.Pregunta4 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta4);
            ViewBag.Pregunta5 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta5);
            ViewBag.Pregunta6 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta6);
            return View(encuestaSatisfaccion1);
        }

        // POST: EncuestaSatisfaccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pregunta1,Pregunta2,Pregunta3,Pregunta4,Pregunta5,Pregunta6,Cliente")] EncuestaSatisfaccion1 encuestaSatisfaccion1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encuestaSatisfaccion1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente", encuestaSatisfaccion1.Cliente);
            ViewBag.Pregunta1 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta1);
            ViewBag.Pregunta2 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta2);
            ViewBag.Pregunta3 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta3);
            ViewBag.Pregunta4 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta4);
            ViewBag.Pregunta5 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta5);
            ViewBag.Pregunta6 = new SelectList(db.Estado2, "Id", "Descripcion", encuestaSatisfaccion1.Pregunta6);
            return View(encuestaSatisfaccion1);
        }

        // GET: EncuestaSatisfaccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncuestaSatisfaccion1 encuestaSatisfaccion1 = db.EncuestaSatisfaccion1.Find(id);
            if (encuestaSatisfaccion1 == null)
            {
                return HttpNotFound();
            }
            return View(encuestaSatisfaccion1);
        }

        // POST: EncuestaSatisfaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EncuestaSatisfaccion1 encuestaSatisfaccion1 = db.EncuestaSatisfaccion1.Find(id);
            db.EncuestaSatisfaccion1.Remove(encuestaSatisfaccion1);
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
