using Dapper;
using RED.Api.DTOs.PropertyDetailDTOs;
using RED.Api.DTOs.PropertyDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.PropertyRepositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly Context _context;

        public PropertyRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPropertyDTO>> GetAllPropertyAsync()
        {
            string query = "Select * From Property";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultPropertyWithCategoryDTO>> GetAllPropertyWithCategoryAsync()
        {
            string query = "Select PropertyID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay,SlugUrl From Property inner join Category on Property.PropertyCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyWithCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5PropertyWithCategoryDTO>> GetLast5PropertyAsync()
        {
            string query = "Select Top(5) PropertyID,Title,Price,City,District,PropertyCategory,CategoryName,AdvertisementDate From Property Inner Join Category On Property.PropertyCategory=Category.CategoryID Where Type='Kiralık' Order By PropertyID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5PropertyWithCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultPropertyAdvertListWithCategoryByEmployeeDTO>> GetPropertyAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "Select PropertyID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay From Property inner join Category on Property.PropertyCategory=Category.CategoryID where EmployeeID=@employeeId and PropertyStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAdvertListWithCategoryByEmployeeDTO>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultPropertyAdvertListWithCategoryByEmployeeDTO>> GetPropertyAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "Select PropertyID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay From Property inner join Category on Property.PropertyCategory=Category.CategoryID where EmployeeID=@employeeId and PropertyStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAdvertListWithCategoryByEmployeeDTO>(query, parameters);
                return values.ToList();
            }
        }

        public async Task PropertyDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Property Set DealOfTheDay=0 where PropertyID=@PropertyID";
            var parameters = new DynamicParameters();
            parameters.Add("@PropertyID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task PropertyDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Property Set DealOfTheDay=1 where PropertyID=@PropertyID";
            var parameters = new DynamicParameters();
            parameters.Add("@PropertyID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task CreateProperty(CreatePropertyDTO createPropertyDTO)
        {
            string query = "insert into Property (Title,Price,CoverImage,City,District,Address,Description,Type,DealOfTheDay,AdvertisementDate,PropertyStatus,PropertyCategory,EmployeeID) values (@Title,@Price,@CoverImage,@City,@District,@Address,@Description,@Type,@DealOfTheDay,@AdvertisementDate,@PropertyStatus,@PropertyCategory,@EmployeeID)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createPropertyDTO.Title);
            parameters.Add("@Price", createPropertyDTO.Price);
            parameters.Add("@CoverImage", createPropertyDTO.CoverImage);
            parameters.Add("@City", createPropertyDTO.City);
            parameters.Add("@District", createPropertyDTO.District);
            parameters.Add("@Address", createPropertyDTO.Address);
            parameters.Add("@Description", createPropertyDTO.Description);
            parameters.Add("@Type", createPropertyDTO.Type);
            parameters.Add("@DealOfTheDay", createPropertyDTO.DealOfTheDay);
            parameters.Add("@AdvertisementDate", createPropertyDTO.AdvertisementDate);
            parameters.Add("@PropertyStatus", createPropertyDTO.PropertyStatus);
            parameters.Add("@PropertyCategory", createPropertyDTO.PropertyCategory);
            parameters.Add("@EmployeeID", createPropertyDTO.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetPropertyByPropertyIdDTO> GetPropertyByPropertyId(int id)
        {
            string query = "Select PropertyID,Title,Price,City,District,Description,CategoryName,CoverImage,Type,Address,DealOfTheDay,AdvertisementDate,SlugUrl From Property inner join Category on Property.PropertyCategory=Category.CategoryID Where PropertyID=@PropertyId";
            var parameters = new DynamicParameters();
            parameters.Add("@PropertyId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetPropertyByPropertyIdDTO>(query,parameters);
                return values.FirstOrDefault();
            }            
        }

        public async Task<GetPropertyDetailByIdDTO> GetPropertyDetailByPropertyId(int id)
        {
            string query = "Select * From PropertyDetails Where PropertyID=@PropertyId";
            var parameters = new DynamicParameters();
            parameters.Add("@PropertyId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetPropertyDetailByIdDTO>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task<List<ResultPropertyWithSearchListDTO>> ResultPropertyWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            string query = "Select * From Property Where Title like '%" + searchKeyValue + "%' And PropertyCategory=@propertyCategoryId And City=@city";
            var parameters = new DynamicParameters();
            //parameters.Add("@searchKeyValue", searchKeyValue);
            parameters.Add("@propertyCategoryId", propertyCategoryId);
            parameters.Add("@city", city);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyWithSearchListDTO>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultPropertyWithCategoryDTO>> GetPropertyByDealOfTheDayTrueWithCategoryAsync()
        {
            string query = "Select PropertyID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay From Property inner join Category on Property.PropertyCategory=Category.CategoryID Where DealOfTheDay=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyWithCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast3PropertyWithCategoryDTO>> GetLast3PropertyAsync()
        {
            string query = "Select Top(3) PropertyID,Title,Price,City,District,PropertyCategory,CategoryName,AdvertisementDate,CoverImage,Description From Property Inner Join Category On Property.PropertyCategory=Category.CategoryID Order By PropertyID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3PropertyWithCategoryDTO>(query);
                return values.ToList();
            }
        }
    }
}
