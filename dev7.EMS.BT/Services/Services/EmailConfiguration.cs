using System.Configuration;

namespace dev7.EMS.Services.Services
{
    public static class EmailConfiguration
    {
        #region SMTP Data Members

        private static string _smtpHost;
        private static string _useDefaultCredentials;
        private static string _port;
        private static string _enableSsl;
        private static string _timeout;
        private static string _fromEmail;
        private static string _fromEmailPassword;
        private static string _fromTitle;
        private static string _defaultToEmail;
        private static string _defaultCcEmail;

        #endregion SMTP Data Members

        #region SMTP Configurations

        public static string SmtpHost
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(_smtpHost))
                _smtpHost = ConfigurationManager.AppSettings["SMTPHost"];
                return _smtpHost;
            }
        }

        public static bool UseDefaultCredentials
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(_useDefaultCredentials))
                _useDefaultCredentials = ConfigurationManager.AppSettings["UseDefaultCredentials"];
                return bool.Parse(_useDefaultCredentials);
            }
        }

        public static int Port
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(_port))
                _port = ConfigurationManager.AppSettings["Port"];
                return int.Parse(_port);
            }
        }

        public static bool EnableSsl
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(_enableSsl))
                _enableSsl = ConfigurationManager.AppSettings["EnableSsl"];
                return bool.Parse(_enableSsl);
            }
        }

        public static int Timeout
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(_timeout))
                _timeout = ConfigurationManager.AppSettings["Timeout"];
                return int.Parse(_timeout);
            }
        }

        public static string FromEmail
        {
            get
            {
                // if (string.IsNullOrWhiteSpace(_fromEmail))
                _fromEmail = ConfigurationManager.AppSettings["FromEmail"];
                return _fromEmail;
            }
        }

        public static string FromEmailPassword
        {
            get
            {
                // if (string.IsNullOrWhiteSpace(_fromEmailPassword))
                _fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"];
                return _fromEmailPassword;
            }
        }

        public static string FromTitle
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(_fromTitle))
                _fromTitle = ConfigurationManager.AppSettings["FromTitle"];
                return _fromTitle;
            }
        }

        public static string DefaultToEmail
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(_defaultToEmail))
                _defaultToEmail = ConfigurationManager.AppSettings["DefaultToEmail"];
                return _defaultToEmail;
            }
        }

        public static string DefaultCcEmail
        {
            get
            {
                _defaultCcEmail = ConfigurationManager.AppSettings["DefaultCcEmail"];
                return _defaultCcEmail;
            }
        }

        //Static configuration
        //public static string SMTP_USER_NAME = "drycleandepot@ssasoft.com"; //"", "lahmed@ssasoft.com";
        //public static string SMTP_From = "DryClean Depot";
        //public static string SMTP_PASSWORD = "pu&d001"; // "la&001r";
        //public static string SMTP_HOST = "mail.ssasoft.com";
        //public static int SMTP_PORT = 25;//25
        //public static string SMTP_MESSAGE_TYPE = "Html";
        //public static bool SMTP_ENABLE_SSL = false;
        //public static string SMTP_TO = "humayun.shoukat@ssasoft.com"; //bzaman@ssasoft.com  lahmed@ssasoft.com  edbabbie@pentacletechnologies.com

        #endregion SMTP Configurations
    }
}
