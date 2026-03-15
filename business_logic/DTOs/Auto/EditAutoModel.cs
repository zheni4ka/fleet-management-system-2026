using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.DTOs
{ 
    public class EditAutoModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public decimal LoadCarryingCapacity { get; set; }
    }
}
