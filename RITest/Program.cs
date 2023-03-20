using Microsoft.EntityFrameworkCore;
using RITest.Entities;
using RITest.Services.Interfaces.DrillBlock;
using RITest.Services;
using RITest.Database.Repositories.Interfaces;
using RITest.Database;
using RITest.Services.Interfaces.DrillBlockPoint;
using RITest.Services.Interfaces.Hole;
using RITest.Services.Interfaces.HolePoint;
using RITest.Database.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddTransient<IBaseRepository<DrillBlockEntity>, BaseRepository<DrillBlockEntity>>();
builder.Services.AddTransient<IBaseRepository<DrillBlockPointEntity>, BaseRepository<DrillBlockPointEntity>>();
builder.Services.AddTransient<IBaseRepository<HoleEntity>, BaseRepository<HoleEntity>>();
builder.Services.AddTransient<IBaseRepository<HolePointEntity>, BaseRepository<HolePointEntity>>();
builder.Services.AddTransient<IDrillBlockService, DrillBlockService>();
builder.Services.AddTransient<IDrillBlockPointService, DrillBlockPointService>();
builder.Services.AddTransient<IHoleService, HoleService>();
builder.Services.AddTransient<IHolePointService, HolePointService>();

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
