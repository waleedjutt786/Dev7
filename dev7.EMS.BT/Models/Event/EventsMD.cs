using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Event
{
    public class EventsMD : ModelBase
    {
        public EventsMD()
        {
            events = new List<EventMD>();
        }
        public List<EventMD> events { get; set; }
    }

}
