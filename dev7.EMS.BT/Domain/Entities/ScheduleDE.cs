using dev7.EMS.BT.Domain;
using dev7.EMS.Domain.Event;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev7.EMS.Domain.Schedule
{
    [Table("Schedule")]
    public class ScheduleDE : BaseDomain
    {
        [Key , ForeignKey ("Event")]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ZipCode  { get; set; }

        public virtual EventDE Event { get; set; }





    }
}