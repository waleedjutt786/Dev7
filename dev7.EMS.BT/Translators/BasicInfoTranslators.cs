//using dev7.EMS.Domain.BasicInfo;
//using dev7.EMS.Model.BasicInfo;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace dev7.EMS.Translators.BasicInfo
//{
//    public static class BasicInfoTranslators
//    {
//        public static BasicInfoDE Translate(this BasicInfoMD from, BasicInfoDE dest = null)
//        {
//            var to = dest ?? new BasicInfoDE();
//            if (to.Id <= 0)
//            {
//                to.Id = from.Id;
//                to.IsActive = true;
//            }
//            else
//            {

//                to.IsActive = from.IsActive;
//                //to.ModifiedDate = DateTime.Now;
//            }
//            to.FirstName = from.FirstName;
//            to.LastName = from.LastName;
//            to.Email = from.Email;
//            to.Email = from.Email;
//            to.PhoneNumber = from.PhoneNumber;
//            to.DateOfBirth = from.DateOfBirth;
//            to.MeritalStatus = from.MeritalStatus;
//            to.Password = from.Password;
//            to.AddressId = from.AddressId;

//            return to;
//        }
//        public static BasicInfoMD Translate(this BasicInfoDE from)
//        {
//            var to = new BasicInfoMD();
//            to.Id = from.Id;
//            to.FirstName = from.FirstName;
//            to.LastName = from.LastName;
//            to.Email = from.Email;
//            to.Email = from.Email;
//            to.PhoneNumber = from.PhoneNumber;
//            to.DateOfBirth = from.DateOfBirth;
//            to.MeritalStatus = from.MeritalStatus;
//            to.Password = from.Password;
//            to.AddressId = from.AddressId;
//            return to;

//        }
//        public static List<BasicInfoMD> Translate(this List<BasicInfoDE> list)
//        {
//            var basicinfos = new List<BasicInfoMD>();
//            foreach (var from in list)
//            {
//                var to = new BasicInfoMD();

//                to.Id = from.Id;
//                to.FirstName = from.FirstName;
//                to.LastName = from.LastName;
//                to.Email = from.Email;
//                to.Email = from.Email;
//                to.PhoneNumber = from.PhoneNumber;
//                to.DateOfBirth = from.DateOfBirth;
//                to.MeritalStatus = from.MeritalStatus;
//                to.Password = from.Password;
//                to.AddressId = from.AddressId;
//                basicinfos.Add(to);
//            }
//            return basicinfos;
//        }

//    }
//}
