using dev7.EMS.BT.Utilities.AppConstants;
using dev7.EMS.DAL;
using dev7.EMS.DAL.Repository;
using dev7.EMS.DAL.UoW;
//using dev7.EMS.DAL.UoWorks;
using dev7.EMS.Domain.Vehicle;
//using dev7.EMS.Domain.Data;
using dev7.EMS.Framework;
using dev7.EMS.Model.Vehicle;
using dev7.EMS.Services.ServiceContracts;
using dev7.EMS.Services.ServiceContracts.Vehicle;
using dev7.EMS.Services.Services;
using dev7.EMS.Translators.Vehicle;
using System;
using System.Linq;

namespace dev7.EMS.Services.Services.Vehicle
{
    public class VehicleService : IVehicleServiceContract
    {
        #region DataMembers

        private readonly IRepository<VehicleDE> _VehicleRepo;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _uow;

        //email code
        private AppConfiguration _appConfiguration;
        #endregion

        #region Constructors

        public VehicleService()
        {
            _uow = new EMSUoW(DBHelper.ConnectionString);
            _VehicleRepo = new EFRepository<VehicleDE>(_uow);

            _encryptionService = new EncryptionService();
            _appConfiguration = new AppConfiguration();
        }

        public VehicleService(IUnitOfWork uow)
        {
            _VehicleRepo = new EFRepository<VehicleDE>(uow);
            _appConfiguration = new AppConfiguration();
        }
        #endregion

        #region methods

        #region Vehicle_crud
        public VehicleMD AddVehicle(VehicleMD mod)
        {
            try
            {
                var entity = mod.Translate();
                _VehicleRepo.Insert(entity);
                _VehicleRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Vehicle"));
                mod.Id = entity.Id;
            }
            catch (Exception ex)
            {
                mod.HasErrors = true;
                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "Vehicle"));
            }

            return mod;
        }

        public VehicleMD DeleteVehicle(int id)
        {
            var mod = new VehicleMD();
            try
            {
                var Vehicle = _VehicleRepo.Fetch(x => x.IsActive);
                Vehicle.IsActive = false;
                _VehicleRepo.Update(Vehicle);
                _VehicleRepo.CommitAllChanges();

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_DELETE, "Vehicle"));
            }
            catch (Exception ex)
            {

                mod.AddErrorMessage(string.Format(AppConstants.CRUD_DELETE_ERROR, "Vehicle"));
            }
            return mod;
        }

        public VehiclesMD GetAllVehicles(int id)
        {
            if (id != 0)
            {
                var vehicles = new VehiclesMD();
                try
                {
                    vehicles.vehicles = _VehicleRepo.GetAll(x => x.IsActive && x.CompanyId == id).ToList().Translate();
                    vehicles.AddSuccessMessage(string.Format(AppConstants.CRUD_GET, "Vehicles"));
                }
                catch (Exception ex)
                {
                    vehicles.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "GetAllVehicles " + " "+ex));
                }
                return vehicles;
            }
            return null;
        }

        public IQueryable<VehicleDE> GetAllQuerableVehicles()
        {
            return _VehicleRepo.Query.Where(x => x.IsActive);
        }

        public VehicleMD GetVehicleById(int id)
        {
            var entity = _VehicleRepo.Fetch(x => x.Id == id && x.IsActive);
            return entity.Translate();
        }

        public VehicleMD ModifyVehicle(VehicleMD mod)
        {
            var entity = mod.Translate();
            try
            {
                _VehicleRepo.Update(entity);
                _VehicleRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Vehicle"));
            }
            catch (Exception ex)
            {
                mod.HasErrors = true;
                mod.AddErrorMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Vehicle"));
            }

            return mod;
        }




        //public VehicleMD UpdateVehicleImage(int id, string url)
        //{
        //    var mod = new VehicleMD();
        //    var entity = _VehicleRepo.Fetch(x => x.Id == id && x.IsActive);
        //    try
        //    {
        //        entity.UserImagePath = url;
        //        _VehicleRepo.Update(entity);
        //        _VehicleRepo.CommitAllChanges();
        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Vehicle"));
        //    }
        //    catch (Exception)
        //    {

        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Vehicle"));
        //    }

        //    return mod;
        //}
        #endregion Vehicle_crud

        #endregion methods

    }
}
