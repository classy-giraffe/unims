using Employee.Business;
using Employee.Business.Abstraction;
using Employee.Business.Profiles;
using Employee.Repository;
using Employee.Repository.Abstraction;
using KafkaFlow;
using KafkaFlow.Serializer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddAutoMapper(typeof(EmployeeProfiles));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure KafkaFlow
const string topicName = "employee-event-topic";
const string producerName = "employee-producer";

builder.Services.AddKafka(
    kafka => kafka
        .UseMicrosoftLog()
        .AddCluster(
            cluster => cluster
                .WithBrokers(new[] { "localhost:9092" })
                .CreateTopicIfNotExists(topicName, 1, 1)
                .AddProducer(
                    producerName,
                    producer => producer
                        .DefaultTopic(topicName)
                        .AddMiddlewares(m =>
                            m.AddSerializer<JsonCoreSerializer>()
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