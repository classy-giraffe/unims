﻿using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository;

public class EmployeeDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<JobTitle> JobTitles { get; set; }
    public DbSet<Department> Departments { get; set; }
    
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Employee Entity Configuration
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.BirthDate)
                .IsRequired();

            entity.Property(e => e.HireDate)
                .IsRequired();

            // Relationship with Department
            entity.HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId);

            // Relationship with JobTitle
            entity.HasOne(e => e.JobTitle)
                .WithMany()
                .HasForeignKey(e => e.JobTitleId);
        });

        // JobTitle Entity Configuration
        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(j => j.JobTitleId);

            entity.Property(j => j.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(j => j.Description)
                .HasMaxLength(500);
        });

        // Department Entity Configuration
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(d => d.DepartmentId);

            entity.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(d => d.Description)
                .HasMaxLength(500);
        });
    }
}