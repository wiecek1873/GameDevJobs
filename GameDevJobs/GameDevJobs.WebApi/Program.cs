using GameDevJobs.Application.Interfaces.Services;
using GameDevJobs.Application.Parsers;
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


//todo Remove this. Only for quick testing
var httpClient = new HttpClient();
var scraper = new SkillshotScraper(httpClient);
var offerParser = new SkillshotOfferParser();
//var xd = await scraper.CallUrlAsync("https://www.skillshot.pl/users/3614");
//var xdd = await scraper.CallUrlAsync("https://www.skillshot.pl/jobs/32100-3d-artist-at-spellarena-sp-z-o-o");


for (int i = 0; i < 100; i++)
{
    try
    {
        var scappedHTML = await scraper.CallUrlAsync("https://www.skillshot.pl/jobs/" + i);
        var offer = offerParser.Parse(scappedHTML);
        System.Diagnostics.Debug.WriteLine(offer.Title);
        System.Diagnostics.Debug.WriteLine(offer.CompanyName);
        System.Diagnostics.Debug.WriteLine(offer.LocationName);
        System.Diagnostics.Debug.WriteLine(offer.CategoryName);
        System.Diagnostics.Debug.WriteLine(offer.WorkingTimeName);
        System.Diagnostics.Debug.WriteLine(offer.SeniorityName);
        System.Diagnostics.Debug.WriteLine(offer.SalaryMin);
        System.Diagnostics.Debug.WriteLine(offer.SalaryMax);
        System.Diagnostics.Debug.WriteLine(offer.Date);
        System.Diagnostics.Debug.WriteLine(offer.Views);
        System.Diagnostics.Debug.WriteLine(offer.Url);

    }
    catch
    {
        continue;
    }

}

app.Run();
