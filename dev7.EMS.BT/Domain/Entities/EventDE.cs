using dev7.EMS.BT.Domain;
using dev7.EMS.BT.Utilities;
using dev7.EMS.Domain.Customer;
using dev7.EMS.Domain.Entities;
using dev7.EMS.Domain.Schedule;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev7.EMS.Domain.Event
{
    [Table("Event")]
    public class EventDE : BaseDomain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public EventStatus EventStatus { get; set; }


        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyDE Company { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public CustomerDE Customer { get; set; }

        public virtual ScheduleDE Schedule { get; set; }






    }
}