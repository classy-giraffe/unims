﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Payroll.Repository;

#nullable disable

namespace Payroll.Repository.Migrations
{
    [DbContext(typeof(PayrollDbContext))]
    [Migration("20240822163133_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Payroll.Repository.Models.Deduction", b =>
                {
                    b.Property<int>("DeductionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DeductionId"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("PayrollId")
                        .HasColumnType("integer");

                    b.HasKey("DeductionId");

                    b.HasIndex("PayrollId");

                    b.ToTable("Deductions");
                });

            modelBuilder.Entity("Payroll.Repository.Models.Payroll", b =>
                {
                    b.Property<int>("PayrollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PayrollId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<decimal>("GrossSalary")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal>("NetSalary")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<DateTime>("PayrollDate")
                        .HasColumnType("date");

                    b.HasKey("PayrollId");

                    b.ToTable("Payrolls");
                });

            modelBuilder.Entity("Payroll.Repository.Models.Salary", b =>
                {
                    b.Property<int>("SalaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SalaryId"));

                    b.Property<decimal>("BaseSalary")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("date");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.HasKey("SalaryId");

                    b.HasIndex("EmployeeId", "EffectiveDate")
                        .IsUnique();

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("Payroll.Repository.Models.Deduction", b =>
                {
                    b.HasOne("Payroll.Repository.Models.Payroll", "Payroll")
                        .WithMany("Deductions")
                        .HasForeignKey("PayrollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payroll");
                });

            modelBuilder.Entity("Payroll.Repository.Models.Payroll", b =>
                {
                    b.Navigation("Deductions");
                });
#pragma warning restore 612, 618
        }
    }
}
