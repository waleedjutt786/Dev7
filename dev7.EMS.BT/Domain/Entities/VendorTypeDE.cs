
using dev7.EMS.BT.Domain;
using dev7.EMS.Domain.Entities;
using dev7.EMS.Domain.Vendor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dev7.EMS.Domain.VendorType
{
    [Table("VendorType")]
    public class VendorTypeDE : BaseDomain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public CompanyDE Company { get; set; }

        public ICollection<VendorDE> Vendor { get; set; }
    }
}