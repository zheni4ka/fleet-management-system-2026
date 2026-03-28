

namespace business_logic.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Auto Auto { get; set; }
        public int AutoId { get; set; }
        public Driver Driver { get; set; }
        public int DriverId { get; set; }
    }
}
