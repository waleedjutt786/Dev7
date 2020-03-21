using dev7.EMS.BT.Utilities.AppConstants;
using dev7.EMS.DAL;
using dev7.EMS.DAL.Repository;
using dev7.EMS.DAL.UoW;
//using dev7.EMS.DAL.UoWorks;
using dev7.EMS.Domain.VehicleFuel;
//using dev7.EMS.Domain.Data;
using dev7.EMS.Framework;
using dev7.EMS.Model.VehicleFuel;
using dev7.EMS.Services.ServiceContracts;
using dev7.EMS.Services.ServiceContracts.VehicleFuel;
using dev7.EMS.Services.Services;
using dev7.EMS.Translators.VehicleFuel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dev7.EMS.Services.Services.VehicleFuel
{
    public class VehicleFuelService : IVehicleFuelServiceContract
    {
        #region DataMembers

        private readonly IRepository<VehicleFuelDE> _VehicleFuelRepo;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _uow;

        //email code
        private AppConfiguration _appConfiguration;
        #endregion

        #region Constructors

        public VehicleFuelService()
        {
            _uow = new EMSUoW(DBHelper.ConnectionString);
            _VehicleFuelRepo = new EFRepository<VehicleFuelDE>(_uow);

            _encryptionService = new EncryptionService();
            _appConfiguration = new AppConfiguration();
        }

        public VehicleFuelService(IUnitOfWork uow)
        {
            _VehicleFuelRepo = new EFRepository<VehicleFuelDE>(uow);
            _appConfiguration = new AppConfiguration();
        }
        #endregion

        #region methods

        #region VehicleFuel_crud
        public VehicleFuelMD AddVehicleFuel(VehicleFuelMD mod)
        {
            try
            {
                var entity = mod.Translate();
                _VehicleFuelRepo.Insert(entity);
                _VehicleFuelRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "VehicleFuel"));
                mod.Id = entity.Id;
            }
            catch (Exception ex)
            {
                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "VehicleFuel"));
            }

            return mod;
        }

        public VehicleFuelMD DeleteVehicleFuel(long id)
        {
            var mod = new VehicleFuelMD();
            try
            {
                var VehicleFuel = _VehicleFuelRepo.Fetch(x => x.IsActive);
                VehicleFuel.IsActive = false;
                _VehicleFuelRepo.Update(VehicleFuel);
                _VehicleFuelRepo.CommitAllChanges();

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_DELETE, "VehicleFuel"));
            }
            catch (Exception ex)
            {

                mod.AddErrorMessage(string.Format(AppConstants.CRUD_DELETE_ERROR, "VehicleFuel"));
            }
            return mod;
        }

        public VehicleFuelsMD GetVehicleFuels(int id)
        {
            var viewModel = new VehicleFuelsMD();
            try
            {
                viewModel.vehicleFuels = _VehicleFuelRepo.GetAll(x => x.IsActive && x.VehicleId==id).ToList().Translate();
                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET, "VehicleFuels"));
            }
            catch (Exception)
            {

                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "VehicleFuels"));
            }
            return viewModel;
        }

        public IQueryable<VehicleFuelDE> GetAllQuerableVehicleFuels()
        {
            return _VehicleFuelRepo.Query.Where(x => x.IsActive);
        }

        public List<VehicleFuelMD> GetVehicleFuelsByVehicleId(int vehicleId)
        {
            var entity = _VehicleFuelRepo.GetAll(x => x.VehicleId == vehicleId && x.IsActive).ToList();
            return entity.Translate();
        }
        public VehicleFuelMD GetVehicleFuelById(int id)
        {
            var entity = _VehicleFuelRepo.Fetch(x => x.Id == id && x.IsActive);
            return entity.Translate();
        }

        public VehicleFuelMD ModifyVehicleFuel(VehicleFuelMD mod)
        {
            var entity = mod.Translate();
            try
            {
                _VehicleFuelRepo.Update(entity);
                _VehicleFuelRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "VehicleFuel"));
            }
            catch (Exception)
            {

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "VehicleFuel"));
            }

            return mod;
        }

        public VehicleFuelMD DeleteVehicleFuel(int id)
        {
            throw new NotImplementedException();
        }

      



        //public VehicleFuelMD UpdateVehicleFuelImage(long id, string url)
        //{
        //    var mod = new VehicleFuelMD();
        //    var entity = _VehicleFuelRepo.Fetch(x => x.Id == id && x.IsActive);
        //    try
        //    {
        //        entity.UserImagePath = url;
        //        _VehicleFuelRepo.Update(entity);
        //        _VehicleFuelRepo.CommitAllChanges();
        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "VehicleFuel"));
        //    }
        //    catch (Exception)
        //    {

        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "VehicleFuel"));
        //    }

        //    return mod;
        //}
        #endregion VehicleFuel_crud

        #endregion methods

    }
}
