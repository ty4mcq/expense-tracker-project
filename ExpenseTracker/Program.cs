using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Environment.GetEnvironmentVariable("SYNCFUSION_LICENSE_KEY"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var environment = builder.Environment.EnvironmentName;
string? connectionString;

if (environment == "Production")
{
    connectionString = Environment.GetEnvironmentVariable("RDS_DB_CONNECTION_STRING");
}
else
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}

// Add the connection string to the configuration
builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;

// Dependency Injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
