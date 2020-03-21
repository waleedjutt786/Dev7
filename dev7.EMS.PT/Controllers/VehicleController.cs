using dev7.EMS.BT.Utilities;
using dev7.EMS.Domain.ResultMessages;
using dev7.EMS.Model.Vehicle;
using dev7.EMS.PT.Models;
using dev7.EMS.Services.Services.Vehicle;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dev7.EMS.PT.Controllers
{
    [AllowAnonymous]
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService;
        public VehicleController()
        {
            _vehicleService = new VehicleService();
        }

        public ActionResult AddNewVehicle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewVehicle(AddVehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vehicle = new VehicleMD();
                vehicle.Type = model.Type;
                vehicle.Number = model.Number;
                vehicle.CompanyId = Convert.ToInt32(User.Identity.GetUserId());
                vehicle.CreatedById = Convert.ToInt32(User.Identity.GetUserId());
                vehicle.CreatedDate = DateTime.Now;

                var result = _vehicleService.AddVehicle(vehicle);
                if (result.HasErrors)
                {
                    model.HasErrorMessage = result.HasErrors;
                    model.MessageType = result.ResultMessages.FirstOrDefault().MessageType;
                    model.Message = result.ResultMessages.FirstOrDefault().Message;
                    return View(model);
                }
            }
            return View();
        }
        public ActionResult ViewAllVehicles()
        {
            var vehicles = new List<VehcileViewModel>();
            var _companyId = Convert.ToInt32(User.Identity.GetUserId());
            if (_companyId > 0)
            {
                var result = _vehicleService.GetAllVehicles(_companyId);
                if(result != null && result.vehicles.Count != 0)
                {
                    foreach(var obj in result.vehicles)
                    {
                        var vehicle = new VehcileViewModel();
                        vehicle.Id = obj.Id;
                        vehicle.Type = obj.Type;
                        vehicle.Number = obj.Number;
                        vehicles.Add(vehicle);
                    }
                }
            }
            return View(vehicles);
        }
        public ActionResult UpdateVehicle(int id)
        {
            var vehicle = new VehicleMD();
            if(id > 0)
            {
                var result = _vehicleService.GetVehicleById(id);
                if(!result.HasErrors)
                {
                    vehicle = result;
                    return View(vehicle);
                }
            }
            return View(vehicle);
        }
        [HttpPost]
        public ActionResult UpdateVehicle(VehicleMD model)
        {
            if (ModelState.IsValid)
            {
                var result = _vehicleService.ModifyVehicle(model);
                if (!result.HasErrors)
                {
                    return RedirectToAction("ViewAllVehicles");
                }
                model.HasErrors = result.HasErrors;
                model.ResultMessages.Add(result.ResultMessages.FirstOrDefault());
            }
            if (!model.HasErrors)
            {
                ResultMessage rs = new ResultMessage();
                rs.MessageType = ResultCode.Danger.ToString();
                rs.Message = "Unable to update Vehicle";
                model.ResultMessages.Add(rs);
            }
            return View(model);
        }
    }
}