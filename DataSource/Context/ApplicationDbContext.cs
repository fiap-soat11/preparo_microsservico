using System;
using System.Collections.Generic;
using DataSource;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataSource.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Preparo> Preparos { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Preparo>(entity =>
        {
            entity.HasKey(e => e.IdPreparo).HasName("PRIMARY");

            entity.ToTable("Preparo");

            entity.HasIndex(e => e.IdPedido, "id_pedido");

            entity.HasIndex(e => e.IdStatus, "id_status");

            entity.Property(e => e.IdPreparo).HasColumnName("id_preparo");
            entity.Property(e => e.DataStatus)
                .HasColumnType("datetime")
                .HasColumnName("data_status");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Preparos)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Preparo_ibfk_2");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PRIMARY");

            entity.ToTable("Status");

            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
