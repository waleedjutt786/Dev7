using dev7.EMS.BT.Utilities.AppConstants;
using dev7.EMS.DAL;
using dev7.EMS.DAL.Repository;
using dev7.EMS.DAL.UoW;
using dev7.EMS.Domain.Entities;
using dev7.EMS.Framework;
using dev7.EMS.Model.Company;
using dev7.EMS.Services.ServiceContracts;
using dev7.EMS.Services.ServiceContracts.Company;
using dev7.EMS.Services.Services;
using dev7.EMS.Translators.Company;
using System;
using System.Linq;

namespace dev7.EMS.Services.Services.Company
{
    public class CompanyService : ICompanyServiceContract
    {
        #region DataMembers

        private readonly IRepository<CompanyDE> _CompanyRepo;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _uow;

        //email code
        private AppConfiguration _appConfiguration;
        #endregion

        #region Constructors

        public CompanyService()
        {
            _uow = new EMSUoW(DBHelper.ConnectionString);
            _CompanyRepo = new EFRepository<CompanyDE>(_uow);

            _encryptionService = new EncryptionService();
            _appConfiguration = new AppConfiguration();
        }

        public CompanyService(IUnitOfWork uow)
        {
            _CompanyRepo = new EFRepository<CompanyDE>(uow);
            _appConfiguration = new AppConfiguration();
        }
        #endregion

        #region methods

        #region Company_crud
        public CompanyMD RegisterCompany(CompanyMD mod)
        {
            try
            {
                var entity = mod.Translate();
                _CompanyRepo.Insert(entity);
                _CompanyRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Company"));
                mod.Id = entity.Id;
            }
            catch (Exception ex)
            {
                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "Company"));
            }

            return mod;
        }

        public CompanyMD DeleteCompany(long id)
        {
            var mod = new CompanyMD();
            try
            {
                var Company = _CompanyRepo.Fetch(x => x.IsActive);
                Company.IsActive = false;
                _CompanyRepo.Update(Company);
                _CompanyRepo.CommitAllChanges();

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_DELETE, "Company"));
            }
            catch (Exception ex)
            {

                mod.AddErrorMessage(string.Format(AppConstants.CRUD_DELETE_ERROR, "Company"));
            }
            return mod;
        }

        public CompaniesMD GetAllCompanys()
        {
            var viewModel = new CompaniesMD();
            try
            {
                viewModel.companies = _CompanyRepo.GetAll(x => x.IsActive).ToList().Translate();
                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET, "Companys"));
            }
            catch (Exception)
            {

                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "Companys"));
            }
            return viewModel;
        }

        public IQueryable<CompanyDE> GetAllQuerableCompanys()
        {
            return _CompanyRepo.Query.Where(x => x.IsActive);
        }

        public CompanyMD GetCompanyById(long id)
        {
            var entity = _CompanyRepo.Fetch(x => x.Id == id && x.IsActive);
            return entity.Translate();
        }

        public CompanyMD ModifyCompany(CompanyMD mod)
        {
            var entity = mod.Translate();
            try
            {
                _CompanyRepo.Update(entity);
                _CompanyRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Company"));
            }
            catch (Exception)
            {

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Company"));
            }

            return mod;
        }



        //public CompanyMD UpdateCompanyImage(long id, string url)
        //{
        //    var mod = new CompanyMD();
        //    var entity = _CompanyRepo.Fetch(x => x.Id == id && x.IsActive);
        //    try
        //    {
        //        entity.UserImagePath = url;
        //        _CompanyRepo.Update(entity);
        //        _CompanyRepo.CommitAllChanges();
        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Company"));
        //    }
        //    catch (Exception)
        //    {

        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Company"));
        //    }

        //    return mod;
        //}
        #endregion Company_crud

        #endregion methods

    }
}
