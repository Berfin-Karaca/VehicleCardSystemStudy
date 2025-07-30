using VehicleCardSystem.Core.Models;

namespace VehicleCardSystem.Services
{
    public class VehicleTypeApiService : IVehicleTypeApiService
    {
        private readonly HttpClient _httpClient;

        public VehicleTypeApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("VehicleApiClient");
        }
        //Listeleme
        public async Task<IEnumerable<VehicleType>> GetVehicleTypesAsync()
        { 
            var responseWrapper = await _httpClient.GetFromJsonAsync<JsonCollectionWrapper<VehicleType>>("api/VehicleTypes");

            return responseWrapper?.Values ?? new List<VehicleType>();
        }
        //Ekleme
        public async Task<bool> AddVehicleTypeAsync(VehicleType vehicleType)
        {
            var response = await _httpClient.PostAsJsonAsync("api/VehicleTypes", vehicleType);
            return response.IsSuccessStatusCode; 
        }
        //Id ye göre listeleme
        public async Task<VehicleType?> GetVehicleTypeByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<VehicleType>($"api/VehicleTypes/{id}");
        }
        //Güncelleme
        public async Task<bool> UpdateVehicleTypeAsync(VehicleType vehicleType)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/VehicleTypes/{vehicleType.VehicletypeId}", vehicleType);
            return response.IsSuccessStatusCode;
        }
        //Silme
        public async Task<bool> DeleteVehicleTypeAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/VehicleTypes/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
