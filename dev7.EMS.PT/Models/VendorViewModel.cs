using dev7.EMS.BT.Utilities;
using dev7.EMS.Domain.ResultMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dev7.EMS.PT.Models
{
    public class VendorViewModel
    {
        public int Id { get; set; }
        public string VendorType { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Vendor Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Image { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "DateOfJoin")]
        public DateTime DateOfJoin { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int VendorTypeId {get;set;}

        [Required]
        public int CompanyId { get; set; }

        public string Password { get; set; }
        public bool HasError { get; set; }
        public ResultMessage ErrorMessage { get; set; }

    }
}