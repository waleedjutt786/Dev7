using dev7.EMS.Domain.ResultMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dev7.EMS.PT.Models
{
    public class VendorTypeViewModel : ResultMessage
    {
        

        [Required]
        [DisplayName("Vendor Type")]
        public string Type { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        public bool HasErrorMessage { get; set; }

    }
}