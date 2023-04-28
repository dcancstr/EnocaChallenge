using Enoca.Business.Abstract;
using Enoca.Business.AutoMappers;
using Enoca.Business.Concrete;
using Enoca.DataAccess;
using Enoca.DataAccess.Abstract;
using Enoca.DataAccess.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ICarrierDal, EfCarrierDal>();
builder.Services.AddScoped<ICarrierService, CarrierManager>();

builder.Services.AddScoped<ICarrierConfigurationDal, EfCarrierConfigurationDal>();
builder.Services.AddScoped<ICarrierConfigurationService, CarrierConfigurationManager>();

builder.Services.AddScoped<IOrderDal, EfOrderDal>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<ICarrierReportDal, EfCarrierReportDal>();
builder.Services.AddScoped<ICarrierReportService, CarrierReportManager>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<Context>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

