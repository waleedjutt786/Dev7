using dev7.EMS.Domain.Event;
using dev7.EMS.Framework;
using dev7.EMS.Model.Event;
using dev7.EMS.Services.ServiceContracts;
using dev7.EMS.Services.ServiceContracts.Event;
using dev7.EMS.Translators.Event;
using System;
using System.Linq;
using dev7.EMS.BT.Utilities.AppConstants;
using dev7.EMS.DAL.Repository;
using dev7.EMS.DAL.UoW;

namespace dev7.EMS.Services.Services.Event
{
    public class EventService : IEventServiceContract
    {
        #region DataMembers

        private readonly IRepository<EventDE> _EventRepo;
        private readonly IEncryptionService _encryptionService;
        private readonly EMSUoW _uow;

        //email code
        private AppConfiguration _appConfiguration;
        #endregion

        #region Constructors

        public EventService()
        {
            _uow = new EMSUoW(DBHelper.ConnectionString);
            _EventRepo = new EFRepository<EventDE>(_uow);

            _encryptionService = new EncryptionService();
            _appConfiguration = new AppConfiguration();
        }

        public EventService(IUnitOfWork uow)
        {
            _EventRepo = new EFRepository<EventDE>(uow);
            _appConfiguration = new AppConfiguration();
        }
        #endregion

        #region methods

        #region Event_crud
        public EventMD AddEvent(EventMD mod)
        {
            try
            {
                var entity = mod.Translate();
                _EventRepo.Insert(entity);
                _EventRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Event"));
                mod.Id = entity.Id;
            }
            catch (Exception ex)
            {
                mod.HasErrors = true;
                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "Event"));
            }

            return mod;
        }

        public EventMD DeleteEvent(long id)
        {
            var mod = new EventMD();
            try
            {
                var Event = _EventRepo.Fetch(x => x.IsActive);
                Event.IsActive = false;
                _EventRepo.Update(Event);
                _EventRepo.CommitAllChanges();

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_DELETE, "Event"));
            }
            catch (Exception ex)
            {

                mod.AddErrorMessage(string.Format(AppConstants.CRUD_DELETE_ERROR, "Event"));
            }
            return mod;
        }

        public EventsMD GetAllEvents()
        {
            var viewModel = new EventsMD();
            try
            {
                viewModel.events = _EventRepo.GetAll(x => x.IsActive).ToList().Translate();
                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET, "Events"));
            }
            catch (Exception)
            {

                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "Events"));
            }
            return viewModel;
        }

        public IQueryable<EventDE> GetAllQuerableEvents()
        {
            return _EventRepo.Query.Where(x => x.IsActive);
        }

        public EventMD GetEventById(long id)
        {
            var entity = _EventRepo.Fetch(x => x.Id == id && x.IsActive);
            return entity.Translate();
        }

        public EventMD ModifyEvent(EventMD mod)
        {
            var entity = mod.Translate();
            try
            {
                _EventRepo.Update(entity);
                _EventRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Event"));
            }
            catch (Exception)
            {

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Event"));
            }

            return mod;
        }



        //public EventMD UpdateEventImage(long id, string url)
        //{
        //    var mod = new EventMD();
        //    var entity = _EventRepo.Fetch(x => x.Id == id && x.IsActive);
        //    try
        //    {
        //        entity.UserImagePath = url;
        //        _EventRepo.Update(entity);
        //        _EventRepo.CommitAllChanges();
        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Event"));
        //    }
        //    catch (Exception)
        //    {

        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Event"));
        //    }

        //    return mod;
        //}
        #endregion Event_crud

        #endregion methods

    }
}
