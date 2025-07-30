using VehicleCardSystem.Core.Models;

namespace VehicleCardSystem.Services
{
    public class VehicleApiService : IVehicleApiService
    {
        private readonly HttpClient _httpClient;

        public VehicleApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("VehicleApiClient");
        }
        //Listeleme
        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
        {
            var responseWrapper = await _httpClient.GetFromJsonAsync<JsonCollectionWrapper<Vehicle>>("api/Vehicles");
            return responseWrapper?.Values ?? new List<Vehicle>();
        }
        
        //Ekleme
        public async Task<bool> AddVehicleAsync(Vehicle vehicle)
        {
            try
            {

                var response = await _httpClient.PostAsJsonAsync("api/Vehicles", vehicle);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                // Ağ veya HTTP ile ilgili bir hata oluştu.
                // ex.Message veya ex.InnerException değerlerini inceleyin.
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
                return false; // Hata durumunda false dönsün
            }
            catch (Exception ex)
            {
                // Diğer genel hatalar.
                Console.WriteLine($"General Error in AddVehicleAsync: {ex.Message}");
                return false;
            }
        }
        //Id ye göre listeleme
        public async Task<Vehicle?> GetVehicleByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Vehicle>($"api/Vehicles/{id}");
        }
        //Güncelleme
        public async Task<bool> UpdateVehicleAsync(Vehicle vehicle)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Vehicles/{vehicle.VehicleId}", vehicle);
            return response.IsSuccessStatusCode;
        }
        //Silme
        public async Task<bool> DeleteVehicleAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/Vehicles/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
