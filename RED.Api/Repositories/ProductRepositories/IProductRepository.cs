using RED.Api.DTOs.PropertyDetailDTOs;
using RED.Api.DTOs.PropertyDTOs;

namespace RED.Api.Repositories.PropertyRepositories
{
    public interface IPropertyRepository
    {
        Task<List<ResultPropertyDTO>> GetAllPropertyAsync();
        Task<List<ResultPropertyAdvertListWithCategoryByEmployeeDTO>> GetPropertyAdvertListByEmployeeAsyncByTrue(int id);
        Task<List<ResultPropertyAdvertListWithCategoryByEmployeeDTO>> GetPropertyAdvertListByEmployeeAsyncByFalse(int id);
        Task<List<ResultPropertyWithCategoryDTO>> GetAllPropertyWithCategoryAsync();
        Task PropertyDealOfTheDayStatusChangeToTrue(int id);
        Task PropertyDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultLast5PropertyWithCategoryDTO>> GetLast5PropertyAsync();
        Task<List<ResultLast3PropertyWithCategoryDTO>> GetLast3PropertyAsync();
        Task CreateProperty(CreatePropertyDTO createPropertyDTO);
        Task<GetPropertyByPropertyIdDTO> GetPropertyByPropertyId(int id);
        Task<GetPropertyDetailByIdDTO> GetPropertyDetailByPropertyId(int id);
        Task<List<ResultPropertyWithSearchListDTO>> ResultPropertyWithSearchList(string searchKeyValue, int propertyCategoryId, string city);
        Task<List<ResultPropertyWithCategoryDTO>> GetPropertyByDealOfTheDayTrueWithCategoryAsync();
    }
}
