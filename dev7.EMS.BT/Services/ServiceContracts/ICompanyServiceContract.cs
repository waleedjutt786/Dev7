using dev7.EMS.Model.Company;
using System.Linq;
using dev7.EMS.Domain.Entities;
//using dev7.EMS.Model.EventTemplate;

namespace dev7.EMS.Services.ServiceContracts.Company
{
    public interface ICompanyServiceContract
    {
        #region Company

        CompanyMD RegisterCompany(CompanyMD mod);
        CompanyMD ModifyCompany(CompanyMD mod);
        CompanyMD DeleteCompany(long id);
        CompaniesMD GetAllCompanys();

        IQueryable<CompanyDE> GetAllQuerableCompanys();
        CompanyMD GetCompanyById(long id);



        #endregion
    }
}
