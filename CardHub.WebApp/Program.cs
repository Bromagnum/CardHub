using ApplicationLayer.Interfaces;
using ApplicationLayer.MappingProfiles;
using InfrastructureLayer.Infrastructurelayer.Data;
using InfrastructureLayer.Infrastructurelayer.Services;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//AutoMapper Configuration

var loggerFactory = LoggerFactory.Create(logging => logging.AddConsole());
var mapperConfig = new MapperConfiguration(cfg =>
{

    cfg.AddProfile<CreditCardProfile>();

}, loggerFactory);
//Mapper Instance
IMapper mapper = mapperConfig.CreateMapper();

//DI container

builder.Services.AddSingleton(mapper);
//Service Registrations

builder.Services.AddScoped<ICreditCardService, CreditCardService>();
//DbContext Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
