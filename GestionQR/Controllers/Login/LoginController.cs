using GestionQR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using GestionQR.Controllers.Usuarios;
using System.Net;

namespace SistemaRH.Controllers
{
    public class LoginController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        public ActionResult BuzonPrincipal()
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult CreateCliente()
        {
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente([Bind(Include = "Id,Nombres_Cliente,Apellidos_Cliente,Teléfono,Direccion,Provincia,Sector,Email,Estado")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Seleccion", "Login");
            }

            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", clientes.Estado);
            return View(clientes);
        }

        public ActionResult Usuarios()
        {
            //write logic here  
            return View();
        }

        public ActionResult LoginQuejas()
        {
            //write logic here  
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginQuejas(Usuarios_quejas objUser)
        {
            if (ModelState.IsValid)
            {
                using (GestionQREntities db = new GestionQREntities())
                {
                    var obj = db.Usuarios_quejas.Where(a => a.Usuario_quejas.Equals(objUser.Usuario_quejas) && a.Clave.Equals(objUser.Clave)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Id"] = obj.Id.ToString();
                        Session["Usuario_quejas"] = obj.Usuario_quejas.ToString();
                        return RedirectToAction("Index", "QuejasEdit");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult LoginReclamaciones()
        {
            //write logic here  
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginReclamaciones(Usuarios_reclamaciones objUser2)
        {
            if (ModelState.IsValid)
            {
                using (GestionQREntities db = new GestionQREntities())
                {
                    var obj2 = db.Usuarios_reclamaciones.Where(b => b.Usuario_reclamo.Equals(objUser2.Usuario_reclamo) && b.Clave.Equals(objUser2.Clave)).FirstOrDefault();
                    if (obj2 != null)
                    {
                        Session["Id"] = obj2.Id.ToString();
                        Session["Usuario_reclamo"] = obj2.Usuario_reclamo.ToString();
                        return RedirectToAction("Index", "ReclamacionesEdit");
                    }
                }
            }
            return View(objUser2);
        }

        public ActionResult Administrador()
        {
            //write logic here  
            return View();
        }

        public ActionResult Seleccion()
        {
            //write logic here  
            return View();
        }

        public ActionResult CreateQueja()
        {
            ViewBag.Nombre_Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente");
            ViewBag.Departamento_a_Queja = new SelectList(db.Departamentos, "id", "encargado_departamento");
            ViewBag.Estado_Quejas = new SelectList(db.Estado, "Id", "Descripcion");
            ViewBag.Tipo_Producto = new SelectList(db.Producto, "Id", "Tipo_Producto");
            ViewBag.Tipo_Quejas = new SelectList(db.Tipo_quejas, "Id", "Descripción");
            ViewBag.Usuario_Quejas_Atendido = new SelectList(db.Usuarios_quejas, "Id", "Usuario_quejas");
            return View();
        }

        // POST: Quejas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQueja([Bind(Include = "Id,Nombre_Cliente,Tipo_Quejas,Tipo_Producto,Departamento_a_Queja,Usuario_Quejas_Atendido,Fecha_Queja,Hora_Queja,Departamento_Respuesta,Fecha_Respuesta,Estado_Quejas,Comentarios_Queja")] Quejas quejas)
        {
            if (ModelState.IsValid)
            {
                db.Quejas.Add(quejas);
                db.SaveChanges();
                return RedirectToAction("BuzonPrincipal", "Login");
            }

            ViewBag.Nombre_Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente", quejas.Nombre_Cliente);
            ViewBag.Departamento_a_Queja = new SelectList(db.Departamentos, "id", "encargado_departamento", quejas.Departamento_a_Queja);
            ViewBag.Estado_Quejas = new SelectList(db.Estado, "Id", "Descripcion", quejas.Estado_Quejas);
            ViewBag.Tipo_Producto = new SelectList(db.Producto, "Id", "Tipo_Producto", quejas.Tipo_Producto);
            ViewBag.Tipo_Quejas = new SelectList(db.Tipo_quejas, "Id", "Descripción", quejas.Tipo_Quejas);
            ViewBag.Usuario_Quejas_Atendido = new SelectList(db.Usuarios_quejas, "Id", "Usuario_quejas", quejas.Usuario_Quejas_Atendido);
            return View(quejas);
        }

        public ActionResult CreateReclamo()
        {
            ViewBag.Nombre_Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente");
            ViewBag.Departamento_a_Reclamacion = new SelectList(db.Departamentos, "id", "encargado_departamento");
            ViewBag.Estado_Reclamacion = new SelectList(db.Estado, "Id", "Descripcion");
            ViewBag.Tipo_Producto = new SelectList(db.Producto, "Id", "Tipo_Producto");
            ViewBag.Tipo_Reclamacion = new SelectList(db.Tipo_reclamacion, "Id", "Descripción");
            ViewBag.Usuario_Reclamo_Atendido = new SelectList(db.Usuarios_reclamaciones, "Id", "Usuario_reclamo");
            return View();
        }

        // POST: Reclamaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReclamo([Bind(Include = "Id,Nombre_Cliente,Tipo_Reclamacion,Tipo_Producto,Departamento_a_Reclamacion,Usuario_Reclamo_Atendido,Fecha_Reclamacion,Hora_Reclamacion,Departamento_Respuesta,Fecha_Respuesta,Estado_Reclamacion,Comentarios_Reclamaciones")] Reclamaciones reclamaciones)
        {
            if (ModelState.IsValid)
            {
                db.Reclamaciones.Add(reclamaciones);
                db.SaveChanges();
                return RedirectToAction("BuzonPrincipal", "Login");
            }

            ViewBag.Nombre_Cliente = new SelectList(db.Clientes, "Id", "Nombres_Cliente", reclamaciones.Nombre_Cliente);
            ViewBag.Departamento_a_Reclamacion = new SelectList(db.Departamentos, "id", "encargado_departamento", reclamaciones.Departamento_a_Reclamacion);
            ViewBag.Estado_Reclamacion = new SelectList(db.Estado, "Id", "Descripcion", reclamaciones.Estado_Reclamacion);
            ViewBag.Tipo_Producto = new SelectList(db.Producto, "Id", "Tipo_Producto", reclamaciones.Tipo_Producto);
            ViewBag.Tipo_Reclamacion = new SelectList(db.Tipo_reclamacion, "Id", "Descripción", reclamaciones.Tipo_Reclamacion);
            ViewBag.Usuario_Reclamo_Atendido = new SelectList(db.Usuarios_reclamaciones, "Id", "Usuario_reclamo", reclamaciones.Usuario_Reclamo_Atendido);
            return View(reclamaciones);
        }

        public ActionResult EncuestaSatisfaccion()
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
        public ActionResult EncuestaSatisfaccion([Bind(Include = "Id,Pregunta1,Pregunta2,Pregunta3,Pregunta4,Pregunta5,Pregunta6,Cliente")] EncuestaSatisfaccion1 encuestaSatisfaccion1)
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
        
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios_quejas quejas, Usuarios_reclamaciones reclamacion)
        {
            if (ModelState.IsValid)
            {
                using (GestionQREntities db = new GestionQREntities())
                {
                    var obj = db.Usuarios_quejas.Where(a => a.Usuario_quejas.Equals(quejas.Usuario_quejas) && a.Clave.Equals(quejas.Clave)).FirstOrDefault();
                    var obj2 = db.Usuarios_reclamaciones.Where(a => a.Usuario_reclamo.Equals(reclamacion.Usuario_reclamo) && a.Clave.Equals(reclamacion.Clave)).FirstOrDefault();
                    
                    if (obj != null)
                    {
                        Session["Id"] = obj.Id.ToString();
                        Session["Usuario_quejas"] = obj.Usuario_quejas.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                    else if (obj2 != null)
                    {
                        Session["Id"] = obj2.Id.ToString();
                        Session["Usuario_reclamo"] = obj2.Usuario_reclamo.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View();
        }
        
        public ActionResult UserDashBoard()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Home");
            }
        }
        */
    }
}
