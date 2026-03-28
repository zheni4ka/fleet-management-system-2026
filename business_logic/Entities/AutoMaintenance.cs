using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Entities
{
    public class AutoMaintenance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ServiceDate { get; set; }
        public int AutoId { get; set; }
        public Auto Auto { get; set; }
    }
}
