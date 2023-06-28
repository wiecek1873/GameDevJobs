using AutoMapper;
using GameDevJobs.Application.Interfaces.Services;
using GameDevJobs.Application.Scrapers;
using GameDevJobs.Application.Services;
using GameDevJobs.Data;
using GameDevJobs.Domain.Interfaces;
using GameDevJobs.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//SETUP DI
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

builder.Services.AddScoped<ILocationsRepository, LocationsRepository>();
builder.Services.AddScoped<ILocationsService, LocationsService>();

builder.Services.AddScoped<ISenioritiesRepository, SenioritiesRepository>();
builder.Services.AddScoped<ISenioritiesService, SenioritiesService>();

builder.Services.AddScoped<IWorkingTimesRepository, WorkingTimesRepository>();
builder.Services.AddScoped<IWorkingTimesService, WorkingTimesService>();

builder.Services.AddScoped<ICompaniesRepository, CompaniesRepository>();
builder.Services.AddScoped<ICompaniesService, CompaniesService>();

builder.Services.AddScoped<IOffersRepository, OffersRepository>();
builder.Services.AddScoped<IOffersService, OffersService>();

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

var httpClient = new HttpClient();
var scraper = new SkillshotScraper(httpClient);
var xd = await scraper.CallUrlAsync("https://www.skillshot.pl/jobs/32104");

app.Run();
