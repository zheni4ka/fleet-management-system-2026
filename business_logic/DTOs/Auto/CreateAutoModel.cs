using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.DTOs
{
    public class CreateAutoModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public double LoadCarryingCapacity { get; set; }
    }
}
