using RED.Api.Models.DapperContext;
using RED.Api.Repositories.AppUserRepositories;
using RED.Api.Repositories.BottomGridRepositories;
using RED.Api.Repositories.CategoryRepositories;
using RED.Api.Repositories.ContactRepositories;
using RED.Api.Repositories.EmployeeRepositories;
using RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;
using RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using RED.Api.Repositories.MessageRepositories;
using RED.Api.Repositories.PopularLocationRepositories;
using RED.Api.Repositories.ProductImageRepositories;
using RED.Api.Repositories.ProductRepositories;
using RED.Api.Repositories.PropertyAmenityRepositories;
using RED.Api.Repositories.ServiceRepositories;
using RED.Api.Repositories.StatisticsRepositories;
using RED.Api.Repositories.SubFeatureRepositories;
using RED.Api.Repositories.TestimonialRepositories;
using RED.Api.Repositories.ToDoListRepositories;
using RED.Api.Repositories.WhoWeAreDetailRepositories;

namespace RED.Api.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddTransient<Context>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IToDoListRepository, ToDoListRepository>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<IChartRepository, ChartRepository>();
            services.AddTransient<ILast5ProductsRepository, Last5ProductsRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
            services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();
        }
    }
}
