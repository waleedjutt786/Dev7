//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Security.Principal;
//using System.Text;
//using System.Threading.Tasks;
//using dev7.EMS.DAL;
//using dev7.EMS.Domain.Customer;
//using dev7.EMS.Domain.Employee;
//using dev7.EMS.Framework;
//using dev7.EMS.Model;
//using dev7.EMS.Services.ServiceContracts;
//using dev7.EMS.Model.Account;
//using dev7.EMS.BT.Utilities;
//using dev7.EMS.Domain.Entities;
//using dev7.EMS.BT.Utilities.AppConstants;
//using dev7.EMS.DAL.Repository;
//using dev7.EMS.Translators.Company;
//using dev7.EMS.Translators.Employee;
//using dev7.EMS.Translators.Customer;
//using dev7.EMS.DAL.UoW;

//namespace dev7.EMS.Services.Services
//{
//    public class AccountService : IAccountService
//    {
//        #region DataMembers

//        private readonly IRepository<CustomerDE> _customerRepo;
//        private readonly IRepository<EmployeeDE> _employeeRepo;
//        private readonly IRepository<CompanyDE> _companyRepo;
//        private readonly IEncryptionService _encryptionService;
//        private readonly IUnitOfWork _CustomerUOW;
//        private readonly IUnitOfWork _EmployeeUOW;
//        private readonly IUnitOfWork _CompanyUOW;

//        //email code
//        private AppConfiguration _appConfiguration;
//        #endregion

//        #region Constructors

//        public AccountService()
//        {
//            _CompanyUOW = new CustomerUoW(DBHelper.ConnectionString);
//            _EmployeeUOW = new CustomerUoW(DBHelper.ConnectionString);
//            _CustomerUOW = new CustomerUoW(DBHelper.ConnectionString);

//            _customerRepo = new EFRepository<CustomerDE>(_CustomerUOW);
//            _employeeRepo = new EFRepository<EmployeeDE>(_EmployeeUOW);
//            _companyRepo = new EFRepository<CompanyDE>(_CompanyUOW);

//            _encryptionService = new EncryptionService();
//            _appConfiguration = new AppConfiguration();
//        }

//        //public AccountService(IUnitOfWork uow)
//        //{
//        //    _customerRepo = new EFRepository<CustomerDE>(_CustomerUOW);
//        //    _employeeRepo = new EFRepository<EmployeeDE>(_EmployeeUOW);
//        //    _companyRepo = new EFRepository<CompanyDE>(_CompanyUOW);

//        //    _appConfiguration = new AppConfiguration();
//        //}
//        #endregion

//        //        #region Service Implementation

//        //        /// <summary>
//        //        /// Validates the user through valid username and password and through particular
//        //        /// LoginUserType,Shows exception when username,password or user type is default. which is
//        //        /// Teacher , Customer or Employee.
//        //        /// </summary>
//        //        /// <param name="username">The username.</param>
//        //        /// <param name="password">The password.</param>
//        //        /// <param name="userType">Type of the user.</param>
//        //        /// <returns></returns>
//        //        /// <exception cref="System.ArgumentOutOfRangeException">userType - null</exception>
//        public MembershipContext ValidateUser(string username, string password, LoginUserType userType)
//        {
//            //Check null
//            if (username == default(string)) throw new ArgumentNullException(nameof(username));
//            if (password == default(string)) throw new ArgumentNullException(nameof(password));
//            if (!Enum.IsDefined(typeof(LoginUserType), userType)) throw new InvalidEnumArgumentException(nameof(userType));

//            MembershipContext membershipCtx = null;
//            //change on condition
//            switch (userType)
//            {
//                case LoginUserType.Customer:
//                    membershipCtx = ValidateCustomer(username, password);
//                    break;

//                case LoginUserType.Employee:
//                    membershipCtx = ValidateEmployee(username, password);
//                    break;

//            }

//            return membershipCtx;
//        }

