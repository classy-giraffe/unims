using KafkaFlow;
using Payroll.Business.Abstractions;
using Payroll.Shared;

namespace Payroll.API;

public class EmployeeHandler(ILogger<EmployeeHandler> logger, IServiceProvider serviceProvider)
    : IMessageHandler<EmployeeEvent>
{
    public async Task Handle(IMessageContext context, EmployeeEvent message)
    {
        using var scope = serviceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IBusiness>();
        switch (message.Event)
        {
            case Event.Created:
                logger.LogInformation("Employee created with ID {Id}", message.Id);
                await repository.CreateEmployee(new CreateEmployeeDto { Id = message.Id });
                break;
            case Event.Deleted:
                logger.LogInformation("Employee deleted with ID {Id}", message.Id);
                await repository.DeleteEmployee(message.Id);
                break;
        }
    }
}