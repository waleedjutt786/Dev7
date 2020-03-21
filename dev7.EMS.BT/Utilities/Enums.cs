using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.BT.Utilities
{
    public enum ReportNames
    {
        // Accounts
        Account_BalanceSheet,
        Account_BankBalanceSheet,
        Account_DailyReport,
        Account_ProfitandLoss,
        Account_SummaryReport,
        Accounts_Ledger,


        //Sales
        Customer_BalanceSheet,
        Invoice,
        InvoicePre,
        InvoiceReturn,


        // SalesOrder
        SaleOrderSummary,
        SaleOrder,
        SaleOrderMainReport,
        SaleOrderContract,
        // Payroll
        Payroll_EmployeePayrollDetail,
        PayrollSummaryLocationWise,
        PayrollDetailLocationWise,
        PayrollSummary,
        PaySlip,

        //Purchase 
        POPre,
        PO,

        //Invoices
        Vendor_BalanceSheet,

        //Production
        ProductionOrder,

        //Stock
        Stock_History,

        //Voucher
        VoucherPreview,
        VouchersList,
        VouchersListByGiftType,

        // Grocery Kit
        GroceryKitPreview
    }

    public enum ReportTypes
    {
        Account, Doors, Payroll, PO, Production, SalesOrder, Sales, Stock, AlKhair, GroceryKit
    }

    public enum ReportPrintingOptions
    {
        PrintToPrinter, ExportToPdf, ExportToExcel
    }

    public enum FileExtensions
    {
        rpt, pdf, png, jpg, gif, xls, xlsx, doc
    }

    public enum GroceryKitSearchCriterias
    {
        ContactNumber = 1
        , HouseStatus = 2
        , DistributionPoint = 3
        , CNIC = 4
        , Occupation = 5
        //,Address = 6
        , Medical = 7
        , Gender = 8
        , Member = 9
        , ZakatAcceptable = 10
        , FamilySize = 11
    }

    public enum MaritalStatus
    {
        Married = 1,
        Unmarried = 2,
        Divorced = 3
    }
    public enum EventStatus
    {
        Pending = 1,
        Completed = 2,
        Canceled = 3
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public enum ResultCode
    {
        Success,
        Danger,
        Warning
    }

    public enum FriendRequestStatus
    {
        [Description("Not Friend")]
        NotFriend,
        [Description("Friend")]
        Friend,
        [Description("Request Sent")]
        RequestSent,
        [Description("Request Received")]
        RequestReceived,
        [Description("Request Reject")]
        RequestReject,
        [Description("Request Accepted")]
        RequestAccepted,
        [Description("ReSend Request")]
        ReSendRequest,
        [Description("Request Cancel")]
        RequestCancel,
        [Description("UnFriend")]
        UnFriend,
        [Description("UnBlocked")]
        UnBlocked,
        [Description("Blocked")]
        Blocked
    }

    public enum DirectoryList
    {
        Campus = 1,
        Request,
        Friend
    }
    public enum UsersGroup
    {
        Student = 1,
        Alumni ,
        Faculty,
        Employee ,
        Resident_fellow,
        Blocked ,
        Other
    }
    public enum SortArray
    {
        Comment = 1,
        Title,
        Score,
        Date,
        User,
        Views
    }

    public enum MessageType
    {
        SMS,
        Email
    }



    public enum BazarListSort
    {
        Price,
        Title,
        Date,
        Views
    }

    public enum LoginUserType
    {
        Admin,
        Employee,
        Customer
    }

    public enum AccountOperation
    {
        SignUp,
        Profile,
        ForgetPassword
    }

    public enum ProfileEducationList
    {
        All,
        Degree,
        Department,
        Univeristy,
        College,
        Major
    }

    public enum ItemCondition
    {
        New,
        [Description("Like New")]
        LikeNew,
        [Description("Very New")]
        VeryGood,
        Good,
        Acceptable
    }

    public enum UserType
    {
        //[Display(Name = "Admin")]
        [Description("Admin")]
        Admin = 1,
        [Description("Employee")]
        Employee = 2,
        [Description("Customer")]
        Customer =3
    }
    public enum MediaType
    {
            ch = 1,
            dh=2
       
    }
    public enum ItemCategory
    {
        Flex = 1,
        [Description("Visiting Card")]
        VisitingCard = 2

    }


    public enum OrderStatus
    {
        Open = 1,
        InProcess = 2,
        [Description("Ready For Printing")]
        ReadyForPrinting = 3,
        [Description("Ready For Delivery")]
        ReadyForDelivery=4,
        [Description("Delivered To Customer")]
        DeliveredToCustomer=5
    }

    public enum FriendStatus
    {
        PendingRequest = 1,
        NotFriend = 2,
        Friend = 3,
        RequestReceived
    }

    public enum ChatType
    {
        One_On_One = 1,
        Multi_Chat = 2
    }

    public enum FileType
    {
        Files = 1,
        Links = 2,
        Pics = 3,
        Videos = 4
    }

    public enum Status
    {
        NotFriend = 0,
        Friend = 1,
        Unfriend = 2
    }
    public enum FileExtension
    {
        jpg = 1,
        png = 2,
        jpeg = 3,
        bmp = 4,
        mp3 = 5,
        avi = 6,
        dat = 7,
        url=101
    }

    public enum CorvisModule
    {
        Profil = 1,
        Directory = 2,
        Bazar = 3,
        Forum = 4,
        Chat = 5
    }
}
