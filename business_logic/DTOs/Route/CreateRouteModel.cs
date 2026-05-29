namespace business_logic.DTOs
{
    public class CreateRouteModel
    {
        public int? StartLocationId { get; set; }
        public int? DestinationLocationId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AutoId { get; set; }
        public int DriverId { get; set; }
        public business_logic.Entities.RouteStatus Status { get; set; } = business_logic.Entities.RouteStatus.Planned;
    }
}
