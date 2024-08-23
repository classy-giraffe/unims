using KafkaFlow;
using KafkaFlow.Serializer;
using Microsoft.EntityFrameworkCore;
using Payroll.API;
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
builder.Services.AddTransient<IBusiness, Business>();
builder.Services.AddAutoMapper(typeof(PayrollProfiles));
builder.Services.AddHttpClient<IClientHttp, ClientHttp>(client =>
    client.BaseAddress = new Uri("http://employee-ms:8080"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure KafkaFlow
const string topicName = "employee-event-topic";
const string groupName = "payroll-consumer-group";

builder.Services.AddKafkaFlowHostedService(
    kafka => kafka
        .UseMicrosoftLog()
        .AddCluster(cluster => cluster
            .WithBrokers(new[] { "localhost:9092" })
            .AddConsumer(consumer =>
                consumer
                    .Topic(topicName)
                    .WithGroupId(groupName)
                    .WithBufferSize(100)
                    .WithWorkersCount(2)
                    .WithAutoOffsetReset(AutoOffsetReset.Earliest)
                    .AddMiddlewares(middlewares => middlewares
                        .AddDeserializer<JsonCoreDeserializer>()
                        .AddTypedHandlers(handlers => handlers
                            .AddHandler<EmployeeHandler>()
                        )
                    )
            )
        )
);

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