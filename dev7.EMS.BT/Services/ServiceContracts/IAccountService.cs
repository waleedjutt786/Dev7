using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dev7.EMS.Framework;
using dev7.EMS.Model;
using dev7.EMS.Model.Account;
using dev7.EMSP.Model.Account;
using dev7.EMS.BT.Utilities;

namespace dev7.EMS.Services.ServiceContracts
{
    public interface IAccountService
    {
        /// <summary>
        /// Validates the user through valid username and password and through particular
        /// LoginUserType,Shows exception when username,password or user type is default. which is
        /// Customer or Employee.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="userType">Type of the user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">userType - null</exception>
        MembershipContext ValidateUser(string username, string password, LoginUserType userType);

        /// <summary>
        /// This method signs up user,firstly check userName already exists or not,Encrypts the
        /// password before saving,Add the address object against EntityType, shows error message if
        /// unable to reach to database.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        CompanySignUpModel SignUpCompany(CompanySignUpModel user);
        EmployeeSignUpModel SignUpEmployee(EmployeeSignUpModel user);
        CustomerSignUpModel SignUpCustomer(CustomerSignUpModel user);

        /// <summary>
        /// Changes the password depends upon LoginUserType (Employee|| Customer) condition by taking
        /// viewModel and LoginUserType as input, shows null exception if viewModel is default
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="userType">Type of the user.</param>
        /// <returns></returns>
       // Task UpdatePassword(ChangePasswordViewModel viewModel, LoginUserType userType);

        /// <summary>
        /// This method handles the forgets the password scenario by verifying user email through
        /// database,shows error message when "Customer Not Found", create unique GUID against that
        /// email also throws null exception when email or viewModel is default.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">email</exception>
       // Task<string> ForgetPassword(string email, ModelBase viewModel);

        /// <summary>
        /// Verifies the forget key matching in database,shows error message "Invalid request access
        /// is denied" when user is default,
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">viewModel</exception>
       // Task<ResetPasswordViewModel> VerifyForgotkey(ResetPasswordViewModel viewModel);

        /// <summary>
        /// Resets the password of user and model user within three days when unique key is
        /// received on email, checks null exception if restModel or viewModel is default,saves
        /// password in encrypted form and shows error message "Error on Updating Password" when
        /// getting any problem of accessing database.
        /// </summary>
        /// <param name="restModel">The rest model.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        //Task ResetPassword(ResetPasswordViewModel restModel);

        void CreateAuthorizationToken(BaseLoginViewModel viewModel, LoginUserType userType);
    }
}
