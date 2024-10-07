using RED.Api.DTOs.SubFeatureDTOs;

namespace RED.Api.Repositories.SubFeatureRepositories
{
    public interface ISubFeatureRepository
    {
        Task<List<ResultSubFeatureDTO>> GetAllSubFeature();
    }
}
