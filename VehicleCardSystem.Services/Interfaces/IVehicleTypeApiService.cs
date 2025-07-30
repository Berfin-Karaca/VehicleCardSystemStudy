using VehicleCardSystem.Core.Models;

namespace VehicleCardSystem.Services
{
    public interface IVehicleTypeApiService
    {
        Task<IEnumerable<VehicleType>> GetVehicleTypesAsync();
        Task<VehicleType?> GetVehicleTypeByIdAsync(Guid id);
        Task<bool> AddVehicleTypeAsync(VehicleType vehicleType);
        Task<bool> UpdateVehicleTypeAsync(VehicleType vehicleType);
        Task<bool> DeleteVehicleTypeAsync(Guid id);
    }
}
