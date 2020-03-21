using System;
using dev7.EMS.Domain.VehicleFuel;
using dev7.EMS.Model.VehicleFuel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Translators.VehicleFuel
{
    public static class VehicleFuelTranslators
    {
        public static VehicleFuelDE Translate(this VehicleFuelMD from, VehicleFuelDE dest = null)
        {
            var to = dest ?? new VehicleFuelDE();
            if (to.Id <= 0)
            {
                to.Id = from.Id;
                to.IsActive = true;
            }
            else
            {

                to.IsActive = from.IsActive;
            }
            to.Date = from.Date;
            to.Amount = from.Amount;
            to.EmployeeId = from.EmployeeId;
            to.VehicleId = from.VehicleId;
            to.CreatedById = from.CreatedById;
            to.CreatedDate = from.CreatedDate;

            return to;
        }
        public static VehicleFuelMD Translate(this VehicleFuelDE from)
        {
            var to = new VehicleFuelMD();
            to.Id = from.Id;
            to.Date = from.Date;
            to.Amount = from.Amount;
            to.EmployeeId = from.EmployeeId.Value;
            to.VehicleId = from.VehicleId;
            to.CreatedById = from.CreatedById;
            to.CreatedDate = from.CreatedDate;
            to.IsActive = from.IsActive;
            return to;

        }
        public static List<VehicleFuelMD> Translate(this List<VehicleFuelDE> list)
        {
            var vehiclefuels = new List<VehicleFuelMD>();
            foreach (var from in list)
            {
                var to = new VehicleFuelMD();
                to.Id = from.Id;
                to.Date = from.Date;
                to.Amount = from.Amount;
                to.EmployeeId = from.EmployeeId.Value;
                to.VehicleId = from.VehicleId;
                to.CreatedById = from.CreatedById;
                to.CreatedDate = from.CreatedDate;
                to.IsActive = from.IsActive;

                vehiclefuels.Add(to);
            }
            return vehiclefuels;
        }
    }
}
