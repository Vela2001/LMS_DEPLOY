using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lead_LandingPage.Models
{
    public partial class ModeloLMS : DbContext
    {
        public ModeloLMS()
            : base("name=ModeloLMS")
        {
        }

        public virtual DbSet<ASIGNACIONES_LEAD> ASIGNACIONES_LEAD { get; set; }
        public virtual DbSet<AUDITORIA_LEADS> AUDITORIA_LEADS { get; set; }
        public virtual DbSet<CITAS> CITAS { get; set; }
        public virtual DbSet<INTERACCIONES> INTERACCIONES { get; set; }
        public virtual DbSet<LEADS> LEADS { get; set; }
        public virtual DbSet<REPORTES> REPORTES { get; set; }
        public virtual DbSet<ROLES> ROLES { get; set; }
        public virtual DbSet<USUARIOS> USUARIOS { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AUDITORIA_LEADS>()
                .Property(e => e.CAMPO_MODIFICADO)
                .IsUnicode(false);

            modelBuilder.Entity<AUDITORIA_LEADS>()
                .Property(e => e.VALOR_ANTERIOR)
                .IsUnicode(false);

            modelBuilder.Entity<AUDITORIA_LEADS>()
                .Property(e => e.VALOR_NUEVO)
                .IsUnicode(false);

            modelBuilder.Entity<CITAS>()
                .Property(e => e.DETALLES)
                .IsUnicode(false);

            modelBuilder.Entity<INTERACCIONES>()
                .Property(e => e.TIPO_INTERACCION)
                .IsUnicode(false);

            modelBuilder.Entity<INTERACCIONES>()
                .Property(e => e.DETALLE)
                .IsUnicode(false);

            modelBuilder.Entity<LEADS>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<LEADS>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<LEADS>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<LEADS>()
                .Property(e => e.EMPRESA)
                .IsUnicode(false);

            modelBuilder.Entity<LEADS>()
                .Property(e => e.CARGO)
                .IsUnicode(false);

            modelBuilder.Entity<LEADS>()
                .Property(e => e.FUENTE_ENTRADA)
                .IsUnicode(false);

            modelBuilder.Entity<LEADS>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<LEADS>()
                .HasMany(e => e.ASIGNACIONES_LEAD)
                .WithRequired(e => e.LEADS)
                .HasForeignKey(e => e.ID_LEAD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LEADS>()
                .HasMany(e => e.AUDITORIA_LEADS)
                .WithRequired(e => e.LEADS)
                .HasForeignKey(e => e.ID_LEAD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LEADS>()
                .HasMany(e => e.CITAS)
                .WithRequired(e => e.LEADS)
                .HasForeignKey(e => e.ID_LEAD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LEADS>()
                .HasMany(e => e.INTERACCIONES)
                .WithRequired(e => e.LEADS)
                .HasForeignKey(e => e.ID_LEAD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REPORTES>()
                .Property(e => e.TIPO_REPORTE)
                .IsUnicode(false);

            modelBuilder.Entity<REPORTES>()
                .Property(e => e.CONTENIDO)
                .IsUnicode(false);

            modelBuilder.Entity<ROLES>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<ROLES>()
                .HasMany(e => e.USUARIOS)
                .WithMany(e => e.ROLES)
                .Map(m => m.ToTable("USUARIO_ROLES").MapLeftKey("ID_ROL").MapRightKey("ID_USUARIO"));

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.NOMBRE_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.HASH_CONTRASEÑA)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .HasMany(e => e.ASIGNACIONES_LEAD)
                .WithRequired(e => e.USUARIOS)
                .HasForeignKey(e => e.ID_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIOS>()
                .HasMany(e => e.AUDITORIA_LEADS)
                .WithOptional(e => e.USUARIOS)
                .HasForeignKey(e => e.USUARIO_MODIFICACION);

            modelBuilder.Entity<USUARIOS>()
                .HasMany(e => e.CITAS)
                .WithRequired(e => e.USUARIOS)
                .HasForeignKey(e => e.ID_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);
        }
    }
}
