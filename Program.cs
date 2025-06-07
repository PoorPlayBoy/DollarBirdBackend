using backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Set up database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Set up CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:5500", "https://your-frontend-site.com")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add controllers
builder.Services.AddControllers();

// Build the app (only ONCE)
var app = builder.Build();

// Middleware setup
app.UseCors("AllowAll");
app.MapControllers();

// Log connection string before running
Console.WriteLine("DB Conn: " + builder.Configuration.GetConnectionString("DefaultConnection"));

// Run the app
app.Run();
