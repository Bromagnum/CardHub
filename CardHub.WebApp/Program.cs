using ApplicationLayer.Interfaces;
using InfrastructureLayer.Infrastructurelayer.Data;
using InfrastructureLayer.Infrastructurelayer.Services;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApplicationLayer.Mapping;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Mapster configuration

var config = TypeAdapterConfig.GlobalSettings;

//Profil ekleme
config.Scan(typeof(CreditCardProfile).Assembly);
// DI kayýtlarý
builder.Services.AddSingleton(config);
// Servis kayýtlarý
builder.Services.AddScoped<IMapper, ServiceMapper>();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();