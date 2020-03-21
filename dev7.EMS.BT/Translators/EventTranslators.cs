using dev7.EMS.Domain.Event;
using dev7.EMS.Model.Event;
using System.Collections.Generic;

namespace dev7.EMS.Translators.Event
{
    public static class EventTranslators
    {
        public static EventDE Translate(this EventMD from, EventDE dest = null)
        {
            var to = dest ?? new EventDE();
            if (to.Id <= 0)
            {
                to.Id = from.Id;
                to.IsActive = true;
            }
            else
            {

                to.IsActive = from.IsActive;
            }
            to.Description = from.Description;
            to.CustomerId = from.CustomerId;
            to.CompanyId = from.CompanyId;
            to.CreatedDate = from.CreatedDate;
            to.CreatedById = from.CreatedById;
            to.EventStatus = from.EventStatus;
            to.IsValid = from.IsValid;


            return to;
        }
        public static EventMD Translate(this EventDE from)
        {
            var to = new EventMD();
            to.Id = from.Id;
            to.Description = from.Description;
            to.CustomerId = from.CustomerId.Value;
            to.CompanyId = from.CompanyId;
            to.CreatedDate = from.CreatedDate;
            to.CreatedById = from.CreatedById;
            to.EventStatus = from.EventStatus;
            to.IsValid = from.IsValid;

            return to;

        }
        public static List<EventMD> Translate(this List<EventDE> list)
        {
            var events = new List<EventMD>();
            foreach (var from in list)
            {
                var to = new EventMD();

                to.Id = from.Id;
                to.Description = from.Description;
                to.CustomerId = from.CustomerId.Value;
                to.CompanyId = from.CompanyId;
                to.CreatedDate = from.CreatedDate;
                to.CreatedById = from.CreatedById;
                to.EventStatus = from.EventStatus;
                to.IsValid = from.IsValid;
                events.Add(to);
            }
            return events;
        }
    }
}
