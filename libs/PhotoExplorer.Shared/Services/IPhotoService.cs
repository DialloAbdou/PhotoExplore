using PhotoExplorer.Shared.Model;

namespace PhotoExplorer.Shared.Services
{
    public interface IPhotoService
    {
       Task<IEnumerable<Photo>?> GetAllPhotosAsync();

       Task<Photo?> GetPhotoByIdAsync(string id);
    }
}
