using AutomobileCatalog.Server.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileCatalog.Shared.Dtos
{
    public class VehicleCreateDto
    {
        public int VehicleModelId { get; set; }

        public double EngineCapacity { get; set; }

        public string? ImageUrl { get; set; }

        public int PriceId { get; set; }

        public string? Description { get; set; }
    }
}
