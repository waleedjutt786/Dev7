using dev7.EMS.BT.Utilities;
using dev7.EMS.Domain.ResultMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dev7.EMS.PT.Models
{
    public class ScheduleViewModel : ResultMessage
    {

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "StartTime")]
        public DateTime StartTime { get; set; }


        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "EndTime")]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "AddressLine")]
        public string AddressLine { get; set; }

        [Required]
        [Display(Name = "Zip/Postal Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State/Province")]
        public string Province { get; set; }


        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public bool HasError { get; set; }

        [Required]
        [DisplayName("EventDescription")]
        public string EventDescription { get; set; }

        [Required]
        [DisplayName("EventStatus")]
        public EventStatus EventStatus { get; set; }

    }
}