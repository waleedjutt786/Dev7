using dev7.ems.model.vendor;
using System.Collections.Generic;

namespace dev7.EMS.Model.Vendor
{
    public class VendorsMD : ModelBase
    {
        public VendorsMD()
        {
            vendors = new List<VendorMD>();
        }
        public List<VendorMD> vendors { get; set; }
    }

}