//        //        /// <summary>
//        //        /// This method signs up user,firstly check userName already exists or not,Encrypts the
//        //        /// password before saving, shows error message if
//        //        /// unable to reach to database.
//        //        /// </summary>
//        //        /// <param name="user">The user.</param>
//        //        /// <param name="viewModel">The view model.</param>
//        //        /// <returns></returns>
//        //        /// <exception cref="System.Exception"></exception>
//        public CompanySignUpModel SignUpCompany(CompanySignUpModel mod)
//        {
//            //check null
//            if (mod == default(CompanySignUpModel)) throw new ArgumentNullException(nameof(mod));


//            //check the user existence in database
//            if (IsCompanyExists(mod.Email, mod))
//            {
//                mod.AddErrorMessage("Company already exist");

//                return mod;
//            }


//            //conversion UserModel to entity
//            var entity = mod.Translate();

//            //Generate the salt for password encryption
//            entity.Salt = _encryptionService.CreateSalt();
//            entity.Password = _encryptionService.EncryptPassword(entity.Password, entity.Salt);

//            try
//            {
//                _companyRepo.Insert(entity);
//                _companyRepo.CommitAllChanges();
//                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Company Registered Successfully"));
//                mod.Id = entity.Id;
//            }
//            catch (Exception ex)
//            {
//                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "Company not Registered, Try again"));
//            }

//            return mod;
//        }

//        //        /// <summary>
//        //        /// This method signs up user,firstly check userName already exists or not,Encrypts the
//        //        /// password before saving, shows error message if
//        //        /// unable to reach to database.
//        //        /// </summary>
//        //        /// <param name="user">The user.</param>
//        //        /// <param name="viewModel">The view model.</param>
//        //        /// <returns></returns>
//        //        /// <exception cref="System.Exception"></exception>
//        public EmployeeSignUpModel SignUpEmployee(EmployeeSignUpModel mod)
//        {
//            //check null
//            if (mod == default(EmployeeSignUpModel)) throw new ArgumentNullException(nameof(mod));


//            //check the user existence in database
//            if (IsEmployeeExists(mod.Email, mod))
//            {
//                mod.AddErrorMessage("Employee already exist");

//                return mod;
//            }


//            //conversion UserModel to entity
//            var entity = mod.Translate();

//            //Generate the salt for password encryption
//            entity.Salt = _encryptionService.CreateSalt();
//            entity.BasicInfo.Password = _encryptionService.EncryptPassword(entity.BasicInfo.Password, entity.Salt);

//            try
//            {
//                _employeeRepo.Insert(entity);
//                _employeeRepo.CommitAllChanges();
//                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Employee Registered Successfully"));
//                mod.Id = entity.Id;
//            }
//            catch (Exception ex)
//            {
//                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "Employee not registered, Try again"));
//            }

//            return mod;
//        }
//        //        /// <summary>
//        //        /// This method signs up user,firstly check userName already exists or not,Encrypts the
//        //        /// password before saving, shows error message if
//        //        /// unable to reach to database.
//        //        /// </summary>
//        //        /// <param name="user">The user.</param>
//        //        /// <param name="viewModel">The view model.</param>
//        //        /// <returns></returns>
//        //        /// <exception cref="System.Exception"></exception>
//        public CustomerSignUpModel SignUpCustomer(CustomerSignUpModel mod)
//        {
//            //check null
//            if (mod == default(CustomerSignUpModel)) throw new ArgumentNullException(nameof(mod));


//            //check the user existence in database
//            if (IsCustomerExists(mod.Email, mod))
//            {
//                mod.AddErrorMessage("Customer already exist");

//                return mod;
//            }


//            //conversion UserModel to entity
//            var entity = mod.Translate();

//            //Generate the salt for password encryption
//            entity.Salt = _encryptionService.CreateSalt();
//            entity.BasicInfo.Password = _encryptionService.EncryptPassword(entity.BasicInfo.Password, entity.Salt);

