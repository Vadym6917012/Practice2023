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
				Id = 1,
				Name = "BMW"
			},
			new Make
			{
				Id = 2,
				Name = "Mercedes"
			},
			new Make
			{
				Id = 3,
				Name = "Toyota"
			},
			new Make
			{
				Id = 4,
				Name = "Alfa Romeo",
			},
			new Make
			{
				Id = 5,
				Name = "Alphina",
			},
			new Make
			{
				Id = 6,
				Name = "Audi"
			}, new Make
			{
				Id = 7,
				Name = "Acura",
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
				Id = 2,
				Name = "e39",
				MakeId = 1,
				VehicleColorId = 2
			},
			new Model
			{
				Id = 3,
				Name = "190",
				MakeId = 2,
				VehicleColorId = 2
			},
			new Model
			{
				Id = 4,
				Name = "230 Pullman",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 5,
				Name = "A-Class",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 6,
				Name = "AMG GT",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 7,
				Name = "AMG GT 4-Door Coupe",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 8,
				Name = "B-Class",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 9,
				Name = "C-Class",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 10,
				Name = "C-Class All-Terrain",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 11,
				Name = "Citan",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 12,
				Name = "CL-Class",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 13,
				Name = "CLA-Class",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 14,
				Name = "CLC-Class",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 15,
				Name = "CLK-Class",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 16,
				Name = "CLS-Class",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id = 17,
				Name = "G-Class",
				MakeId = 2,
				VehicleColorId = 1
			},
			new Model
			{
				Id= 18,
				Name = "Camry",
				MakeId = 3,
				VehicleColorId = 1
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
