using dev7.EMS.Domain.Employee;
using dev7.EMS.Model.Employee;
using System.Linq;

namespace dev7.EMS.Services.ServiceContracts.Employee
{
    public interface IEmployeeServiceContract
    {
        #region Employee

        EmployeeMD RegisterEmployee(EmployeeMD mod);
        EmployeeMD ModifyEmployee(EmployeeMD mod);
        EmployeeMD DeleteEmployee(long id);
        EmployeesMD GetAllEmployees(int id);

        IQueryable<EmployeeDE> GetAllQuerableEmployees();
        EmployeeMD GetEmployeeById(long id);

        #endregion
    }
}
