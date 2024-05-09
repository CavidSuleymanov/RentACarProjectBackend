using Core.Entities.Concrete;
using Entities;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RenteCarContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\projectmodels;DataBase=rentacar1;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDetailDto>(builder =>
    {
        builder.HasNoKey();
        builder.ToTable("CarDetailDtos");
    });
            
            modelBuilder.Entity<RentalDetailDto>(builder =>
            {
                builder.HasNoKey();
                builder.ToTable("RentalDetailDtos");
            });
            /*
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.HasNoKey();
                builder.ToTable("Customers");
            });
            */

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<CarDetailDto> CarDetailDtos { get; set; }
        public DbSet<RentalDetailDto> RentalDetailDtos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
		public DbSet<Payment> Payments { get; set; }











	}
}
