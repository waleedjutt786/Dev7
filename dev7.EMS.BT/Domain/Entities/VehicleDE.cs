using dev7.EMS.BT.Domain;
//using dev7.EMS.BT.Domain.Entities;
using dev7.EMS.Domain.Entities;
using dev7.EMS.Domain.VehicleFuel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dev7.EMS.Domain.Vehicle
{
    [Table("Vehicle")]
    public class VehicleDE : BaseDomain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyDE Company { get; set; }

        //[ForeignKey("VehicleType")]
        //public int VehicleTypeId { get; set; }
        //public VehicleTypeDE VehicleType { get; set; }

        ////public ICollection<VehicleTypeDE> VehicleType { get; set; }
        public ICollection<VehicleFuelDE> VehicleFuel { get; set; }

    }
}