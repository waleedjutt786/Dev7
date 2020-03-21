using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Schedule
{
    public class ScheduleMD:ModelBase
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }


        public override bool IsValid
        {
            get
            {
                bool isValid = true;
                if (Date.Equals(0.0) || Date.Equals(" "))
                {
                    this.AddErrorMessage("Date can not be empty");
                    isValid = false;
                }
                if (StartTime.Equals(0.0) || StartTime.Equals(" "))
                {
                    this.AddErrorMessage("StartTime can not be empty");
                    isValid = false;
                }
                if (EndTime.Equals(0.0) || EndTime.Equals(" "))
                {
                    this.AddErrorMessage("EndTime can not be empty");
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(AddressLine))
                {
                    this.AddErrorMessage("AddressLine can not be empty");
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(City))
                {
                    this.AddErrorMessage("City can not be empty");
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(Province))
                {
                    this.AddErrorMessage("Province can not be empty");
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(Country))
                {
                    this.AddErrorMessage("Country can not be empty");
                    isValid = false;
                }
                return isValid;

            }


        }
    }
}
