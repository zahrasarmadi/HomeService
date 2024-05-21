using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeService.Infra.DataBase.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    BackUpPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BankCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfrim = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceSubCategories_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceSubCategoryId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ServiceSubCategories_ServiceSubCategoryId",
                        column: x => x.ServiceSubCategoryId,
                        principalTable: "ServiceSubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpertService",
                columns: table => new
                {
                    ExpertsId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertService", x => new { x.ExpertsId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_ExpertService_Experts_ExpertsId",
                        column: x => x.ExpertsId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoneAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suggestions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedAt", "FirstName", "Gender", "IsDeleted", "LastName" },
                values: new object[] { 1, new DateTime(2024, 5, 20, 22, 29, 36, 204, DateTimeKind.Local).AddTicks(7004), "زهرا", 1, false, "سرمدی" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Expert", "EXPERT" },
                    { 3, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3350), "آذربایجان شرقی" },
                    { 2, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3352), "آذربایجان غربی" },
                    { 3, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3354), "اردبیل" },
                    { 4, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3356), "اصفهان" },
                    { 5, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3358), "البرز" },
                    { 6, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3359), "ایلام" },
                    { 7, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3360), "بوشهر" },
                    { 8, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3362), "تهران" },
                    { 9, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3364), "چهارمحال و بختیاری" },
                    { 10, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3375), "خراسان جنوبی" },
                    { 11, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3377), "خراسان رضوی" },
                    { 12, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3395), "خراسان شمالی" },
                    { 13, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3397), "خوزستان" },
                    { 14, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3399), "زنجان" },
                    { 15, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3400), "سمنان" },
                    { 16, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3402), "سیستان و بلوچستان" },
                    { 17, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3403), "فارس" },
                    { 18, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3405), "قزوین" },
                    { 19, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3407), "قم" },
                    { 20, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3408), "کردستان" },
                    { 21, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3410), "کرمان" },
                    { 22, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3411), "کرمانشاه" },
                    { 23, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3413), "کهگیلویه و بویراحمد" },
                    { 24, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3414), "گلستان" },
                    { 25, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3416), "گیلان" },
                    { 26, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3417), "لرستان" },
                    { 27, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3419), "مازندران" },
                    { 28, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3421), "مرکزی" },
                    { 29, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3422), "هرمزگان" },
                    { 30, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3424), "همدان" },
                    { 31, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(3425), "یزد" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BackUpPhoneNumber", "BankCardNumber", "CreatedAt", "FirstName", "Gender", "IsDeleted", "LastName" },
                values: new object[,]
                {
                    { 1, "09123669858", "1234123412341234", new DateTime(2024, 5, 20, 22, 29, 36, 207, DateTimeKind.Local).AddTicks(2049), "سحر", 1, false, "محمودی" },
                    { 2, "09123623258", "1239684412341234", new DateTime(2024, 5, 20, 22, 29, 36, 207, DateTimeKind.Local).AddTicks(2087), "محمد", 2, false, "اصغری" }
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "BankCardNumber", "BirthDate", "CreatedAt", "FirstName", "Gender", "IsConfrim", "IsDeleted", "LastName", "PhoneNumber", "ProfileImage" },
                values: new object[,]
                {
                    { 1, "1234123412341234", new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 20, 22, 29, 36, 207, DateTimeKind.Local).AddTicks(9906), "علی", 2, true, false, "آموزگار", "09362356998", null },
                    { 2, "1234123412341255", new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 20, 22, 29, 36, 207, DateTimeKind.Local).AddTicks(9911), "سارا", 2, true, false, "همتی", "09362357998", null }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(7477), null, false, "تمیزکاری" },
                    { 2, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(7480), null, false, "ساختمان" },
                    { 3, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(7482), null, false, "تعمیرات اشیاء" },
                    { 4, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(7483), null, false, "اسباب کشی و حمل بار" },
                    { 5, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(7485), null, false, "خودرو" },
                    { 6, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(7487), null, false, "سازمان ها و مجتمع ها" },
                    { 7, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(7489), null, false, "سلامت و زیبایی" },
                    { 8, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(7491), null, false, "کشکول" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdminId", "ConcurrencyStamp", "CustomerId", "Email", "EmailConfirmed", "ExpertId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, 1, "ed2a6cbf-90a0-4510-ab64-a968de82804f", null, "Zahrasarmadi17@gmail.com", false, null, false, null, "ZAHRASARMADI17@GMAIL.COM", "ZAHRASARMADI17@GMAIL.COM", "AQAAAAIAAYagAAAAEBKbdquuh0jURNpf2D5v4VxBFOfVm5K6UB7dB45BmvtKnRmCm5UMOm4XwZSLMaL09w==", "09927848276", false, "9b7de613-0c0d-4402-9a2e-8835c4e3b38d", false, "Zahrasarmadi17@gmail.com" },
                    { 2, 0, null, "f0b6afac-3044-4396-96dc-ff14b262eddc", null, "Ali@gmail.com", false, 1, false, null, "ALI@GMAIL.COM", "ALI@GMAIL.COM", "AQAAAAIAAYagAAAAEMeEU2qC17SWb1aNPWouNIj9/oibq0Np3sdPBUhyblTBlg3Z0Mnbl58a58rwrKphLA==", "09377507920", false, "6ac827be-180c-4d43-9833-4cd4b381bec6", false, "Ali@gmail.com" },
                    { 3, 0, null, "8a2833d6-3d2c-43d6-845e-2d09bd46ae6b", 1, "Sahar@gmail.com", false, null, false, null, "SAHAR@GMAIL.COM", "SAHAR@GMAIL.COM", "AQAAAAIAAYagAAAAEIbxEVvCyEVBPypHXbDxbN8HDL6uQPOqSrTliHm8p0aR1WKrYY3obtjRHTrW4OFroA==", "09377507920", false, "e71818a7-bd4c-46fa-acb3-ca060addc950", false, "Sahar@gmail.com" },
                    { 4, 0, null, "aa2d77b4-e76a-4236-adba-b6c6e99d69b3", null, "Sara@gmail.com", false, 2, false, null, "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAED2JJXxwza07o0JIYtvhBnafXmHD+23tJgbsUqVj71TXt8FBAjnl9YWWdqwGMU3Hjw==", "09377507920", false, "a816ce8a-47f0-4b35-8009-114a582a0349", false, "Sara@gmail.com" },
                    { 5, 0, null, "7627cae6-e494-4f0a-bf9d-887060b1fa17", 2, "Mohammad@gmail.com", false, null, false, null, "MOHAMMAD@GMAIL.COM", "MOHAMMAD@GMAIL.COM", "AQAAAAIAAYagAAAAEHtmMXbixFY0oFt2PHbWYUpvw+59gmU6L6Hqn4Gic4WipB181n00Y4dwZakMoFIlcg==", "09377507920", false, "d6f0cedf-b7b1-47e5-b005-cb1a9bc22334", false, "Mohammad@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "ExpertId", "IsAccept", "IsDeleted", "Score", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 20, 22, 29, 36, 206, DateTimeKind.Local).AddTicks(8262), 1, "کارش عالی بود", 1, false, false, 4, "عالی" });

            migrationBuilder.InsertData(
                table: "ServiceSubCategories",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9324), null, false, "نظافت و پذیرایی", 1 },
                    { 2, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9327), null, false, "شستشو", 1 },
                    { 3, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9329), null, false, "کارواش و دیتیلینگ", 1 },
                    { 4, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9331), null, false, "سرمایش و گرمایش", 3 },
                    { 5, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9333), null, false, "نصب وتعمیر لوازم خانگی", 3 },
                    { 6, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9335), null, false, "کارواش و دیتیلینگ", 3 },
                    { 7, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9337), null, false, "خذمات کامپیوتری", 3 },
                    { 8, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9339), null, false, "تعمیرات موبایل", 3 },
                    { 9, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9341), null, false, "سرمایش و گرمایش", 2 },
                    { 10, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9343), null, false, "تعمیرا ساختمان", 2 },
                    { 11, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9344), null, false, "لوله کشی", 2 },
                    { 12, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9346), null, false, "طراحی و بازسازی ساختمان", 2 },
                    { 13, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9348), null, false, "برق کاری", 2 },
                    { 14, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9350), null, false, "چوب و کابینت", 2 },
                    { 15, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9352), null, false, "خدمات شیشه ای ساختمان", 2 },
                    { 16, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9353), null, false, "باغبانی و فضای سبز", 2 },
                    { 17, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9355), null, false, "باربری و جا به جایی", 4 },
                    { 18, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9357), null, false, "خدمات و تعمیرات خودرو", 5 },
                    { 19, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9359), null, false, "کارواش و دیتیلینگ", 5 },
                    { 20, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9360), null, false, "خدمات شرکتی", 6 },
                    { 21, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9362), null, false, "زیبایی بانوان", 7 },
                    { 22, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9364), null, false, "پیرایش و زیبایی آقایان", 7 },
                    { 23, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9365), null, false, "پزشکی و پرستاری", 7 },
                    { 24, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(9367), null, false, "حیوانات خانگی", 7 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 2, 4 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name", "Price", "ServiceSubCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(3435), null, false, "سرویس عادی نظافت", 700000, 1 },
                    { 2, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(3439), null, false, "سرویس لوکسن نظافت", 850000, 1 },
                    { 3, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(3441), null, false, "سرویس ویژه نظافت", 1000000, 1 },
                    { 4, new DateTime(2024, 5, 20, 22, 29, 36, 208, DateTimeKind.Local).AddTicks(3443), null, false, "تعمیر و سرویس کولر آبی", 200000, 4 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "DoneAt", "ExpertId", "Image", "IsDeleted", "RequestedAt", "ServiceId", "Status", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 20, 22, 29, 36, 205, DateTimeKind.Local).AddTicks(9756), 1, "نظافت خونه صد متری هب طور کامل", new DateTime(2024, 5, 20, 22, 29, 36, 205, DateTimeKind.Local).AddTicks(9761), 1, null, false, new DateTime(2024, 5, 20, 22, 29, 36, 205, DateTimeKind.Local).AddTicks(9767), 1, 6, "نظافت" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ExpertId",
                table: "Addresses",
                column: "ExpertId",
                unique: true,
                filter: "[ExpertId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ExpertId",
                table: "AspNetUsers",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ExpertId",
                table: "Comments",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertService_ServicesId",
                table: "ExpertService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ExpertId",
                table: "Orders",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceId",
                table: "Orders",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceSubCategoryId",
                table: "Services",
                column: "ServiceSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSubCategories_ServiceCategoryId",
                table: "ServiceSubCategories",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_ExpertId",
                table: "Suggestions",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_OrderId",
                table: "Suggestions",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ExpertService");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "ServiceSubCategories");

            migrationBuilder.DropTable(
                name: "ServiceCategories");
        }
    }
}
