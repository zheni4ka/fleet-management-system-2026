namespace business_logic.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string LicenseNumber { get; set; }
        public IEnumerable<Route> Routes { get; set; }
    }
}
