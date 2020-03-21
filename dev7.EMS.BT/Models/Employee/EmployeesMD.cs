using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Employee
{
   public class EmployeesMD : ModelBase
    {
        public EmployeesMD()
        {
            employees = new List<EmployeeMD>();
        }
        public List<EmployeeMD> employees { get; set; }
    }

}
