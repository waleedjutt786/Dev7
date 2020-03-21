using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Model.Vehicle
{
    public class VehiclesMD : ModelBase
    {
        public VehiclesMD()
        {
            vehicles = new List<VehicleMD>();
        }
        public List<VehicleMD> vehicles { get; set; }
    }

}
