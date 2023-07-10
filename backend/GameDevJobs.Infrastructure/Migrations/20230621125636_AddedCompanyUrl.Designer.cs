﻿// <auto-generated />
using GameDevJobs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

#nullable disable

namespace GameDevJobs.Migrations;
[DbContext(typeof(GameDevJobsContext))]
[Migration("20230621125636_AddedCompanyUrl")]
partial class AddedCompanyUrl
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.7")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity("GameDevJobs.Domain.Entities.Category", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Categories");
            });

        modelBuilder.Entity("GameDevJobs.Domain.Entities.Company", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Description")
                    .HasColumnType("text");

                b.Property<string>("Link")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Website")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Companies");
            });

        modelBuilder.Entity("GameDevJobs.Domain.Entities.Location", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Locations");
            });

        modelBuilder.Entity("GameDevJobs.Domain.Entities.Offer", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<int>("CategoryId")
                    .HasColumnType("integer");

                b.Property<int>("CompanyId")
                    .HasColumnType("integer");

                b.Property<DateOnly>("Date")
                    .HasColumnType("date");

                b.Property<int>("LocationId")
                    .HasColumnType("integer");

                b.Property<int?>("SalaryMax")
                    .HasColumnType("integer");

                b.Property<int?>("SalaryMin")
                    .HasColumnType("integer");

                b.Property<int?>("SeniorityId")
                    .HasColumnType("integer");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Url")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<int>("Views")
                    .HasColumnType("integer");

                b.Property<int>("WorkingTimeId")
                    .HasColumnType("integer");

                b.HasKey("Id");

                b.HasIndex("CategoryId");

                b.HasIndex("CompanyId");

                b.HasIndex("LocationId");

                b.HasIndex("SeniorityId");

                b.HasIndex("WorkingTimeId");

                b.ToTable("Offers");
            });

        modelBuilder.Entity("GameDevJobs.Domain.Entities.Seniority", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Seniorities");
            });

        modelBuilder.Entity("GameDevJobs.Domain.Entities.WorkingTime", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("WorkingTimes");
            });

        modelBuilder.Entity("GameDevJobs.Domain.Entities.Offer", b =>
            {
                b.HasOne("GameDevJobs.Domain.Entities.Category", "Category")
                    .WithMany("Offers")
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("GameDevJobs.Domain.Entities.Company", "Company")
                    .WithMany("Offers")
                    .HasForeignKey("CompanyId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("GameDevJobs.Domain.Entities.Location", "Location")
                    .WithMany("Offers")
                    .HasForeignKey("LocationId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("GameDevJobs.Domain.Entities.Seniority", "Seniority")
                    .WithMany("Offers")
                    .HasForeignKey("SeniorityId");

                b.HasOne("GameDevJobs.Domain.Entities.WorkingTime", "WorkingTime")
                    .WithMany("Offers")
                    .HasForeignKey("WorkingTimeId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Category");

                b.Navigation("Company");

                b.Navigation("Location");

                b.Navigation("Seniority");

                b.Navigation("WorkingTime");
            });

        modelBuilder.Entity("GameDevJobs.Domain.Entities.Category", b =>
            {
                b.Navigation("Offers");
            });

        modelBuilder.Entity("GameDevJobs.Domain.Entities.Company", b =>
            {
                b.Navigation("Offers");
            });

        modelBuilder.Entity("GameDevJobs.Domain.Entities.Location", b =>
            {
                b.Navigation("Offers");
            });

        modelBuilder.Entity("GameDevJobs.Domain.Entities.Seniority", b =>
            {
                b.Navigation("Offers");
            });

        modelBuilder.Entity("GameDevJobs.Domain.Entities.WorkingTime", b =>
            {
                b.Navigation("Offers");
            });
#pragma warning restore 612, 618
    }
}
