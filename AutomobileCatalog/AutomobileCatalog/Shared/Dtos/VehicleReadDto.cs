using AutomobileCatalog.Server.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileCatalog.Shared.Dtos
{
    public class VehicleReadDto
    {
        public int Id { get; set; }
        public Model? VehicleModel { get; set; }

        public string? ImageUrl { get; set; }
        public double EngineCapacity { get; set; }

        public virtual ICollection<Price>? Price { get; set; }

        public string? Description { get; set; }
    }
}
