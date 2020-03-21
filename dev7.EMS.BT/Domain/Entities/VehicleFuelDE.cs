using dev7.EMS.BT.Domain;
using dev7.EMS.Domain.Employee;
using dev7.EMS.Domain.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dev7.EMS.Domain.VehicleFuel
{
    [Table("VehicleFuel")]
    public class VehicleFuelDE : BaseDomain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public EmployeeDE Employee { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public VehicleDE Vehicle { get; set; }

    }
}