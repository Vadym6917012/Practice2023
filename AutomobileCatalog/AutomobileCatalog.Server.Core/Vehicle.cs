using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileCatalog.Server.Core
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int VehicleModelId { get; set; }
        public Model? VehicleModel { get; set; }

        public double EngineCapacity { get; set; }

        public int PriceId { get; set; }
        public virtual ICollection<Price>? Price { get; set; }

        public string? Description { get; set; }
    }
}
