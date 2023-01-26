using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutomobileCatalog.Server.Core
{
    public class VehicleColor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Model>? Models { get; set; }
    }
}