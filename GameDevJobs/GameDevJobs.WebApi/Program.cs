using AutoMapper;
using GameDevJobs.Application.Interfaces;
using GameDevJobs.Application.Services;
using GameDevJobs.Data;
using GameDevJobs.Domain.Interfaces;
using GameDevJobs.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using GameDevJobs.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//SETUP DI
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

//SETUP Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//SETUP Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SETUP DB
builder.Services.AddDbContext<GameDevJobsContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("GameDevJobs")));

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
