using dev7.EMS.Domain.Schedule;
using dev7.EMS.Model.Schedule;
using System.Linq;

namespace dev7.EMS.Services.ServiceContracts.Schedule
{
    public interface IScheduleServiceContract
    {
        #region Schedule

        ScheduleMD AddSchedule(ScheduleMD mod);
        ScheduleMD ModifySchedule(ScheduleMD mod);
        ScheduleMD DeleteSchedule(long id);
        SchedulesMD GetAllSchedules(int Id);

        IQueryable<ScheduleDE> GetAllQuerableSchedules();
        ScheduleMD GetScheduleById(long id);

        #endregion
    }
}
