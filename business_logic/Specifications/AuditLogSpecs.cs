using Ardalis.Specification;
using business_logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Specifications
{
    public class AuditLogSpecs 
    {
        public class ById : Specification<AuditLog>
        {
            ById(int id)
            {
                Query.Where(x => x.Id == id);
            }
        }

        public class All : Specification<AuditLog>
        {
            All()
            {
                Query.OrderBy(x => x.Id);
            }
        }
    }
}
