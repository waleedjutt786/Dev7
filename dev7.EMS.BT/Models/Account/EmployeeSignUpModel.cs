using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Account
{
     public class EmployeeSignUpModel : ModelBase
    {
        #region Properties


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string MeritalStatus { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public long PayRate { get; set; }
        public string ExperianceLevel { get; set; }
        public string EducationLevel { get; set; }
        public System.DateTime DateOfHire { get; set; }
        public long Salary { get; set; }

        public bool TermAndCondition { get; set; } = true;

        #endregion Properties
    }
}