//            try
//            {
//                _customerRepo.Insert(entity);
//                _customerRepo.CommitAllChanges();
//                mod.AddSuccessMessage(string.Format(AppConstants.CRUD_ADD, "Customer Registered Successfully"));
//                mod.Id = entity.Id;
//            }
//            catch (Exception ex)
//            {
//                mod.AddErrorMessage(string.Format(AppConstants.CRUD_ADD_ERROR, "Customer not registered, try again"));
//            }

//            return mod;
//        }
//        //        /// <summary>
//        //        /// Changes the password depends upon LoginUserType (User) condition by taking
//        //        /// viewModel and LoginUserType as input, shows null exception if viewModel is default
//        //        /// </summary>
//        //        /// <param name="viewModel">The view model.</param>
//        //        /// <param name="userType">Type of the user.</param>
//        //        /// <returns></returns>
//        //        public async Task UpdatePassword(ChangePasswordViewModel viewModel, LoginUserType userType)
//        //        {
//        //            //check the null
//        //            if (viewModel == default(ChangePasswordViewModel)) throw new ArgumentNullException(nameof(viewModel));

//        //            //change on condition
//        //            switch (userType)
//        //            {
//        //                case LoginUserType.Teacher:
//        //                    await UpdateUserPassword(viewModel);
//        //                    break;
//        //                default:
//        //                    throw new ArgumentOutOfRangeException(nameof(userType), userType, "Undefined user type");
//        //            }
//        //        }

//        //        /// <summary>
//        //        /// This method handles the forget password scenario by verifying customer email through
//        //        /// database,shows error message when "Customer Not Found", create unique GUID against that
//        //        /// email also throws null exception when email or viewModel is default.
//        //        /// </summary>
//        //        /// <param name="email">The email.</param>
//        //        /// <param name="viewModel"></param>
//        //        /// <returns></returns>
//        //        /// <exception cref="System.ArgumentNullException">email</exception>
//        //        public async Task<string> ForgetPassword(string email, ModelBase viewModel)
//        //        {
//        //            if (email == default(string)) throw new ArgumentNullException(nameof(email));
//        //            if (viewModel == default(ModelBase)) throw new ArgumentNullException(nameof(viewModel));

//        //            var teacher = await _repository.FetchAsync<Entities.Teacher>(x => x.Email == email);

//        //            if (teacher == default(Entities.Teacher))
//        //            {
//        //                viewModel.AddErrorMessage("Email is not registered.");
//        //                return string.Empty;
//        //            }

//        //            var guid = Guid.NewGuid();
//        //            teacher.PasswordForgetKey = guid.ToString();
//        //            teacher.Salt = _encryptionService.CreateSalt();
//        //            teacher.Password = _encryptionService.EncryptPassword(guid.ToString(), teacher.Salt);
//        //            teacher.ModifiedDate = DateTime.Now;
//        //            //As HttpContext does not contains user id because user is not logged in to passing that information using Entity property.
//        //            teacher.LoggedUserId = teacher.Id;
//        //            var entity = await _repository.SaveAsync(teacher);
//        //            if (entity.HasErrors)
//        //                viewModel.AddErrorMessage("Error processing forget password request.");
//        //            else
//        //                viewModel.AddSuccessMessage("Login information is emailed successfully.");

//        //            return teacher.PasswordForgetKey;
//        //        }

//        //        /// <summary>
//        //        /// Verifies the forget key matching in database,shows error message "Invalid request access
//        //        /// is denied" when user is default,
//        //        /// </summary>
//        //        /// <param name="viewModel">The view model.</param>
//        //        /// <returns></returns>
//        //        /// <exception cref="System.ArgumentNullException">viewModel</exception>
//        //        public async Task<ResetPasswordViewModel> VerifyForgotkey(ResetPasswordViewModel viewModel)
//        //        {
//        //            //Check the Null
//        //            if (viewModel == default(ResetPasswordViewModel)) throw new ArgumentNullException(nameof(viewModel));

