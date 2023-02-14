using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileCatalog.Server.Core
{
    public static class DataContextExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Make>().HasData(new Make
            {
                Id= 1,
                Name = "BMW"
            },
            new Make
            {
                Id= 2,
                Name = "Mercedes"
            },
            new Make
            {
                Id= 3,
                Name = "Toyota"
            });

            builder.Entity<Model>().HasData(new Model
            {
                Id = 1,
                Name = "e220",
                MakeId = 2,
                VehicleColorId = 1
            },
            new Model
            {
                Id= 2,
                Name = "e39",
                MakeId = 1,
                VehicleColorId = 2
            });

            builder.Entity<VehicleColor>().HasData(new VehicleColor
            { 
                Id = 1,
                Name = "Чорний"
            },
            new VehicleColor
            {
                Id = 2,
                Name = "Білий"
            });

            builder.Entity<Price>().HasData(new Price
            {
                Id = 1,
                Value = 19000,
                InitialPriceDate = DateTime.Now,
                VehicleId = 1
            },
            new Price
            {
                Id = 2,
                Value = 15000,
                InitialPriceDate = DateTime.Now,
                VehicleId = 2
            });

            builder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = 1,
                EngineCapacity = 2.0,
                PriceId = 1,
                VehicleModelId = 1,
                Description = "The best car"
            },
            new Vehicle
            {
                Id = 2,
                EngineCapacity = 1.6,
                PriceId = 2,
                VehicleModelId = 2,
                Description = "Test description"
            });
        }
    }
}
