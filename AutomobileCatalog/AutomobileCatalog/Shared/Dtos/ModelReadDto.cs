﻿using AutomobileCatalog.Server.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileCatalog.Shared.Dtos
{
    public class ModelReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int MakeId { get; set; }
        public Make? Make { get; set; }

        public int VehicleColorId { get; set; }
        public VehicleColor? VehicleColor { get; set; }
    }
}
