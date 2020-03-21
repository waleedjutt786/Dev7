using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Company
{
    public class CompanyMD : ModelBase
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Logo { get; set; }

        public override bool IsValid
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(Name))
                {
                    this.AddErrorMessage("Name can not be empty");
                    isValid = false;
                }
                return isValid;
            }
        }
    }
}
