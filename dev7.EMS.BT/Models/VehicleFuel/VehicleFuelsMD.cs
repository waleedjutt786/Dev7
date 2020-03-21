using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.VehicleFuel
{
    public class VehicleFuelsMD : ModelBase
    {
        public VehicleFuelsMD()
        {
            vehicleFuels = new List<VehicleFuelMD>();
        }
        public List<VehicleFuelMD> vehicleFuels { get; set; }
    }

}
