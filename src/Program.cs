using Microsoft.EntityFrameworkCore;
using Visual.Models.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("cs");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "Connection string 'cs' is missing. Configure it using user-secrets or environment variable 'ConnectionStrings__cs'.");
}

var dbPath = Path.GetDirectoryName(connectionString.Replace("Data Source=", ""));
if (!string.IsNullOrEmpty(dbPath))
    Directory.CreateDirectory(dbPath);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>()
        .CreateLogger("DatabaseStartup");
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        logger.LogInformation("Applying pending Entity Framework migrations.");
        db.Database.Migrate();
        logger.LogInformation("Database migration check completed successfully.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Database migration failed during application startup.");
        throw;
    }
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    // .WithStaticAssets();


app.Run();