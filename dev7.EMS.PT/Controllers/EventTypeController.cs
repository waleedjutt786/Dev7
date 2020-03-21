using dev7.EMS.Model.EventType;
using dev7.EMS.PT.Models;
using dev7.EMS.Services.ServiceContracts.EventType;
using dev7.EMS.Services.Services.EventType;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace dev7.EMS.PT.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly IEventTypeServiceContract _eventTypeService;
        public EventTypeController()
        {
            _eventTypeService = new EventTypeService();

        }

        public ActionResult AddEventType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEventType(EventTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                EventTypeMD result = null;
                try
                {
                    var eventtype = new EventTypeMD();
                    eventtype.Type = model.Type;
                    eventtype.Description = model.Description;
                    eventtype.CompanyId = Convert.ToInt32(User.Identity.GetUserId());
                    eventtype.CreatedById = Convert.ToInt32(User.Identity.GetUserId());
                    eventtype.CreatedDate = DateTime.Now;

                    result = _eventTypeService.AddEventType(eventtype);
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


        public ActionResult ViewAllEventTypes()
        {
            var eventtypes = new List<EventTypeViewModel>();
            var _companyId = Convert.ToInt32(User.Identity.GetUserId());
            if (_companyId > 0)
            {
                var result = _eventTypeService.GetAllEventTypes(_companyId);
                if (result != null && result.eventTypes.Count != 0)
                {
                    foreach (var obj in result.eventTypes)
                    {
                        var eventtype = new EventTypeViewModel();
                        eventtype.Id = obj.Id;
                        eventtype.Type = obj.Type;
                        eventtype.Description = obj.Description;
                        eventtypes.Add(eventtype);
                    }
                }
            }
            return View(eventtypes);
        }
    }
}