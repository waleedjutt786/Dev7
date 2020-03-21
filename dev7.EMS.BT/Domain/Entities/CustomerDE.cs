using dev7.EMS.BT.Domain;
using dev7.EMS.BT.Utilities;
//using dev7.EMS.Domain.BasicInfo;
using dev7.EMS.Domain.Entities;
using dev7.EMS.Domain.Event;
using dev7.EMS.PT.Models;
//using dev7.EMS.Domain.Event;
//using dev7.EMS.Domain.Feedback;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dev7.EMS.Domain.Customer
{
    [Table("Customer")]
    public class CustomerDE : BaseDomain
    {
        [Key, ForeignKey("ApplicationUser")]
        public virtual int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        // public int MaritalStatus { get; set; }
        public string Image { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyDE Company { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }



        //[ForeignKey("BasicInfo")]
        //public long BasicInfoId { get; set; }
        //public BasicInfoDE BasicInfo { get; set; }

        public ICollection<EventDE> EventDE { get; set; }
        //public ICollection<FeedbackDE> FeedbackDE { get; set; }




    }
}