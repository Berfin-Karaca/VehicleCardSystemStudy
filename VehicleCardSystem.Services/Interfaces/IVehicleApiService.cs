using VehicleCardSystem.Core.Models;

namespace VehicleCardSystem.Services
{
    public interface IVehicleApiService
    {
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();
        Task<Vehicle?> GetVehicleByIdAsync(Guid id);
        Task<bool> AddVehicleAsync(Vehicle vehicle);
        Task<bool> UpdateVehicleAsync(Vehicle vehicle);
        Task<bool> DeleteVehicleAsync(Guid id);

    }
}
