﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionQR.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GestionQREntities2 : DbContext
    {
        public GestionQREntities2()
            : base("name=GestionQREntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Puesto> Puesto { get; set; }
        public DbSet<Quejas> Quejas { get; set; }
        public DbSet<Reclamaciones> Reclamaciones { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Tipo_de_quejas> Tipo_de_quejas { get; set; }
        public DbSet<Tipo_de_reclamación> Tipo_de_reclamación { get; set; }
        public DbSet<Usuarios_de_quejas> Usuarios_de_quejas { get; set; }
        public DbSet<Usuarios_de_reclamaciones> Usuarios_de_reclamaciones { get; set; }
    }
}
