using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.DTOs
{
    public class EditDriverModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string LicenseNumber { get; set; }
    }
}
