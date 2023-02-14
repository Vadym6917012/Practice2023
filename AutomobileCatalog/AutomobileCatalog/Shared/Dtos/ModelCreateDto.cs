using AutomobileCatalog.Server.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileCatalog.Shared.Dtos
{
    public class ModelCreateDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public int MakeId { get; set; }

        [Required]
        public int VehicleColorId { get; set; }
    }
}
