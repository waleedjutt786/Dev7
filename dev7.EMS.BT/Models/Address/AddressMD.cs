using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Address
{
    public class AddressMD:ModelBase
    {
        public string City { get; set; }
        public string Province { get; set; }
        public long ZipCode { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        public override bool IsValid
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(City))
                {
                    this.AddErrorMessage("City can not be empty");
                    isValid = false;
                }
               else if (string.IsNullOrWhiteSpace(Province))
                {
                    this.AddErrorMessage("Province can not be empty");
                    isValid = false;
                }

                else if (string.IsNullOrWhiteSpace(Country))
                {
                    this.AddErrorMessage("Country can not be empty");
                    isValid = false;
                }
                else if (string.IsNullOrWhiteSpace(Address))
                {
                    this.AddErrorMessage("Address  can not be empty");
                    isValid = false;

                }
                return isValid;
            }
        }
    }
}
