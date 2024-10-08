namespace RED.Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int PropertyCount();
        int ApartmentCount();
        string EmployeeNameByMaxPropertyCount();
        string CategoryNameByMaxPropertyCount();
        decimal AveragePropertyPriceByRent();
        decimal AveragePropertyPriceBySale();
        string CityNameByMaxPropertyCount();
        int DifferentCityCount();
        decimal LastPropertyPrice();
        string NewestBuildingYear();
        string OldestBuildingYear();
        int AverageRoomCount();
        int ActiveEmployeeCount();
    }
}
