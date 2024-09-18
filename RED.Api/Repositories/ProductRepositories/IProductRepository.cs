using RED.Api.DTOs.ProductDTOs;

namespace RED.Api.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdvertListByEmployeeAsync(int id);
        Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync();
        void ProductDealOfTheDayStatusChangeToTrue(int id);
        void ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5ProductAsync();
    }
}
