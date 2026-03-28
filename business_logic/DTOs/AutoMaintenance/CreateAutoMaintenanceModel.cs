using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.DTOs
{
    public class CreateAutoMaintenanceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ServiceDate { get; set; }
        public int AutoId { get; set; }
    }
}
