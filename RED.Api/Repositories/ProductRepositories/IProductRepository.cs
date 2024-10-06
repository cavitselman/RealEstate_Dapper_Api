using RED.Api.DTOs.ProductDetailDTOs;
using RED.Api.DTOs.ProductDTOs;

namespace RED.Api.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdvertListByEmployeeAsyncByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdvertListByEmployeeAsyncByFalse(int id);
        Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync();
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5ProductAsync();
        Task<List<ResultLast3ProductWithCategoryDTO>> GetLast3ProductAsync();
        Task CreateProduct(CreateProductDTO createProductDTO);
        Task<GetProductByProductIdDTO> GetProductByProductId(int id);
        Task<GetProductDetailByIdDTO> GetProductDetailByProductId(int id);
        Task<List<ResultProductWithSearchListDTO>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city);
        Task<List<ResultProductWithCategoryDTO>> GetProductByDealOfTheDayTrueWithCategoryAsync();
    }
}
