using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GestionQR.Models
{
    public partial class GestionQREntities : DbContext
    {
        public GestionQREntities()
            : base("name=GestionQREntities1")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<EncuestaSatisfaccion1> EncuestaSatisfaccion1 { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Estado2> Estado2 { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Puesto> Puesto { get; set; }
        public virtual DbSet<Quejas> Quejas { get; set; }
        public virtual DbSet<Reclamaciones> Reclamaciones { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Tipo_quejas> Tipo_quejas { get; set; }
        public virtual DbSet<Tipo_reclamacion> Tipo_reclamacion { get; set; }
        public virtual DbSet<Usuarios_quejas> Usuarios_quejas { get; set; }
        public virtual DbSet<Usuarios_reclamaciones> Usuarios_reclamaciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .Property(e => e.Nombres_Cliente)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Apellidos_Cliente)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Teléfono)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Provincia)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.EncuestaSatisfaccion1)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Quejas)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.Nombre_Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Reclamaciones)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.Nombre_Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departamentos>()
                .Property(e => e.Nombre_departamento)
                .IsUnicode(false);

            modelBuilder.Entity<Departamentos>()
                .HasMany(e => e.Quejas)
                .WithRequired(e => e.Departamentos)
                .HasForeignKey(e => e.Departamento_a_Queja)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departamentos>()
                .HasMany(e => e.Reclamaciones)
                .WithRequired(e => e.Departamentos)
                .HasForeignKey(e => e.Departamento_a_Reclamacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departamentos>()
                .HasMany(e => e.Usuarios_quejas)
                .WithRequired(e => e.Departamentos)
                .HasForeignKey(e => e.Departamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departamentos>()
                .HasMany(e => e.Usuarios_reclamaciones)
                .WithRequired(e => e.Departamentos)
                .HasForeignKey(e => e.Departamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Clientes)
                .WithRequired(e => e.Estado1)
                .HasForeignKey(e => e.Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Departamentos)
                .WithRequired(e => e.Estado)
                .HasForeignKey(e => e.Estado_Departamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Producto)
                .WithRequired(e => e.Estado)
                .HasForeignKey(e => e.Estado_Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Quejas)
                .WithRequired(e => e.Estado)
                .HasForeignKey(e => e.Estado_Quejas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Reclamaciones)
                .WithRequired(e => e.Estado)
                .HasForeignKey(e => e.Estado_Reclamacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Tipo_quejas)
                .WithRequired(e => e.Estado1)
                .HasForeignKey(e => e.Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Tipo_reclamacion)
                .WithRequired(e => e.Estado1)
                .HasForeignKey(e => e.Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado2>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Estado2>()
                .HasMany(e => e.EncuestaSatisfaccion1)
                .WithRequired(e => e.Estado2)
                .HasForeignKey(e => e.Pregunta1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado2>()
                .HasMany(e => e.EncuestaSatisfaccion11)
                .WithRequired(e => e.Estado21)
                .HasForeignKey(e => e.Pregunta2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado2>()
                .HasMany(e => e.EncuestaSatisfaccion12)
                .WithRequired(e => e.Estado22)
                .HasForeignKey(e => e.Pregunta3)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado2>()
                .HasMany(e => e.EncuestaSatisfaccion13)
                .WithRequired(e => e.Estado23)
                .HasForeignKey(e => e.Pregunta4)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado2>()
                .HasMany(e => e.EncuestaSatisfaccion14)
                .WithRequired(e => e.Estado24)
                .HasForeignKey(e => e.Pregunta5)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado2>()
                .HasMany(e => e.EncuestaSatisfaccion15)
                .WithRequired(e => e.Estado25)
                .HasForeignKey(e => e.Pregunta6)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Tipo_Producto)
                .IsFixedLength();

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Quejas)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.Tipo_Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Reclamaciones)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.Tipo_Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Puesto>()
                .Property(e => e.Descripcion)
                .IsFixedLength();

            modelBuilder.Entity<Puesto>()
                .Property(e => e.Funciones)
                .IsFixedLength();

            modelBuilder.Entity<Puesto>()
                .HasMany(e => e.Usuarios_quejas)
                .WithRequired(e => e.Puesto1)
                .HasForeignKey(e => e.Puesto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Puesto>()
                .HasMany(e => e.Usuarios_reclamaciones)
                .WithRequired(e => e.Puesto1)
                .HasForeignKey(e => e.Puesto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quejas>()
                .Property(e => e.Departamento_Respuesta)
                .IsUnicode(false);

            modelBuilder.Entity<Quejas>()
                .Property(e => e.Comentarios_Queja)
                .IsUnicode(false);

            modelBuilder.Entity<Reclamaciones>()
                .Property(e => e.Departamento_Respuesta)
                .IsUnicode(false);

            modelBuilder.Entity<Reclamaciones>()
                .Property(e => e.Comentarios_Reclamaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Descripcion_Rol)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Usuarios_quejas)
                .WithRequired(e => e.Rol1)
                .HasForeignKey(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Usuarios_reclamaciones)
                .WithRequired(e => e.Rol1)
                .HasForeignKey(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_quejas>()
                .Property(e => e.Descripción)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_quejas>()
                .HasMany(e => e.Quejas)
                .WithRequired(e => e.Tipo_quejas1)
                .HasForeignKey(e => e.Tipo_Quejas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_reclamacion>()
                .Property(e => e.Descripción)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_reclamacion>()
                .HasMany(e => e.Reclamaciones)
                .WithRequired(e => e.Tipo_reclamacion1)
                .HasForeignKey(e => e.Tipo_Reclamacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios_quejas>()
                .Property(e => e.Usuario_quejas)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios_quejas>()
                .Property(e => e.Clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios_quejas>()
                .HasMany(e => e.Quejas)
                .WithRequired(e => e.Usuarios_quejas)
                .HasForeignKey(e => e.Usuario_Quejas_Atendido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios_reclamaciones>()
                .Property(e => e.Usuario_reclamo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios_reclamaciones>()
                .Property(e => e.Clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios_reclamaciones>()
                .HasMany(e => e.Reclamaciones)
                .WithRequired(e => e.Usuarios_reclamaciones)
                .HasForeignKey(e => e.Usuario_Reclamo_Atendido)
                .WillCascadeOnDelete(false);
        }
    }
}
