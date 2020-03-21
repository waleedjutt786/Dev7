using System.Configuration;

namespace dev7.EMS.Framework
{

    public static class DBHelper
    {
        //Returns the database connection string
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["csEMS"].ConnectionString;
            }
        }
    }
}
