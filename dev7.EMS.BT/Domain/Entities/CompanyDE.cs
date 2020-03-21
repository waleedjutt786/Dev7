using dev7.EMS.BT.Domain;
//using dev7.EMS.Domain.Address;
using dev7.EMS.Domain.Customer;
//using dev7.EMS.Domain.Designation;
using dev7.EMS.Domain.Employee;
using dev7.EMS.Domain.Vehicle;
using dev7.EMS.PT.Models;
//using dev7.EMS.Domain.EventTemplate;
//using dev7.EMS.Domain.Vehicle;
using dev7.EMS.Domain.Vendor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using dev7.EMS.Domain.VendorType;
using dev7.EMS.Domain.EventType;
using dev7.EMS.Domain.Event;

namespace dev7.EMS.Domain.Entities
{
    [Table("Company")]
    public class CompanyDE : BaseDomain
    {
        [Key, ForeignKey("ApplicationUser")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Logo { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public ICollection<CustomerDE> Customer { get; set; }
        public ICollection<EmployeeDE> Employee { get; set; }
        public ICollection<VehicleDE> Vehicles { get; set; }
        public ICollection<VendorTypeDE> VendorType { get; set; }
        public ICollection<EventTypeDE> EventType { get; set; }
        public ICollection<EventDE> Event { get; set; }












        //public string Password { get; set; }

        //public string Email { get; set; }
        //public string ContactNo { get; set; }
        //public string Salt { get; set; } 
        //public string PasswordForgetKey { get; set; }

        /// <summary>
        /// ///// Company Address
        /// </summary>
        /// 
        //public string Country { get; set; }
        //public string Province { get; set; }
        //public string City { get; set; }
        //public long ZipCode { get; set; }
        //public string AddressLine1 { get; set; }
        //public string AddressLine2 { get; set; }
        /// <summary>
        /// //////////// end
        /// </summary>



        //[ForeignKey("Address")]
        //public long AddressId { get; set; }
        //public AddressDE Address { get; set; }

        //public ICollection<EventTemplateDE> EventTemplateDE { get; set; }
        //public ICollection<DesignationDE> DesignationDE { get; set; }
        //public ICollection<VehicleDE> Vehicle { get; set; }
        //public ICollection<VendorDE> VendorDE { get; set; }




    }
}