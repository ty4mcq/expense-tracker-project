using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Set environment based on environment variable
var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
if (environmentName == "Production")
{
    builder.Environment.EnvironmentName = "Production";
}
else
{
    builder.Environment.EnvironmentName = "Development";
}

// Get Syncfusion license key based on environment
var syncfusionLicenceKey = builder.Environment.IsDevelopment()
    ? builder.Configuration["SYNCFUSION_LICENCE_KEY"]
    : Environment.GetEnvironmentVariable("SYNCFUSION_LICENCE_KEY");

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(syncfusionLicenceKey);


// Add services to the container.
builder.Services.AddControllersWithViews();

// Use the connection string from configuration based on environment
var connectionString = builder.Environment.IsDevelopment() 
    ? builder.Configuration.GetConnectionString("DefaultConnection")
    : Environment.GetEnvironmentVariable("RDS_DB_CONNECTION_STRING");

// Dependency Injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();