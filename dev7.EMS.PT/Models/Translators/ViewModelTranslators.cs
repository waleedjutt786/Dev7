using dev7.EMS.Model.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dev7.EMS.PT.Models.Translators
{
    public static class ViewModelTranslators
    {
        public static CompanyMD Translate(this RegisterCompanyViewModel from, CompanyMD dest = null)
        {
            var to = dest ?? new CompanyMD();
            to.Id = from.Id;
            to.Name = from.Name;
            to.IsActive = true;
            to.Logo = "";
            to.ImagePath = "";
            to.CreatedDate = DateTime.Now;
            to.CreatedById = 0;

            return to;
        }
    }
}