using System;
using System.Collections.Generic;
using DashboardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Data;

public partial class DashboardDb34Context : DbContext
{
    public DashboardDb34Context()
    {
    }

    public DashboardDb34Context(DbContextOptions<DashboardDb34Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Fridge> Fridges { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductReceipt> ProductReceipts { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DashboardDb34;Trusted_Connection=true;TrustServerCertificate=true").UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Fridge>(entity =>
        {
            entity.ToTable("Fridge");

            entity.Property(e => e.Code).HasMaxLength(6);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.TotalVolume).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.UsedVolume).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Fridges)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fridge_Warehouse");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Name).HasMaxLength(80);
            entity.Property(e => e.Sku)
                .HasMaxLength(12)
                .HasColumnName("SKU");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<ProductReceipt>(entity =>
        {
            entity.ToTable("ProductReceipt");

            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Fridge).WithMany(p => p.ProductReceipts)
                .HasForeignKey(d => d.FridgeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductReceipt_Fridge");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductReceipts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductReceipt_Product");

            entity.HasOne(d => d.Receipt).WithMany(p => p.ProductReceipts)
                .HasForeignKey(d => d.ReceiptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductReceipt_Receipt");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.ToTable("Receipt");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Number).HasMaxLength(12);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receipt_Supplier");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(80);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
