using dev7.EMS.Domain.Customer;
using dev7.EMS.Model.Customer;
using System.Linq;

namespace dev7.EMS.Services.ServiceContracts.Customer
{
    public interface ICustomerServiceContract
    {
        #region Customer

        CustomerMD RegisterCustomer(CustomerMD mod);
        CustomerMD ModifyCustomer(CustomerMD mod);
        CustomerMD DeleteCustomer(int id);
        CustomersMD GetAllCustomers(int id);

        IQueryable<CustomerDE> GetAllQuerableCustomers();
        CustomerMD GetCustomerById(int id);

        #endregion
    }
}
