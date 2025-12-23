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

    public virtual DbSet<Categoria> Categoria { get; set; }

    
    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    
    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<ProdutoIngrediente> ProdutoIngredientes { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        
        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.IdIngrediente).HasName("PRIMARY");

            entity.ToTable("Ingrediente");

            entity.Property(e => e.IdIngrediente).HasColumnName("id_ingrediente");
            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .HasColumnName("descricao");
            entity.Property(e => e.EstoqueMinimo)
                .HasPrecision(10, 2)
                .HasColumnName("estoque_minimo");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.PrecoUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("preco_unitario");
            entity.Property(e => e.QuantidadeEmEstoque)
                .HasPrecision(10, 2)
                .HasColumnName("quantidade_em_estoque");
            entity.Property(e => e.UnidadeMedida)
                .HasMaxLength(20)
                .HasColumnName("unidade_medida");
        });

        
        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PRIMARY");

            entity.ToTable("Produto");

            entity.HasIndex(e => e.IdCategoria, "id_categoria");

            entity.Property(e => e.IdProduto).HasColumnName("id_produto");
            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .HasColumnName("descricao");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Imagens)
                .HasMaxLength(500)
                .HasColumnName("imagens");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Preco)
                .HasPrecision(10, 2)
                .HasColumnName("preco");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Produto_ibfk_1");
        });

        modelBuilder.Entity<ProdutoIngrediente>(entity =>
        {
            entity.HasKey(e => e.IdProdutoIngrediente).HasName("PRIMARY");

            entity.ToTable("Produto_Ingrediente");

            entity.HasIndex(e => e.IdIngrediente, "id_ingrediente");

            entity.HasIndex(e => e.IdProduto, "id_produto");

            entity.Property(e => e.IdProdutoIngrediente).HasColumnName("id_produto_ingrediente");
            entity.Property(e => e.IdIngrediente).HasColumnName("id_ingrediente");
            entity.Property(e => e.IdProduto).HasColumnName("id_produto");
            entity.Property(e => e.Quantidade)
                .HasPrecision(10, 2)
                .HasColumnName("quantidade");

            entity.HasOne(d => d.IdIngredienteNavigation).WithMany(p => p.ProdutoIngredientes)
                .HasForeignKey(d => d.IdIngrediente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Produto_Ingrediente_ibfk_1");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.ProdutoIngredientes)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Produto_Ingrediente_ibfk_2");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
