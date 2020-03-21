using dev7.EMS.BT.Utilities;
using dev7.EMS.Framework;
using dev7.EMS.Model;
using dev7.EMS.Model.Customer;
using dev7.EMS.PT;
using dev7.EMS.PT.Models;
using dev7.EMS.Services.Services.Customer;
using dev7.EMS.Translators.Customer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace dev7.EMS.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;
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
        public CustomerController()
        {
            _customerService = new CustomerService();
        }
        [AllowAnonymous]
        public ActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterCustomer(RegisterCustomerViewModel model)
        {
            //if (model.Gender != Gender.Male || model.Gender != Gender.Female) model.Gender 
            if (ModelState.IsValid)
            {
                var randomNumber = new Random();
                model.Password = model.FirstName + "@P" + randomNumber.Next(1, 999999999);

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    CustomerMD customer = new CustomerMD();
                    customer.FirstName = model.FirstName;
                    customer.LastName = model.LastName;
                    customer.Gender = model.Gender;
                    customer.DateOfBirth = model.DateOfBirth;
                    customer.CreatedDate = DateTime.Now;
                    customer.Image = "";
                    customer.Id = user.Id;
                    customer.CompanyId = Convert.ToInt32(User.Identity.GetUserId());
                    customer.CreatedById = Convert.ToInt64(User.Identity.GetUserId());

                    //user.Customer = customer.Translate();
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    var res = _customerService.RegisterCustomer(customer);
                    if (res.HasErrors)
                    {
                        await UserManager.DeleteAsync(user);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        public async Task<ActionResult> ViewAllCustomers()
        {
            EMSDbContext db = new EMSDbContext();
            var customersList = new List<CustomerViewModel>();

            int _companyId = Convert.ToInt32(User.Identity.GetUserId());
            if (_companyId > 0)
            {
                try
                {
                    var customers = _customerService.GetAllCustomers(_companyId);
                    foreach (var obj in customers.customers)
                    {
                        var customer = new CustomerViewModel();
                        var user = db.Users.Where(x => x.Id == obj.Id).FirstOrDefault();
                        customer.FullName = obj.FirstName + " " + obj.LastName;
                        customer.DateOfBirth = obj.DateOfBirth;
                        customer.Gender = obj.Gender;
                        customer.Email = user.Email;
                        customer.PhoneNumber = user.PhoneNumber;

                        customersList.Add(customer);
                    }
                }
                catch (Exception ex) { }

            }
            return View(customersList);
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