//        //            //Get the user data from database
//        //            var user = await _repository.FetchAsync<Entities.Teacher>(x => x.PasswordForgetKey == viewModel.Forgotkey);

//        //            if (user == default(Entities.Teacher))
//        //            {
//        //                viewModel.AddErrorMessage("Invalid request access is denied.");
//        //                return viewModel;
//        //            }

//        //            var days = (DateTime.Now - user.ModifiedDate?.Date)?.Days;
//        //            if (!string.IsNullOrWhiteSpace(days.ToString()) && days <= _appConfiguration.ForgetKeyExpirationDays)
//        //            {
//        //                viewModel.Forgotkey = user.PasswordForgetKey;
//        //                viewModel.Isvalid = true;
//        //            }
//        //            else
//        //            {
//        //                viewModel.AddErrorMessage("URL is expired.");
//        //            }
//        //            return viewModel;
//        //        }

//        //        /// <summary>
//        //        /// Resets the password of user and model user within three days when unique key is
//        //        /// received on email, checks null exception if restModel or viewModel is default,saves
//        //        /// password in encrypted form and shows error message "Error on Updating Password" when
//        //        /// getting any problem of accessing database.
//        //        /// </summary>
//        //        /// <param name="restModel">The rest model.</param>
//        //        /// <param name="viewModel">The view model.</param>
//        //        /// <returns></returns>
//        //        /// <exception cref="System.NotImplementedException"></exception>
//        //        /// 
//        //        public async Task ResetPassword(ResetPasswordViewModel restModel)
//        //        {
//        //            //check the null
//        //            if (restModel == default(ResetPasswordViewModel)) throw new ArgumentNullException(nameof(restModel));

//        //            //Get teacher form database
//        //            var user = await _repository.FetchAsync<Entities.Teacher>(x => x.PasswordForgetKey == restModel.Forgotkey);
//        //            if (user == default(Entities.Teacher))
//        //            {
//        //                restModel.AddErrorMessage("Invalid request access is denied.");
//        //                return;
//        //            }
//        //            restModel.Isvalid = false;
//        //            var days = (DateTime.Now - user.ModifiedDate?.Date)?.Days;
//        //            if (!string.IsNullOrWhiteSpace(days.ToString()) && days <= _appConfiguration.ForgetKeyExpirationDays)
//        //            {
//        //                //Encrypts the password before saving
//        //                user.PasswordForgetKey = null;
//        //                user.Salt = _encryptionService.CreateSalt();
//        //                user.Password = _encryptionService.EncryptPassword(restModel.Password, user.Salt);

//        //                //saving data into database
//        //                var entiy = await _repository.SaveAsync(user);
//        //                //Getting error on updating password
//        //                if (entiy.HasErrors)
//        //                    restModel.AddErrorMessage("Error resetting password");
//        //                else
//        //                {
//        //                    restModel.AddSuccessMessage("Password is reset successfully.");
//        //                    restModel.Isvalid = true;
//        //                }
//        //            }
//        //            else
//        //            {
//        //                restModel.AddErrorMessage("URL is expired.");
//        //            }
//        //        }

//        public void CreateAuthorizationToken(BaseLoginViewModel viewModel, LoginUserType userType)
//        {
//            var plainText = $"{viewModel.Email}:{viewModel.Password}:{ userType}";
//            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
//            var token = $"Basic {Convert.ToBase64String(plainTextBytes)}";
//            viewModel.SetToken(token);
//        }

//        //        /// <summary>
//        //        /// Update the customer password by taking viewModel of ChangePasswordViewModel type as input
//        //        /// ,checks the old password and null exception if viewModel.Id is default show error message
//        //        /// when unable to access database, customer is not found in database or Incorrect given
//        //        /// current password.
//        //        /// </summary>
//        //        /// <param name="viewModel">The view model.</param>
//        //        /// <returns></returns>
//        //        /// <exception cref="System.ArgumentNullException"></exception>
//        //        //private async Task UpdateCustomerPassword(ChangePasswordViewModel viewModel)
//        //        //{
//        //        //    //check the null
//        //        //    if (viewModel.Id == default(long)) throw new ArgumentNullException(nameof(viewModel.Id));

