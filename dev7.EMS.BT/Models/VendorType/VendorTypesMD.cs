using System.Collections.Generic;

namespace dev7.EMS.Model.VendorType
{
    public class VendorTypesMD : ModelBase
    {
        public VendorTypesMD()
        {
            vendortypes = new List<VendorTypeMD>();
        }
        public List<VendorTypeMD> vendortypes { get; set; }
    }
}
