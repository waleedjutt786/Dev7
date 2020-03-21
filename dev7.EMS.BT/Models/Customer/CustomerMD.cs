using dev7.EMS.BT.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Customer
{
    public class CustomerMD : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public int CompanyId { get; set; }

        public override bool IsValid
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(FirstName))
                {
                    this.AddErrorMessage("First Name can not be empty");
                    isValid = false;
                }
                else if (string.IsNullOrWhiteSpace(LastName))
                {
                    this.AddErrorMessage("Last Name can not be empty");
                    isValid = false;
                }
                return isValid;

            }
        }
    }
}
