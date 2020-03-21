using dev7.EMS.Domain.ResultMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dev7.EMS.PT.Models
{
    public class AddVehicleFuelViewModel :ResultMessage
    {
        public int Id { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public double Amount { get; set; }


        [Required]
        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public bool HasErrorMessage { get; set; }
    }

    public class VehicleFuelViewModel : ResultMessage
    {
        public int VehicleId { get; set; }
        public int VehicleFuelId { get; set; }
        public int EmployeeId { get; set; }
        public string VehicleType { get; set; }
        public string VehicleNumber { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public bool HasErrorMessage { get; set; }


    }
}
