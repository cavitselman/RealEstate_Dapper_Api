using RED.Api.DTOs.TestimonialDTOs;

namespace RED.Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDTO>> GetAllTestimonialAsync();
    }
}
