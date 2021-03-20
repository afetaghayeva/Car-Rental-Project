using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using RecapProject.Entities.Concrete;

namespace RecapProject.DataAccess.Concrete.EntityFramework.Context
{
    public class CarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Car;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Car>().Property(c => c.Id).HasColumnName("Id");
            modelBuilder.Entity<Car>().Property(c => c.BrandId).HasColumnName("BrandId");
            modelBuilder.Entity<Car>().Property(c => c.ColorId).HasColumnName("ColorId");
            modelBuilder.Entity<Car>().Property(c => c.ModelYear).HasColumnName("ModelYear");
            modelBuilder.Entity<Car>().Property(c => c.DailyPrice).HasColumnName("DailyPrice");
            modelBuilder.Entity<Car>().Property(c => c.Description).HasColumnName("Description");
            modelBuilder.Entity<Car>().Property(c => c.CarName).HasColumnName("CarName");

            modelBuilder.Entity<Color>().ToTable("Colors");
            modelBuilder.Entity<Color>().Property(c => c.Id).HasColumnName("Id");
            modelBuilder.Entity<Color>().Property(c => c.ColorName).HasColumnName("ColorName");

            modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<Brand>().Property(c => c.Id).HasColumnName("Id");
            modelBuilder.Entity<Brand>().Property(c => c.BrandName).HasColumnName("BrandName");

            modelBuilder.Entity<Rental>().ToTable("Rentals");
            modelBuilder.Entity<Rental>().Property(r => r.Id).HasColumnName("Id");
            modelBuilder.Entity<Rental>().Property(r => r.CarId).HasColumnName("CarId");
            modelBuilder.Entity<Rental>().Property(r => r.CustomerId).HasColumnName("CustomerId");
            modelBuilder.Entity<Rental>().Property(r => r.RentDate).HasColumnName("RentDate");
            modelBuilder.Entity<Rental>().Property(r => r.ReturnDate).HasColumnName("ReturnDate");

            modelBuilder.Entity<CarImage>().ToTable("CarImages");
            modelBuilder.Entity<CarImage>().Property(c => c.Id).HasColumnName("Id");
            modelBuilder.Entity<CarImage>().Property(c => c.CarId).HasColumnName("CarId");
            modelBuilder.Entity<CarImage>().Property(c => c.ImagePath).HasColumnName("ImagePath");
            modelBuilder.Entity<CarImage>().Property(c => c.Date).HasColumnName("Date");

            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("Id");
            //modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnName("FirstName");
            //modelBuilder.Entity<User>().Property(u => u.LastName).HasColumnName("LastName");
            //modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("Email");

            //modelBuilder.Entity<OperationClaim>().ToTable("OperationClaims");
            //modelBuilder.Entity<OperationClaim>().Property(u => u.Id).HasColumnName("Id");
            //modelBuilder.Entity<OperationClaim>().Property(u => u.Name).HasColumnName("FirstName");
            //modelBuilder.Entity<OperationClaim>().Property(u => u.LastName).HasColumnName("LastName");
            //modelBuilder.Entity<OperationClaim>().Property(u => u.Email).HasColumnName("Email");
        }
    }
}
