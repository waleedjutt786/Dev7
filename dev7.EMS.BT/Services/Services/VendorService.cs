using dev7.EMS.Domain.Vendor;
using dev7.EMS.Framework;
using dev7.EMS.Model.Vendor;
using dev7.EMS.Services.ServiceContracts;
using dev7.EMS.Services.ServiceContracts.Vendor;
using dev7.EMS.Translators.Vendor;
using System;
using System.Linq;
using dev7.EMS.DAL.UoW;
using dev7.EMS.DAL.Repository;
using dev7.ems.model.vendor;
using dev7.EMS.BT.Utilities.AppConstants;

namespace dev7.EMS.Services.Services.Vendor
{
    public class VendorService : IVendorServiceContract
    {
        #region DataMembers

        private readonly IRepository<VendorDE> _VendorRepo;
        private readonly IEncryptionService _encryptionService;
        private readonly EMSUoW _uow;

        //email code
        private AppConfiguration _appConfiguration;
        #endregion

        #region Constructors

        public VendorService()
        {
            _uow = new EMSUoW(DBHelper.ConnectionString);
            _VendorRepo = new EFRepository<VendorDE>(_uow);

            _encryptionService = new EncryptionService();
            _appConfiguration = new AppConfiguration();
        }

        public VendorService(IUnitOfWork uow)
        {
            _VendorRepo = new EFRepository<VendorDE>(uow);
            _appConfiguration = new AppConfiguration();
        }
        #endregion

        #region methods

        #region Vendor_crud
        public VendorMD AddVendor(VendorMD mod)
        {
            try
            {
                var entity = mod.Translate();
                _VendorRepo.Insert(entity);
                _VendorRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Vendor"));
                mod.Id = entity.Id;
            }
            catch (Exception ex)
            {
                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "Vendor"));
            }

            return mod;
        }

        public VendorMD DeleteVendor(long id)
        {
            var mod = new VendorMD();
            try
            {
                var Vendor = _VendorRepo.Fetch(x => x.IsActive);
                Vendor.IsActive = false;
                _VendorRepo.Update(Vendor);
                _VendorRepo.CommitAllChanges();

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_DELETE, "Vendor"));
            }
            catch (Exception ex)
            {

                mod.AddErrorMessage(string.Format(AppConstants.CRUD_DELETE_ERROR, "Vendor"));
            }
            return mod;
        }

        public VendorsMD GetAllVendors(int id)
        {
            var viewModel = new VendorsMD();
            try
            {
                viewModel.vendors = _VendorRepo.GetAll(x => x.IsActive).ToList().Translate();
                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET, "Vendors"));
            }
            catch (Exception)
            {

                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "Vendors"));
            }
            return viewModel;
        }

        public IQueryable<VendorDE> GetAllQuerableVendors()
        {
            return _VendorRepo.Query.Where(x => x.IsActive);
        }

        public VendorMD GetVendorById(long id)
        {
            var entity = _VendorRepo.Fetch(x => x.Id == id && x.IsActive);
            return entity.Translate();
        }

        public VendorMD ModifyVendor(VendorMD mod)
        {
            var entity = mod.Translate();
            try
            {
                _VendorRepo.Update(entity);
                _VendorRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Vendor"));
            }
            catch (Exception)
            {

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Vendor"));
            }

            return mod;
        }



        //public VendorMD UpdateVendorImage(long id, string url)
        //{
        //    var mod = new VendorMD();
        //    var entity = _VendorRepo.Fetch(x => x.Id == id && x.IsActive);
        //    try
        //    {
        //        entity.UserImagePath = url;
        //        _VendorRepo.Update(entity);
        //        _VendorRepo.CommitAllChanges();
        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Vendor"));
        //    }
        //    catch (Exception)
        //    {

        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Vendor"));
        //    }

        //    return mod;
        //}
        #endregion Vendor_crud

        #endregion methods

    }
}
