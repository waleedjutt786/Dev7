using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Schedule
{
    public class SchedulesMD : ModelBase
    {
        public SchedulesMD()
        {
            schedules = new List<ScheduleMD>();
        }
        public List<ScheduleMD> schedules { get; set; }
    }

}
