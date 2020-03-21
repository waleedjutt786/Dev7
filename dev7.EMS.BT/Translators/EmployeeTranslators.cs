using System;
using dev7.EMS.Domain.Employee;
using dev7.EMS.Model.Employee;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dev7.EMS.Model;
using dev7.EMSP.Model.Account;
using dev7.EMS.Model.Account;

namespace dev7.EMS.Translators.Employee
{
   public static class EmployeeTranslators
    {
        public static EmployeeDE Translate(this EmployeeMD from, EmployeeDE dest = null)
        {
            var to = dest ?? new EmployeeDE();
            if (to.Id <= 0)
            {
                to.Id = from.Id;
                //to.IsActive = true;
            }
            else
            {

                to.IsActive = from.IsActive;
                //to.ModifiedDate = DateTime.Now;
            }
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Image = from.Image;
            to.Salary = from.Salary;
            to.DateOfBirth = from.DateOfBirth;
            to.CreatedDate = from.CreatedDate;
            to.DateOfHire = from.DateOfHire;
            to.DateOfLeaving = from.DateOfLeaving;
            to.Gender = from.Gender;
            to.MaritalStatus = from.MaritalStatus;
            to.CompanyId = from.CompanyId;
            to.CreatedById = from.CreatedById;
            to.IsValid = from.IsValid;
            to.IsActive = true;

            return to;
        }
        public static EmployeeMD Translate(this EmployeeDE from)
        {
            var to = new EmployeeMD();
            to.Id = from.Id;
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Image = from.Image;
            to.Salary = from.Salary;
            to.DateOfBirth = from.DateOfBirth;
            to.CreatedDate = from.CreatedDate;
            to.DateOfHire = from.DateOfHire;
            to.DateOfLeaving = from.DateOfLeaving;
            to.Gender = from.Gender;
            to.MaritalStatus = from.MaritalStatus;
            to.CompanyId = from.CompanyId;
            to.CreatedById = from.CreatedById;
            to.IsValid = from.IsValid;
            to.IsActive = true;
            to.CompanyId = from.CompanyId;
            return to;

        }
        public static List<EmployeeMD> Translate(this List<EmployeeDE> list)
        {
            var employees = new List<EmployeeMD>();
            foreach (var from in list)
            {
                var to = new EmployeeMD();

                to.Id = from.Id;
                to.FirstName = from.FirstName;
                to.LastName = from.LastName;
                to.Image = from.Image;
                to.Salary = from.Salary;
                to.DateOfBirth = from.DateOfBirth;
                to.CreatedDate = from.CreatedDate;
                to.DateOfHire = from.DateOfHire;
                to.DateOfLeaving = from.DateOfLeaving;
                to.Gender = from.Gender;
                to.MaritalStatus = from.MaritalStatus;
                to.CompanyId = from.CompanyId;
                to.CreatedById = from.CreatedById;
                to.IsValid = from.IsValid;
                to.IsActive = true;
                to.CompanyId = from.CompanyId;
                employees.Add(to);
            }
            return employees;
        }
        public static UserModel ToUserModel(this EmployeeDE from, UserModel dest = null)
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
        public static EmployeeDE Translate(this EmployeeSignUpModel from, EmployeeDE dest = null)
        {
            var to = dest ?? new EmployeeDE();
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
            //to.PayRate = from.PayRate;
            //to.ExperianceLevel = from.ExperianceLevel;
            //to.EducationLevel = from.EducationLevel;
            //to.DateOfHire = from.DateOfHire;
            //to.Salary = from.Salary;

            //to.AddressId = from.AddressId;
            //to.UserImagePath = from.UserImagePath;

            to.IsActive = from.IsActive;

            return to;
        }

    }
}
