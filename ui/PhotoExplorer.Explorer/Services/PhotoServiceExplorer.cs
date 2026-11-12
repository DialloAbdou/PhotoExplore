

using PhotoExplorer.Shared.Model;
using PhotoExplorer.Shared.Services;
using System.Net.Http.Json;

namespace PhotoExplorer.Explorer.Services
{
    public class PhotoServiceExplorer : IPhotoService
    {

        private readonly HttpClient _httpClient;
        
        public PhotoServiceExplorer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Photo>?> GetAllPhotosAsync()
        {
             return   await _httpClient.GetFromJsonAsync<IEnumerable<Photo>>("/photos");

        }

        public async Task<Photo?> GetPhotoByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Photo?>($"/photos/{id}");
        }
    }
}
