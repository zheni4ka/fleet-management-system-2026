namespace business_logic.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        // Navigation
        public IEnumerable<Route> StartRoutes { get; set; }
        public IEnumerable<Route> DestinationRoutes { get; set; }
    }
}
