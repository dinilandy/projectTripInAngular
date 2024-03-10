
using BLL.Functions;
using BLL.Interfaces;
using DAL.Functions;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrganizedTripsContext>(options => options.UseSqlServer("Server=DESKTOP-E0FAPSB\\SQLEXPRESS;Database=OrganizedTrips;TrustServerCertificate=True;Trusted_Connection=True;"));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped(typeof(IUserDAL), typeof(UserDAl));
builder.Services.AddScoped(typeof(IUserBLL), typeof(UserBLL));

builder.Services.AddScoped(typeof(ITypesTripDAL), typeof(TypesTripDAL));
builder.Services.AddScoped(typeof(ITypesTripBLL), typeof(TypesTripBLL));

builder.Services.AddScoped(typeof(ITheTripDAL), typeof(TheTripDAL));
builder.Services.AddScoped(typeof(ITheTripBLL), typeof(TheTripBLL));

builder.Services.AddScoped(typeof(IOrderPlaceDAL), typeof(OrderPlaceDAL));
builder.Services.AddScoped(typeof(IOrderPlaceBLL), typeof(OrderPlaceBLL));


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 app.UseCors(builder =>
 {
    builder.AllowAnyOrigin() .AllowAnyHeader().AllowAnyMethod();
 });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



