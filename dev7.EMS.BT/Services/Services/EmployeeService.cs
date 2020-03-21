using dev7.EMS.BT.Utilities.AppConstants;
using dev7.EMS.DAL;
using dev7.EMS.DAL.Repository;
using dev7.EMS.DAL.UoW;
using dev7.EMS.Domain.Employee;
using dev7.EMS.Framework;
using dev7.EMS.Model.Employee;
using dev7.EMS.Services.ServiceContracts;
using dev7.EMS.Services.ServiceContracts.Employee;
using dev7.EMS.Services.Services;
using dev7.EMS.Translators.Employee;
using System;
using System.Linq;

namespace dev7.EMS.Services.Services.Employee
{
    public class EmployeeService : IEmployeeServiceContract
    {
        #region DataMembers

        private readonly IRepository<EmployeeDE> _EmployeeRepo;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _uow;

        //email code
        private AppConfiguration _appConfiguration;
        #endregion

        #region Constructors

        public EmployeeService()
        {
            _uow = new EMSUoW(DBHelper.ConnectionString);
            _EmployeeRepo = new EFRepository<EmployeeDE>(_uow);

            _encryptionService = new EncryptionService();
            _appConfiguration = new AppConfiguration();
        }

        public EmployeeService(IUnitOfWork uow)
        {
            _EmployeeRepo = new EFRepository<EmployeeDE>(uow);
            _appConfiguration = new AppConfiguration();
        }
        #endregion

        #region methods

        #region Employee_crud
        public EmployeeMD RegisterEmployee(EmployeeMD mod)
        {
            try
            {
                var entity = mod.Translate();
                _EmployeeRepo.Insert(entity);
                _EmployeeRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Employee"));
                mod.Id = entity.Id;
            }
            catch (Exception ex)
            {
                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "Employee"));
            }

            return mod;
        }

        public EmployeeMD DeleteEmployee(long id)
        {
            var mod = new EmployeeMD();
            try
            {
                var Employee = _EmployeeRepo.Fetch(x => x.IsActive);
                Employee.IsActive = false;
                _EmployeeRepo.Update(Employee);
                _EmployeeRepo.CommitAllChanges();

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_DELETE, "Employee"));
            }
            catch (Exception ex)
            {

                mod.AddErrorMessage(string.Format(AppConstants.CRUD_DELETE_ERROR, "Employee"));
            }
            return mod;
        }

        public EmployeesMD GetAllEmployees(int id)
        {
            var viewModel = new EmployeesMD();
            try
            {
                var abc = _EmployeeRepo.GetAll(x => x.IsActive && x.CompanyId==id).ToList();
                viewModel.employees = abc.Translate();
                viewModel.AddSuccessMessage(string.Format(AppConstants.CRUD_GET, "Employees"));
            }
            catch (Exception ex)
            {
                viewModel.HasErrors = true;
                viewModel.AddErrorMessage(string.Format(AppConstants.CRUD_GET_ERROR, "Employees"));
            }
            return viewModel;
        }

        public IQueryable<EmployeeDE> GetAllQuerableEmployees()
        {
            return _EmployeeRepo.Query.Where(x => x.IsActive);
        }

        public EmployeeMD GetEmployeeById(long id)
        {
            var entity = _EmployeeRepo.Fetch(x => x.Id == id && x.IsActive);
            return entity.Translate();
        }

        public EmployeeMD ModifyEmployee(EmployeeMD mod)
        {
            var entity = mod.Translate();
            try
            {
                _EmployeeRepo.Update(entity);
                _EmployeeRepo.CommitAllChanges();
                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Employee"));
            }
            catch (Exception)
            {

                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Employee"));
            }

            return mod;
        }



        //public EmployeeMD UpdateEmployeeImage(long id, string url)
        //{
        //    var mod = new EmployeeMD();
        //    var entity = _EmployeeRepo.Fetch(x => x.Id == id && x.IsActive);
        //    try
        //    {
        //        entity.UserImagePath = url;
        //        _EmployeeRepo.Update(entity);
        //        _EmployeeRepo.CommitAllChanges();
        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE, "Employee"));
        //    }
        //    catch (Exception)
        //    {

        //        mod.AddSuccessMessage(string.Format(AppConstants.CRUD_UPDATE_ERROR, "Employee"));
        //    }

        //    return mod;
        //}
        #endregion Employee_crud

        #endregion methods

    }
}
