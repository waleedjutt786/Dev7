using dev7.EMS.BT.Utilities.AppConstants;
using dev7.EMS.Framework;
using dev7.EMS.Model.Company;
using dev7.EMS.PT;
using dev7.EMS.PT.Models;
using dev7.EMS.Services.Services.Company;
using dev7.EMS.Translators.Company;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace dev7.EMS.MVC.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly CompanyService _CompanyService;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public CompanyController()
        {
            _CompanyService = new CompanyService();
        }
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
        public ActionResult GetCompanyById(long id)
        {
            if (id > 0)
            {
                var Company = _CompanyService.GetCompanyById(id);
                if (!Company.HasErrors)
                {
                    Company.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Company added"));
                    RedirectToAction("Home", "Index");
                }
                Company.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "AddNewCompany failed"));
            }

            return View();
        }
        public ActionResult GetAllCompanies()
        {

            var Company = _CompanyService.GetAllCompanys();
            if (Company.HasErrors)
            {
                Company.AddSuccessMessage(string.Format(AppConstants.CRUD_GET, "Companyes get"));
                RedirectToAction("Home", "Index");
            }
            Company.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "GetAllCompanys failed"));

            return View(Company);
        }

        [AllowAnonymous]
        public ActionResult RegisterCompany()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterCompany(RegisterCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var appDbContext = HttpContext.GetOwinContext().Get<EMSDbContext>();
                //using (var context = appDbContext.Database.BeginTransaction())
                //{
                //    try
                //    {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var company = new CompanyMD();
                    company.Name = model.Name;
                    company.ImagePath = "";
                    company.Logo = "";
                    company.CreatedDate = DateTime.Now;
                    company.Id = user.Id;
                    company.CreatedById = 0;

                    user.Company = company.Translate();
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    var res = _CompanyService.RegisterCompany(company);
                    if (res.HasErrors)
                    {
                        await UserManager.DeleteAsync(user);
                    }
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                    //    }
                    //    AddErrors(result);
                    //}
                    //catch (Exception)
                    //{
                    //    context.Rollback();
                    //}
                }
            }
            return View(model);
        }
        public ActionResult UpdateCompany(CompanyMD Company)
        {
            if (ModelState.IsValid)
            {
                var entity = _CompanyService.ModifyCompany(Company);
                if (!entity.HasErrors)
                {
                    entity.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Company modifeid"));
                    RedirectToAction("Home", "Index");
                }
                Company.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "UpdateCompany failed"));
            }

            return View(Company);
        }
        public ActionResult DeleteCompany(int id)
        {
            if (id > 0)
            {
                var Company = _CompanyService.DeleteCompany(id);
                if (!Company.HasErrors)
                {
                    Company.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Company deleted"));
                    RedirectToAction("Home", "Index");
                }
                Company.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "DeleteCompany failed"));
            }

            return View();
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