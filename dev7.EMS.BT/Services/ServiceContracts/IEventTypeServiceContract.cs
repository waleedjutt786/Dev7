using dev7.EMS.Domain.EventType;
using dev7.EMS.Model.EventType;
using System.Linq;

namespace dev7.EMS.Services.ServiceContracts.EventType
{
    public interface IEventTypeServiceContract
    {
        #region EventType

        EventTypeMD AddEventType(EventTypeMD mod);
        EventTypeMD ModifyEventType(EventTypeMD mod);
        EventTypeMD DeleteEventType(long id);
        EventTypesMD GetAllEventTypes(int id);

        IQueryable<EventTypeDE> GetAllQuerableEventTypes();
        EventTypeMD GetEventTypeById(long id);

        #endregion
    }
}
