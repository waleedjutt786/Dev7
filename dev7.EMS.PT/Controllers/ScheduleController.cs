using dev7.EMS.BT.Utilities;
using dev7.EMS.Model.Event;
using dev7.EMS.Model.Schedule;
using dev7.EMS.PT.Models;
using dev7.EMS.Services.Services.Event;
using dev7.EMS.Services.Services.Schedule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace dev7.EMS.PT.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ScheduleService _scheduleService;
        private readonly EventService _eventService;

        public ScheduleController()
        {
            _scheduleService = new ScheduleService();
            _eventService = new EventService();
        }
        [AllowAnonymous]
        public ActionResult AddSchedule()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSchedule(ScheduleViewModel model)
        {
            //if (model.Gender != Gender.Male || model.Gender != Gender.Female) model.Gender 
            if (ModelState.IsValid)
            {
                var eventmd = new EventMD();
                eventmd.Description = model.EventDescription;
                eventmd.EventStatus = EventStatus.Pending;
                var result = _eventService.AddEvent(eventmd);
               
                if (!result.HasErrors)
                {
                    ScheduleMD schedule = new ScheduleMD();
                    schedule.Date = model.Date;
                    schedule.StartTime = model.StartTime;
                    schedule.EndTime = model.EndTime;
                    schedule.AddressLine = model.AddressLine;
                    schedule.City = model.City;
                    schedule.Province = model.Province;
                    schedule.Country = model.Country;

                    schedule.CreatedDate = DateTime.Now;
                    schedule.CreatedById = Convert.ToInt64(User.Identity.GetUserId());
                    schedule.IsValid = true;

                    var res = _scheduleService.AddSchedule(schedule);
                    if (res.HasErrors)
                    {
                        model.HasError = true;
                        //model.ErrorMessage.Message = res.ResultMessages.FirstOrDefault().Message;
                        //model.ErrorMessage.MessageType =  "Try again! " + res.ResultMessages.FirstOrDefault().MessageType;
                        //await UserManager.DeleteAsync(user);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        public async Task<ActionResult> ViewAllSchedules()
        {
            var schedulesList = new List<ScheduleViewModel>();

            int _companyId = Convert.ToInt32(User.Identity.GetUserId());
            if (_companyId > 0)
            {
                try
                {
                    EMSDbContext db = new EMSDbContext();
                    var schedules = _scheduleService.GetAllSchedules(_companyId);
                    foreach (var obj in schedules.schedules)
                    {
                        var schedule = new ScheduleViewModel();
                        var eventResult = _eventService.GetEventById(schedule.Id);
                        schedule.Date = obj.Date;
                        schedule.StartTime = obj.StartTime;
                        schedule.EndTime = obj.EndTime;
                        schedule.AddressLine = obj.AddressLine;
                        schedule.ZipCode = obj.ZipCode;
                        schedule.City = obj.City;
                        schedule.Province = obj.Province;
                        schedule.Country = obj.Country;
                        schedule.EventDescription = eventResult.Description;

                        schedulesList.Add(schedule);
                    }
                }
                catch (Exception ex) { }

            }
            return View(schedulesList);
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