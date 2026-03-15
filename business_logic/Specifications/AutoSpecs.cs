using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.Specification;
using business_logic.Entities;

namespace business_logic.Specifications
{
    public class AutoSpecs : Specification<Auto>
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

        public class ByColor : Specification<Auto>
        {
            public ByColor(string color)
            {
                Query.Where(a => a.Color == color);
            }
        }

    }
}
