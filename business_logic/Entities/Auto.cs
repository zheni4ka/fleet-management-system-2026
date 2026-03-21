
namespace business_logic.Entities
{
    public class Auto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public double LoadCarryingCapacity { get; set; }
        public IEnumerable<Route> Routes { get; set; }
    }
}
