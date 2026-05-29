

using business_logic.Entities;

namespace business_logic.DTOs
{
    public class CreateAutoModel
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public double Capacity { get; set; }
    }
}
