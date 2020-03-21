//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using CrystalDecisions.CrystalReports.Engine;       //what is CrystalDecisions used for?  crystal reports?
//using CrystalDecisions.Shared;
//using CrystalDecisions.Web;
//using System.Configuration;
//using System.IO;
//using System.Data;
//using System.Data.SqlClient;
//using dev7.EMS.Framework;

//namespace dev7.EMS.Framework
//{
//    public class ReportsHelper
//    {
//        private readonly ReportDocument _rptDoc;    
//        private readonly ReportNames _rptName;
//        private readonly ReportTypes _rptType;
//        private readonly string _appRootPath;
//        private readonly string _tempReportsPath;
//        private string _rptFile;
//        //private string _rptFileFromRoot;
//        private string _msg;
//        private string _tempReportsFolder;

//        public ReportsHelper(ReportTypes rptType, ReportNames rptName, string appRootPath) //, Dictionary<string,object> rptParams=null)
//        {
//            _rptType = rptType;
//            _rptName = rptName;
//            _appRootPath = appRootPath; // HttpContext.Current.Server.MapPath("~\\");

//            _rptDoc = new ReportDocument();
//            _rptFile = GetReportFile();
//            _rptDoc.Load(_rptFile);
//            _rptDoc.FileName = _rptFile;
//            _tempReportsFolder = @"TempReports\";

//            _tempReportsPath = string.Format("{0}{1}", _appRootPath, _tempReportsFolder);
//            TranslateConnection();
//        }
//        public void SetParameterValue(string name, object val)
//        {
//            _rptDoc.SetParameterValue(name, val);
//        }


//        public void SetFormulaField(FormulaField rptFormulaFields)
//        {

//            try { _rptDoc.DataDefinition.FormulaFields["rpt_CompanyName"].Text = "'" + rptFormulaFields.CompanyName + "'"; }
//            catch { }
//            try { _rptDoc.DataDefinition.FormulaFields["rpt_CompanyAddress1"].Text = "'" + rptFormulaFields.CompanyAddress1 + "'"; }
//            catch { }
//            try { _rptDoc.DataDefinition.FormulaFields["rpt_CompanyAddress2"].Text = "'" + rptFormulaFields.CompanyAddress2 + "'"; }
//            catch { }
//            try { _rptDoc.DataDefinition.FormulaFields["rpt_CompanyContact"].Text = "'" + rptFormulaFields.CompanyContact + "'"; }
//            catch { }

//            try { _rptDoc.DataDefinition.FormulaFields["rpt_DevelopedBy"].Text = "'" + rptFormulaFields.DevelopedBy + "'"; }
//            catch { }
//            try { _rptDoc.DataDefinition.FormulaFields["rpt_DevelopedContact"].Text = "'" + rptFormulaFields.DevelopedContact + "'"; }
//            catch { }
//            try { _rptDoc.DataDefinition.FormulaFields["rpt_ReportTitle"].Text = "'" + rptFormulaFields.ReportTitle + "'"; }
//            catch { }
//            try { _rptDoc.DataDefinition.FormulaFields["rpt_ReportCriteria"].Text = "'" + rptFormulaFields.ReportCriteria + "'"; }
//            catch { }

//            try { _rptDoc.DataDefinition.FormulaFields["rpt_LoginUser"].Text = "'" + rptFormulaFields.LoginUser + "'"; }
//            catch { }
//            try { _rptDoc.DataDefinition.FormulaFields["rpt_LoginSite"].Text = "'" + rptFormulaFields.LoginSite + "'"; }
//            catch { }
//            try { _rptDoc.DataDefinition.FormulaFields["rpt_LoginYear"].Text = "'" + rptFormulaFields.LoginYear + "'"; }
//            catch { }
//            try { _rptDoc.DataDefinition.FormulaFields["rpt_LoginDateTime"].Text = "'" + rptFormulaFields.LoginDateTime + "'"; }
//            catch { }
//        }

//        public bool PrintToPrinter(int nCopies, bool collated, int startPageN, int endPageN)
//        {
//            bool retVal = false;
//            try
//            {
//                _rptDoc.PrintToPrinter(nCopies, collated, startPageN, endPageN);
//                retVal = true;
//            }
//            catch (Exception ex)
//            {
//                _msg = ex.Message;
//            }
//            return retVal;
//        }
//        public string PDFBase64 
//        { 
//            get
//            {
//                return Convert.ToBase64String(File.ReadAllBytes(ReportFile));
            
