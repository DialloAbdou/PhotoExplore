
using PhotoExplorer.Shared.Model;
using PhotoExplorer.Shared.Services;
using System.Net.Http.Json;

namespace PhotoExplorer.Mobile.Services
{
    public class PhotoServiceMobile : IPhotoService
    {
        private HttpClient _httpClient;
        public PhotoServiceMobile( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Photo>?> GetAllPhotosAsync()
        {

            return await _httpClient.GetFromJsonAsync<IEnumerable<Photo>>("/photos");
        }

        public async Task<Photo?> GetPhotoByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Photo?>($"/photos/{id}");
        }
    }
}
