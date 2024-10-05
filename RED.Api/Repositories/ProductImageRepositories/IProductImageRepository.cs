using RED.Api.DTOs.ProductImageDTOs;

namespace RED.Api.Repositories.ProductImageRepositories
{
    public interface IProductImageRepository
    {
        Task<List<GetProductImageByProductIdDTO>> GetProductImageByProductId(int id);
    }
}
