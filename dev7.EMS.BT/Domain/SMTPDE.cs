using dev7.EMS.BT.Domain;
using dev7.EMS.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Domain.SMTPDE
{
    public class SMTPDE : BaseDomain
    {
        public long Id { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public long AppId { get; set; }
        [NotMapped]
        public override bool IsValid 
        {
            get
            {
                bool isValid = true;
                if (Id == default(long))
                {
                    this.AddErrorMessage("Id is emtpy");
                    isValid = false;
                }
                else if (Host == default(string))
                {
                    this.AddErrorMessage("Host is emtpy");
                    isValid = false;
                }
                else if (User == default(string))
                {
                    this.AddErrorMessage("User is emtpy");
                    isValid = false;
                }
                else if (Password == default(string))
                {
                    this.AddErrorMessage("Password is emtpy");
                    isValid = false;
                }
                else if (Port == default(long))
                {
                    this.AddErrorMessage("Port is emtpy");
                    isValid = false;
                }
                else if (AppId == default(long))
                {
                    this.AddErrorMessage("AppId is emtpy");
                    isValid = false;
                }

                return isValid;
            }
        }
    }
}
