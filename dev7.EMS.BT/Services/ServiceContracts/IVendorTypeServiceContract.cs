using dev7.EMS.Domain.VendorType;
using dev7.EMS.Model.VendorType;
using System.Linq;

namespace dev7.EMS.Services.ServiceContracts.VendorType
{
    public interface IVendorTypeServiceContract
    {
        #region VendorType

        VendorTypeMD AddVendorType(VendorTypeMD mod);
        VendorTypeMD ModifyVendorType(VendorTypeMD mod);
        VendorTypeMD DeleteVendorType(long id);
        VendorTypesMD GetAllVendorTypes(int id);

        IQueryable<VendorTypeDE> GetAllQuerableVendorTypes();
        VendorTypeMD GetVendorTypeById(long id);

        #endregion
    }
}
