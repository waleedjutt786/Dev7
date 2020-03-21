using dev7.EMS.BT.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Event
{
    public class EventMD:ModelBase
    {
        
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public EventStatus EventStatus { get; set; }
        public override bool IsValid
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace((Description)))
                {
                    this.AddErrorMessage("Description Can not be empty");
                    isValid = false;
                }
                return isValid;

            }


        }
    }
}
