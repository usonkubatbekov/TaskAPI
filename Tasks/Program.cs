using AutoMapper;
using DataLayer;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Manager.Interface;
using ServiceLayer.Manager;
using ServiceLayer.Mapping;
using ServiceLayer.Service;
using ServiceLayer.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var con = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TasksDBcontext>(options => options.UseSqlServer(con, b => b.MigrationsAssembly("DataLayer")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Repositories
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<IFilePathRepository, FilePathRepository>();

// Services
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<IFilePathService, FilePathService>();
builder.Services.AddTransient<IFileService, FileService>();

// Managers
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IDataManager, DataManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TasksDBcontext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