//            }
//            //set; 
//        }

//        public string PdfFileName { get; set; }
//        public bool ExportToDisk(string timeStamp = "", ReportPrintingOptions reportPrintingOptions = ReportPrintingOptions.ExportToPdf)
//        {
//            bool retVal = false;
//            try
//            {
//                DeleteExistingFiles();
//                string rptFile = string.Empty;
//                string fileExtension = string.Empty;
                
//                switch(reportPrintingOptions)
//                {
//                    case ReportPrintingOptions.ExportToPdf:
//                        fileExtension = string.Format(".{0}", FileExtensions.pdf.ToString());
//                        break;
//                    case ReportPrintingOptions.ExportToExcel:
//                        fileExtension = string.Format(".{0}", FileExtensions.xlsx.ToString());
//                        break;
//                }
                
//                if (string.IsNullOrEmpty(timeStamp))
//                    timeStamp = "_" + DateTime.Now.Year.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.ToShortTimeString().Replace(":", "");
//                string rptFullName = _rptName.ToString() + timeStamp + fileExtension;
//                PdfFileName = rptFullName;
//                rptFile = string.Format("{0}{1}", _tempReportsPath, rptFullName);
//                //try
//                //{
//                //    DataTable dt = GetAppImageDataTable();
//                //    _rptDoc.Database.Tables["AppImages"].SetDataSource(dt);
//                //}
//                //catch { }
//                //_rptFileFromRoot = _tempReportsFolder + rptFullName;
//                if (reportPrintingOptions == ReportPrintingOptions.ExportToPdf)
//                    _rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, rptFile);
//                    //_rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, "C:\\Output.pdf");
//                else if (reportPrintingOptions == ReportPrintingOptions.ExportToExcel)
//                    _rptDoc.ExportToDisk(ExportFormatType.Excel, rptFile);
//                //_rptFile = rptFullName;
//                _rptFile = rptFile; // rptFullName;

//                retVal = true;
//            }
//            catch (Exception ex)
//            {
//                _msg = ex.Message;
//            }
//            return retVal;
//        }

//        private void DeleteExistingFiles()
//        {
//            DirectoryInfo dirInfo = new DirectoryInfo(_tempReportsPath);
//            foreach (FileInfo file in dirInfo.GetFiles())
//            {
//                try
//                {
//                    file.Delete();
//                }
//                catch 
//                {
                
//                }
//            }
//        }

//        public string Message
//        {
//            get { return _msg; }
//        }

//        public string ReportFile
//        {
//            get
//            { return _rptFile; }
//        }

//        public ReportDocument ReportDoc
//        {
//            get { return _rptDoc; }
//        }

//        private string GetReportFile()
//        {
//            string rptFile = String.Empty;
//            string rptFilePath = string.Empty;
//            string fileExtension = string.Format(".{0}", FileExtensions.rpt.ToString());

//            switch (_rptType)
//            {
//                case ReportTypes.Account: rptFilePath = _appRootPath + @"Reports\Account\"; break;
//                case ReportTypes.Doors: rptFilePath = _appRootPath + @"Reports\Doors\"; break;
//                case ReportTypes.Payroll: rptFilePath = _appRootPath + @"Reports\Payroll\"; break;
//                case ReportTypes.PO: rptFilePath = _appRootPath + @"Reports\PO\"; break;
//                case ReportTypes.Production: rptFilePath = _appRootPath + @"Reports\Production\"; break;
//                case ReportTypes.SalesOrder: rptFilePath = _appRootPath + @"Reports\SaleOrder\"; break;
//                case ReportTypes.Sales: rptFilePath = _appRootPath + @"Reports\Sales\"; break;
//                case ReportTypes.Stock: rptFilePath = _appRootPath + @"Reports\Stock\"; break;
//                case ReportTypes.AlKhair: rptFilePath = _appRootPath + @"Reports\AlKhair\"; break;

//                case ReportTypes.GroceryKit: rptFilePath = _appRootPath + @"Reports\GroceryKit\"; break;
//            }

