using Ardalis.Specification;
using business_logic.Entities;

namespace business_logic.Specifications
{
    public class RouteSpecs : Specification<Route>
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
                Query.Where(r => r.Start == startPoint);
            }
        }
         public class ByDestination : Specification<Route>
        {
            public ByDestination(string endPoint)
            {
                Query.Where(r => r.Destination == endPoint);
            }
        }
    }
}
