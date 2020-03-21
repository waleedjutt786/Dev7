using dev7.EMS.Domain.EventType;
using dev7.EMS.Framework;
using dev7.EMS.Model.EventType;
using dev7.EMS.Services.ServiceContracts;
using dev7.EMS.Services.ServiceContracts.EventType;
using System;
using System.Linq;
using dev7.EMS.Translators.EventType;
using dev7.EMS.DAL.Repository;
using dev7.EMS.DAL.UoW;
using dev7.EMS.BT.Utilities.AppConstants;

namespace dev7.EMS.Services.Services.EventType
{
    public class EventTypeService : IEventTypeServiceContract
    {
        #region DataMembers

        private readonly IRepository<EventTypeDE> _EventTypeRepo;
        private readonly IEncryptionService _encryptionService;
        private readonly EMSUoW _uow;

        //email code
        private AppConfiguration _appConfiguration;
        #endregion

        #region Constructors

        public EventTypeService()
        {
            _uow = new EMSUoW(DBHelper.ConnectionString);
            _EventTypeRepo = new EFRepository<EventTypeDE>(_uow);

            _encryptionService = new EncryptionService();
            _appConfiguration = new AppConfiguration();
        }

        public EventTypeService(IUnitOfWork uow)
        {
            _EventTypeRepo = new EFRepository<EventTypeDE>(uow);
            _appConfiguration = new AppConfiguration();
        }
        #endregion

        #region methods

        #region EventType_crud
        public EventTypeMD AddEventType(EventTypeMD mod)
        {
            try
            {
                var entity = mod.Translate();
                _EventTypeRepo.Insert(entity);
                _EventTypeRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "EventType"));
                mod.Id = entity.Id;
            }
            catch (Exception ex)
            {
                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "EventType"));
            }

            return mod;
        }

        public EventTypeMD DeleteEventType(long id)
        {
            var mod = new EventTypeMD();
            try
            {
                var EventType = _EventTypeRepo.Fetch(x => x.IsActive);
                EventType.IsActive = false;
                _EventTypeRepo.Update(EventType);
                _EventTypeRepo.CommitAllChanges();

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_DELETE, "EventType"));
            }
            catch (Exception ex)
            {

                mod.AddErrorMessage(string.Format(AppConstants.CRUD_DELETE_ERROR, "EventType"));
            }
            return mod;
        }

        public EventTypesMD GetAllEventTypes(int id)
        {
            var viewModel = new EventTypesMD();
            try
            {
                viewModel.eventTypes = _EventTypeRepo.GetAll(x => x.IsActive).ToList().Translate();
                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET, "EventTypes"));
            }
            catch (Exception)
            {

                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "EventTypes"));
            }
            return viewModel;
        }

        public IQueryable<EventTypeDE> GetAllQuerableEventTypes()
        {
            return _EventTypeRepo.Query.Where(x => x.IsActive);
        }

        public EventTypeMD GetEventTypeById(long id)
        {
            var entity = _EventTypeRepo.Fetch(x => x.Id == id && x.IsActive);
            return entity.Translate();
        }

        public EventTypeMD ModifyEventType(EventTypeMD mod)
        {
            var entity = mod.Translate();
            try
            {
                _EventTypeRepo.Update(entity);
                _EventTypeRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "EventType"));
            }
            catch (Exception)
            {

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "EventType"));
            }

            return mod;
        }



        //public EventTypeMD UpdateEventTypeImage(long id, string url)
        //{
        //    var mod = new EventTypeMD();
        //    var entity = _EventTypeRepo.Fetch(x => x.Id == id && x.IsActive);
        //    try
        //    {
        //        entity.UserImagePath = url;
        //        _EventTypeRepo.Update(entity);
        //        _EventTypeRepo.CommitAllChanges();
        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "EventType"));
        //    }
        //    catch (Exception)
        //    {

        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "EventType"));
        //    }

        //    return mod;
        //}
        #endregion EventType_crud

        #endregion methods

    }
}
