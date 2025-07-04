﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudentReportCard.Infrastructure.Persistence;

#nullable disable

namespace StudentReportCard.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StudentReportCard.Domain.Entities.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("StudentReportCard.Domain.Entities.Mark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uuid");

                    b.Property<int>("MaximumMarks")
                        .HasColumnType("integer");

                    b.Property<int>("ObtainedMarks")
                        .HasColumnType("integer");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("StudentReportCard.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentReportCard.Domain.Entities.StudentClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("StudentReportCard.Domain.Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudentReportCard.Domain.Entities.Mark", b =>
                {
                    b.HasOne("StudentReportCard.Domain.Entities.Exam", "Exam")
                        .WithMany("Marks")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentReportCard.Domain.Entities.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentReportCard.Domain.Entities.Subject", "Subject")
                        .WithMany("Marks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentReportCard.Domain.Entities.Student", b =>
                {
                    b.HasOne("StudentReportCard.Domain.Entities.StudentClass", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("StudentReportCard.Domain.Entities.Exam", b =>
                {
                    b.Navigation("Marks");
                });

            modelBuilder.Entity("StudentReportCard.Domain.Entities.Student", b =>
                {
                    b.Navigation("Marks");
                });

            modelBuilder.Entity("StudentReportCard.Domain.Entities.StudentClass", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentReportCard.Domain.Entities.Subject", b =>
                {
                    b.Navigation("Marks");
                });
#pragma warning restore 612, 618
        }
    }
}
