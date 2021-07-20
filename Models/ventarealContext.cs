using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WSVentas_3.Models
{
    public partial class ventarealContext : DbContext
    {
        public ventarealContext()
        {
        }

        public ventarealContext(DbContextOptions<ventarealContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Concepto> Conceptos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Ventum> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Database=ventareal;User Id=ventasmanager;Password=ventasmanager;Port=5432");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Spain.1252");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompletedAt).HasColumnName("completed_at");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.ToTable("concepto");

                entity.HasIndex(e => e.IdVenta, "concepto_id_venta_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CompletedAt).HasColumnName("completed_at");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.Importe)
                    .HasPrecision(16, 2)
                    .HasColumnName("importe");

                entity.Property(e => e.Preciounitario)
                    .HasPrecision(16, 2)
                    .HasColumnName("preciounitario");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Conceptos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithOne(p => p.Concepto)
                    .HasForeignKey<Concepto>(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venta");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompletedAt).HasColumnName("completed_at");

                entity.Property(e => e.Costo)
                    .HasPrecision(16, 2)
                    .HasColumnName("costo");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Preciounitario)
                    .HasPrecision(16, 2)
                    .HasColumnName("preciounitario");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.ToTable("venta");

                entity.HasIndex(e => e.IdCliente, "venta_id_cliente_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompletedAt).HasColumnName("completed_at");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Total)
                    .HasPrecision(16, 2)
                    .HasColumnName("total");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithOne(p => p.Ventum)
                    .HasForeignKey<Ventum>(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
