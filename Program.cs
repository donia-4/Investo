using Investo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// For CoreEntitiesDbContext
builder.Services.AddDbContext<CoreEntitiesDbContext>(options =>
    options.UseSqlServer(
        connectionString,
        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "CoreEntities")));

// For RealTimeDbContext
builder.Services.AddDbContext<RealTimeDbContext>(options =>
    options.UseSqlServer(
        connectionString,
        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "RealTime")));

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

app.Run();
