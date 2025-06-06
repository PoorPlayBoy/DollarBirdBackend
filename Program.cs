using backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load config (optional if already default)
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAll");
app.MapControllers();

// ✅ Move this BEFORE app.Run()
Console.WriteLine("DB Conn: " + builder.Configuration.GetConnectionString("DefaultConnection"));

app.Run();
