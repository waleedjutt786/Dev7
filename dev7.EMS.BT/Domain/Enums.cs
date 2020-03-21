using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Domain
{
    public enum ProjectStatuses { Open = 1, Close, InProgress }
    public enum DBOperations { Select, Insert, Delete, Update }
    public enum AddressTypes { Personal = 10, Billing = 20, Shipping = 30, Picking = 40, Delivery = 50 }
    public enum EntityTypes { CMP, DOC, MGR, EMP, KIT}
    public enum IncomeTypes { SAL, DON, OTH }
    public enum CostTypes { FOD, HSE, SCH, UTL, MED, OTH }

    public enum ExcelSheetImportErrors
    {
        NoError,
        ReadFileError,
        ReadColumnError,
        ReadRowError,
        InsertRowInDBError,
        EditRowInDBError,
        RecordAlreadyExistsInDB
    }

    public enum EntityTypeCodes
    { 
        /// <summary> Company </summary>
        CMP
       , /// <summary> Donor </summary> 
        DNR
       , /// <summary> DOC </summary> 
       DOC
       , /// <summary> Gift </summary>
       GFT
       , /// <summary> Employee </summary>
        EMP
        , /// <summary> Bank </summary>
        BNK
    }

    public enum PrlongOptions 
    { SaveOnly, SaveAndPrlong, SaveAndPdf, SaveAndExcel }

    public enum ExportTypes { PDF, Excel }
}
