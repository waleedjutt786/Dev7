using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Domain
{
    public static class AppConstants
    {
        public static string SITE_CODE = "QST";
        public static string ENTITY_TYPE_CODE = "KIT";

        #region CRUD Operations

        public static string CRUD_CREATE = "{0} Added Successfully  تم الحفظ بنجاح";
        public static string CRUD_UPDATE = "{0} Modified Successfully    تم الحفظ بنجاح";
        public static string CRUD_DELETE = "{0} Deleted Successfully     تم الحفظ بنجاح";

        #endregion

        public static string VALIDATION_REQUIRED_FIELD = "{0} is Required Field يجب ادخال قيمه";
        public static string VALIDATION_ALREADY_EXISTS = "{0} already exists  موجود من قبل";

        public static string DEFAULT_DONOR_CODE = "000";
        public static DateTime DEFAULT_DATE = new DateTime(1900, 1, 1);
        //public static string CON_STR = System.Configuration.ConfigurationManager.ConnectionStrings["csPQS"].ConnectionString;

        public static string KIT_MEMBER_PICS_PATH = @"~\images\GroceryKitMembers\";

    }
}
