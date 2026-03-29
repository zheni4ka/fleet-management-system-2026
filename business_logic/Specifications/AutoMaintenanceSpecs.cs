using Ardalis.Specification;
using business_logic.Entities;

namespace business_logic.Specifications
{
    public class AutoMaintenanceSpecs
    {
        public class ById : Specification<AutoMaintenance>
        {
            public ById(int id)
            {
                Query.Where(am => am.Id == id);
            }
        }

        public class All : Specification<AutoMaintenance>
        {
            public All()
            {
                Query.OrderBy(am => am.Id);
            }
        }

        public class ByDate : Specification<AutoMaintenance>
        {
            public ByDate(DateTime date)
            {
                Query.Where(am => am.ServiceDate.Date == date.Date);
            }
        }

        public class ByAutoId : Specification<AutoMaintenance>
        {
            public ByAutoId(int autoId)
            {
                Query.Where(am => am.AutoId == autoId);
            }
        }
    }
}
