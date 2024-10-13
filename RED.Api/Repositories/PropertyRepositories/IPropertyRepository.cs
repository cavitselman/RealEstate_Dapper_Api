using RED.Api.DTOs.PropertyDetailDTOs;
using RED.Api.DTOs.PropertyDTOs;

namespace RED.Api.Repositories.PropertyRepositories
{
    public interface IPropertyRepository
    {
        Task<List<ResultPropertyDTO>> GetAllProperty();
        Task<List<ResultPropertyAdvertListWithCategoryByEmployeeDTO>> GetPropertyAdvertListByAppUserByTrue(int id);
        Task<List<ResultPropertyAdvertListWithCategoryByEmployeeDTO>> GetPropertyAdvertListByAppUserByFalse(int id);
        Task<List<ResultPropertyWithCategoryDTO>> GetAllPropertyWithCategory();
        Task<List<ResultPropertyWithCategoryDTO>> GetCategoryByVilla();
        Task<List<ResultPropertyWithCategoryDTO>> GetCategoryByDaire();
        Task<List<ResultPropertyWithCategoryDTO>> GetCategoryByYazlik();
        Task PropertyDealOfTheDayStatusChangeToTrue(int id);
        Task PropertyDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultLast5PropertyWithCategoryDTO>> GetLast5Property();
        Task<List<ResultLast3PropertyWithCategoryDTO>> GetLast3Property();
        Task CreateProperty(CreatePropertyDTO createPropertyDTO);
        Task UpdateProperty(UpdatePropertyDTO updatePropertyDTO);
        Task<GetPropertyByPropertyIdDTO> GetPropertyByPropertyId(int id);
        Task<GetPropertyByAdvertIdDTO> GetPropertyByAdvertId(int id);
        Task<GetPropertyDetailByIdDTO> GetPropertyDetailByPropertyId(int id);
        Task<List<ResultPropertyWithSearchListDTO>> ResultPropertyWithSearchList(string searchKeyValue, int propertyCategoryId, string city);
        Task<List<ResultPropertyWithCategoryDTO>> GetPropertyByDealOfTheDayTrueWithCategory();
        Task PropertyStatusChangeToTrue(int id);
        Task PropertyStatusChangeToFalse(int id);
    }
}
