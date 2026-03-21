namespace business_logic.DTOs
{
    public class CreateRouteModel
    {
        public int AutoId { get; set; }
        public int DriverId { get; set; }
        public string Start { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