//        //        //    //Get data from database
//        //        //    var customer = await _repository.FetchAsync<Entities.Customer>(x => x.Id == viewModel.Id);
//        //        //    //show error message
//        //        //    if (customer == default(Entities.Customer))
//        //        //    {
//        //        //        viewModel.AddErrorMessage("Customer not found.");
//        //        //        return;
//        //        //    }

//        //        //    if (customer.HasErrors)
//        //        //    {
//        //        //        viewModel.AddErrorMessage("Unable to fetch Customer information.");
//        //        //        return;
//        //        //    }

//        //        //    //check the old password
//        //        //    if (!string.Equals(_encryptionService.EncryptPassword(viewModel.OldPassword, customer.Salt), customer.Password))
//        //        //    {
//        //        //        viewModel.AddErrorMessage("Incorrect current password.");
//        //        //        return;
//        //        //    }

//        //        //    customer.Salt = _encryptionService.CreateSalt();
//        //        //    customer.Password = _encryptionService.EncryptPassword(viewModel.Password, customer.Salt);
//        //        //    //saving new encrypted password into DB
//        //        //    var entity = await _repository.SaveAsync(customer);

//        //        //    if (entity.HasErrors)
//        //        //        viewModel.AddErrorMessage("Error on updating password, try again.");
//        //        //    else
//        //        //        viewModel.AddSuccessMessage("Password is updated successfully");
//        //        //}

//        //        /// <summary>
//        //        /// Update the user password by taking viewModel of ChangePasswordViewModel type as input
//        //        /// ,checks the old password and null exception if viewModel.Id is default show error message
//        //        /// when unable to access database, user is not found in database or Incorrect given current password.
//        //        /// </summary>
//        //        /// <param name="viewModel">The view model.</param>
//        //        /// <returns></returns>
//        //        /// <exception cref="System.ArgumentNullException"></exception>
//        //        private async Task UpdateUserPassword(ChangePasswordViewModel viewModel)
//        //        {
//        //            //check the null
//        //            if (viewModel.Id == default(long)) throw new ArgumentNullException(nameof(viewModel.Id));

//        //            //Get request from database
//        //            var user = await _repository.FetchAsync<Entities.Teacher>(x => x.Id == viewModel.Id);
//        //            //Show error message
//        //            if (user == default(Entities.Teacher))
//        //            {
//        //                viewModel.AddErrorMessage("User not found.");
//        //                return;
//        //            }
//        //            if (user.HasErrors)
//        //            {
//        //                viewModel.AddErrorMessage("Unable to fetch User information.");
//        //                return;
//        //            }
//        //            //check the old password
//        //            if (!string.Equals(_encryptionService.EncryptPassword(viewModel.OldPassword, user.Salt), user.Password))
//        //            {
//        //                viewModel.AddErrorMessage("Incorrect current password.");
//        //                return;
//        //            }

//        //            user.Salt = _encryptionService.CreateSalt();
//        //            user.Password = _encryptionService.EncryptPassword(viewModel.Password, user.Salt);
//        //            //saving new encrypted password
//        //            var entity = await _repository.SaveAsync(user);

//        //            if (entity.HasErrors)
//        //                viewModel.AddErrorMessage("Error updating password");
//        //            else
//        //                viewModel.AddSuccessMessage("Password is Updated successfully");
//        //        }

//        //        /// <summary>
//        //        /// Validates the customer.
//        //        /// </summary>
//        //        /// <param name="username">The username.</param>
//        //        /// <param name="password">The password.</param>
//        //        /// <returns></returns>
//        private MembershipContext ValidateCustomer(string username, string password)
//        {
//            var membershipCtx = new MembershipContext();
//            //Get data from database
//            var customer = _customerRepo.Fetch(x => x.BasicInfo.Email.Trim() == username.Trim());

