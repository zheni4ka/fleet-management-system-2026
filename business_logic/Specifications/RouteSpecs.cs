using Ardalis.Specification;
using business_logic.Entities;

namespace business_logic.Specifications
{
    public class RouteSpecs
    {
        public class ById : Specification<Route>
        {
            public ById(int id)
            {
                Query.Where(r => r.Id == id);
            }
        }
        public class All : Specification<Route>
        {
            public All()
            {
                Query.OrderBy(r => r.Id);
            }
        }
        public class ByStart : Specification<Route>
        {
            public ByStart(string startPoint)
            {
                Query.Where(r => (r.StartLocation != null && r.StartLocation.City == startPoint) || (r.StartLocationId != null && r.StartLocationId.ToString() == startPoint));
            }
        }
        public class ByDestination : Specification<Route>
        {
            public ByDestination(string endPoint)
            {
                Query.Where(r => (r.DestinationLocation != null && r.DestinationLocation.City == endPoint) || (r.DestinationLocationId != null && r.DestinationLocationId.ToString() == endPoint));
            }
        }

        public class ByDriverId : Specification<Route>
        {
            public ByDriverId(int driverId)
            {
                Query.Where(r => r.DriverId == driverId);
            }
        }
    }
}
