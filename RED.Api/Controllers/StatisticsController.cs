using Microsoft.AspNetCore.Mvc;
using RED.Api.Repositories.StatisticsRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_statisticsRepository.ActiveCategoryCount());
        }

        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {
            return Ok(_statisticsRepository.ActiveEmployeeCount());
        }

        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount()
        {
            return Ok(_statisticsRepository.ApartmentCount());
        }
        
        [HttpGet("AveragePropertyPriceByRent")]
        public IActionResult AveragePropertyPriceByRent()
        {
            return Ok(_statisticsRepository.AveragePropertyPriceByRent());
        }

        [HttpGet("AveragePropertyPriceBySale")]
        public IActionResult AveragePropertyPriceBySale()
        {
            return Ok(_statisticsRepository.AveragePropertyPriceBySale());
        }

        [HttpGet("AverageRoomCount")]
        public IActionResult AverageRoomCount()
        {
            return Ok(_statisticsRepository.AverageRoomCount());
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_statisticsRepository.CategoryCount());
        }

        [HttpGet("CategoryNameByMaxPropertyCount")]
        public IActionResult CategoryNameByMaxPropertyCount()
        {
            return Ok(_statisticsRepository.CategoryNameByMaxPropertyCount());
        }

        [HttpGet("CityNameByMaxPropertyCount")]
        public IActionResult CityNameByMaxPropertyCount()
        {
            return Ok(_statisticsRepository.CityNameByMaxPropertyCount());
        }

        [HttpGet("DifferentCityCount")]
        public IActionResult DifferentCityCount()
        {
            return Ok(_statisticsRepository.DifferentCityCount());
        }

        [HttpGet("EmployeeNameByMaxPropertyCount")]
        public IActionResult EmployeeNameByMaxPropertyCount()
        {
            return Ok(_statisticsRepository.EmployeeNameByMaxPropertyCount());
        }

        [HttpGet("LastPropertyPrice")]
        public IActionResult LastPropertyPrice()
        {
            return Ok(_statisticsRepository.LastPropertyPrice());
        }

        [HttpGet("NewestBuildingYear")]
        public IActionResult NewestBuildingYear()
        {
            return Ok(_statisticsRepository.NewestBuildingYear());
        }

        [HttpGet("OldestBuildingYear")]
        public IActionResult OldestBuildingYear()
        {
            return Ok(_statisticsRepository.OldestBuildingYear());
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(_statisticsRepository.PassiveCategoryCount());
        }

        [HttpGet("PropertyCount")]
        public IActionResult PropertyCount()
        {
            return Ok(_statisticsRepository.PropertyCount());
        }
    }
}
