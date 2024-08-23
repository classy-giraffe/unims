using KafkaFlow;
using Payroll.Shared;

namespace Payroll.API;

public class EmployeeCreatedHandler(IServiceProvider serviceProvider, ILogger<EmployeeCreatedHandler> logger)
    : IMessageHandler<EmployeeCreatedEvent>
{
    public Task Handle(IMessageContext context, EmployeeCreatedEvent message)
    {
        logger.LogInformation("EmployeeCreatedHandler: EmployeeId={EmployeeId}", message.EmployeeId);
        return Task.CompletedTask;
    }
}