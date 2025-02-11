using Microsoft.EntityFrameworkCore;
using MemberService.Data;
using MemberService.Repositories;
using MemberService.Services;
using MemberService.DTOs;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);
// Use .env file
DotEnv.Load();

// Get .env variables
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbDatabase = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUsername = Environment.GetEnvironmentVariable("DB_USERNAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var trustServerCertificate = Environment.GetEnvironmentVariable("TrustServerCertificate");

// Database credential connection
var connectionString = $"Server={dbHost};Database={dbDatabase};User Id={dbUsername};Password={dbPassword};TrustServerCertificate={trustServerCertificate};";

// Register  DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register repositories y services
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberManagementService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply  migrations and seeders
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    DataSeeder.Seed(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
