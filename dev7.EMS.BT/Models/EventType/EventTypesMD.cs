using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.EventType
{
    public class EventTypesMD : ModelBase
    {
        public EventTypesMD()
        {
            eventTypes = new List<EventTypeMD>();
        }
        public List<EventTypeMD> eventTypes { get; set; }
    }

}