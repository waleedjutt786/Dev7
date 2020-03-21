using dev7.EMS.Domain.Schedule;
using dev7.EMS.Model.Schedule;
using System.Collections.Generic;

namespace dev7.EMS.Translators.Schedule
{
    public static class ScheduleTranslators
    {
        public static ScheduleDE Translate(this ScheduleMD from, ScheduleDE dest = null)
        {
            var to = dest ?? new ScheduleDE();
            if (to.Id <= 0)
            {
                to.Id = from.Id;
                to.IsActive = true;
            }
            else
            {

                to.IsActive = from.IsActive;
            }
            to.Date = from.Date;
            to.StartTime = from.StartTime;
            to.EndTime = from.EndTime;
            to.AddressLine = from.AddressLine;
            to.City = from.City;
            to.Province = from.Province;
            to.Country = from.Country;
            to.ZipCode = from.ZipCode;
            to.CreatedDate = from.CreatedDate;
            to.CreatedById = from.CreatedById;
            to.IsValid = from.IsValid;


            return to;
        }
        public static ScheduleMD Translate(this ScheduleDE from)
        {
            var to = new ScheduleMD();
            to.Id = from.Id;
            to.Date = from.Date;
            to.StartTime = from.StartTime;
            to.EndTime = from.EndTime;
            to.AddressLine = from.AddressLine;
            to.City = from.City;
            to.Province = from.Province;
            to.Country = from.Country;
            to.ZipCode = from.ZipCode;
            to.CreatedDate = from.CreatedDate;
            to.CreatedById = from.CreatedById;
            to.IsValid = from.IsValid;

            return to;

        }
        public static List<ScheduleMD> Translate(this List<ScheduleDE> list)
        {
            var schedules = new List<ScheduleMD>();
            foreach (var from in list)
            {
                var to = new ScheduleMD();

                to.Id = from.Id;
                to.Date = from.Date;
                to.StartTime = from.StartTime;
                to.EndTime = from.EndTime;
                to.AddressLine = from.AddressLine;
                to.City = from.City;
                to.Province = from.Province;
                to.Country = from.Country;
                to.ZipCode = from.ZipCode;
                to.CreatedDate = from.CreatedDate;
                to.CreatedById = from.CreatedById;
                to.IsValid = from.IsValid;

                schedules.Add(to);
            }
            return schedules;
        }
    }
}
