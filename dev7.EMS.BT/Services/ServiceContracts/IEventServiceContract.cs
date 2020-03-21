using dev7.EMS.Domain.Event;
using dev7.EMS.Model.Event;
using System.Linq;

namespace dev7.EMS.Services.ServiceContracts.Event
{
    public interface IEventServiceContract
    {
        #region Event

        EventMD AddEvent(EventMD mod);
        EventMD ModifyEvent(EventMD mod);
        EventMD DeleteEvent(long id);
        EventsMD GetAllEvents();

        IQueryable<EventDE> GetAllQuerableEvents();
        EventMD GetEventById(long id);

        #endregion
    }
}
