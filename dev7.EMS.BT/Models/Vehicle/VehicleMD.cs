using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Vehicle
{
    public class VehicleMD:ModelBase
    {
        //public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public int CompanyId { get; set; }

        public override bool IsValid
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace((Type)))
                {
                    this.AddErrorMessage("Type Can not be empty");
                    isValid = false;
                }
                else if (string.IsNullOrWhiteSpace((Number)))
                {
                    this.AddErrorMessage("Number Can not be empty");
                    isValid = false;
                }

                return isValid;
            }
        }
    }
}
