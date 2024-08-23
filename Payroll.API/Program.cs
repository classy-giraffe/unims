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
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddAutoMapper(typeof(PayrollProfiles));
builder.Services.AddHttpClient<IClientHttp, ClientHttp>(client =>
    client.BaseAddress = new Uri("http://employee-ms:8080"));
builder.Services.AddScoped<EmployeeCreatedHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure KafkaFlow
const string topicName = "employee-topic";
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
                    .WithWorkersCount(4)
                    .WithAutoOffsetReset(AutoOffsetReset.Latest)
                    .AddMiddlewares(middlewares => middlewares
                        .AddSerializer<JsonCoreSerializer>()
                        .AddTypedHandlers(handlers => handlers
                            .AddHandler<EmployeeCreatedHandler>()
                        )
                    )
            )
        )
);

var app = builder.Build();
var kafkaBus = app.Services.CreateKafkaBus();
await kafkaBus.StartAsync();

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