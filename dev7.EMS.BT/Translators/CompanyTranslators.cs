using System;
using dev7.EMS.Model.Company;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dev7.EMS.Model;
using dev7.EMSP.Model.Account;
using dev7.EMS.Model.Account;
using dev7.EMS.Domain.Entities;

namespace dev7.EMS.Translators.Company
{
    public static class CompanyTranslators
    {
        public static CompanyDE Translate(this CompanyMD from, CompanyDE dest = null)
        {
            var to = dest ?? new CompanyDE();
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
            to.Name = from.Name;
            //to.Password = from.Password;

            //to.Email = from.Email;        
            //to.ContactNo = from.ContactNo;
            to.Logo = from.Logo;
            //to.Salt = from.Salt;
            //to.PasswordForgetKey = from.PasswordForgetKey;
            to.ImagePath = from.ImagePath;
           

            return to;
        }
        public static CompanyMD Translate(this CompanyDE from)
        {
            var to = new CompanyMD();
            to.Id = from.Id;
            to.Name = from.Name;
            //to.Password = from.Password;

            //to.Email = from.Email;
            //to.ContactNo = from.ContactNo;
            to.Logo = from.Logo;
            //to.Salt = from.Salt;
            //to.PasswordForgetKey = from.PasswordForgetKey;
            to.ImagePath = from.ImagePath;

            return to;

        }
        public static List<CompanyMD> Translate(this List<CompanyDE> list)
        {
            var companies = new List<CompanyMD>();
            foreach (var from in list)
            {
                var to = new CompanyMD();

                to.Id = from.Id;
                to.Name = from.Name;
                //to.Password = from.Password;

                //to.Email = from.Email;
                //to.ContactNo = from.ContactNo;
                to.Logo = from.Logo;
                //to.Salt = from.Salt;
                //to.PasswordForgetKey = from.PasswordForgetKey;
                to.ImagePath = from.ImagePath;

                companies.Add(to);
            }
            return companies;
        }
        public static UserModel ToUserModel(this CompanyDE from, UserModel dest = null)
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
           // to.LastName = from.bas.LastName;
            ////to.Email = from.Email;
            ////to.Password = from.Password;
            ////to.FirstName = from.Name;
            
            ///////////////////////////
            ////to.MobilePhone = from.ContactNo;
            //to.Logo = from.Logo;
            //to.CompanyName = from.CompanyName;
            //to.AddressId = from.AddressId;
            //to.UserImagePath = from.UserImagePath;
            //to.Biography = from.Biography;
            //to.CreatedById = from.CreatedById;
            //to.CreatedDate = from.CreatedDate;
            //////////////////////////////

            //to.Salt = from.Salt;                                  //salt
            to.IsActive = from.IsActive;

            return to;
        }
        public static CompanyDE Translate(this CompanySignUpModel from, CompanyDE dest = null)
        {
            var to = dest ?? new CompanyDE();
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
            to.Name = from.CompanyName;
            ////to.Email = from.Email;
            ////to.Password = from.Password;
            ////to.ContactNo = from.Phone;
            //to.Logo = from.Logo;
            //to.CompanyName = from.CompanyName;
            //to.AddressId = from.AddressId;
            //to.UserImagePath = from.UserImagePath;
            //to.Biography = from.Biography;
            //to.CreatedById = from.CreatedById;
            //to.CreatedDate = from.CreatedDate;
            //to.IsActive = from.IsActive;

            return to;
        }
       
    }
}
