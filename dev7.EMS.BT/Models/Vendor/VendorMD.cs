using dev7.EMS.BT.Utilities;
using dev7.EMS.Model;
using System;

namespace dev7.ems.model.vendor
{
    public class VendorMD : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public DateTime DateOfJoin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int VendorTypeId { get; set; }
        public int CompanyId { get; set; }
       

        public override bool IsValid
        {
            get
            {
                bool IsValid = true;

                if (string.IsNullOrWhiteSpace((FirstName)))
                {
                    this.AddErrorMessage("FirstName can not be empty");
                    IsValid = false;
                }
                else if (string.IsNullOrWhiteSpace((LastName)))
                {
                    this.AddErrorMessage("LastName can not be empty");
                    IsValid = false;
                }
                else if (Gender.Equals(null))
                {
                    this.AddErrorMessage("Gender can not be empty");
                    IsValid = false;
                }
                else if (DateOfJoin.Equals(null))
                {
                    this.AddErrorMessage("DateOfJoin can not be empty");
                    IsValid = false;
                }

                return IsValid;
            }
        }

    }
}
