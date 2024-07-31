using RED.Api.DTOs.ProductDTOs;

namespace RED.Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync();
    }
}