//            rptFile = string.Format("{0}{1}{2}", rptFilePath, _rptName.ToString(), fileExtension);

//            return rptFile;
//        }

//        private void TranslateConnection()
//        {
//            ConnectionInfo rptConnectionInfo = new ConnectionInfo();
//            TableLogOnInfo rptTableLogOnInfo = new TableLogOnInfo();

//            SqlConnectionStringBuilder sqlSb = new SqlConnectionStringBuilder(DBHelper.ConnectionString);

//            //rptConnectionInfo.ServerName = sqlSb.DataSource; // AppHelper.DataSource;
//            //rptConnectionInfo.DatabaseName = sqlSb.InitialCatalog; // AppHelper.DataBase;
//            //if (!string.IsNullOrEmpty(sqlSb.UserID) && !string.IsNullOrEmpty(sqlSb.Password))
//            //{
//            //    rptConnectionInfo.UserID = sqlSb.UserID; // AppHelper.UserID;
//            //    rptConnectionInfo.Password = sqlSb.Password; // AppHelper.Password;
//            //}
//            //else
//            //    rptConnectionInfo.IntegratedSecurity = sqlSb.IntegratedSecurity;

//            rptConnectionInfo.ServerName = sqlSb.DataSource; // ConfigurationManager.AppSettings["DataSource"]; 
//            rptConnectionInfo.DatabaseName = sqlSb.InitialCatalog; // ConfigurationManager.AppSettings["DataBase"];
//            //if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["UserID"]))
//            if (!string.IsNullOrEmpty(sqlSb.UserID))
//            {
//                rptConnectionInfo.UserID = sqlSb.UserID; // ConfigurationManager.AppSettings["UserID"];
//                rptConnectionInfo.Password = sqlSb.Password; // ConfigurationManager.AppSettings["Password"];
//            }
//            else
//                rptConnectionInfo.IntegratedSecurity = true;

//            foreach (CrystalDecisions.CrystalReports.Engine.Table rptTable in _rptDoc.Database.Tables)
//            {
//                rptTableLogOnInfo = rptTable.LogOnInfo;
//                rptTableLogOnInfo.ConnectionInfo = rptConnectionInfo;
//                rptTable.ApplyLogOnInfo(rptTableLogOnInfo);
//            }
//        }

//        private DataTable GetAppImageDataTable()
//        {
//            DataTable dt = new DataTable();
//            try
//            {
//                DataRow dRow;
//                dt.Columns.Add("Image", System.Type.GetType("System.Byte[]"));
//                dRow = dt.NewRow();
//                FileStream fs;
//                BinaryReader br;
//                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Images\logo.png"))
//                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\Images\logo_reports.png", FileMode.Open);
//                else
//                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\Images\twitter.png", FileMode.Open);

//                br = new BinaryReader(fs);
//                Byte[] imgbyte = new Byte[fs.Length];
//                imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length));
//                dRow[0] = imgbyte;
//                dt.Rows.Add(dRow);
//                br.Close();
//                fs.Close();
//            }
//            catch (Exception ex)
//            {

//            }
//            return dt;
//        }
//    }

//    public class FormulaField
//    {
//        public FormulaField()
//        {
//            CompanyName = ConfigurationManager.AppSettings["CompanyName"];
//            CompanyAddress1 = ConfigurationManager.AppSettings["CompanyAddressLine1"];
//            CompanyAddress2 = ConfigurationManager.AppSettings["CompanyAddressLine2"];
//            CompanyContact = ConfigurationManager.AppSettings["CompanyContact"];
//            DevelopedBy = ConfigurationManager.AppSettings["DevelopedBy"];
//            DevelopedContact = ConfigurationManager.AppSettings["DevelopedContact"];
//        }
//        public string CompanyName { get; set; }
//        public string CompanyAddress1 { get; set; }
//        public string CompanyAddress2 { get; set; }
//        public string CompanyContact { get; set; }
//        public string DevelopedBy { get; set; }
//        public string DevelopedContact { get; set; }
//        public string ReportTitle { get; set; }
//        public string ReportCriteria { get; set; }
//        public string LoginUser { get; set; }
//        public string LoginSite { get; set; }
//        public string LoginYear { get; set; }
//        public string LoginDateTime { get; set; }
//    }
//}
