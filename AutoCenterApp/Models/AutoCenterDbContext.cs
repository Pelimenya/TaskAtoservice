using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AutoCenterApp.Models;

public partial class AutoCenterDbContext : DbContext
{
    public AutoCenterDbContext()
    {
    }

    public AutoCenterDbContext(DbContextOptions<AutoCenterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auto> Autos { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderService> OrderServices { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=AutoCenterDB;User Id=sa;Password=Root_2005;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Auto__3214EC07F13DE268");

            entity.ToTable("Auto");

            entity.Property(e => e.Vin).HasColumnName("VIN");

            entity.HasOne(d => d.AutoModelNavigation).WithMany(p => p.Autos)
                .HasForeignKey(d => d.AutoModel)
                .HasConstraintName("FK__Auto__AutoModel__5070F446");

            entity.HasOne(d => d.AutoOwnerNavigation).WithMany(p => p.Autos)
                .HasForeignKey(d => d.AutoOwner)
                .HasConstraintName("FK__Auto__AutoOwner__5165187F");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC072897A951");

            entity.ToTable("Category");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC072F8752A0");

            entity.ToTable("Client");
        });

        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mark__3214EC07AB360B22");

            entity.ToTable("Mark");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Model__3214EC07E7D3C409");

            entity.ToTable("Model");

            entity.HasOne(d => d.Mark).WithMany(p => p.Models)
                .HasForeignKey(d => d.MarkId)
                .HasConstraintName("FK__Model__MarkId__52593CB8");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC07A619A45A");

            entity.ToTable("Order");

            entity.Property(e => e.OrderDate).HasColumnType("datetime");

            entity.HasOne(d => d.OrderAutoNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderAuto)
                .HasConstraintName("FK__Order__OrderAuto__534D60F1");

            entity.HasOne(d => d.OrderPersonalNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderPersonal)
                .HasConstraintName("FK__Order__OrderPers__5441852A");

            entity.HasOne(d => d.OrderStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatus)
                .HasConstraintName("FK__Order__OrderStat__5535A963");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSer__3214EC0726B6DEBF");

            entity.ToTable("OrderService");

            entity.HasOne(d => d.OrderNavigation).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.Order)
                .HasConstraintName("FK__OrderServ__Order__5629CD9C");

            entity.HasOne(d => d.ServiceNavigation).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.Service)
                .HasConstraintName("FK__OrderServ__Servi__571DF1D5");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personal__3214EC07A471B849");

            entity.ToTable("Personal");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3214EC0786CD86EB");

            entity.ToTable("Service");

            entity.Property(e => e.Cost).HasColumnType("money");

            entity.HasOne(d => d.Category).WithMany(p => p.Services)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Service__Categor__5812160E");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3214EC07FC4113AE");

            entity.ToTable("Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
