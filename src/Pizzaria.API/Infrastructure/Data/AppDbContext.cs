using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pizzaria.API.Domain.Entities;

namespace Pizzaria.API.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Iten> Itens { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ECFP120D1320729\\SQLDL;Database=DbPizzaria;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AtualizadoEm).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.CriadoEm).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Nome).HasMaxLength(100);
        });

        modelBuilder.Entity<Iten>(entity =>
        {
            entity.HasIndex(e => e.PedidoId, "IX_Itens_PedidoId");

            entity.HasIndex(e => e.ProdutoId, "IX_Itens_ProdutoId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AtualizadoEm).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.CriadoEm).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Quantidade).HasDefaultValue(1);

            entity.HasOne(d => d.Pedido).WithMany(p => p.Itens)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK_Itens_Pedidos");

            entity.HasOne(d => d.Produto).WithMany(p => p.Itens)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Itens_Produtos");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasIndex(e => new { e.Status, e.Rascunho }, "IX_Pedidos_Status_Rascunho");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AtualizadoEm).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.CriadoEm).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.NomeCliente).HasMaxLength(100);
            entity.Property(e => e.Rascunho).HasDefaultValue(true);
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasIndex(e => e.CategoriaId, "IX_Produtos_CategoriaId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AtualizadoEm).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Banner).HasMaxLength(255);
            entity.Property(e => e.CriadoEm).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Descricao).HasMaxLength(500);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Preco).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK_Produtos_Categorias");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasIndex(e => e.Email, "UQ_Usuarios_Email").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AtualizadoEm).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.CriadoEm).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Senha).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
