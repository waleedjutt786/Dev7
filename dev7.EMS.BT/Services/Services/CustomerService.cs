using dev7.EMS.BT.Utilities.AppConstants;
using dev7.EMS.DAL.Repository;
using dev7.EMS.DAL.UoW;
using dev7.EMS.Domain.Customer;
using dev7.EMS.Framework;
using dev7.EMS.Model.Customer;
using dev7.EMS.Services.ServiceContracts;
using dev7.EMS.Services.ServiceContracts.Customer;
using dev7.EMS.Translators.Customer;
using System;
using System.Linq;

namespace dev7.EMS.Services.Services.Customer
{
    public class CustomerService : ICustomerServiceContract
    {
        #region DataMembers

        private readonly IRepository<CustomerDE> _CustomerRepo;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _uow;

        //email code
        private AppConfiguration _appConfiguration;
        #endregion

        #region Constructors

        public CustomerService()
        {
            _uow = new EMSUoW(DBHelper.ConnectionString);
            _CustomerRepo = new EFRepository<CustomerDE>(_uow);

            _encryptionService = new EncryptionService();
            _appConfiguration = new AppConfiguration();
        }

        public CustomerService(IUnitOfWork uow)
        {
            _CustomerRepo = new EFRepository<CustomerDE>(uow);
            _appConfiguration = new AppConfiguration();
        }
        #endregion

        #region methods

        #region Customer_crud
        public CustomerMD RegisterCustomer(CustomerMD mod)
        {
            try
            {
                var entity = mod.Translate();
                _CustomerRepo.Insert(entity);
                _CustomerRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Customer"));
                mod.Id = entity.Id;
            }
            catch (Exception ex)
            {
                mod.HasErrors = true;
                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "Customer"));
            }

            return mod;
        }

        public CustomerMD DeleteCustomer(int id)
        {
            var mod = new CustomerMD();
            try
            {
                var Customer = _CustomerRepo.Fetch(x => x.IsActive);
                Customer.IsActive = false;
                _CustomerRepo.Update(Customer);
                _CustomerRepo.CommitAllChanges();

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_DELETE, "Customer"));
            }
            catch (Exception ex)
            {

                mod.AddErrorMessage(string.Format(AppConstants.CRUD_DELETE_ERROR, "Customer"));
            }
            return mod;
        }

        public CustomersMD GetAllCustomers(int id) 
        {
            var viewModel = new CustomersMD();
            try
            {
                viewModel.customers = _CustomerRepo.GetAll(x => x.CompanyId == id && x.IsActive).ToList().Translate();
                viewModel.AddSuccessMessage(string.Format(AppConstants.CRUD_GET, "Customers"));
            }
            catch (Exception)
            {
                viewModel.HasErrors = true;
                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "Customers"));
            }
            return viewModel;
        }

        public IQueryable<CustomerDE> GetAllQuerableCustomers()
        {
            return _CustomerRepo.Query.Where(x => x.IsActive);
        }

        public CustomerMD GetCustomerById(int id)
        {
            var entity = _CustomerRepo.Fetch(x => x.Id == id && x.IsActive);
            return entity.Translate();
        }

        public CustomerMD ModifyCustomer(CustomerMD mod)
        {
            var entity = mod.Translate();
            try
            {
                _CustomerRepo.Update(entity);
                _CustomerRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Customer"));
            }
            catch (Exception)
            {

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Customer"));
            }

            return mod;
        }



        //public CustomerMD UpdateCustomerImage(long id, string url)
        //{
        //    var mod = new CustomerMD();
        //    var entity = _CustomerRepo.Fetch(x => x.Id == id && x.IsActive);
        //    try
        //    {
        //        entity.UserImagePath = url;
        //        _CustomerRepo.Update(entity);
        //        _CustomerRepo.CommitAllChanges();
        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Customer"));
        //    }
        //    catch (Exception)
        //    {

        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Customer"));
        //    }

        //    return mod;
        //}
        #endregion Customer_crud

        #endregion methods

    }
}
