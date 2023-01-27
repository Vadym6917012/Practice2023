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
        }
    }
}
