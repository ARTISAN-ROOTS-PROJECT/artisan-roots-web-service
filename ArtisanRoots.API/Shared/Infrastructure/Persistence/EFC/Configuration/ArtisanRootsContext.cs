using ArtisanRoots.API.Commerce.Domain.Model.Aggregates;
using ArtisanRoots.API.Commerce.Domain.Model.Entities;
using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.IAM.Domain.Model.Aggregates;
using ArtisanRoots.API.IAM.Domain.Model.Entities;
using ArtisanRoots.API.Models;
using ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public partial class ArtisanRootsContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Artisan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__artisans__3213E83F0E364754");

            entity.ToTable("artisans");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Lastname)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RolesId).HasColumnName("roles_id");
            entity.Property(e => e.Status)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Roles).WithMany(p => p.Artisans)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("FK__artisans__roles___4222D4EF");
        });

        builder.Entity<ArtisanCredential>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__artisan___3213E83FCA2112A5");

            entity.ToTable("artisan_credentials");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ArtisansId).HasColumnName("artisans_id");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.Artisans).WithMany(p => p.ArtisanCredentials)
                .HasForeignKey(d => d.ArtisansId)
                .HasConstraintName("FK__artisan_c__artis__4316F928");
        });

        builder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83F13C51B9C");

            entity.ToTable("categories");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        builder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83F99C137CC");

            entity.ToTable("customers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Lastname)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RolesId).HasColumnName("roles_id");
            entity.Property(e => e.Status)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Roles).WithMany(p => p.Customers)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("FK__customers__roles__3B75D760");
        });

        builder.Entity<CustomerCredential>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83F8C4BDC93");

            entity.ToTable("customer_credentials");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CustomersId).HasColumnName("customers_id");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.Customers).WithMany(p => p.CustomerCredentials)
                .HasForeignKey(d => d.CustomersId)
                .HasConstraintName("FK__customer___custo__3C69FB99");
        });

        builder.Entity<DetailSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__detail_s__3213E83F39209F7D");

            entity.ToTable("detail_sales");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.OrderSalesId).HasColumnName("order_sales_id");
            entity.Property(e => e.ProductsId).HasColumnName("products_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalCost");

            entity.HasOne(d => d.OrderSales).WithMany(p => p.DetailSales)
                .HasForeignKey(d => d.OrderSalesId)
                .HasConstraintName("FK__detail_sa__order__3E52440B");

            entity.HasOne(d => d.Products).WithMany(p => p.DetailSales)
                .HasForeignKey(d => d.ProductsId)
                .HasConstraintName("FK__detail_sa__produ__3F466844");
        });

        builder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__location__3213E83F305F5419");

            entity.ToTable("locations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        builder.Entity<NotificationArtisan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notifica__3213E83F30F9DD50");

            entity.ToTable("notification_artisans");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ArtisansId).HasColumnName("artisans_id");
            entity.Property(e => e.Content)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Artisans).WithMany(p => p.NotificationArtisans)
                .HasForeignKey(d => d.ArtisansId)
                .HasConstraintName("FK__notificat__artis__440B1D61");
        });

        builder.Entity<NotificationOwner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notification_owner");

            entity.ToTable("notification_owners");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.Title).HasColumnName("title");

            entity.Property(e => e.Content).HasColumnName("content");

            entity.Property(e => e.OwnersId).HasColumnName("owners_id");

            entity.HasOne(e => e.Owners).WithMany(o => o.NotificationOwners)
            .HasForeignKey(d => d.OwnersId)
            .HasConstraintName("FK_notification_owner");

        });

        builder.Entity<OrderSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_sa__3213E83F0F9421F1");

            entity.ToTable("order_sales");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CustomersId).HasColumnName("customers_id");
            entity.Property(e => e.FinalCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("finalCost");

            entity.HasOne(d => d.Customers).WithMany(p => p.OrderSales)
                .HasForeignKey(d => d.CustomersId)
                .HasConstraintName("FK__order_sal__custo__3D5E1FD2");
        });

        builder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__owners__3213E83FD4737284");

            entity.ToTable("owners");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Lastname)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RolesId).HasColumnName("roles_id");
            entity.Property(e => e.Status)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Roles).WithMany(p => p.Owners)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("FK__owners__roles_id__403A8C7D");
     
        });

        builder.Entity<OwnerCredential>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__owner_cr__3213E83F6A3B39BF");

            entity.ToTable("owner_credentials");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.OwnersId).HasColumnName("owners_id");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.Owners).WithMany(p => p.OwnerCredentials)
                .HasForeignKey(d => d.OwnersId)
                .HasConstraintName("FK__owner_cre__owner__412EB0B6");
        });

        builder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3213E83F300BEB41");

            entity.ToTable("products");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ArtisansId).HasColumnName("artisans_id");
            entity.Property(e => e.CategoriesId).HasColumnName("categories_id");
            entity.Property(e => e.LocationsId).HasColumnName("locations_id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Photo)
                .IsUnicode(false)
                .HasColumnName("photo");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Artisans).WithMany(p => p.Products)
                .HasForeignKey(d => d.ArtisansId)
                .HasConstraintName("FK__products__artisa__44FF419A");

            entity.HasOne(d => d.Categories).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoriesId)
                .HasConstraintName("FK__products__catego__45F365D3");

            entity.HasOne(d => d.Locations).WithMany(p => p.Products)
                .HasForeignKey(d => d.LocationsId)
                .HasConstraintName("FK__products__locati__46E78A0C");
        });

        builder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F8CCE3201");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        builder.UseSnakeCaseWithPluralizedTableNamingConvention();

    }
}
