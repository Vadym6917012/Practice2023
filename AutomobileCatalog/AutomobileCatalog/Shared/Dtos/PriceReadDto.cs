using AutomobileCatalog.Server.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileCatalog.Shared.Dtos
{
    public class PriceReadDto
    {
        public int Id { get; set; }

        public DateTime InitialPriceDate { get; set; }
        public decimal Value { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
