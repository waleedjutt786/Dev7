using dev7.EMS.BT.Domain;
using dev7.EMS.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev7.EMS.Domain.EventType
{
    [Table("EventType")]
    public class EventTypeDE : BaseDomain
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyDE Company { get; set; }

        //public ICollection<EventTemplateDE> EventTemplateDE { get; set; }

    }
}