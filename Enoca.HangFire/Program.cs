using Enoca.Business.Abstract;
using Enoca.Business.AutoMappers;
using Enoca.Business.Concrete;
using Enoca.DataAccess;
using Enoca.DataAccess.Abstract;
using Enoca.DataAccess.Concrete;
using Enoca.HangFire.Transactions;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddTransient<IOrderDal, EfOrderDal>();
builder.Services.AddTransient<IOrderService, OrderManager>();

builder.Services.AddTransient<ICarrierReportDal, EfCarrierReportDal>();
builder.Services.AddTransient<ICarrierReportService, CarrierReportManager>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<Context>();



//builder.Configuration["ConnectionStrings:DefaultConnection"]
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHangfire(x => x.UseSqlServerStorage("Server=localhost;Database=Hangfire1DB;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=True"
));
builder.Services.AddHangfireServer();

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
app.UseHangfireDashboard("/job", new DashboardOptions());
app.UseHangfireServer(new BackgroundJobServerOptions());
GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 2 });
RecurringJobs.GetHourlyReport();

app.Run();

