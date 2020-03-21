using dev7.EMS.Domain.ResultMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dev7.EMS.PT.Models
{
    public class AddVehicleViewModel : ResultMessage
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Vehicle Type")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Vehicle Number")]
        public string Number { get; set; }
        public bool HasErrorMessage { get; set; }
    }
    public class VehcileViewModel : ResultMessage
    {
        //public int Id { get; set; }   // using id from ResultMessage
        public bool HasErrorMessage { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Number { get; set; }
    }
}