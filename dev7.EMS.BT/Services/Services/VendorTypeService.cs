     using dev7.EMS.BT.Utilities.AppConstants;
using dev7.EMS.DAL.Repository;
using dev7.EMS.DAL.UoW;
using dev7.EMS.Domain.VendorType;
using dev7.EMS.Framework;
using dev7.EMS.Model.VendorType;
using dev7.EMS.Services.ServiceContracts;
using dev7.EMS.Services.ServiceContracts.VendorType;
using dev7.EMS.Translators.VendorType;
using System;
using System.Linq;

namespace dev7.EMS.Services.Services.VendorType
{
    public class VendorTypeService : IVendorTypeServiceContract
    {
        #region DataMembers

        private readonly IRepository<VendorTypeDE> _VendorTypeRepo;
        private readonly IEncryptionService _encryptionService;
        private readonly EMSUoW _uow;

        //email code
        private AppConfiguration _appConfiguration;
        #endregion

        #region Constructors

        public VendorTypeService()
        {
            _uow = new EMSUoW(DBHelper.ConnectionString);
            _VendorTypeRepo = new EFRepository<VendorTypeDE>(_uow);

            _encryptionService = new EncryptionService();
            _appConfiguration = new AppConfiguration();
        }

        public VendorTypeService(EMSUoW uow)
        {
            _VendorTypeRepo = new EFRepository<VendorTypeDE>(uow);
            _appConfiguration = new AppConfiguration();
        }
        #endregion

        #region methods

        #region VendorType_crud
        public VendorTypeMD AddVendorType(VendorTypeMD mod)
        {
            try
            {
                var entity = mod.Translate();
                _VendorTypeRepo.Insert(entity);
                _VendorTypeRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "VendorType"));
                mod.Id = entity.Id;
            }
            catch (Exception ex)
            {
                mod.HasErrors = true;
                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "VendorType"));
            }

            return mod;
        }

        public VendorTypeMD DeleteVendorType(long id)
        {
            var mod = new VendorTypeMD();
            try
            {
                var VendorType = _VendorTypeRepo.Fetch(x => x.IsActive);
                VendorType.IsActive = false;
                _VendorTypeRepo.Update(VendorType);
                _VendorTypeRepo.CommitAllChanges();

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_DELETE, "VendorType"));
            }
            catch (Exception ex)
            {

                mod.AddErrorMessage(string.Format(AppConstants.CRUD_DELETE_ERROR, "VendorType"));
            }
            return mod;
        }

        public VendorTypesMD GetAllVendorTypes(int id)
        {
            var viewModel = new VendorTypesMD();
            try
            {
                viewModel.vendortypes = _VendorTypeRepo.GetAll(x => x.IsActive).ToList().Translate();
                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET, "VendorTypes"));
            }
            catch (Exception)
            {

                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "VendorTypes"));
            }
            return viewModel;
        }

        public IQueryable<VendorTypeDE> GetAllQuerableVendorTypes()
        {
            return _VendorTypeRepo.Query.Where(x => x.IsActive);
        }

        public VendorTypeMD GetVendorTypeById(long id)
        {
            var entity = _VendorTypeRepo.Fetch(x => x.Id == id && x.IsActive);
            return entity.Translate();
        }

        public VendorTypeMD ModifyVendorType(VendorTypeMD mod)
        {
            var entity = mod.Translate();
            try
            {
                _VendorTypeRepo.Update(entity);
                _VendorTypeRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "VendorType"));
            }
            catch (Exception)
            {

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "VendorType"));
            }

            return mod;
        }



        //public VendorTypeMD UpdateVendorTypeImage(long id, string url)
        //{
        //    var mod = new VendorTypeMD();
        //    var entity = _VendorTypeRepo.Fetch(x => x.Id == id && x.IsActive);
        //    try
        //    {
        //        entity.UserImagePath = url;
        //        _VendorTypeRepo.Update(entity);
        //        _VendorTypeRepo.CommitAllChanges();
        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "VendorType"));
        //    }
        //    catch (Exception)
        //    {

        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "VendorType"));
        //    }

        //    return mod;
        //}
        #endregion VendorType_crud

        #endregion methods

    }
}
