using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.BasicInfo
{
    public class BasicInfoMD : ModelBase
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string MeritalStatus { get; set; }
        public string Password { get; set; }

        public long AddressId { get; set; }

        public override bool IsValid
        {
            get
            {
                bool isValid = true;

                if (string.IsNullOrWhiteSpace(FirstName))
                {
                    this.AddErrorMessage("FirstName can not be empty");
                    isValid = false;
                }
                else if (string.IsNullOrWhiteSpace(LastName))
                {
                    this.AddErrorMessage("LastName can not be empty");
                    isValid = false;
                }
                else if (string.IsNullOrWhiteSpace(UserName))
                {
                    this.AddErrorMessage("UserName  can not be empty");
                    isValid = false;
                }
                else if (string.IsNullOrWhiteSpace(PhoneNumber))
                {
                    this.AddErrorMessage("PhoneNumber can not be empty");
                    isValid = false;
                }
                else if (string.IsNullOrWhiteSpace(Password))
                {
                    this.AddErrorMessage("Password can not be empty");
                    isValid = false;
                }


                return isValid;
            }
        }
    }
}
