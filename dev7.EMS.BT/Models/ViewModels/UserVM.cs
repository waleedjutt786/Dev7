using dev7.EMS.Model.ViewModels;

namespace dev7.EMS.Model
{
    public class BaseLoginViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; private set; }

        public void SetToken(string value)
        {
            Token = value;
        }
    }

    public class LoginViewModel : BaseLoginViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
        }

    }

    // Following class is used for list of users that contain only field that show in table
    public class UsersModel : ModelBase
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string StatusStr { get; set; }
        public string Role { get; set; }
    }

    //Following class is used for adding new user and modifying user
    public class UserModel : ModelBase 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => Framework.Extention.StringExtensions.FirstNameLastNameFormat(FirstName, LastName);
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int RoleId { get; set; }
        public bool IsLocked { get; set; } = false;
    }
}
