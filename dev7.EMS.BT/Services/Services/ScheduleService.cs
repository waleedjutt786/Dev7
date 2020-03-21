using dev7.EMS.BT.Utilities.AppConstants;
using dev7.EMS.DAL.Repository;
using dev7.EMS.DAL.UoW;
using dev7.EMS.Domain.Schedule;
using dev7.EMS.Framework;
using dev7.EMS.Model.Schedule;
using dev7.EMS.Services.ServiceContracts;
using dev7.EMS.Services.ServiceContracts.Schedule;
using dev7.EMS.Translators.Schedule;
using System;
using System.Linq;

namespace dev7.EMS.Services.Services.Schedule
{
    public class ScheduleService : IScheduleServiceContract
    {
        #region DataMembers

        private readonly IRepository<ScheduleDE> _ScheduleRepo;
        private readonly IEncryptionService _encryptionService;
        private readonly EMSUoW _uow;

        //email code
        private AppConfiguration _appConfiguration;
        #endregion

        #region Constructors

        public ScheduleService()
        {
            _uow = new EMSUoW(DBHelper.ConnectionString);
            _ScheduleRepo = new EFRepository<ScheduleDE>(_uow);

            _encryptionService = new EncryptionService();
            _appConfiguration = new AppConfiguration();
        }

        public ScheduleService(IUnitOfWork uow)
        {
            _ScheduleRepo = new EFRepository<ScheduleDE>(uow);
            _appConfiguration = new AppConfiguration();
        }
        #endregion

        #region methods

        #region Schedule_crud
        public ScheduleMD AddSchedule(ScheduleMD mod)
        {
            try
            {
                var entity = mod.Translate();
                _ScheduleRepo.Insert(entity);
                _ScheduleRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Schedule"));
                mod.Id = entity.Id;
            }
            catch (Exception ex)
            {
                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "Schedule"));
            }

            return mod;
        }

        public ScheduleMD DeleteSchedule(long id)
        {
            var mod = new ScheduleMD();
            try
            {
                var Schedule = _ScheduleRepo.Fetch(x => x.IsActive);
                Schedule.IsActive = false;
                _ScheduleRepo.Update(Schedule);
                _ScheduleRepo.CommitAllChanges();

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_DELETE, "Schedule"));
            }
            catch (Exception ex)
            {

                mod.AddErrorMessage(string.Format(AppConstants.CRUD_DELETE_ERROR, "Schedule"));
            }
            return mod;
        }

        public SchedulesMD GetAllSchedules(int Id)
        {
            var viewModel = new SchedulesMD();
            try
            {
                viewModel.schedules = _ScheduleRepo.GetAll(x => x.IsActive).ToList().Translate();
                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET, "Schedules"));
            }
            catch (Exception)
            {

                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "Schedules"));
            }
            return viewModel;
        }

        public IQueryable<ScheduleDE> GetAllQuerableSchedules()
        {
            return _ScheduleRepo.Query.Where(x => x.IsActive);
        }

        public ScheduleMD GetScheduleById(long id)
        {
            var entity = _ScheduleRepo.Fetch(x => x.Id == id && x.IsActive);
            return entity.Translate();
        }

        public ScheduleMD ModifySchedule(ScheduleMD mod)
        {
            var entity = mod.Translate();
            try
            {
                _ScheduleRepo.Update(entity);
                _ScheduleRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Schedule"));
            }
            catch (Exception)
            {

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Schedule"));
            }

            return mod;
        }



        //public ScheduleMD UpdateScheduleImage(long id, string url)
        //{
        //    var mod = new ScheduleMD();
        //    var entity = _ScheduleRepo.Fetch(x => x.Id == id && x.IsActive);
        //    try
        //    {
        //        entity.UserImagePath = url;
        //        _ScheduleRepo.Update(entity);
        //        _ScheduleRepo.CommitAllChanges();
        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Schedule"));
        //    }
        //    catch (Exception)
        //    {

        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Schedule"));
        //    }

        //    return mod;
        //}
        #endregion Schedule_crud

        #endregion methods

    }
}
