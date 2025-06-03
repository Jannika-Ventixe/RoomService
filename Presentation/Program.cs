using Application.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories;
using Persistence.Seeders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("BookingDatabaseConnection")));

var app = builder.Build();
app.MapOpenApi();
app.MapControllers();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Room Service API");
        c.RoutePrefix = string.Empty;
    });
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
using (var scope = app.Services.CreateScope())
{
    await AppSeeder.SeedDb(scope.ServiceProvider);
}

app.Run();