//            var user = customer == default(CustomerDE) ? new UserModel() : customer.ToUserModel();

//            if (user == default(UserModel) || !IsUserValid(user, password)) return membershipCtx;

//            membershipCtx.User = user;

//            var identity = new GenericIdentity(user.FullName);
//            var roles = new[] { "Customer" };
//            membershipCtx.Principal = new GenericPrincipal(identity, roles);

//            return membershipCtx;
//        }

//        //        /// <summary>
//        //        /// Validates the Employee.
//        //        /// </summary>
//        //        /// <param name="username">The username.</param>
//        //        /// <param name="password">The password.</param>
//        //        /// <returns></returns>
//        private MembershipContext ValidateEmployee(string username, string password)
//        {
//            var membershipCtx = new MembershipContext();
//            //Get data from database
//            var employee = _employeeRepo.Fetch(x => x.BasicInfo.Email.Trim() == username.Trim());

//            var user = employee == default(EmployeeDE) ? new UserModel() : employee.ToUserModel();

//            if (user == default(UserModel) || !IsUserValid(user, password)) return membershipCtx;

//            membershipCtx.User = user;

//            var identity = new GenericIdentity(user.FullName);
//            var roles = new[] { "Employee" };
//            membershipCtx.Principal = new GenericPrincipal(identity, roles);

//            return membershipCtx;
//        }

//        //        /// <summary>
//        //        /// Validates the Company.
//        //        /// </summary>
//        //        /// <param name="username">The username.</param>
//        //        /// <param name="password">The password.</param>
//        //        /// <returns></returns>
//        private MembershipContext ValidateCompany(string username, string password)
//        {
//            var membershipCtx = new MembershipContext();
//            //Get data from database
//            var company = _companyRepo.Fetch(x => x.Email.Trim() == username.Trim());

//            var user = company == default(CompanyDE) ? new UserModel() : company.ToUserModel();

//            if (user == default(UserModel) || !IsUserValid(user, password)) return membershipCtx;

//            membershipCtx.User = user;

//            var identity = new GenericIdentity(user.FullName);
//            var roles = new[] { "company" };
//            membershipCtx.Principal = new GenericPrincipal(identity, roles);

//            return membershipCtx;
//        }

//        //        /// <summary>
//        //        /// Validates the user.
//        //        /// </summary>
//        //        /// <param name="username">The username.</param>
//        //        /// <param name="password">The password.</param>
//        //        /// <returns></returns>
//        //        private MembershipContext ValidateTeacher(string username, string password)
//        //        {
//        //            var membershipCtx = new MembershipContext();
//        //            //Get teacher data from database
//        //            var teacher = _repository.Fetch<Entities.Teacher>(x => x.Email.Trim() == username.Trim());

//        //            var user = teacher == default(Entities.Teacher) ? new UserModel() : teacher.To<UserModel>();
//        //            ////Return null membership
//        //            if (user == default(UserModel) || !IsUserValid(user, password)) return membershipCtx;

//        //            membershipCtx.User = user;

//        //            var identity = new GenericIdentity(user.FullName);
//        //            var roles = new[] { "Teacher" };
//        //            membershipCtx.Principal = new GenericPrincipal(identity, roles);

//        //            return membershipCtx;
//        //        }

//        //private MembershipContext ValidateEmployee(string username, string password)
//        //{
//        //    var membershipCtx = new MembershipContext();
//        //   // Get employee data from database
//        //    var employee = _repository.Fetch<>(x => x.Email.Trim() == username.Trim());

//        //    var user = employee == default(User) ? new UserModel() : employee.To<UserModel>();
//        //    //Return null membership
//        //    if (user == default(UserModel) || !IsUserValid(user, password)) return membershipCtx;

//        //    membershipCtx.User = user;

