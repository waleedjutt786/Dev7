using System;
using dev7.EMS.Domain.Vehicle;
using dev7.EMS.Model.Vehicle;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Translators.Vehicle
{
    public static class VehicleTranslators
    {
        public static VehicleDE Translate(this VehicleMD from, VehicleDE dest = null)
        {
            var to = dest ?? new VehicleDE();
           if(from.Id > 0)
            {
                to.Id = from.Id;
            }
            to.IsActive = true;
           
            to.Type = from.Type;
            to.Number = from.Number;
            to.CompanyId = from.CompanyId;
            to.CreatedDate = from.CreatedDate;
            to.CreatedById = from.CreatedById;

            return to;
        }
        public static VehicleMD Translate(this VehicleDE from)
        {
            var to = new VehicleMD();
            to.Id = from.Id;
            to.Type = from.Type;
            to.Number = from.Number;
            to.CompanyId = from.CompanyId;
            to.IsActive = from.IsActive;
            to.CreatedDate = from.CreatedDate;
            to.CreatedById = from.CreatedById; return to;

        }
        public static List<VehicleMD> Translate(this List<VehicleDE> list)
        {
            var vehicles = new List<VehicleMD>();
            foreach (var from in list)
            {
                var to = new VehicleMD();

                to.Id = from.Id;
                to.Type = from.Type;
                to.Number = from.Number;
                to.CompanyId = from.CompanyId;
                to.IsActive = from.IsActive;
                to.CreatedDate = from.CreatedDate;
                to.CreatedById = from.CreatedById;
                vehicles.Add(to);
            }
            return vehicles;
        }
    }
}
