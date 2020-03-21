using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using dev7.EMS.Model;
using dev7.EMS.Model.ViewModels;

namespace dev7.EMS.Services
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public UserModel User { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
