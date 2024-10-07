using RED.Api.DTOs.ProductDTOs;

namespace RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public interface ILast5ProductsRepository
    {
        Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5Product(int id);
    }
}
