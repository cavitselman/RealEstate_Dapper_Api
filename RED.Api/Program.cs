using RED.Api.Models.DapperContext;
using RED.Api.Repositories.BottomGridRepositories;
using RED.Api.Repositories.CategoryRepositories;
using RED.Api.Repositories.ContactRepositories;
using RED.Api.Repositories.EmployeeRepositories;
using RED.Api.Repositories.PopularLocationRepositories;
using RED.Api.Repositories.ProductRepositories;
using RED.Api.Repositories.ServiceRepositories;
using RED.Api.Repositories.StatisticsRepositories;
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
