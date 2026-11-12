

using PhotoExplorer.Shared.Model;
using PhotoExplorer.Shared.Services;

namespace PhotoExplorer.Manager.Services
{
    public class PhotoServiceManager : IPhotoService
    {
        private IHttpClientFactory _httpClientFactory;

        public PhotoServiceManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Photo>?> GetAllPhotosAsync()
        {
            using var httpClient = _httpClientFactory.CreateClient("Photo");
            return await httpClient.GetFromJsonAsync<IEnumerable<Photo>>("/photos");

        }

        public async Task<Photo?> GetPhotoByIdAsync(string id)
        {
            using var httpClient = _httpClientFactory.CreateClient("Photo");
            return await httpClient.GetFromJsonAsync<Photo?>($"/photos/{id}");
        }
    }
}
