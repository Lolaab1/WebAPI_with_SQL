// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClothWEPAPI.Models;

namespace ClothWEPAPI.Data
{
    public partial class ClothesDBContext : DbContext
    {
        public ClothesDBContext()
        {
        }

        public ClothesDBContext(DbContextOptions<ClothesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Balance> Balances { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DetailsBill> DetailsBills { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialsCategory> MaterialsCategories { get; set; }
        public virtual DbSet<Query1> Query1s { get; set; }
        public virtual DbSet<Query2> Query2s { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<View1> View1s { get; set; }
        public virtual DbSet<View2> View2s { get; set; }
        public virtual DbSet<View3> View3s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Account1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Account");

                entity.Property(e => e.CurrencyAccountId).HasColumnName("CurrencyAccountID");

                entity.Property(e => e.CustomerAccountId).HasColumnName("CustomerAccountID");

                entity.HasOne(d => d.CurrencyAccount)
                    .WithMany()
                    .HasForeignKey(d => d.CurrencyAccountId)
                    .HasConstraintName("FK_Accounts_Currency");

                entity.HasOne(d => d.CustomerAccount)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerAccountId)
                    .HasConstraintName("FK_Accounts_Customers");
            });

            modelBuilder.Entity<Balance>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BalanceDate).HasColumnType("datetime");

                entity.Property(e => e.CategoriesBalanceId).HasColumnName("CategoriesBalanceID");

                entity.Property(e => e.StoreBalanceId).HasColumnName("StoreBalanceID");

                entity.HasOne(d => d.CategoriesBalance)
                    .WithMany()
                    .HasForeignKey(d => d.CategoriesBalanceId)
                    .HasConstraintName("FK_Balances_Categories");

                entity.HasOne(d => d.StoreBalance)
                    .WithMany()
                    .HasForeignKey(d => d.StoreBalanceId)
                    .HasConstraintName("FK_Balances_Stores");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.BillId).ValueGeneratedNever();

                entity.Property(e => e.BillType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("Store_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Bill_Customers");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Bill_Stores");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Bill_Users");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoriesId);

                entity.Property(e => e.CategoriesId).ValueGeneratedNever();

                entity.Property(e => e.CategoriesName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CategoriesPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.Property(e => e.CurrencyId).ValueGeneratedNever();

                entity.Property(e => e.CurrencyType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetailsBill>(entity =>
            {
                entity.HasKey(e => e.DitailsId);

                entity.ToTable("DetailsBill");

                entity.Property(e => e.DitailsId)
                    .ValueGeneratedNever()
                    .HasColumnName("Ditails_ID");

                entity.Property(e => e.BillDitailsId).HasColumnName("BillDitails_ID");

                entity.Property(e => e.CategoriesId).HasColumnName("CategoriesID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.BillDitails)
                    .WithMany(p => p.DetailsBills)
                    .HasForeignKey(d => d.BillDitailsId)
                    .HasConstraintName("FK_DetailsBill_Bill1");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.DetailsBills)
                    .HasForeignKey(d => d.CategoriesId)
                    .HasConstraintName("FK_DetailsBill_Categories");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Login");

                entity.Property(e => e.LoginPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LoginRoleId).HasColumnName("LoginRole_ID");

                entity.Property(e => e.LoginUserId).HasColumnName("LoginUser_ID");

                entity.Property(e => e.LoginUserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.LoginRole)
                    .WithMany()
                    .HasForeignKey(d => d.LoginRoleId)
                    .HasConstraintName("FK_Login_Roles");

                entity.HasOne(d => d.LoginUser)
                    .WithMany()
                    .HasForeignKey(d => d.LoginUserId)
                    .HasConstraintName("FK_Login_Users");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.MaterialsId);

                entity.Property(e => e.MaterialsId).ValueGeneratedNever();

                entity.Property(e => e.MaterialsName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialsPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<MaterialsCategory>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CategoriesId).HasColumnName("CategoriesID");

                entity.Property(e => e.MaterialsId).HasColumnName("MaterialsID");

                entity.HasOne(d => d.Categories)
                    .WithMany()
                    .HasForeignKey(d => d.CategoriesId)
                    .HasConstraintName("FK_MaterialsCategories_Categories");

                entity.HasOne(d => d.Materials)
                    .WithMany()
                    .HasForeignKey(d => d.MaterialsId)
                    .HasConstraintName("FK_MaterialsCategories_Materials");
            });

            modelBuilder.Entity<Query1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Query1");

                entity.Property(e => e.CategoriesName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Expr1).HasColumnType("decimal(38, 0)");
            });

            modelBuilder.Entity<Query2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Query2");

                entity.Property(e => e.CategoriesName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Expr1).HasColumnType("decimal(38, 0)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RoleType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreId).ValueGeneratedNever();

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_1");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Expr1).HasColumnType("money");
            });

            modelBuilder.Entity<View2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_2");

                entity.Property(e => e.Expr1).HasColumnType("money");

                entity.Property(e => e.Expr2)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<View3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_3");

                entity.Property(e => e.BillType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CategoriesName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}