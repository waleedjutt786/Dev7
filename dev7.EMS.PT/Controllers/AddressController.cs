//using dev7.EMS.BT.Utilities.AppConstants;
//using dev7.EMS.Framework;
//using dev7.EMS.Model;
//using dev7.EMS.Model.Address;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Web;
//using System.Web.Mvc;

//namespace dev7.EMS.MVC.Controllers
//{
//    //[Authorize]
//    //[ValidateAntiForgeryToken]
//    public class AddressController : Controller
//    {
//        private readonly AddressService _addressService;
//        public AddressController()
//        {
//            _addressService = new AddressService();
//        }

//        public ActionResult GetAddressById(long id)
//        {
//            if (id > 0)
//            {
//                var address = _addressService.GetAddressById(id);
//                if (!address.HasErrors)
//                {
//                    address.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Address added"));
//                    RedirectToAction("Home", "Index");
//                }
//                address.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "AddNewAddress failed"));
//            }

//            return View();
//        }
//        public ActionResult GetAllAddresss()
//        {
            
//                var address = _addressService.GetAllAddresss();
//                if (address.HasErrors)
//                {
//                    address.AddSuccessMessage(string.Format(AppConstants.CRUD_GET, "Addresses get"));
//                    RedirectToAction("Home", "Index");
//                }
//            address.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "GetAllAddresss failed"));

//            return View(address);
//        }
//        public ActionResult AddNewAddress(AddressMD Address)
//        {
//            if (ModelState.IsValid)
//            {
//                var address = _addressService.AddAddress(Address);
//                if (!address.HasErrors)
//                {
//                    address.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Address added"));
//                    RedirectToAction("Home", "Index");
//                }
//                address.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "AddNewAddress failed"));
//            }

//            return View(Address);
//        }
//        public ActionResult UpdateAddress(AddressMD Address)
//        {
//            if (ModelState.IsValid)
//            {
//                var address = _addressService.ModifyAddress(Address);
//                if (!address.HasErrors)
//                {
//                    address.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Address modifeid"));
//                    RedirectToAction("Home", "Index");
//                }
//                address.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "UpdateAddress failed"));
//            }

//            return View(Address);
//        }
//        public ActionResult DeleteAddress(int id)
//        {
//            if (id > 0)
//            {
//                var address = _addressService.DeleteAddress(id);
//                if (!address.HasErrors)
//                {
//                    address.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Address deleted"));
//                    RedirectToAction("Home", "Index");
//                }
//                address.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "DeleteAddress failed"));
//            }

//            return View();
//        }

//    }
//}