//        //    var identity = new GenericIdentity(user.FullName);
//        //    var roles = new[] { "Employee" };
//        //    membershipCtx.Principal = new GenericPrincipal(identity, roles);

//        //    return membershipCtx;
//        //}

//        //        #endregion Service Implementation

//        #region Helper methods

//        /// <summary>
//        /// these two methods verifies valid user and password
//        /// </summary>
//        /// <param name="user"></param>
//        /// <param name="password"></param>
//        /// <returns></returns>
//        private bool IsUserValid(UserModel user, string password)
//        {
//            if (IsPasswordValid(user, password))
//            {
//                return !user.IsLocked;
//            }

//            return false;
//        }

//        /// <summary>
//        /// Determines whether [is password valid] [the specified user].
//        /// </summary>
//        /// <param name="user">The user.</param>
//        /// <param name="password">The password.</param>
//        /// <returns><c>true</c> if [is password valid] [the specified user]; otherwise, <c>false</c>.</returns>
//        private bool IsPasswordValid(UserModel user, string password)
//        {
//            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.Password);
//        }

//        /// <summary>
//        /// Determines if the email address already exists in the database. Also raises the error
//        /// flag and adds error message for the model class.
//        /// </summary>
//        /// <param name="email">The Email.</param>
//        /// <param name="viewModel">The view model.</param>
//        /// <returns>Returns a Boolean true or false.</returns>
//        private bool IsCompanyExists(string email, ModelBase viewModel)
//        {
//            var company = _companyRepo.Fetch(x => x.Email == email);
//            var result = company != default(CompanyDE);

//            if (!result) return false;
//            viewModel.HasErrors = true;
//            viewModel.AddErrorMessage("Email address already exists. Please try another email address to register company.");

//            return true;
//        }
//        /// <summary>
//        /// Determines if the email address already exists in the database. Also raises the error
//        /// flag and adds error message for the model class.
//        /// </summary>
//        /// <param name="Email">The Email.</param>
//        /// <param name="viewModel">The view model.</param>
//        /// <returns>Returns a Boolean true or false.</returns>
//        private bool IsEmployeeExists(string email, ModelBase viewModel)
//        {
//            var employee = _employeeRepo.Fetch(x => x.BasicInfo.Email == email);
//            var result = employee != default(EmployeeDE);

//            if (!result) return false;
//            viewModel.HasErrors = true;
//            viewModel.AddErrorMessage("Email address already exists. Please try another email address.");

//            return true;
//        }
//        /// <summary>
//        /// Determines if the email address already exists in the database. Also raises the error
//        /// flag and adds error message for the model class.
//        /// </summary>
//        /// <param name="email">The email.</param>
//        /// <param name="viewModel">The view model.</param>
//        /// <returns>Returns a Boolean true or false.</returns>
//        private bool IsCustomerExists(string email, ModelBase viewModel)
//        {
//            var Customer = _customerRepo.Fetch(x => x.BasicInfo.Email == email);
//            var result = Customer != default(CustomerDE);

//            if (!result) return false;
//            viewModel.HasErrors = true;
//            viewModel.AddErrorMessage("Email address already exists. Please try another email address.");

//            return true;
//        }

//        #endregion Helper methods

//        //        #region ctor

//        //        /// <summary>
//        //        /// Initializes a new instance of the <see cref="AccountService"/> class.
//        //        /// </summary>
//        //        /// <param name="encryptionService">The encryption service.</param>
//        //        /// <param name="repository">The repository.</param>
//        //        /// <param name="appConfiguration">The application configuration.</param>
//        //public AccountService(IEncryptionService encryptionService, IDCEntitiesGenericRepository repository, IAppConfiguartion appConfiguration) : base(repository)
//        //{
//        //    _encryptionService = encryptionService;
//        //    _repository = repository;
//        //    _appConfiguration = appConfiguration;
//        //}

//        //        #endregion ctor
//    }
//}
