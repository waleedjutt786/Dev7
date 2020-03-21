using System;
using dev7.EMS.Domain.Customer;
using dev7.EMS.Model.Customer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dev7.EMS.Model;
using dev7.EMSP.Model.Account;
using dev7.EMS.Model.Account;

namespace dev7.EMS.Translators.Customer
{
    public static class CustomerTranslators
    {
        public static CustomerDE Translate(this CustomerMD from, CustomerDE dest = null)
        {
            var to = dest ?? new CustomerDE();
            if (to.Id <= 0)
            {
                to.Id = from.Id;
                to.IsActive = true;
            }
            else
            {

                to.IsActive = from.IsActive;
                //to.ModifiedDate = DateTime.Now;
            }
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Image = from.Image;
            to.DateOfBirth = from.DateOfBirth;
            to.CreatedDate = from.CreatedDate;
            to.Gender = from.Gender;
            to.CompanyId = from.CompanyId;
            to.CreatedById = from.CreatedById;
            to.IsValid = from.IsValid;

            return to;
        }
        public static CustomerMD Translate(this CustomerDE from)
        {
            var to = new CustomerMD();
            to.Id = from.Id;
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Image = from.Image;
            to.DateOfBirth = from.DateOfBirth;
            to.CreatedDate = from.CreatedDate;
            to.Gender = from.Gender;
            to.CompanyId = from.CompanyId;
            to.CreatedById = from.CreatedById;
            to.IsValid = from.IsValid;

            return to;

        }
        public static List<CustomerMD> Translate(this List<CustomerDE> list)
        {
            var customers = new List<CustomerMD>();
            foreach (var from in list)
            {
                var to = new CustomerMD();

                to.Id = from.Id;
                to.FirstName = from.FirstName;
                to.LastName = from.LastName;
                to.Image = from.Image;
                to.DateOfBirth = from.DateOfBirth;
                to.CreatedDate = from.CreatedDate;
                to.Gender = from.Gender;
                to.CompanyId = from.CompanyId;
                to.CreatedById = from.CreatedById;
                to.IsValid = from.IsValid;

                customers.Add(to);
            }
            return customers;
        }
        public static UserModel ToUserModel(this CustomerDE from, UserModel dest = null)
        {
            var to = dest ?? new UserModel();
            if (to.Id <= 0)
            {
                to.Id = from.Id;
                to.IsActive = true;
            }
            else
            {
                to.IsActive = from.IsActive;
                //to.ModifiedDate = DateTime.Now;
            }
            ////to.LastName = from.BasicInfo.LastName;
            ////to.Email = from.BasicInfo.Email;
            ////to.Password = from.BasicInfo.Password;
            ////to.FirstName = from.BasicInfo.FirstName;
            //to.ContactNo = from.ContactNo;
            //to.Logo = from.Logo;
            //to.CompanyName = from.CompanyName;
            //to.AddressId = from.AddressId;
            //to.UserImagePath = from.UserImagePath;
            //to.Biography = from.Biography;
            //to.CreatedById = from.CreatedById;
            //to.CreatedDate = from.CreatedDate;
            //to.Salt = from.Salt;                                  //salt
            to.IsActive = from.IsActive;

            return to;
        }
        public static CustomerDE Translate(this CustomerSignUpModel from, CustomerDE dest = null)
        {
            var to = dest ?? new CustomerDE();
            if (to.Id <= 0)
            {
                to.Id = from.Id;
                to.IsActive = true;
            }
            else
            {
                to.IsActive = from.IsActive;
                //to.ModifiedDate = DateTime.Now;
            }
            //to.BasicInfo.FirstName = from.FirstName;
            //to.BasicInfo.LastName = from.LastName;
            //to.BasicInfo.Email = from.Email;
            //to.BasicInfo.Password = from.Password;
            //to.BasicInfo.PhoneNumber = from.Phone;
            //to.BasicInfo.DateOfBirth = from.DateOfBirth;
            //to.BasicInfo.MeritalStatus = from.MeritalStatus;

            //to.AddressId = from.AddressId;
            //to.UserImagePath = from.UserImagePath;

            to.IsActive = from.IsActive;

            return to;
        }

    }
}

