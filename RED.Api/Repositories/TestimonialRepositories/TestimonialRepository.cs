using Dapper;
using RED.Api.DTOs.TestimonialDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultTestimonialDTO>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDTO>(query);
                return values.ToList();
            }
        }
    }
}
