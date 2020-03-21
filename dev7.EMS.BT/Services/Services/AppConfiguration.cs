using System;
using System.Configuration;
using dev7.EMS.Services.ServiceContracts;

namespace dev7.EMS.Services.Services
{
    public class AppConfiguration : IAppConfiguartion
    {
        #region ApplicaitonPath

        /// <summary>
        /// Gets the portal base Url.
        /// </summary>
        /// <value>The portal base Url.</value>
        public string PortalBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["PortalBaseURL"];
            }
        }
        //public string PortalBaseUrl { get; set; }
        #endregion ApplicaitonPath

        #region BusinessDaysAndHours

        public string BusinessDaysAndHours => ConfigurationManager.AppSettings["BusinessDaysAndHours"];

        #endregion BusinessDaysAndHours


        #region ContactNumber
        public string ContactNumber => ConfigurationManager.AppSettings["ContactNumber"];
        #endregion ContactNumber

        #region Forget Key

        /// <summary>
        /// Password Forget key expiration days.
        /// </summary>
        public short ForgetKeyExpirationDays => short.Parse(ConfigurationManager.AppSettings["ExpDays"]);

        public string FromUserEmail => ConfigurationManager.AppSettings["FromEmail"];


        #endregion Forget Key

        #region CompanyName
        public string CompanyName => ConfigurationManager.AppSettings["CompanyName"];

        public string ResetPath
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion CompanyName  

    }
}
