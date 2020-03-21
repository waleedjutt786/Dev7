using dev7.EMS.BT.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Employee
{
    public class EmployeeMD:ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public long Salary { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string Image { get; set; }
        public DateTime DateOfHire { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public int CompanyId { get; set; }

        public override bool IsValid
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(FirstName))
                {
                    this.AddErrorMessage("First Name Can not be empty");
                    isValid = false;
                }
                else if (string.IsNullOrWhiteSpace(LastName))
                {
                    this.AddErrorMessage("Last Name Can not be empty");
                    isValid = false;
                }
                //else if (DateOfHire.Equals(0.0) || DateOfHire.Equals(" "))
                //{
                //    this.AddErrorMessage("DateOfHire can not be empty");
                //    isValid = false;
                //}
                //else if (CompanyId <= 0)
                //{
                //    this.AddErrorMessage("CompanyId can not be empty");
                //    isValid = false;
                //}




                return isValid;
            }
        }
    }
}
