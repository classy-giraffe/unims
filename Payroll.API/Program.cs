using Microsoft.EntityFrameworkCore;
using Payroll.Business;
using Payroll.Business.Abstractions;
using Payroll.Business.Profiles;
using Payroll.Http;
using Payroll.Http.Abstractions;
using Payroll.Repository;
using Payroll.Repository.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<PayrollDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddAutoMapper(typeof(PayrollProfiles));
builder.Services.AddHttpClient<IClientHttp, ClientHttp>(client =>
    client.BaseAddress = new Uri("http://employee-ms:8080"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MigrateDb();
app.Run();