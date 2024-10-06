using RED.Api.Hubs;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();
builder.Services.AddTransient<IStatisticRepository, StatisticRepository>();
builder.Services.AddTransient<IChartRepository, ChartRepository>();
builder.Services.AddTransient<ILast5ProductsRepository, Last5ProductsRepository>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<IProductImageRepository, ProductImageRepository>();
builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();
builder.Services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
builder.Services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials();
    });
});
builder.Services.AddHttpClient();
builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
