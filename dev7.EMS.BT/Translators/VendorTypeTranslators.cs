using System;
using dev7.EMS.Domain.VendorType;
using dev7.EMS.Model.VendorType;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Translators.VendorType
{
    public static class VendorTypeTranslators
    {
        public static VendorTypeDE Translate(this VendorTypeMD from, VendorTypeDE dest = null)
        {
            var to = dest ?? new VendorTypeDE();
            if (to.Id <= 0)
            {
                to.Id = from.Id;
                to.IsActive = true;
            }
            else
            {

                to.IsActive = from.IsActive;
                
            }
            to.Type = from.Type;
            to.Description = from.Description;
            to.CreatedById = from.CreatedById;
            to.CompanyId = from.CompanyId;
            to.CreatedDate = from.CreatedDate;
            

            return to;
        }
        public static VendorTypeMD Translate(this VendorTypeDE from)
        {
            var to = new VendorTypeMD();
            to.Id = from.Id;
            to.Type = from.Type;
            to.Description = from.Description;
            to.CreatedById = from.CreatedById;
            to.CompanyId = from.CompanyId.Value;
            to.CreatedDate = from.CreatedDate;
           
            return to;

        }
        public static List<VendorTypeMD> Translate(this List<VendorTypeDE> list)
        {
            var vendortypes = new List<VendorTypeMD>();
            foreach (var from in list)
            {
                var to = new VendorTypeMD();

                to.Id = from.Id;
                to.Type = from.Type;
                to.Description = from.Description;
                to.CreatedById = from.CreatedById;
                to.CompanyId = from.CompanyId.Value;
                to.CreatedDate = from.CreatedDate;
                
                vendortypes.Add(to);
            }
            return vendortypes;
        }
    }
}
