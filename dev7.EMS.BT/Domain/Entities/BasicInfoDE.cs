//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using dev7.EMS.Domain.Address;
//using dev7.EMS.Domain.Customer;
//using dev7.EMS.Domain.Employee;
//using dev7.EMS.BT.Domain;
////using dev7.EMS.Domain.Vendor;

//namespace dev7.EMS.Domain.BasicInfo
//{
//    [Table("BasicInfo")]
//    public class BasicInfoDE : BaseDomain
//    {
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string Email { get; set; }
//        public string PhoneNumber { get; set; }
//        public string DateOfBirth { get; set; }
//        public string MeritalStatus { get; set; }
//        public string Password { get; set; }
//        public string ImagePath { get; set; }
//        public string PasswordForgetKey { get; set; }

//        [ForeignKey("Address")]
//        public long AddressId { get; set; }
//        public AddressDE Address { get; set; }

//        public ICollection<CustomerDE> Customer { get; set; }
//        public ICollection<EmployeeDE> Employee { get; set; }
//        //public ICollection<VendorDE> VendorDE { get; set; }

//    }
//}