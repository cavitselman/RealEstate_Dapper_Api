using Dapper;
using RED.Api.DTOs.WhoWeAreDetailDTOs;
using RED.Api.DTOs.WhoWeAreDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }
        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO)
        {
            string query = "insert into WhoWeAreDetail (Title,Subtitle,Description1,Description2) values (@title,@subTitle,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetailDTO.Title);
            parameters.Add("@subTitle", createWhoWeAreDetailDTO.Subtitle);
            parameters.Add("@description1", createWhoWeAreDetailDTO.Description1);
            parameters.Add("@description2", createWhoWeAreDetailDTO.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDTO>(query, parameters);
                return values;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDTO updateWhoWeAreDetailDTO)
        {
            string query = "Update WhoWeAreDetail Set Title=@title,Subtitle=@subTitle,Description1=@description1,Description2=@description2 where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDetailDTO.Title);
            parameters.Add("@subTitle", updateWhoWeAreDetailDTO.Subtitle);
            parameters.Add("@description1", updateWhoWeAreDetailDTO.Description1);
            parameters.Add("@description2", updateWhoWeAreDetailDTO.Description2);
            parameters.Add("@whoWeAreDetailID", updateWhoWeAreDetailDTO.WhoWeAreDetailId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
