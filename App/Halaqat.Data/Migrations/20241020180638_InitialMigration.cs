using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicQualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicQualifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appreciations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appreciations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationalStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalStages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "NVARCHAR(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    ExpectedDuration = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sorahs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorahs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersManagementPrivileges_CanCreate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    UsersManagementPrivileges_CanRead = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    UsersManagementPrivileges_CanUpdate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    UsersManagementPrivileges_CanDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    EmployeesManagementPrivileges_CanCreate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    EmployeesManagementPrivileges_CanRead = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    EmployeesManagementPrivileges_CanUpdate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    EmployeesManagementPrivileges_CanDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    StudentsManagementPrivileges_CanCreate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    StudentsManagementPrivileges_CanRead = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    StudentsManagementPrivileges_CanUpdate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    StudentsManagementPrivileges_CanDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CirclesManagementPrivileges_CanCreate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CirclesManagementPrivileges_CanRead = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CirclesManagementPrivileges_CanUpdate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CirclesManagementPrivileges_CanDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ProgramsManagementPrivileges_CanCreate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ProgramsManagementPrivileges_CanRead = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ProgramsManagementPrivileges_CanUpdate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ProgramsManagementPrivileges_CanDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ReportsManagementPrivileges_CanCreate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ReportsManagementPrivileges_CanRead = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ReportsManagementPrivileges_CanUpdate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ReportsManagementPrivileges_CanDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    UserName = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    EducationalStageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_EducationalStages_EducationalStageId",
                        column: x => x.EducationalStageId,
                        principalTable: "EducationalStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramDays_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SorahId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Page = table.Column<int>(type: "int", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Hezb = table.Column<int>(type: "int", nullable: false),
                    Joza = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verses_Sorahs_SorahId",
                        column: x => x.SorahId,
                        principalTable: "Sorahs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitleId = table.Column<int>(type: "int", nullable: false),
                    AcademicQualificationId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AcademicQualifications_AcademicQualificationId",
                        column: x => x.AcademicQualificationId,
                        principalTable: "AcademicQualifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Employees_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramDayAppreciation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAppreciated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgramDayId = table.Column<int>(type: "int", nullable: false),
                    AppreciationId = table.Column<int>(type: "int", nullable: false),
                    ProgramDayItemTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramDayAppreciation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramDayAppreciation_Appreciations_AppreciationId",
                        column: x => x.AppreciationId,
                        principalTable: "Appreciations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramDayAppreciation_ProgramDays_ProgramDayId",
                        column: x => x.ProgramDayId,
                        principalTable: "ProgramDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramDayAppreciation_ProgramItemTypes_ProgramDayItemTypeId",
                        column: x => x.ProgramDayItemTypeId,
                        principalTable: "ProgramItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramDayItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramDayId = table.Column<int>(type: "int", nullable: false),
                    ProgramDayItemTypeId = table.Column<int>(type: "int", nullable: false),
                    SorahId = table.Column<int>(type: "int", nullable: false),
                    VerseFromId = table.Column<int>(type: "int", nullable: true),
                    VerseToId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramDayItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramDayItems_ProgramDays_ProgramDayId",
                        column: x => x.ProgramDayId,
                        principalTable: "ProgramDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramDayItems_ProgramItemTypes_ProgramDayItemTypeId",
                        column: x => x.ProgramDayItemTypeId,
                        principalTable: "ProgramItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramDayItems_Sorahs_SorahId",
                        column: x => x.SorahId,
                        principalTable: "Sorahs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramDayItems_Verses_VerseFromId",
                        column: x => x.VerseFromId,
                        principalTable: "Verses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramDayItems_Verses_VerseToId",
                        column: x => x.VerseToId,
                        principalTable: "Verses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePhone",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PhonesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePhone", x => new { x.EmployeeId, x.PhonesId });
                    table.ForeignKey(
                        name: "FK_EmployeePhone_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePhone_Phones_PhonesId",
                        column: x => x.PhonesId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Circles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Circles_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    CircleId = table.Column<int>(type: "int", nullable: true),
                    ProgramId = table.Column<int>(type: "int", nullable: true),
                    EducationalStageId = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_EducationalStages_EducationalStageId",
                        column: x => x.EducationalStageId,
                        principalTable: "EducationalStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneStudent",
                columns: table => new
                {
                    PhonesId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneStudent", x => new { x.PhonesId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_PhoneStudent_Phones_PhonesId",
                        column: x => x.PhonesId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicQualifications",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "جامعي" },
                    { 2, "متوسط" },
                    { 3, "دكتوراه" },
                    { 4, "بدون" }
                });

            migrationBuilder.InsertData(
                table: "Appreciations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "إعادة" },
                    { 2, "جيد" },
                    { 3, "جيد جدا" },
                    { 4, "ممتاز" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "مدينة 1" },
                    { 2, "مدينة 2" },
                    { 3, "مدينة 3" }
                });

            migrationBuilder.InsertData(
                table: "EducationalStages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ما قبل الدراسة" },
                    { 2, "إبتدائي" },
                    { 3, "متوسطة" },
                    { 4, "ثانوي" },
                    { 5, "جامعي" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ذكر" },
                    { 2, "أنثى" }
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "Id", "DateCreated", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "معلم" },
                    { 2, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "إداري" }
                });

            migrationBuilder.InsertData(
                table: "ProgramItemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "حفظ" },
                    { 2, "مراجعة" }
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "ExpectedDuration", "Name", "Notes" },
                values: new object[] { 1, 612, "برنامج الـ 612 يوم", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "IsActive", "Password", "UserName" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "EducationalStageId", "Name" },
                values: new object[,]
                {
                    { 1, 2, "أول" },
                    { 2, 2, "ثاني" },
                    { 3, 2, "ثالث" },
                    { 4, 2, "رابع" },
                    { 5, 2, "خامس" },
                    { 6, 2, "سادس" },
                    { 7, 3, "أول" },
                    { 8, 3, "ثاني" },
                    { 9, 3, "ثالث" },
                    { 10, 4, "أول" },
                    { 11, 4, "ثاني" },
                    { 12, 4, "ثالث" },
                    { 13, 5, "أول" },
                    { 14, 5, "ثاني" },
                    { 15, 5, "ثالث" },
                    { 16, 5, "رابع" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicQualifications_Name",
                table: "AcademicQualifications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Appreciations_Name",
                table: "Appreciations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Circles_Name",
                table: "Circles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Circles_TeacherId",
                table: "Circles",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_EducationalStageId",
                table: "Classes",
                column: "EducationalStageId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalStages_Name",
                table: "EducationalStages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhone_PhonesId",
                table: "EmployeePhone",
                column: "PhonesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AcademicQualificationId",
                table: "Employees",
                column: "AcademicQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_Name",
                table: "JobTitles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneStudent_StudentId",
                table: "PhoneStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayAppreciation_AppreciationId",
                table: "ProgramDayAppreciation",
                column: "AppreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayAppreciation_ProgramDayId",
                table: "ProgramDayAppreciation",
                column: "ProgramDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayAppreciation_ProgramDayItemTypeId",
                table: "ProgramDayAppreciation",
                column: "ProgramDayItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayItems_ProgramDayId",
                table: "ProgramDayItems",
                column: "ProgramDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayItems_ProgramDayItemTypeId",
                table: "ProgramDayItems",
                column: "ProgramDayItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayItems_SorahId",
                table: "ProgramDayItems",
                column: "SorahId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayItems_VerseFromId",
                table: "ProgramDayItems",
                column: "VerseFromId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayItems_VerseToId",
                table: "ProgramDayItems",
                column: "VerseToId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDays_ProgramId",
                table: "ProgramDays",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CircleId",
                table: "Students",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EducationalStageId",
                table: "Students",
                column: "EducationalStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GenderId",
                table: "Students",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramId",
                table: "Students",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verses_SorahId",
                table: "Verses",
                column: "SorahId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePhone");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropTable(
                name: "PhoneStudent");

            migrationBuilder.DropTable(
                name: "ProgramDayAppreciation");

            migrationBuilder.DropTable(
                name: "ProgramDayItems");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Appreciations");

            migrationBuilder.DropTable(
                name: "ProgramDays");

            migrationBuilder.DropTable(
                name: "ProgramItemTypes");

            migrationBuilder.DropTable(
                name: "Verses");

            migrationBuilder.DropTable(
                name: "Circles");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Sorahs");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "EducationalStages");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AcademicQualifications");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
