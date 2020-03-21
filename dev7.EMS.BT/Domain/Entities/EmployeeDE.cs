using dev7.EMS.BT.Domain;
using dev7.EMS.BT.Utilities;
//using dev7.EMS.Domain.BasicInfo;
using dev7.EMS.Domain.Entities;
using dev7.EMS.Domain.VehicleFuel;
using dev7.EMS.PT.Models;
//using dev7.EMS.Domain.Designation;
//using dev7.EMS.Domain.EventStaff;
//using dev7.EMS.Domain.VehicleFuel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dev7.EMS.Domain.Employee
{
    [Table("Employee")]
    public class EmployeeDE : BaseDomain
    {
        [Key, ForeignKey("ApplicationUser")]
        public virtual int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public long Salary { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string Image { get; set; }
        public DateTime DateOfHire { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfLeaving { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyDE Company { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<VehicleFuelDE> VehicleFuel { get; set; }

        //public long PayRate { get; set; }
        //public string ExperianceLevel { get; set; }
        //public string EducationLevel { get; set; }
        //public DateTime DateOfHire { get; set; }
        //public long Salary { get; set; }
        //public DateTime DateOfLeaving { get; set; }
        //public string Salt { get; set; }

        //[ForeignKey("BasicInfo")]
        //public long BasicInfoId { get; set; }
        //public BasicInfoDE BasicInfo { get; set; }
        //public ICollection<DesignationDE> DesignationDE { get; set; }
        //public ICollection<EventStaffDE> EventStaffDE { get; set; }

    }
}