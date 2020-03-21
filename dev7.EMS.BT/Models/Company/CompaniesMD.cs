using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Company
{
    public class CompaniesMD : ModelBase
    {

        public CompaniesMD()
        {
            companies = new List<CompanyMD>();
        }
        public List<CompanyMD> companies { get; set; }

    }
}
