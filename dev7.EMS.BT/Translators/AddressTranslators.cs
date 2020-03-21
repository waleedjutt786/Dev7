//using dev7.EMS.Domain.Address;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using dev7.EMS.Model.Address;

//namespace dev7.EMS.Translators.Address
//{
//  public static  class AddressTranslators
//    {
//        public static AddressDE Translate(this AddressMD from,AddressDE dest=null)
//        {
//            var to = dest ?? new AddressDE();
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
//            to.Address = from.Address;
//            to.Province = from.Province;
//            to.City = from.City;
//            to.Country = from.Country;
//            to.ZipCode = from.ZipCode;

//            return to;
//        }
//        public static AddressMD Translate(this AddressDE from)
//        {
//            var to = new AddressMD();
//            to.Id = from.Id;
//            to.Address = from.Address;
//            to.Province = from.Province;
//            to.City = from.City;
//            to.Country = from.Country;
//            to.ZipCode = from.ZipCode;
//            return to;

//        }
//        public static List<AddressMD> Translate(this List<AddressDE> list)
//        {
//            var addresses = new List<AddressMD>();
//            foreach (var from in list)
//            {
//                var to = new AddressMD();

//                to.Id = from.Id;
//                to.Address = from.Address;
//                to.Province = from.Province;
//                to.City = from.City;
//                to.Country = from.Country;
//                to.ZipCode = from.ZipCode;

//                addresses.Add(to);
//            }
//            return addresses;
//        }

//    }
//    }

