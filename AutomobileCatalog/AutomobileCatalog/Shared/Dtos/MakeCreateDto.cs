using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileCatalog.Shared.Dtos
{
    public class MakeCreateDto
    {
        [Required(ErrorMessage = "Enter name")]
        [StringLength(32, ErrorMessage = "Must be between 1 and 32 characters", MinimumLength = 1)]
        public string? Name { get; set; }
    }
}
