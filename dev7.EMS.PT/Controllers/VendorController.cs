using dev7.ems.model.vendor;
using dev7.EMS.PT.Models;
using dev7.EMS.Services.Services.Vendor;
using dev7.EMS.Services.Services.VendorType;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace dev7.EMS.PT.Controllers
{
    public class VendorController : Controller
    {
        private readonly VendorService _vendorService;
        private readonly VendorTypeService _vendortypeService;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public VendorController()
        {
            _vendorService = new VendorService();
            _vendortypeService = new VendorTypeService();
        }
        [AllowAnonymous]
        public ActionResult RegisterVendor()
        {
            var result = _vendortypeService.GetAllVendorTypes(Convert.ToInt32(User.Identity.GetUserId()));
            ViewBag.VendorTypes = result.vendortypes;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterVendor(VendorViewModel model)
        {
            //if (model.Gender != Gender.Male || model.Gender != Gender.Female) model.Gender 
            if (ModelState.IsValid)
            {
                var randomNumber = new Random();
                model.Password = model.FirstName + "@P" + randomNumber.Next(1, 99999);

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    VendorMD vendor = new VendorMD();
                    vendor.FirstName = model.FirstName;
                    vendor.LastName = model.LastName;
                    vendor.Gender = model.Gender;
                    vendor.DateOfJoin = model.DateOfJoin;
                    vendor.DateOfBirth = model.DateOfBirth;
                    vendor.Image = "";
                    vendor.Id = user.Id;
                    vendor.VendorTypeId = model.VendorTypeId;
                    vendor.CompanyId = Convert.ToInt32(User.Identity.GetUserId());
                    vendor.CreatedById = Convert.ToInt64(User.Identity.GetUserId());
                    vendor.CreatedDate = DateTime.Now;

                    //vendor.IsValid = true;

                    var res = _vendorService.AddVendor(vendor);
                    if (res.HasErrors)
                    {
                        model.HasError = true;
                        //model.ErrorMessage.Message = res.ResultMessages.FirstOrDefault().Message;
                        //model.ErrorMessage.MessageType =  "Try again! " + res.ResultMessages.FirstOrDefault().MessageType;
                        await UserManager.DeleteAsync(user);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        public async Task<ActionResult> ViewAllVendors()
        {
            var vendorsList = new List<VendorViewModel>();

            int _companyId = Convert.ToInt32(User.Identity.GetUserId());
            if (_companyId > 0)
            {
                try
                {
                    EMSDbContext db = new EMSDbContext();
                    var vendors = _vendorService.GetAllVendors(_companyId);
                    foreach (var obj in vendors.vendors)
                    {
                        var vendor = new VendorViewModel();
                        var user = db.Users.Where(x => x.Id == obj.Id).FirstOrDefault();
                        vendor.FullName = obj.FirstName + " " + obj.LastName;
                        vendor.DateOfBirth = obj.DateOfBirth;
                        vendor.Gender = obj.Gender;
                        vendor.DateOfJoin = obj.DateOfJoin;
                        vendor.DateOfBirth = obj.DateOfBirth;
                        vendor.Email = user.Email;
                        vendor.PhoneNumber = user.PhoneNumber;
                        vendor.VendorType = _vendortypeService.GetVendorTypeById(obj.VendorTypeId).Type;

                        vendorsList.Add(vendor);
                    }
                }
                catch (Exception ex) { }

            }
            return View(vendorsList);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}