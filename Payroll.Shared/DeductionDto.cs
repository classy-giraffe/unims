namespace Payroll.Shared;

public record CreateDeductionDto(
    string? Description,
    decimal Amount
);

public record ReadDeductionDto(
    int DeductionId,
    string? Description,
    decimal Amount
);

public record UpdateDeductionDto(
    int DeductionId,
    string? Description,
    decimal Amount
);