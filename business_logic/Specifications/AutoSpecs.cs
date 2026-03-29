using Ardalis.Specification;
using business_logic.Entities;

namespace business_logic.Specifications
{
    public class AutoSpecs
    {
        public class ById : Specification<Auto>
        {
            public ById(int id)
            {
                Query.Where(a => a.Id == id);
            }
        }

        public class ByName : Specification<Auto>
        {
            public ByName(string name)
            {
                Query.Where(a => a.Name == name);
            }
        }

        public class All : Specification<Auto>
        {
            public All()
            {
                Query.OrderBy(a => a.Name);
            }
        }

        public class CapacityMoreThan : Specification<Auto>
        {
            public CapacityMoreThan(double value)
            {
                Query.Where(a => a.Capacity >= value);
            }
        }

        public class CapacityLessThan : Specification<Auto>
        {
            public CapacityLessThan(double value)
            {
                Query.Where(a => a.Capacity <= value);
            }
        }

        public class ByColor : Specification<Auto>
        {
            public ByColor(string color)
            {
                Query.Where(a => a.Color == color);
            }
        }

    }
}
