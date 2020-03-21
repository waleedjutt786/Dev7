using System;
using dev7.EMS.Domain.EventType;
using dev7.EMS.Model.EventType;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Translators.EventType
{
    public static class EventTypeTranslators
    {
        public static EventTypeDE Translate(this EventTypeMD from, EventTypeDE dest = null)
        {
            var to = dest ?? new EventTypeDE();
            if (to.Id <= 0)
            {
                to.Id = from.Id;
                to.IsActive = true;
            }
            else
            {

                to.IsActive = from.IsActive;
            }
            to.Type = from.Type;
            to.Description = from.Description;
            to.CompanyId = from.CompanyId;
            to.CreatedById = from.CreatedById;
            to.CreatedDate = from.CreatedDate;

            return to;
        }
        public static EventTypeMD Translate(this EventTypeDE from)
        {
            var to = new EventTypeMD();
            to.Id = from.Id;
            to.Type = from.Type;
            to.Description = from.Description;
            to.CompanyId = from.CompanyId;
            to.CreatedById = from.CreatedById;
            to.CreatedDate = from.CreatedDate;
            return to;

        }
        public static List<EventTypeMD> Translate(this List<EventTypeDE> list)
        {
            var eventtypes = new List<EventTypeMD>();
            foreach (var from in list)
            {
                var to = new EventTypeMD();

                to.Id = from.Id;
                to.Type = from.Type;
                to.Description = from.Description;
                to.CompanyId = from.CompanyId;
                to.CreatedById = from.CreatedById;
                to.CreatedDate = from.CreatedDate;
                eventtypes.Add(to);
            }
            return eventtypes;
        }
    }
}
