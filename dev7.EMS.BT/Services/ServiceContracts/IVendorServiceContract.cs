using dev7.ems.model.vendor;
using dev7.EMS.Domain.Vendor;
using dev7.EMS.Model.Vendor;
using System.Linq;

namespace dev7.EMS.Services.ServiceContracts.Vendor
{
    public interface IVendorServiceContract
    {
        #region Vendor

        VendorMD AddVendor(VendorMD mod);
        VendorMD ModifyVendor(VendorMD mod);
        VendorMD DeleteVendor(long id);
        VendorsMD GetAllVendors(int id);

        IQueryable<VendorDE> GetAllQuerableVendors();
        VendorMD GetVendorById(long id);

        #endregion
    }
}
