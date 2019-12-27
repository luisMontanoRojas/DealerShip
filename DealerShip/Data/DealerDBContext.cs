using DealerShip.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerShip.Data
{
    public class DealerDBContext:DbContext
    {
        public DealerDBContext(DbContextOptions<DealerDBContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarBrandEntity>().ToTable("CarBrands");
            modelBuilder.Entity<CarBrandEntity>().HasMany(a => a.carModels).WithOne(b => b.carBrandId);
            modelBuilder.Entity<CarBrandEntity>().Property(a => a.id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CarModelEntity>().ToTable("CarModels");
            modelBuilder.Entity<CarModelEntity>().Property(b => b.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CarModelEntity>().HasOne(b =>b.carBrandId).WithMany(a => a.carModels);

        }
        public DbSet<CarBrandEntity> CarBrands { get; set; }
        public DbSet<CarModelEntity> CarModels { get; set; }

    }
}
