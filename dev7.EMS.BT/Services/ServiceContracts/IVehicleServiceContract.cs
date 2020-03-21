//using dev7.EMS.DAL.DataContexts;
using dev7.EMS.Domain.Vehicle;
using dev7.EMS.Model.Vehicle;
using System.Linq;

namespace dev7.EMS.Services.ServiceContracts.Vehicle
{
    public interface IVehicleServiceContract
    {
        #region Vehicle

        VehicleMD AddVehicle(VehicleMD mod);
        VehicleMD ModifyVehicle(VehicleMD mod);
        VehicleMD DeleteVehicle(int id);
        VehiclesMD GetAllVehicles(int id);

        IQueryable<VehicleDE> GetAllQuerableVehicles();
        VehicleMD GetVehicleById(int id);

        #endregion
    }
}
