﻿using RED.Api.DTOs.PopularLocationDTOs;

namespace RED.Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDTO>> GetAllPopularLocation();
        Task CreatePopularLocation(CreatePopularLocationDTO createPopularLocationDTO);
        Task DeletePopularLocation(int id);
        Task UpdatePopularLocation(UpdatePopularLocationDTO updatePopularLocationDTO);
        Task<GetByIDPopularLocationDTO> GetPopularLocation(int id);
    }
}
