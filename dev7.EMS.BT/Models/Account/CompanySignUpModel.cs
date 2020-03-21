using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Account
{
    public class CompanySignUpModel : ModelBase
    {
        #region Properties

        public string Phone { get; set; }

        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }

        public bool TermAndCondition { get; set; } = true;

        #endregion Properties
    }
}
