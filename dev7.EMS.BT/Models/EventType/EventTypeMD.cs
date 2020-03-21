using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.EventType
{
    public class EventTypeMD:ModelBase
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public override bool IsValid
        {
            get
            {
                bool isValid = true;
                 if (string.IsNullOrWhiteSpace((Type)))
                {
                    this.AddErrorMessage("Type Can not be empty");
                    isValid = false;
                }
                else if (string.IsNullOrWhiteSpace((Description)))
                {
                    this.AddErrorMessage("Description Can not be empty");
                    isValid = false;
                }
                return isValid;

            }


        }
    }
}
