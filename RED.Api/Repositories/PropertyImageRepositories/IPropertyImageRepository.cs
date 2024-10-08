using RED.Api.DTOs.PropertyImageDTOs;

namespace RED.Api.Repositories.PropertyImageRepositories
{
    public interface IPropertyImageRepository
    {
        Task<List<GetPropertyImageByPropertyIdDTO>> GetPropertyImageByPropertyId(int id);
    }
}
