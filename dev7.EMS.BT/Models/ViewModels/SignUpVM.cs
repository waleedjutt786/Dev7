using dev7.EMS.Model;
using dev7.EMSP.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.ViewModels
{
    public class SignUpViewModel : BaseLoginViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpViewModel"/> class.
        /// </summary>
        public SignUpViewModel()
        {
            Signup = new SignUpModel();
        }

        public SignUpModel Signup { get; set; }
    }
}
