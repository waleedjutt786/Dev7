using dev7.EMS.BT.Utilities;
using dev7.EMS.Domain.ResultMessages;
using dev7.EMS.Domain.VehicleFuel;
using dev7.EMS.Model.VehicleFuel;
using dev7.EMS.PT.Models;
using dev7.EMS.Services.Services.Employee;
using dev7.EMS.Services.Services.Vehicle;
using dev7.EMS.Services.Services.VehicleFuel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dev7.EMS.PT.Controllers
{
    [AllowAnonymous]
    public class VehicleFuelController : Controller
    {
        private readonly VehicleFuelService _vehiclefuelService;
        private readonly VehicleService _vehicleService;
        private readonly EmployeeService _employeeService;
        public VehicleFuelController()
        {
            _vehiclefuelService = new VehicleFuelService();
          _vehicleService = new VehicleService();
            _employeeService = new EmployeeService();
        }

        public ActionResult AddNewVehicleFuel()
        {
            var vehicles = _vehicleService.GetAllVehicles(Convert.ToInt32(User.Identity.GetUserId()));
            var empls = _employeeService.GetAllEmployees(Convert.ToInt32(User.Identity.GetUserId()));
            var employees = new List<EmployeeViewModel>();
            foreach(var obj in empls.employees)
            {
                var emp = new EmployeeViewModel();
                emp.Id = obj.Id;
                emp.FullName = obj.FirstName + " " + obj.LastName;
                employees.Add(emp);
            }

            ViewBag.VehicleList = vehicles.vehicles;
            ViewBag.EmployeeList = employees;

            return View();
        }

        [HttpPost]
        public ActionResult AddNewVehicleFuel(AddVehicleFuelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var VehicleFuel = new VehicleFuelMD();
                VehicleFuel.Date = model.Date;
                VehicleFuel.Amount = model.Amount;
                VehicleFuel.VehicleId = model.VehicleId;
                VehicleFuel.EmployeeId = model.EmployeeId;
                VehicleFuel.CreatedById = Convert.ToInt32(User.Identity.GetUserId());
                VehicleFuel.CreatedDate = DateTime.Now;

                var result = _vehiclefuelService.AddVehicleFuel(VehicleFuel);
                if(!result.HasErrors)
                {
                    return RedirectToAction("ViewAllVehicleFuels");
                }
                else{
                    model.HasErrorMessage = result.HasErrors;
                    model.MessageType = result.ResultMessages.FirstOrDefault().MessageType;
                    model.Message = result.ResultMessages.FirstOrDefault().Message;
                    return View(model);
                }
            }
            return RedirectToAction("AddNewVehicleFuel");
        }
        public ActionResult ViewAllVehicleFuels()
        {
            var vehiclefuelsList = new List<VehicleFuelViewModel>();
            var vehicleFuelVM = new VehicleFuelViewModel();
            var _companyId = Convert.ToInt32(User.Identity.GetUserId());
            if (_companyId > 0)
            {
                var vehicleList = _vehicleService.GetAllVehicles(_companyId);
                foreach(var obj in vehicleList.vehicles)
                {
                    vehicleFuelVM.VehicleType = obj.Type;
                    vehicleFuelVM.VehicleNumber = obj.Number;
                    try {
                        var vehicleFuels = _vehiclefuelService.GetVehicleFuelsByVehicleId(obj.Id);
                        if(vehicleFuels.Count > 0)
                        {
                            foreach(var vf in vehicleFuels)
                            {
                                vehicleFuelVM.Id = vf.Id;
                                vehicleFuelVM.VehicleId = vf.VehicleId;
                                vehicleFuelVM.VehicleFuelId = vehicleFuelVM.VehicleFuelId;
                                vehicleFuelVM.EmployeeId = vf.EmployeeId;
                                vehicleFuelVM.Date = vf.Date;
                                vehicleFuelVM.Amount = vf.Amount;

                                var employee = _employeeService.GetEmployeeById(vf.EmployeeId);
                                vehicleFuelVM.EmployeeName = employee.FirstName + " " + employee.LastName;
                                vehiclefuelsList.Add(vehicleFuelVM);
                            }

;                        }
                    }
                    catch(Exception ex)
                    {
                        break;  // have to redirect somewhere, later
                    }
                }
               
            }
            return View(vehiclefuelsList);
        }
        public ActionResult ViewVehicleFuels(int id)
        {
            var vehicleFuels = new VehicleFuelsMD();
            if(id > 0)
            {
                try {
                    var result = _vehiclefuelService.GetVehicleFuelsByVehicleId(id);
                    if(result.Count > 0)
                    {
                        foreach (var obj in result)
                        {
                            vehicleFuels.vehicleFuels.Add(obj);
                        }
                        return View(vehicleFuels);
                    }
                }
                catch(Exception ex)
                {

                }
            }
            return View(vehicleFuels);
        }
        public ActionResult UpdateVehicleFuel(int id)
        {
            var VehicleFuel = new VehicleFuelMD();
            if (id > 0)
            {
                var result = _vehiclefuelService.GetVehicleFuelById(id);
                if (!result.HasErrors)
                {
                    VehicleFuel = result;
                    return View(VehicleFuel);
                }
            }
            return View(VehicleFuel);
        }
        [HttpPost]
        public ActionResult UpdateVehicleFuel(VehicleFuelMD model)
        {
            if (ModelState.IsValid)
            {
                var result = _vehiclefuelService.ModifyVehicleFuel(model);
                if (!result.HasErrors)
                {
                    return RedirectToAction("ViewAllVehicleFuels");
                }
                model.HasErrors = result.HasErrors;
                model.ResultMessages.Add(result.ResultMessages.FirstOrDefault());
            }
            if (!model.HasErrors)
            {
                ResultMessage rs = new ResultMessage();
                rs.MessageType = ResultCode.Danger.ToString();
                rs.Message = "Unable to update VehicleFuel";
                model.ResultMessages.Add(rs);
            }
            return View(model);
        }
    }
}