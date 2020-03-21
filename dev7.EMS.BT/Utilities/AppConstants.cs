namespace dev7.EMS.BT.Utilities.AppConstants
{
    public static class AppConstants
    {
        public static string CRUD_ADD = "{0} Added Successfully";
        public static string CRUD_ADD_ERROR = "Unable to save {0}";
        public static string CRUD_ADD_ERROR_DETAIL = "Unable to save {0} Error Detail is: {1}";

        public static string CRUD_UPDATE = "{0} Updated Successfully";
        public static string CRUD_UPDATE_ERROR = "Unable to update {0}";
        public static string CRUD_UPDATE_ERROR_DETAIL = "Unable to update {0} Error Detail is: {1}";


        public static string CRUD_DELETE = "{0} Deleted Successfully";
        public static string CRUD_DELETE_ERROR = "Unable to delete {0}";
        public static string CRUD_DELETE_ERROR_DETAIL = "Unable to delete {0} Error Detail is: {1}";
        public static string LEAVE = "{0} Leave Successfully";
             
        public static string CRUD_ERROR = "Error to perform operation";

        public static string EMPTY_ERROR = "{0} id is empty";
        public static string NOT_FOUND_ERROR = "{0} is not found";
        public static string NOTVALID_ERROR = "{0} is not valid";

        public static string CRUD_GET = "{0} Get Successfully";
        public static string CRUD_GET_ERROR = "Unable to Get {0}";
        public static string CRUD_GET_ERROR_DETAIL = "Unable to get {0} Error Detail is: {1}";

        #region APP_Config

        public static string ApiBaseURL = System.Configuration.ConfigurationManager.AppSettings["ApiBaseURL"];
        public static string Openfire = System.Configuration.ConfigurationManager.AppSettings["OpenFireURL"];//OpenFireURL
        public static string DefaultForumImage = "api//DefaultImage.png";
        public static string LogFile = "api/files/Log.txt"; // "api/Log.txt"; // ConfigurationManager.AppSettings["LogFile"];

        #endregion


    }
}
