using GameDevJobs.Application.Parsers;
using GameDevJobs.Application.Scrapers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
