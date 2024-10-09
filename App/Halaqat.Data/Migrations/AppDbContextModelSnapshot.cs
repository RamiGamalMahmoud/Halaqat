﻿// <auto-generated />
using System;
using Halaqat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Halaqat.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeePhone", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("PhonesId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "PhonesId");

                    b.HasIndex("PhonesId");

                    b.ToTable("EmployeePhone", (string)null);
                });

            modelBuilder.Entity("Halaqat.Shared.Models.AcademicQualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AcademicQualifications", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "جامعي"
                        },
                        new
                        {
                            Id = 2,
                            Name = "متوسط"
                        },
                        new
                        {
                            Id = 3,
                            Name = "دكتوراه"
                        },
                        new
                        {
                            Id = 4,
                            Name = "بدون"
                        });
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Circle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TeacherId");

                    b.ToTable("Circles", (string)null);
                });

            modelBuilder.Entity("Halaqat.Shared.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Cities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "مدينة 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "مدينة 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "مدينة 3"
                        });
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AcademicQualificationId")
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AcademicQualificationId");

                    b.HasIndex("AddressId");

                    b.HasIndex("GenderId");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Employees", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(5)");

                    b.HasKey("Id");

                    b.ToTable("Gender", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ذكر"
                        },
                        new
                        {
                            Id = 2,
                            Name = "أنثى"
                        });
                });

            modelBuilder.Entity("Halaqat.Shared.Models.JobTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("JobTitles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "معلم"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "إداري"
                        });
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(14)");

                    b.HasKey("Id");

                    b.ToTable("Phones", (string)null);
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExpectedDuration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Notes")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.HasKey("Id");

                    b.ToTable("Programs", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExpectedDuration = 612,
                            Name = "برنامج الـ 612 يوم"
                        });
                });

            modelBuilder.Entity("Halaqat.Shared.Models.ProgramDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("ProgramDays", (string)null);
                });

            modelBuilder.Entity("Halaqat.Shared.Models.ProgramDayItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProgramDayId")
                        .HasColumnType("int");

                    b.Property<int>("ProgramDayItemTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SorahId")
                        .HasColumnType("int");

                    b.Property<int?>("VerseFromId")
                        .HasColumnType("int");

                    b.Property<int?>("VerseToId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgramDayId");

                    b.HasIndex("ProgramDayItemTypeId");

                    b.HasIndex("SorahId");

                    b.HasIndex("VerseFromId");

                    b.HasIndex("VerseToId");

                    b.ToTable("ProgramDayItems", (string)null);
                });

            modelBuilder.Entity("Halaqat.Shared.Models.ProgramDayItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("ProgramItemTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "حفظ"
                        },
                        new
                        {
                            Id = 2,
                            Name = "مراجعة"
                        });
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Sorah", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sorahs", (string)null);
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("CircleId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateCreated")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<int?>("ProgramId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CircleId");

                    b.HasIndex("GenderId");

                    b.HasIndex("ProgramId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("Halaqat.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Password = "admin",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Verse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Hezb")
                        .HasColumnType("int");

                    b.Property<int>("Joza")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Page")
                        .HasColumnType("int");

                    b.Property<int>("Quarter")
                        .HasColumnType("int");

                    b.Property<string>("SearchText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SorahId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SorahId");

                    b.ToTable("Verses", (string)null);
                });

            modelBuilder.Entity("PhoneStudent", b =>
                {
                    b.Property<int>("PhonesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("PhonesId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("PhoneStudent", (string)null);
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Teacher", b =>
                {
                    b.HasBaseType("Halaqat.Shared.Models.Employee");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("EmployeePhone", b =>
                {
                    b.HasOne("Halaqat.Shared.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Halaqat.Shared.Models.Phone", null)
                        .WithMany()
                        .HasForeignKey("PhonesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Address", b =>
                {
                    b.HasOne("Halaqat.Shared.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Circle", b =>
                {
                    b.HasOne("Halaqat.Shared.Models.Teacher", "Teacher")
                        .WithMany("Circles")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Employee", b =>
                {
                    b.HasOne("Halaqat.Shared.Models.AcademicQualification", "AcademicQualification")
                        .WithMany()
                        .HasForeignKey("AcademicQualificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Halaqat.Shared.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Halaqat.Shared.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Halaqat.Shared.Models.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Halaqat.Shared.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("Halaqat.Shared.Models.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("AcademicQualification");

                    b.Navigation("Address");

                    b.Navigation("Gender");

                    b.Navigation("JobTitle");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Halaqat.Shared.Models.ProgramDay", b =>
                {
                    b.HasOne("Halaqat.Shared.Models.Program", "Program")
                        .WithMany("ProgramDays")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Halaqat.Shared.Models.ProgramDayItem", b =>
                {
                    b.HasOne("Halaqat.Shared.Models.ProgramDay", "ProgramDay")
                        .WithMany("ProgramDayItems")
                        .HasForeignKey("ProgramDayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Halaqat.Shared.Models.ProgramDayItemType", "ProgramDayItemType")
                        .WithMany()
                        .HasForeignKey("ProgramDayItemTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Halaqat.Shared.Models.Sorah", "Sorah")
                        .WithMany()
                        .HasForeignKey("SorahId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Halaqat.Shared.Models.Verse", "VerseFrom")
                        .WithMany()
                        .HasForeignKey("VerseFromId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Halaqat.Shared.Models.Verse", "VerseTo")
                        .WithMany()
                        .HasForeignKey("VerseToId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ProgramDay");

                    b.Navigation("ProgramDayItemType");

                    b.Navigation("Sorah");

                    b.Navigation("VerseFrom");

                    b.Navigation("VerseTo");
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Student", b =>
                {
                    b.HasOne("Halaqat.Shared.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Halaqat.Shared.Models.Circle", "Circle")
                        .WithMany("Students")
                        .HasForeignKey("CircleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Halaqat.Shared.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Halaqat.Shared.Models.Program", "Program")
                        .WithMany()
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Address");

                    b.Navigation("Circle");

                    b.Navigation("Gender");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Verse", b =>
                {
                    b.HasOne("Halaqat.Shared.Models.Sorah", "Sorah")
                        .WithMany("Verses")
                        .HasForeignKey("SorahId");

                    b.Navigation("Sorah");
                });

            modelBuilder.Entity("PhoneStudent", b =>
                {
                    b.HasOne("Halaqat.Shared.Models.Phone", null)
                        .WithMany()
                        .HasForeignKey("PhonesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Halaqat.Shared.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Teacher", b =>
                {
                    b.HasOne("Halaqat.Shared.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("Halaqat.Shared.Models.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Circle", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Program", b =>
                {
                    b.Navigation("ProgramDays");
                });

            modelBuilder.Entity("Halaqat.Shared.Models.ProgramDay", b =>
                {
                    b.Navigation("ProgramDayItems");
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Sorah", b =>
                {
                    b.Navigation("Verses");
                });

            modelBuilder.Entity("Halaqat.Shared.Models.Teacher", b =>
                {
                    b.Navigation("Circles");
                });
#pragma warning restore 612, 618
        }
    }
}
