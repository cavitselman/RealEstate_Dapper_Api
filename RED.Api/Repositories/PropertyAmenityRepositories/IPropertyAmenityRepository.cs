using RED.Api.DTOs.PropertyAmenityDTOs;

namespace RED.Api.Repositories.PropertyAmenityRepositories
{
    public interface IPropertyAmenityRepository
    {
        Task<List<ResultPropertyAmenityByStatusTrueDTO>> ResultPropertyAmenityByStatusTrue(int id);
    }
}
