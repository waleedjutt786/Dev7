
using dev7.EMS.Model;

namespace dev7.EMSP.Model.Account
{
    public class SignUpModel : ModelBase
    {
        #region Properties


        public string Phone { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string MeritalStatus { get; set; }
        public string Password { get; set; }

        public long PayRate { get; set; }
        public string ExperianceLevel { get; set; }
        public string EducationLevel { get; set; }
        public System.DateTime DateOfHire { get; set; }
        public long Salary { get; set; }
        public System.DateTime DateOfLeaving { get; set; }
        public System.DateTime DateOfRegistration { get; set; }

        public bool TermAndCondition { get; set; } = true;

        #endregion Properties
    }
}
