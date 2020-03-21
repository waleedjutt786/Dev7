using dev7.EMS.Domain.Vendor;
using System.Collections.Generic;
using dev7.ems.model.vendor;

namespace dev7.EMS.Translators.Vendor
{
    public static class VendorTranslators
    {
        public static VendorDE Translate(this VendorMD from, VendorDE dest = null)
        {
            var to = dest ?? new VendorDE();
            if (to.Id <= 0)
            {
                to.Id = from.Id;
            }
            
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Gender = from.Gender;
            to.Image = from.Image;
            to.DateOfJoin = from.DateOfJoin;
            to.DateOfBirth = from.DateOfBirth;        
            to.VendorTypeId = from.VendorTypeId;
            to.CompanyId = from.CompanyId;
            to.CreatedById = from.CreatedById;
            to.CreatedDate = from.CreatedDate;
            to.IsActive = true;

            return to;
        }
        public static VendorMD Translate(this VendorDE from)
        {
            var to = new VendorMD();
            to.Id = from.Id;
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Gender = from.Gender;
            to.Image = from.Image;
            to.DateOfJoin = from.DateOfJoin;
            to.DateOfBirth = from.DateOfBirth;
            to.VendorTypeId = from.VendorTypeId;
            to.CompanyId = from.CompanyId;
            to.CreatedById = from.CreatedById;
            to.CreatedDate = from.CreatedDate;
            to.IsActive = from.IsActive;
            return to;

        }
        public static List<VendorMD> Translate(this List<VendorDE> list)
        {
            var vendors = new List<VendorMD>();
            foreach (var from in list)
            {
                var to = new VendorMD();

                to.Id = from.Id;
                to.FirstName = from.FirstName;
                to.LastName = from.LastName;
                to.Gender = from.Gender;
                to.Image = from.Image;
                to.DateOfJoin = from.DateOfJoin;
                to.DateOfBirth = from.DateOfBirth;
                to.VendorTypeId = from.VendorTypeId;
                to.CompanyId = from.CompanyId;
                to.CreatedById = from.CreatedById;
                to.CreatedDate = from.CreatedDate;
                to.IsActive = from.IsActive;
                vendors.Add(to);
            }
            return vendors;
        }
    }
}
