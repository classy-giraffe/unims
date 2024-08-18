using Attendance.Business;
using Attendance.Business.Abstractions;
using Attendance.Business.Profiles;
using Attendance.Http;
using Attendance.Http.Abstractions;
using Attendance.Repository;
using Attendance.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AttendanceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddAutoMapper(typeof(AttendanceProfiles));
builder.Services.AddHttpClient<IClientHttp, ClientHttp>(client => client.BaseAddress = new Uri("http://employee-ms:8080"));
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