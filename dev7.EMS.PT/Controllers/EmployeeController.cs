using dev7.EMS.Model.Employee;
using dev7.EMS.PT.Models;
using dev7.EMS.Services.Services.Employee;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace dev7.EMS.PT.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
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
        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }
        [AllowAnonymous]
        public ActionResult RegisterEmployee()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterEmployee(EmployeeViewModel model)
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
                    EmployeeMD employee = new EmployeeMD();
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.Gender = model.Gender;
                    employee.MaritalStatus = model.MaritalStatus;
                    employee.Salary = model.Salary;
                    employee.DateOfBirth = model.DateOfBirth;

                    employee.DateOfLeaving = new DateTime(1900,01,01);

                    employee.DateOfHire = model.DateOfHire;
                    employee.CreatedDate = DateTime.Now;
                    employee.Image = "";
                    employee.Id = user.Id;
                    employee.CompanyId = Convert.ToInt32(User.Identity.GetUserId());
                    employee.CreatedById = Convert.ToInt64(User.Identity.GetUserId());
                    employee.IsValid = true;

                    var res = _employeeService.RegisterEmployee(employee);
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
        public async Task<ActionResult> ViewAllEmployees()
        {
            var employeesList = new List<EmployeeViewModel>();

            int _companyId = Convert.ToInt32(User.Identity.GetUserId());
            if (_companyId > 0)
            {
                try
                {
                    EMSDbContext db = new EMSDbContext();
                    var employees = _employeeService.GetAllEmployees(_companyId);
                    foreach (var obj in employees.employees)
                    {
                        var employee = new EmployeeViewModel();
                        var user = db.Users.Where(x => x.Id == obj.Id).FirstOrDefault();
                        employee.FullName = obj.FirstName + " " + obj.LastName;
                        employee.DateOfBirth = obj.DateOfBirth;
                        employee.Gender = obj.Gender;
                        employee.MaritalStatus = obj.MaritalStatus;
                        employee.Salary = obj.Salary;
                        employee.DateOfHire = obj.DateOfHire;
                        employee.Email = user.Email;
                        employee.PhoneNumber = user.PhoneNumber;

                        employeesList.Add(employee);
                    }
                }
                catch (Exception ex) { }

            }
            return View(employeesList);
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