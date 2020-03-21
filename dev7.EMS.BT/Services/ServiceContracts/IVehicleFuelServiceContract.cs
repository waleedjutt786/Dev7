//using dev7.EMS.DAL.DataContexts;
using dev7.EMS.Domain.VehicleFuel;
using dev7.EMS.Model.VehicleFuel;
using System.Collections.Generic;
using System.Linq;

namespace dev7.EMS.Services.ServiceContracts.VehicleFuel
{
    public interface IVehicleFuelServiceContract
    {
        #region VehicleFuel

        VehicleFuelMD AddVehicleFuel(VehicleFuelMD mod);
        VehicleFuelMD ModifyVehicleFuel(VehicleFuelMD mod);
        VehicleFuelMD DeleteVehicleFuel(int id);
        VehicleFuelsMD GetVehicleFuels(int id);
        List<VehicleFuelMD> GetVehicleFuelsByVehicleId(int vehicleId);
        IQueryable<VehicleFuelDE> GetAllQuerableVehicleFuels();
        VehicleFuelMD GetVehicleFuelById(int id);

        #endregion
    }
}
