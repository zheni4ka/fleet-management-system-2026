using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.Specification;
using business_logic.Entities;

namespace business_logic.Specifications
{
    public class DriverSpecs : Specification<Driver>
    {
        public class ById : Specification<Driver>
        {
            public ById(int id)
            {
                Query.Where(d => d.Id == id);
            }
        }

        public class ByName : Specification<Driver>
        {
            public ByName(string name)
            {
                Query.Where(d => d.Name == name);
            }
        }

        public class All : Specification<Driver>
        {
            public All()
            {
                Query.OrderBy(d => d.Id);
            }
        }
    }
}
