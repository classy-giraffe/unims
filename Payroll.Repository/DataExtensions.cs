﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Payroll.Repository;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<PayrollDbContext>();
        context.Database.Migrate();
    }
}