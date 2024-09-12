using RED.Api.DTOs.CategoryDTOs;

namespace RED.Api.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDTO>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDTO categoryDTO);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDTO categoryDTO);
        Task<GetByIDCategoryDTO> GetCategory(int id);
    }
}
