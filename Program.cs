
using Microsoft.EntityFrameworkCore;
using MechRentAPI.Data;
using MechRentAPI.Repositories;
using MechRentAPI.Services;

using System.Net.Http;
using System.Net.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    HttpClientHandler clientHandler = new HttpClientHandler();
    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
    HttpClient client = new HttpClient(clientHandler);
}

// Database context
builder.Services.AddDbContext<MechRentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IExcavatorRepository, ExcavatorRepository>();
builder.Services.AddScoped<IPublicWorkRepository, PublicWorkRepository>();
builder.Services.AddScoped<IRentedExcavatorRepository, RentedExcavatorRepository>();

// Services
builder.Services.AddScoped<IExcavatorService, ExcavatorService>();
builder.Services.AddScoped<IPublicWorkService, PublicWorkService>();
builder.Services.AddScoped<IRentedExcavatorService, RentedExcavatorService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

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