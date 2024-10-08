using RED.Api.DTOs.PropertyDTOs;

namespace RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastPropertysRepositories
{
    public interface ILast5PropertysRepository
    {
        Task<List<ResultLast5PropertyWithCategoryDTO>> GetLast5Property(int id);
    }
}
