using dev7.EMS.Domain.VendorType;
using dev7.EMS.Model.VendorType;
using dev7.EMS.PT.Models;
using dev7.EMS.Services.ServiceContracts.VendorType;
using dev7.EMS.Services.Services.VendorType;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dev7.EMS.PT.Controllers
{
    public class VendorTypeController : Controller
    {
        private readonly IVendorTypeServiceContract _vendorTypeService;
        public VendorTypeController()
        {
            _vendorTypeService = new VendorTypeService();

        }

        public ActionResult AddVendorType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVendorType(VendorTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                VendorTypeMD result = null;
                try
                {
                    var vendortype = new VendorTypeMD();
                    vendortype.Type = model.Type;
                    vendortype.Description = model.Description;
                    vendortype.CompanyId = Convert.ToInt32(User.Identity.GetUserId());
                    vendortype.CreatedById = Convert.ToInt32(User.Identity.GetUserId());
                    vendortype.CreatedDate = DateTime.Now;

                    result = _vendorTypeService.AddVendorType(vendortype);
                    if (result.HasErrors)
                    {
                        model.HasErrorMessage = result.HasErrors;
                        model.MessageType = result.ResultMessages.FirstOrDefault().MessageType;
                        model.Message = result.ResultMessages.FirstOrDefault().Message;
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    if (!model.HasErrorMessage && result != null)
                    {
                        model.HasErrorMessage = result.HasErrors;
                        model.MessageType = result.ResultMessages.FirstOrDefault().MessageType;
                        model.Message = result.ResultMessages.FirstOrDefault().Message;
                    }
                }
            }
            return View(model);
        }


        public ActionResult ViewAllVendorTypes()
        {
            var vendortypes = new List<VendorTypeViewModel>();
            var _companyId = Convert.ToInt32(User.Identity.GetUserId());
            if (_companyId > 0)
            {
                var result = _vendorTypeService.GetAllVendorTypes(_companyId);
                if (result != null && result.vendortypes.Count != 0)
                {
                    foreach (var obj in result.vendortypes)
                    {
                        var vendortype = new VendorTypeViewModel();
                        vendortype.Id = obj.Id;
                        vendortype.Type = obj.Type;
                        vendortype.Description = obj.Description;
                        vendortypes.Add(vendortype);
                    }
                }
            }
            return View(vendortypes);
        }
    }
}