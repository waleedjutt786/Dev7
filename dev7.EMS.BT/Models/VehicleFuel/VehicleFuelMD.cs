using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.VehicleFuel
{
    public class VehicleFuelMD:ModelBase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public int EmployeeId { get; set; }
        public int VehicleId { get; set; }

        public override bool IsValid
        {
            get
            {
                bool isValid = true;
                if (Date.Equals(0.0) || Date.Equals(" "))
                {
                    this.AddErrorMessage("Date can not be empty");
                    isValid = false;
                }
                else if (Amount.Equals(0.0) || Amount.Equals(" "))
                {
                    this.AddErrorMessage("Amount can not be empty");
                    isValid = false;
                }

                return isValid;
            }
        }


    }
}
