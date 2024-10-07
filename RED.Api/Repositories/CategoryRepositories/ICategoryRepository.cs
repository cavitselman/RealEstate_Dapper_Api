using RED.Api.DTOs.CategoryDTOs;

namespace RED.Api.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDTO>> GetAllCategory();
        Task CreateCategory(CreateCategoryDTO categoryDTO);
        Task DeleteCategory(int id);
        Task UpdateCategory(UpdateCategoryDTO categoryDTO);
        Task<GetByIDCategoryDTO> GetCategory(int id);
    }
}
