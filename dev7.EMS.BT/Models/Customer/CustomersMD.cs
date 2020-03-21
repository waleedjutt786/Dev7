using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Customer
{
    public class CustomersMD : ModelBase
    {
        public CustomersMD()
        {
            customers = new List<CustomerMD>();
        }
        public List<CustomerMD> customers { get; set; }
    }
}