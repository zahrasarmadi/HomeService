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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfrim = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceSubCategoryId = table.Column<int>(type: "int", nullable: false),
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
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequesteForTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    SuggestedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Expert", "EXPERT" },
                    { 3, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "b8a8d1d6-2994-4f84-adef-0c81350008f6", "Zahrasarmadi17@gmail.com", false, false, null, "ZAHRASARMADI17@GMAIL.COM", "ZAHRASARMADI17@GMAIL.COM", "AQAAAAIAAYagAAAAEC7+q0GlMUFXpnv1bTkSuv/HLbEj5rrYiIp7KH1RqsxPa8W7YN8DWmAoAJ0z1r/1aA==", "09927848276", false, "33555ffa-d139-4d48-9ee9-a27b21a4b45f", false, "Zahrasarmadi17@gmail.com" },
                    { 2, 0, "1d8585b1-88c0-424c-b166-addd9c765598", "Ali@gmail.com", false, false, null, "ALI@GMAIL.COM", "ALI@GMAIL.COM", "AQAAAAIAAYagAAAAEPK6L1hVEuka50DWQgMmbrBuOM0h5mV+5livp8C9FMRAWzbochJ5Uv684LRMLqYFaw==", "09377507920", false, "fe51ea36-11d1-4232-ad28-837cf9f680f7", false, "Ali@gmail.com" },
                    { 3, 0, "e4b0ef46-ad08-4a3c-8207-7ed18d3689c1", "Sahar@gmail.com", false, false, null, "SAHAR@GMAIL.COM", "SAHAR@GMAIL.COM", "AQAAAAIAAYagAAAAEKQn0hkUnkmx2zNoIitAt/iHp6JlGYa1pAGeXImJG6xKwJ6WAx2cJnjaL/lM8EwCdw==", "09377507920", false, "64bc7676-2088-458f-b9b8-121e9490b796", false, "Sahar@gmail.com" },
                    { 4, 0, "049a87d3-3042-404c-b57c-d12a0991b909", "Sara@gmail.com", false, false, null, "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAEHwoQMLEWlduhx7BfhCDPen+/GeK8SE4oU9LOe7YeX0pmZTk0es4gOAhthqnjcTREw==", "09377507920", false, "12d1fc8f-ef00-4432-8a3b-04b80bf9fa01", false, "Sara@gmail.com" },
                    { 5, 0, "800a9e35-2aed-4dff-8d42-c9f9ede4f66e", "Mohammad@gmail.com", false, false, null, "MOHAMMAD@GMAIL.COM", "MOHAMMAD@GMAIL.COM", "AQAAAAIAAYagAAAAEO22i5P+qCaPsE6ZkL7iV0eME+3jTvNYxDGLNxgrc7kijgqcAu6Q8T4LvaR+KdU40g==", "09377507920", false, "a6787abd-155e-430c-9838-7b1bbe1891ee", false, "Mohammad@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(380), "آذربایجان شرقی" },
                    { 2, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(382), "آذربایجان غربی" },
                    { 3, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(384), "اردبیل" },
                    { 4, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(386), "اصفهان" },
                    { 5, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(387), "البرز" },
                    { 6, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(389), "ایلام" },
                    { 7, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(391), "بوشهر" },
                    { 8, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(392), "تهران" },
                    { 9, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(394), "چهارمحال و بختیاری" },
                    { 10, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(407), "خراسان جنوبی" },
                    { 11, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(409), "خراسان رضوی" },
                    { 12, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(428), "خراسان شمالی" },
                    { 13, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(429), "خوزستان" },
                    { 14, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(431), "زنجان" },
                    { 15, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(432), "سمنان" },
                    { 16, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(434), "سیستان و بلوچستان" },
                    { 17, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(435), "فارس" },
                    { 18, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(437), "قزوین" },
                    { 19, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(438), "قم" },
                    { 20, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(440), "کردستان" },
                    { 21, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(441), "کرمان" },
                    { 22, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(443), "کرمانشاه" },
                    { 23, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(444), "کهگیلویه و بویراحمد" },
                    { 24, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(446), "گلستان" },
                    { 25, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(448), "گیلان" },
                    { 26, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(449), "لرستان" },
                    { 27, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(450), "مازندران" },
                    { 28, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(452), "مرکزی" },
                    { 29, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(453), "هرمزگان" },
                    { 30, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(455), "همدان" },
                    { 31, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(456), "یزد" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(5625), "\\assets\\img\\category\\broom-solid.svg", false, "تمیزکاری" },
                    { 2, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(5627), "\\assets\\img\\category\\building-solid.svg", false, "ساختمان" },
                    { 3, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(5630), "\\assets\\img\\category\\screwdriver-wrench-solid.svg", false, "تعمیرات اشیاء" },
                    { 4, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(5631), "\\assets\\img\\category\\truck-moving-solid.svg", false, "اسباب‌کشی و حمل بار" },
                    { 5, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(5633), "\\assets\\img\\category\\car-solid.svg", false, "خودرو" },
                    { 6, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(5635), "\\assets\\img\\category\\building-flag-solid.svg", false, "سازمان‌ها و مجتمع‌ها" },
                    { 7, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(5637), "\\assets\\img\\category\\suitcase-medical-solid.svg", false, "سلامت و زیبایی" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "FirstName", "Gender", "IsDeleted", "LastName" },
                values: new object[] { 1, 1, new DateTime(2024, 6, 20, 1, 9, 19, 69, DateTimeKind.Local).AddTicks(9946), "زهرا", 1, false, "سرمدی" });

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
                table: "Customers",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "FirstName", "Gender", "IsDeleted", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(5685), "سحر", 1, false, "محمودی", "09123669858" },
                    { 2, 5, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(5689), "محمد", 2, false, "اصغری", "09123623258" }
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "ApplicationUserId", "BirthDate", "CreatedAt", "FirstName", "Gender", "IsConfrim", "IsDeleted", "LastName", "PhoneNumber", "ProfileImage" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(207), "علی", 2, true, false, "آموزگار", "09362356998", null },
                    { 2, 4, new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(210), "سارا", 2, true, false, "همتی", "09362357998", null }
                });

            migrationBuilder.InsertData(
                table: "ServiceSubCategories",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(6981), "\\assets\\img\\sub-category\\tamiz-kari\\nezafat-pazirayi.webp", false, "نظافت و پذیرایی", 1 },
                    { 2, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(6984), "\\assets\\img\\sub-category\\tamiz-kari\\shosteshu.webp", false, "شستشو", 1 },
                    { 3, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(6986), "\\assets\\img\\sub-category\\tamiz-kari\\carwash.webp", false, "کارواش و دیتیلینگ", 1 },
                    { 4, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(6988), "\\assets\\img\\sub-category\\tamirat\\sarmayesh-garmayesh.webp", false, "سرمایش و گرمایش", 3 },
                    { 5, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(6990), "\\assets\\img\\sub-category\\tamirat\\tamir-lavazem-khanegi.webp", false, "نصب وتعمیر لوازم خانگی", 3 },
                    { 7, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(6992), "\\assets\\img\\sub-category\\tamirat\\khadamat-computer.webp", false, "خذمات کامپیوتری", 3 },
                    { 8, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(6994), "\\assets\\img\\sub-category\\tamirat\\tamirat-mobile.webp", false, "تعمیرات موبایل", 3 },
                    { 9, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(6996), "\\assets\\img\\sub-category\\sakhtemen\\sarmayesh-garmayesh.webp", false, "سرمایش و گرمایش", 2 },
                    { 10, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(6998), "\\assets\\img\\sub-category\\sakhtemen\\tamirat-sakhteman.webp", false, "تعمیرا ساختمان", 2 },
                    { 11, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(6999), "\\assets\\img\\sub-category\\sakhtemen\\lule-keshi.webp", false, "لوله کشی", 2 },
                    { 12, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7001), "\\assets\\img\\sub-category\\sakhtemen\\tarahi-sakhtemen.webp", false, "طراحی و بازسازی ساختمان", 2 },
                    { 13, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7003), "\\assets\\img\\sub-category\\sakhtemen\\bargh-kari.webp", false, "برق کاری", 2 },
                    { 14, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7005), "\\assets\\img\\sub-category\\sakhtemen\\chub-cabinet.webp", false, "چوب و کابینت", 2 },
                    { 15, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7007), "\\assets\\img\\sub-category\\sakhtemen\\khadamat-shishei.webp", false, "خدمات شیشه ای ساختمان", 2 },
                    { 16, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7009), "\\assets\\img\\sub-category\\sakhtemen\\baghbani.webp", false, "باغبانی و فضای سبز", 2 },
                    { 17, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7011), "\\assets\\img\\sub-category\\barbari.webp", false, "باربری و جا به جایی", 4 },
                    { 18, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7013), "\\assets\\img\\sub-category\\khodro\\khdamet-khodro.webp", false, "خدمات و تعمیرات خودرو", 5 },
                    { 19, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7014), "\\assets\\img\\sub-category\\khodro\\carwash.webp", false, "کارواش و دیتیلینگ", 5 },
                    { 20, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7016), "\\assets\\img\\sub-category\\khadamat-sherkati.webp", false, "خدمات شرکتی", 6 },
                    { 21, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7018), "\\assets\\img\\sub-category\\salamat-zibayi\\zibayi-banovan.webp", false, "زیبایی بانوان", 7 },
                    { 22, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7020), "\\assets\\img\\sub-category\\salamat-zibayi\\zibayi-aghayan.webp", false, "پیرایش و زیبایی آقایان", 7 },
                    { 23, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7022), "\\assets\\img\\sub-category\\salamat-zibayi\\pezeshki.webp", false, "پزشکی و پرستاری", 7 },
                    { 24, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7024), "\\assets\\img\\sub-category\\salamat-zibayi\\pet.webp", false, "حیوانات خانگی", 7 },
                    { 25, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(7025), "\\assets\\img\\sub-category\\salamat-zibayi\\varzesh.webp", false, "تندرستی و ورزش", 7 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "ExpertId", "IsAccept", "IsDeleted", "Score", "Title" },
                values: new object[] { 1, new DateTime(2024, 6, 20, 1, 9, 19, 71, DateTimeKind.Local).AddTicks(4450), 1, "کارش عالی بود", 1, false, false, 4, "عالی" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Price", "ServiceSubCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2781), false, "سرویس عادی نظافت", 700000, 1 },
                    { 2, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2783), false, "سرویس لوکس نظافت", 850000, 1 },
                    { 3, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2785), false, "سرویس ویژه نظافت", 1000000, 1 },
                    { 5, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2787), false, "نظافت راه‌پله", 1000000, 1 },
                    { 6, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2789), false, "سرویس نظافت فوری", 1000000, 1 },
                    { 7, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2791), false, "پذیرایی", 1000000, 1 },
                    { 8, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2793), false, "کارگر ساده", 1000000, 1 },
                    { 9, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2795), false, "سمپاشی فضای داخلی", 1000000, 1 },
                    { 10, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2797), false, "ضدعفونی منزل و محل کار", 1000000, 1 },
                    { 11, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2799), false, "شستشوی مبل ،فرش و موکت در محل", 1000000, 2 },
                    { 12, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2803), false, "خشکشویی", 1000000, 2 },
                    { 13, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2805), false, "پرده شویی", 1000000, 2 },
                    { 25, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2806), false, "تعمیر و سرویس کولر آبی", 1000000, 9 },
                    { 26, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2808), false, "تعمیر کولر گازی و داکت اسپلیت", 1000000, 9 },
                    { 27, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2810), false, "تعمیر و سرویس پکیج", 1000000, 9 },
                    { 28, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2812), false, "تعمیر و سرویس ابگرمکن", 1000000, 9 },
                    { 29, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2814), false, "کانال سازی کولر", 1000000, 9 },
                    { 32, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2817), false, "سرویس و تعمیر چیلر", 1000000, 9 },
                    { 33, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2819), false, "تعمیر و سرویس فن کویل", 1000000, 9 },
                    { 34, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2821), false, "نصب و تعمیر بخاری گازی و شومینه", 1000000, 9 },
                    { 36, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2822), false, "بهبود آلاینده‌های موتورخانه با دستگاه آنالیز", 1000000, 9 },
                    { 37, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2824), false, "ساخت و نصب توری", 1000000, 10 },
                    { 38, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2826), false, "جوشکاری و آهنگری ، درب و پنجره آهنی", 1000000, 10 },
                    { 39, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2828), false, "دوخت و نصب پرده", 1000000, 10 },
                    { 40, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2830), false, "کاشی کاری و سرامیک", 1000000, 10 },
                    { 41, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2832), false, "بنایی", 1000000, 10 },
                    { 42, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2834), false, "کلید سازی", 1000000, 10 },
                    { 43, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2835), false, "نصب و تعمیر انواع کفپوش و دیوارپوش", 1000000, 10 },
                    { 44, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2837), false, "کچ کاری و رابیتس کاری", 1000000, 10 },
                    { 45, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2839), false, "آچار فرانسه", 1000000, 10 },
                    { 46, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2841), false, "دریل کاری", 1000000, 10 },
                    { 47, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2843), false, "نصب ایزوگام ، قیرگونی و آسفالت", 1000000, 10 },
                    { 48, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2845), false, "تعمیرات نما و نماشویی", 1000000, 10 },
                    { 49, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2846), false, "کفسابی", 1000000, 10 },
                    { 50, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2848), false, "تخریب", 1000000, 10 },
                    { 51, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2850), false, "سقف و دیوار PVC و اسمان مجازی", 1000000, 10 },
                    { 52, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2853), false, "شیروانی و ایرانیت", 1000000, 10 },
                    { 53, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2855), false, "تعمیر و نگهداری استخر", 1000000, 10 },
                    { 54, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2856), false, "کپسول آتش‌ نشانی", 1000000, 10 },
                    { 55, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2858), false, "کناف کاری", 1000000, 10 },
                    { 56, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2915), false, "نصب و تعمیر شیرآلات", 1000000, 11 },
                    { 57, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2917), false, "تخلیه چاه و لوله بازکنی", 1000000, 11 },
                    { 58, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2919), false, "لوله کشی آب و فاضلاب", 1000000, 11 },
                    { 59, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2921), false, "نصب و سرویس توالت فرنگی و ایرانی", 1000000, 11 },
                    { 60, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2923), false, "تشخیص و ترمیم ترکیدگی لوله", 1000000, 11 },
                    { 61, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2925), false, "پمپ و منبع آب", 1000000, 11 },
                    { 62, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2927), false, "نصب و تعمیر دستگاه تصفیه آب", 1000000, 11 },
                    { 63, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2929), false, "نصب و تعمیر فلاش تانک و سیفون", 1000000, 11 },
                    { 64, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2931), false, "لوله کشی گاز", 1000000, 11 },
                    { 65, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2932), false, "نصب سینک ظرفشویی", 1000000, 11 },
                    { 66, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2934), false, "نصب روشویی", 1000000, 11 },
                    { 67, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2936), false, "نصب و تعمیر وال هنگ", 1000000, 11 },
                    { 68, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2938), false, "اتصال به شبکه فاضلاب شهری", 1000000, 11 },
                    { 69, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2940), false, "مشاوره و بازسازی ساختمان", 1000000, 12 },
                    { 70, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2942), false, "دکوراسیون و طراحی ساختمان", 1000000, 12 },
                    { 71, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2945), false, "رفع اتصالی", 1000000, 13 },
                    { 72, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2947), false, "نصب و تعمیر آیفون صوتی و تصویری", 1000000, 13 },
                    { 73, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2949), false, "نصب لوستر و چراغ", 1000000, 13 },
                    { 74, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2950), false, "سیم کشی تلفن و نصب سانترال", 1000000, 13 },
                    { 75, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2952), false, "نصب و تعمیر آنتن تلویزیون", 1000000, 13 },
                    { 76, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2954), false, "نصب و تعمیر دوربین مداربسته", 1000000, 13 },
                    { 77, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2956), false, "کلید و پریز", 1000000, 13 },
                    { 78, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2958), false, "تعمیر و سرویس آسانسور", 1000000, 13 },
                    { 79, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2960), false, "نصب و تعمیر کرکره برقی", 1000000, 13 },
                    { 80, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2962), false, "نصب و تعمیر جک پارکینگ و آرام بند", 1000000, 13 },
                    { 81, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2964), false, "هواکش و تهویه مطبوع", 1000000, 13 },
                    { 82, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2966), false, "ساخت و تعمیر تابلو روان و چلنیوم", 1000000, 13 },
                    { 83, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2967), false, "نصب و تعمیر بالابر", 1000000, 13 },
                    { 84, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2969), false, "نصب و تعمیر دزدگیر اماکن", 1000000, 13 },
                    { 85, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2971), false, "سیم پیجی", 1000000, 13 },
                    { 86, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2973), false, "خدمات برق صنعتی و سه فاز", 1000000, 13 },
                    { 87, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2975), false, "نصب سنسور و تایمر", 1000000, 13 },
                    { 88, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2977), false, "نصب محافظ برق و استابلایزر", 1000000, 13 },
                    { 89, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2978), false, "ساهت و تعمیر تابلو برق", 1000000, 13 },
                    { 90, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2981), false, "طراحی و اجرای نور مخفی", 1000000, 13 },
                    { 91, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2983), false, "نصب داکت و ترانکینگ", 1000000, 13 },
                    { 92, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2985), false, "نصب و تعمیر زنراتور و برق اضطراری", 1000000, 13 },
                    { 93, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2987), false, "نصب و تعمیر اگزاست‌فن و سانتریفیوژ", 1000000, 13 },
                    { 94, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2989), false, "طراحی و علامت گذاری جعبه فیوز", 1000000, 13 },
                    { 95, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2991), false, "سیستم اعلام و اطفاء جریق", 1000000, 13 },
                    { 96, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2992), false, "سیم کشی ارت", 1000000, 13 },
                    { 97, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2994), false, "هوشمندسازی ساختمان", 1000000, 13 },
                    { 98, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2996), false, "طراحی و اجرای فنس الکتریکی", 1000000, 13 },
                    { 99, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2998), false, "نصب و تعمیر راه بند", 1000000, 13 },
                    { 100, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3000), false, "نصب و سرویس پله برقی", 1000000, 13 },
                    { 101, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3002), false, "ساخت ، نصب و تعمیر کابینت", 1000000, 14 },
                    { 102, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3004), false, "نجاری", 1000000, 14 },
                    { 103, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3006), false, "تعمیرا مبلمان", 1000000, 14 },
                    { 104, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3008), false, "خدمات درب چوبی و ضدسرقت", 1000000, 14 },
                    { 105, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3009), false, "تعمیر و ساخت کمد دیواری", 1000000, 14 },
                    { 106, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3011), false, "شیشه بری و آینه کاری", 1000000, 14 },
                    { 107, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3013), false, "ساخت ، رگلاژ درب و پنجره آلمینیومی و UPVC", 1000000, 15 },
                    { 108, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3015), false, "شیشه ریلی و جام بالکن", 1000000, 15 },
                    { 109, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3018), false, "نصب و تعمیر درب اتوماتیک", 1000000, 15 },
                    { 110, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3020), false, "شیشه ریلی اسلاید", 1000000, 15 },
                    { 111, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3021), false, "ساخت کابین دوش", 1000000, 15 },
                    { 112, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3023), false, "باغبانی", 1000000, 16 },
                    { 113, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3025), false, "نگهداری از گیاهان آپارتمانی", 1000000, 16 },
                    { 114, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3027), false, "سمپاچی باغچه و فضای سبز", 1000000, 16 },
                    { 115, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3029), false, "مشاوره گل و گیاه", 1000000, 16 },
                    { 116, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3031), false, "طراحی و اجرای فضای سبز", 1000000, 16 },
                    { 117, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3033), false, "روف گاردن", 1000000, 16 },
                    { 118, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3035), false, "هرس درختان", 1000000, 16 },
                    { 120, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3036), false, "تعمیر کولر گازی و اسپلیت", 1000000, 4 },
                    { 122, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3038), false, "تعمیر و سرویس آبگرمکن", 1000000, 4 },
                    { 124, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3040), false, "نصب و تعمیر رادیاتور شوفاژ", 1000000, 4 },
                    { 125, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3042), false, "تعمیر و نگهداری موتورخانه", 1000000, 4 },
                    { 127, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3044), false, "نصب و سرویس فن کویل", 1000000, 4 },
                    { 128, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3046), false, "نصب و تعمیر بخاری و شومینه", 1000000, 4 },
                    { 129, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3048), false, "نصب و تعمیر VRF و DVR", 1000000, 4 },
                    { 130, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3049), false, "بهبود الاینده‌های موتورخانه با دستگاه آنالیز", 1000000, 4 },
                    { 131, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3051), false, "نصب و تعمیر یخچال و فریزر", 1000000, 5 },
                    { 132, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3054), false, "نصب و تعمیر ماشین لباسشویی", 1000000, 5 },
                    { 133, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3056), false, "نصب و تعمیر اجاق گاز", 1000000, 5 },
                    { 134, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3058), false, "نصب و تعمیر ماشین ظرفشویی", 1000000, 5 },
                    { 135, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3060), false, "تعمیرات تخصصی تلویزیون", 1000000, 5 },
                    { 136, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3062), false, "نصب تلویزیون و لوازم صوتی تصویری", 1000000, 5 },
                    { 137, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3063), false, "نصب و تعمیر مایکروویو و سولاردام", 1000000, 5 },
                    { 138, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3065), false, "نصب و تعمیر هود آشپزخانه", 1000000, 5 },
                    { 139, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3067), false, "نصب و تعمیر جاروبرقی", 1000000, 5 },
                    { 140, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3069), false, "نصب و تعمیر چرخ خیاطی", 1000000, 5 },
                    { 141, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3071), false, "نصب و تعمیر تردمیل", 1000000, 5 },
                    { 142, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3073), false, "تعمیر چایی ساز و قهوه ساز", 1000000, 5 },
                    { 143, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3075), false, "تعمیر دستگاه بخور", 1000000, 13 },
                    { 144, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3076), false, "تعمیر پنکه", 1000000, 5 },
                    { 145, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3078), false, "نصب و تعمیر فر", 1000000, 5 },
                    { 146, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3080), false, "تعمیر اتو", 1000000, 5 },
                    { 147, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3082), false, "تعمیر آبمیوه گیری و مخلوط کن", 1000000, 5 },
                    { 148, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3084), false, "تعمیر ساندبار و اسپیکر", 1000000, 5 },
                    { 149, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3085), false, "تعمیر کنسول بازی", 1000000, 5 },
                    { 150, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3087), false, "تعمیر بخارشور", 1000000, 5 },
                    { 151, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3090), false, "تعمیر غذاساز و خردکن", 1000000, 5 },
                    { 152, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3092), false, "تعمیرات ریش تراش و اپلیدی", 1000000, 5 },
                    { 153, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3094), false, "تعمیر سینمای خانگی", 1000000, 5 },
                    { 154, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3095), false, "تعمیر چرخ گوشت", 1000000, 5 },
                    { 155, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3097), false, "تعمیر رادیو و ضبط صوت", 1000000, 5 },
                    { 156, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3099), false, "تعمیر صندلی ماساژور", 1000000, 13 },
                    { 157, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3101), false, "تعمیر سرخ کن", 1000000, 5 },
                    { 158, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3103), false, "تعمیر بخارپز و پلوپز", 1000000, 5 },
                    { 159, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3104), false, "تعمیر سشوار", 1000000, 5 },
                    { 160, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3106), false, "تعمیر شوفاژ برقی", 1000000, 5 },
                    { 161, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3108), false, "ترمیم و بازسازی ظروف آشپزخانه", 1000000, 5 },
                    { 162, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3110), false, "تعمیر کامپیوتر و لپ تاپ", 1000000, 7 },
                    { 163, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3112), false, "تعمیر ماشین‌های اداری", 1000000, 7 },
                    { 164, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3113), false, "پشتیبانی شبکه و سرور", 1000000, 7 },
                    { 165, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3115), false, "مودم و اینترنت", 1000000, 7 },
                    { 166, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3117), false, "طراحی سایت و لوگو", 1000000, 7 },
                    { 167, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3119), false, "نصب و راه‌اندازی VoIP", 1000000, 7 },
                    { 168, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3121), false, "تعمیر دستگاه کارتخوان و بارکدخوان", 1000000, 7 },
                    { 169, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3122), false, "خدمات تاچ و ال سی دی", 1000000, 8 },
                    { 170, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3125), false, "خدمات باتری", 1000000, 8 },
                    { 171, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3127), false, "خدمات عیب‌یابی و تعمیر برد", 1000000, 8 },
                    { 172, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3129), false, "خدمات نرم افزاری", 1000000, 8 },
                    { 173, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3130), false, "مشاوره خرید موبایل و کالاهای دیجیتال", 1000000, 8 },
                    { 174, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3158), false, "خدمات اسپیکر", 1000000, 8 },
                    { 175, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3160), false, "خدمات فریم و قاب", 1000000, 8 },
                    { 176, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3162), false, "خدمات دوربین", 1000000, 8 },
                    { 177, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3164), false, "خدمات سنسور", 1000000, 8 },
                    { 178, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3166), false, "اسباب کشی با خاور و کامیون", 1000000, 17 },
                    { 179, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3168), false, "اسباب کشی و حمل بار بین شهری", 1000000, 17 },
                    { 180, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3169), false, "اسباب کشی با وانت و نیسان", 1000000, 17 },
                    { 181, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3171), false, "سرویس بسته بندی", 1000000, 17 },
                    { 182, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3173), false, "کارگر جا به جایی", 1000000, 17 },
                    { 183, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3175), false, "جا به جایی گاو صندوق", 1000000, 17 },
                    { 184, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3177), false, "حمل نخاله و ضایعات ساختمانی", 1000000, 17 },
                    { 185, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3178), false, "اسباب کشی شرکت ها و سازمان ها", 1000000, 17 },
                    { 186, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3180), false, "خرید ملزومات بسته بندی", 1000000, 17 },
                    { 187, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3182), false, "شارژ گاز کولر ماشین", 1000000, 18 },
                    { 188, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3184), false, "تعویض باتری خودرو", 1000000, 18 },
                    { 189, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3187), false, "امداد خودرو", 1000000, 18 },
                    { 190, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3189), false, "برق و باتری خودرو", 1000000, 18 },
                    { 191, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3191), false, "مکانیگی خودرو", 1000000, 18 },
                    { 192, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3192), false, "تست دیاگ و ریمپ ECU خودرو", 1000000, 18 },
                    { 193, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3194), false, "حمل خودرو", 1000000, 18 },
                    { 194, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3196), false, "تعویض روغن خودرو", 1000000, 18 },
                    { 195, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3198), false, "پنچرگیری و تعویض لاستیک", 1000000, 18 },
                    { 196, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3200), false, "کارشناسی خودرو", 1000000, 18 },
                    { 197, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3201), false, "تعویض لنت خودرو", 1000000, 18 },
                    { 198, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3203), false, "تعویض شمع و وایر خودرو", 1000000, 18 },
                    { 199, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3205), false, "کاهش مصرف سوخت", 1000000, 18 },
                    { 200, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3207), false, "سرویس دوره ای گیربکس اتوماتیک", 1000000, 18 },
                    { 201, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3209), false, "نصب GPS خودرو", 1000000, 18 },
                    { 202, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3210), false, "نصب دزدگیر خودرو", 1000000, 18 },
                    { 203, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3212), false, "سپرسازی و جوش پلاستیک", 1000000, 18 },
                    { 204, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3214), false, "تعویض شیشه خودرو", 1000000, 18 },
                    { 205, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3216), false, "تعمیر موتورسیکلت", 1000000, 18 },
                    { 206, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3218), false, "سوخت رسانی", 1000000, 18 },
                    { 207, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3219), false, "ساخت سوئیچ و ریموت خودرو در محل", 1000000, 18 },
                    { 208, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3223), false, "تعمیر و تعویض چراغ خودرو", 1000000, 18 },
                    { 209, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3225), false, "سرامیک خودرو", 1000000, 19 },
                    { 210, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3227), false, "کارواش نانو", 1000000, 19 },
                    { 211, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3229), false, "کارواش با آب", 1000000, 19 },
                    { 212, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3231), false, "واکس و پولیش خودرو", 1000000, 19 },
                    { 213, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3233), false, "صفرشویی خودرو", 1000000, 19 },
                    { 214, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3234), false, "موتورشویی خودرو", 1000000, 19 },
                    { 215, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3236), false, "پکیج کارواش VIP", 1000000, 19 },
                    { 216, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3238), false, "شفاف سازی چراغ خودرو", 1000000, 19 },
                    { 217, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3240), false, "احیای رنگ خودرو", 1000000, 19 },
                    { 218, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3242), false, "صافکاری و نقاشی خودرو", 1000000, 19 },
                    { 219, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3243), false, "نصب شیشه دودی خودرو در محل", 1000000, 19 },
                    { 220, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3245), false, "خدمات شرکتی ویژه شرکت ها کوچک و متوسط", 1000000, 20 },
                    { 221, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3247), false, "خدمات شرکتی ویژه سازمان های بزرگ", 1000000, 20 },
                    { 222, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3249), false, "خدمات ناخن", 1000000, 21 },
                    { 223, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3250), false, "خدمات ویژه ناخن", 1000000, 21 },
                    { 224, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3252), false, "اصلاح صورت و ابرو بانوان", 1000000, 21 },
                    { 225, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3254), false, "اپیلاسیون بانوان در خانه", 1000000, 21 },
                    { 226, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3256), false, "براشینگ مو بانوان", 1000000, 21 },
                    { 227, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3259), false, "رنگ مو بانوان", 1000000, 21 },
                    { 228, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3260), false, "مش ، لایت ، بالیاژ و آمبره بانوان", 1000000, 21 },
                    { 229, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3262), false, "لیفت و لمینت مژه و ابرو بانوان", 1000000, 21 },
                    { 230, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3264), false, "کاشت و اکستنشن مژه بانوان در خانه", 1000000, 21 },
                    { 231, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3268), false, "پاکسازی و لایه برداری پوست بانوان", 1000000, 21 },
                    { 232, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3269), false, "شینیون مو بانوان در خانه", 1000000, 21 },
                    { 233, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3271), false, "آرایش صورت بانوان در خانه", 1000000, 21 },
                    { 234, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3273), false, "بافت مو بانوان در خانه", 1000000, 21 },
                    { 235, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3275), false, "اکستنشن مو بانوان در خانه", 1000000, 21 },
                    { 236, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3276), false, "میکروپیمنتیشن و میکروبلیدینگ بانوان", 1000000, 21 },
                    { 237, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3278), false, "کوتاهی مو بانوان", 1000000, 21 },
                    { 238, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3280), false, "درمان سرپایی در محل", 1000000, 23 },
                    { 239, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3282), false, "تزریقات در منزل", 1000000, 23 },
                    { 240, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3284), false, "پرستاری و مراقبت بیمار", 1000000, 23 },
                    { 241, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3285), false, "پرستاری و مراقبت سالمند", 1000000, 23 },
                    { 242, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3287), false, "آزمایش و نمونه گیری در منزل", 1000000, 23 },
                    { 243, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3289), false, "ICU در منزل", 1000000, 23 },
                    { 244, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3291), false, "معاینه پزشکی", 1000000, 23 },
                    { 245, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3293), false, "فیزیوتراپی در منزل", 1000000, 23 },
                    { 246, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3294), false, "اصلاح سر و صورت آقایان", 1000000, 22 },
                    { 247, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3296), false, "سرویس ماهانه پیرایش اقایان", 1000000, 22 },
                    { 248, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3298), false, "خدمات ناخن آقایان", 1000000, 22 },
                    { 249, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3300), false, "مراقبت و زیبایی اقایان", 1000000, 22 },
                    { 250, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3301), false, "گریم داماد", 1000000, 22 },
                    { 251, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3303), false, "هتل های حیوانات خانگی", 1000000, 24 },
                    { 252, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3305), false, "خدمات دامپزشکی در محل", 1000000, 24 },
                    { 253, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3307), false, "خدمات تربیتی حیوانات خانگی", 1000000, 24 },
                    { 254, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3309), false, "خدمات شستشو و آرایش حیوانات خانگی", 1000000, 24 },
                    { 255, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3311), false, "پت شاپ", 1000000, 24 },
                    { 256, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3312), false, "کلاس سی ایکس در خانه", 1000000, 25 },
                    { 257, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3314), false, "برنامه ورزشی و تغذیه", 1000000, 25 },
                    { 258, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3316), false, "کلاس یوگا در خانه", 1000000, 25 },
                    { 259, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3318), false, "کلاس پیلاتس در خانه", 1000000, 25 },
                    { 260, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3320), false, "حرکات اصلاحی", 1000000, 25 },
                    { 261, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(3266), false, "کراتینه و ویتامینه مو بانوان", 1000000, 21 },
                    { 262, new DateTime(2024, 6, 20, 1, 9, 19, 72, DateTimeKind.Local).AddTicks(2801), false, "قالیشویی", 1000000, 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "DoneAt", "Image", "IsDeleted", "RequesteForTime", "ServiceId", "Status", "Title" },
                values: new object[] { 1, new DateTime(2024, 6, 20, 1, 9, 19, 70, DateTimeKind.Local).AddTicks(7119), 1, "نظافت خونه صد متری هب طور کامل", new DateTime(2024, 6, 20, 1, 9, 19, 70, DateTimeKind.Local).AddTicks(7123), null, false, new DateTime(2024, 6, 20, 1, 9, 19, 70, DateTimeKind.Local).AddTicks(7127), 1, 3, "نظافت" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ExpertId",
                table: "Addresses",
                column: "ExpertId",
                unique: true,
                filter: "[ExpertId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ApplicationUserId",
                table: "Admins",
                column: "ApplicationUserId",
                unique: true);

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
                name: "IX_Customers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experts_ApplicationUserId",
                table: "Experts",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpertService_ServicesId",
                table: "ExpertService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

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
                name: "Admins");

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
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ServiceSubCategories");

            migrationBuilder.DropTable(
                name: "ServiceCategories");
        }
    }
}
