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
                    BackUpPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    BankCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
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
                    SuggestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { 1, 0, "e5489d1a-479a-47ed-b983-7e1bba6278ce", "Zahrasarmadi17@gmail.com", false, false, null, "ZAHRASARMADI17@GMAIL.COM", "ZAHRASARMADI17@GMAIL.COM", "AQAAAAIAAYagAAAAEHarsVhcelM+k9+ybkEYVu5ONoax9vD0GxJ3d/NWaHpjbelmxBx9pkpXxwl6qohNDw==", "09927848276", false, "09bb7d81-21d6-498b-9c25-afe2adaf77ca", false, "Zahrasarmadi17@gmail.com" },
                    { 2, 0, "a34ff08d-48e1-4bbb-849c-56e542dae1f5", "Ali@gmail.com", false, false, null, "ALI@GMAIL.COM", "ALI@GMAIL.COM", "AQAAAAIAAYagAAAAEEwLqNXpvXLxSHkGH3Ogg67zHz2l8HhB+AukcvhZEjLjGyHEib786LwL/ACSDsZ6ig==", "09377507920", false, "453f40ee-999a-4b4c-a0f7-354e318c3cd3", false, "Ali@gmail.com" },
                    { 3, 0, "a8a8c201-2388-4112-9b77-7ee6d15c146c", "Sahar@gmail.com", false, false, null, "SAHAR@GMAIL.COM", "SAHAR@GMAIL.COM", "AQAAAAIAAYagAAAAELK/yKOTvgP7Qv00VrUcL6lD5P6jAxkZVBltGslGl4/Qiu8WhgCE0zRrKr+Os3W5IA==", "09377507920", false, "714ebc22-c601-4d24-9aad-376a72d711f4", false, "Sahar@gmail.com" },
                    { 4, 0, "82aab10a-530a-4f70-96bf-66f7d7ff586b", "Sara@gmail.com", false, false, null, "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAEIrA1qO8umJhagfV2nUxabRFmHMBXaHQTMc9dodcO7c9UavFOPnWiH0S5GZT7f9LJw==", "09377507920", false, "ea07a475-3f82-4a93-9ef0-b07a1a1daaf5", false, "Sara@gmail.com" },
                    { 5, 0, "32f1378d-b223-4f6d-b915-8f2d8e5e6663", "Mohammad@gmail.com", false, false, null, "MOHAMMAD@GMAIL.COM", "MOHAMMAD@GMAIL.COM", "AQAAAAIAAYagAAAAELvuIG6kuwgME8Lutx7yHZ0W6SLwvtTSml5Xi+0PtjBgeD1h9Eds1ijzOAt4E6FAuA==", "09377507920", false, "24daf68a-e89e-4e0c-bfc5-651bdefedb7c", false, "Mohammad@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(7968), "آذربایجان شرقی" },
                    { 2, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(7970), "آذربایجان غربی" },
                    { 3, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(7972), "اردبیل" },
                    { 4, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(7974), "اصفهان" },
                    { 5, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(7975), "البرز" },
                    { 6, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(7978), "ایلام" },
                    { 7, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(7979), "بوشهر" },
                    { 8, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(7981), "تهران" },
                    { 9, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(7982), "چهارمحال و بختیاری" },
                    { 10, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(7993), "خراسان جنوبی" },
                    { 11, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(7995), "خراسان رضوی" },
                    { 12, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8015), "خراسان شمالی" },
                    { 13, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8017), "خوزستان" },
                    { 14, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8018), "زنجان" },
                    { 15, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8020), "سمنان" },
                    { 16, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8021), "سیستان و بلوچستان" },
                    { 17, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8023), "فارس" },
                    { 18, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8024), "قزوین" },
                    { 19, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8026), "قم" },
                    { 20, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8027), "کردستان" },
                    { 21, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8029), "کرمان" },
                    { 22, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8030), "کرمانشاه" },
                    { 23, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8032), "کهگیلویه و بویراحمد" },
                    { 24, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8033), "گلستان" },
                    { 25, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8035), "گیلان" },
                    { 26, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8036), "لرستان" },
                    { 27, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8038), "مازندران" },
                    { 28, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8039), "مرکزی" },
                    { 29, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8041), "هرمزگان" },
                    { 30, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8042), "همدان" },
                    { 31, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(8044), "یزد" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(8150), "\\assets\\img\\category\\broom-solid.svg", false, "تمیزکاری" },
                    { 2, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(8153), "\\assets\\img\\category\\building-solid.svg", false, "ساختمان" },
                    { 3, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(8155), "\\assets\\img\\category\\screwdriver-wrench-solid.svg", false, "تعمیرات اشیاء" },
                    { 4, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(8157), "\\assets\\img\\category\\truck-moving-solid.svg", false, "اسباب کشی و حمل بار" },
                    { 5, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(8159), "\\assets\\img\\category\\car-solid.svg", false, "خودرو" },
                    { 6, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(8161), "\\assets\\img\\category\\building-flag-solid.svg", false, "سازمان ها و مجتمع ها" },
                    { 7, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(8163), "\\assets\\img\\category\\suitcase-medical-solid.svg", false, "سلامت و زیبایی" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "FirstName", "Gender", "IsDeleted", "LastName" },
                values: new object[] { 1, 1, new DateTime(2024, 5, 28, 11, 17, 47, 456, DateTimeKind.Local).AddTicks(4094), "زهرا", 1, false, "سرمدی" });

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
                columns: new[] { "Id", "ApplicationUserId", "BackUpPhoneNumber", "BankCardNumber", "CreatedAt", "FirstName", "Gender", "IsDeleted", "LastName" },
                values: new object[,]
                {
                    { 1, 3, "09123669858", "1234123412341234", new DateTime(2024, 5, 28, 11, 17, 47, 458, DateTimeKind.Local).AddTicks(6493), "سحر", 1, false, "محمودی" },
                    { 2, 5, "09123623258", "1239684412341234", new DateTime(2024, 5, 28, 11, 17, 47, 458, DateTimeKind.Local).AddTicks(6497), "محمد", 2, false, "اصغری" }
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "ApplicationUserId", "BankCardNumber", "BirthDate", "CreatedAt", "FirstName", "Gender", "IsConfrim", "IsDeleted", "LastName", "PhoneNumber", "ProfileImage" },
                values: new object[,]
                {
                    { 1, 2, "1234123412341234", new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(2032), "علی", 2, true, false, "آموزگار", "09362356998", null },
                    { 2, 4, "1234123412341255", new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(2038), "سارا", 2, true, false, "همتی", "09362357998", null }
                });

            migrationBuilder.InsertData(
                table: "ServiceSubCategories",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9583), "\\assets\\img\\sub-category\\tamiz-kari\\nezafat-pazirayi.webp", false, "نظافت و پذیرایی", 1 },
                    { 2, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9587), "\\assets\\img\\sub-category\\tamiz-kari\\shosteshu.webp", false, "شستشو", 1 },
                    { 3, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9589), "\\assets\\img\\sub-category\\tamiz-kari\\carwash.webp", false, "کارواش و دیتیلینگ", 1 },
                    { 4, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9591), "\\assets\\img\\sub-category\\tamirat\\sarmayesh-garmayesh.webp", false, "سرمایش و گرمایش", 3 },
                    { 5, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9593), "\\assets\\img\\sub-category\\tamirat\\tamir-lavazem-khanegi.webp", false, "نصب وتعمیر لوازم خانگی", 3 },
                    { 7, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9595), "\\assets\\img\\sub-category\\tamirat\\khadamat-computer.webp", false, "خذمات کامپیوتری", 3 },
                    { 8, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9597), "\\assets\\img\\sub-category\\tamirat\\tamirat-mobile.webp", false, "تعمیرات موبایل", 3 },
                    { 9, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9599), "\\assets\\img\\sub-category\\sakhtemen\\sarmayesh-garmayesh.webp", false, "سرمایش و گرمایش", 2 },
                    { 10, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9601), "\\assets\\img\\sub-category\\sakhtemen\\tamirat-sakhteman.webp", false, "تعمیرا ساختمان", 2 },
                    { 11, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9603), "\\assets\\img\\sub-category\\sakhtemen\\lule-keshi.webp", false, "لوله کشی", 2 },
                    { 12, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9605), "\\assets\\img\\sub-category\\sakhtemen\\tarahi-sakhtemen.webp", false, "طراحی و بازسازی ساختمان", 2 },
                    { 13, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9607), "\\assets\\img\\sub-category\\sakhtemen\\bargh-kari.webp", false, "برق کاری", 2 },
                    { 14, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9609), "\\assets\\img\\sub-category\\sakhtemen\\chub-cabinet.webp", false, "چوب و کابینت", 2 },
                    { 15, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9610), "\\assets\\img\\sub-category\\sakhtemen\\khadamat-shishei.webp", false, "خدمات شیشه ای ساختمان", 2 },
                    { 16, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9612), "\\assets\\img\\sub-category\\sakhtemen\\baghbani.webp", false, "باغبانی و فضای سبز", 2 },
                    { 17, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9614), "\\assets\\img\\sub-category\\barbari.webp", false, "باربری و جا به جایی", 4 },
                    { 18, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9616), "\\assets\\img\\sub-category\\khodro\\khdamet-khodro.webp", false, "خدمات و تعمیرات خودرو", 5 },
                    { 19, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9618), "\\assets\\img\\sub-category\\khodro\\carwash.webp", false, "کارواش و دیتیلینگ", 5 },
                    { 20, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9620), "\\assets\\img\\sub-category\\khadamat-sherkati.webp", false, "خدمات شرکتی", 6 },
                    { 21, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9622), "\\assets\\img\\sub-category\\salamat-zibayi\\zibayi-banovan.webp", false, "زیبایی بانوان", 7 },
                    { 22, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9624), "\\assets\\img\\sub-category\\salamat-zibayi\\zibayi-aghayan.webp", false, "پیرایش و زیبایی آقایان", 7 },
                    { 23, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9625), "\\assets\\img\\sub-category\\salamat-zibayi\\pezeshki.webp", false, "پزشکی و پرستاری", 7 },
                    { 24, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9627), "\\assets\\img\\sub-category\\salamat-zibayi\\pet.webp", false, "حیوانات خانگی", 7 },
                    { 25, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(9629), "\\assets\\img\\sub-category\\salamat-zibayi\\varzesh.webp", false, "تندرستی و ورزش", 7 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "ExpertId", "IsAccept", "IsDeleted", "Score", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 28, 11, 17, 47, 458, DateTimeKind.Local).AddTicks(2439), 1, "کارش عالی بود", 1, false, false, 4, "عالی" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name", "Price", "ServiceSubCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4755), null, false, "سرویس عادی نظافت", 700000, 1 },
                    { 2, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4758), null, false, "سرویس لوکس نظافت", 850000, 1 },
                    { 3, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4877), null, false, "سرویس ویژه نظافت", 1000000, 1 },
                    { 4, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4880), null, false, "سرویس ویژه نظافت", 1000000, 1 },
                    { 5, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4883), null, false, "نظافت راه‌پله", 1000000, 1 },
                    { 6, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4886), null, false, "سرویس نظافت فوری", 1000000, 1 },
                    { 7, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4888), null, false, "پذیرایی", 1000000, 1 },
                    { 8, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4890), null, false, "کارگر ساده", 1000000, 1 },
                    { 9, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4894), null, false, "سمپاشی فضای داخلی", 1000000, 1 },
                    { 10, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4896), null, false, "ضدعفونی منزل و محل کار", 1000000, 1 },
                    { 11, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4901), null, false, "شستشوی مبل ،فرش و موکت در محل", 1000000, 2 },
                    { 12, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4905), null, false, "خشکشویی", 1000000, 2 },
                    { 13, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4907), null, false, "پرده شویی", 1000000, 2 },
                    { 14, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4909), null, false, "سرامیک خودرو", 1000000, 3 },
                    { 15, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4911), null, false, "کارواش نانو", 1000000, 3 },
                    { 16, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4913), null, false, "کارواش با آب", 1000000, 3 },
                    { 17, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4915), null, false, "واکس و پولیش خودرو", 1000000, 3 },
                    { 18, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4916), null, false, "صفرشویی خودرو", 1000000, 3 },
                    { 19, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4918), null, false, "موتورشویی خودرو", 1000000, 3 },
                    { 20, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4920), null, false, "پکیج کارواش VIP", 1000000, 3 },
                    { 21, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4922), null, false, "شفاف سازی چراغ خودرو", 1000000, 3 },
                    { 22, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4924), null, false, "احیای رنگ خودرو", 1000000, 3 },
                    { 23, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4926), null, false, "صافکاری و نقاشی خودرو", 1000000, 3 },
                    { 24, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4928), null, false, "نصب شیشه دودی خودرو در محل", 1000000, 3 },
                    { 25, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4930), null, false, "تعمیر و سرویس کولر آبی", 1000000, 9 },
                    { 26, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4932), null, false, "تعمیر کولر گازی و داکت اسپلیت", 1000000, 9 },
                    { 27, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5091), null, false, "تعمیر و سرویس پکیج", 1000000, 9 },
                    { 28, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5095), null, false, "تعمیر و سرویس ابگرمکن", 1000000, 9 },
                    { 29, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5097), null, false, "کانال سازی کولر", 1000000, 9 },
                    { 30, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5099), null, false, "نصب و تعمیر رادیاتور شوفاژ", 1000000, 9 },
                    { 31, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5101), null, false, "تعمیر و نگهداری موتورخانه", 1000000, 9 },
                    { 32, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5102), null, false, "سرویس و تعمیر چیلر", 1000000, 9 },
                    { 33, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5104), null, false, "تعمیر و سرویس فن کویل", 1000000, 9 },
                    { 34, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5106), null, false, "نصب و تعمیر بخاری گازی و شومینه", 1000000, 9 },
                    { 35, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5108), null, false, "نصب و تعمیر VRF و DVR", 1000000, 9 },
                    { 36, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5110), null, false, "بهبود آلاینده‌های موتورخانه با دستگاه آنالیز", 1000000, 9 },
                    { 37, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5112), null, false, "ساخت و نصب توری", 1000000, 10 },
                    { 38, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5113), null, false, "جوشکاری و آهنگری ، درب و پنجره آهنی", 1000000, 10 },
                    { 39, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5115), null, false, "دوخت و نصب پرده", 1000000, 10 },
                    { 40, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5117), null, false, "کاشی کاری و سرامیک", 1000000, 10 },
                    { 41, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5119), null, false, "بنایی", 1000000, 10 },
                    { 42, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5121), null, false, "کلید سازی", 1000000, 10 },
                    { 43, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5122), null, false, "نصب و تعمیر انواع کفپوش و دیوارپوش", 1000000, 10 },
                    { 44, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5124), null, false, "کچ کاری و رابیتس کاری", 1000000, 10 },
                    { 45, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5126), null, false, "آچار فرانسه", 1000000, 10 },
                    { 46, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5129), null, false, "دریل کاری", 1000000, 10 },
                    { 47, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5131), null, false, "نصب ایزوگام ، قیرگونی و آسفالت", 1000000, 10 },
                    { 48, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5133), null, false, "تعمیرات نما و نماشویی", 1000000, 10 },
                    { 49, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5134), null, false, "کفسابی", 1000000, 10 },
                    { 50, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5136), null, false, "تخریب", 1000000, 10 },
                    { 51, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5138), null, false, "سقف و دیوار PVC و اسمان مجازی", 1000000, 10 },
                    { 52, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5140), null, false, "شیروانی و ایرانیت", 1000000, 10 },
                    { 53, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5142), null, false, "تعمیر و نگهداری استخر", 1000000, 10 },
                    { 54, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5143), null, false, "کپسول آتش‌ نشانی", 1000000, 10 },
                    { 55, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5145), null, false, "کناف کاری", 1000000, 10 },
                    { 56, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5147), null, false, "نصب و تعمیر شیرآلات", 1000000, 11 },
                    { 57, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5149), null, false, "تخلیه چاه و لوله بازکنی", 1000000, 11 },
                    { 58, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5150), null, false, "لوله کشی آب و فاضلاب", 1000000, 11 },
                    { 59, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5152), null, false, "نصب و سرویس توالت فرنگی و ایرانی", 1000000, 11 },
                    { 60, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5154), null, false, "تشخیص و ترمیم ترکیدگی لوله", 1000000, 11 },
                    { 61, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5156), null, false, "پمپ و منبع آب", 1000000, 11 },
                    { 62, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5158), null, false, "نصب و تعمیر دستگاه تصفیه آب", 1000000, 11 },
                    { 63, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5160), null, false, "نصب و تعمیر فلاش تانک و سیفون", 1000000, 11 },
                    { 64, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5161), null, false, "لوله کشی گاز", 1000000, 11 },
                    { 65, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5164), null, false, "نصب سینک ظرفشویی", 1000000, 11 },
                    { 66, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5167), null, false, "نصب روشویی", 1000000, 11 },
                    { 67, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5168), null, false, "نصب و تعمیر وال هنگ", 1000000, 11 },
                    { 68, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5170), null, false, "اتصال به شبکه فاضلاب شهری", 1000000, 11 },
                    { 69, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5172), null, false, "مشاوره و بازسازی ساختمان", 1000000, 12 },
                    { 70, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5174), null, false, "دکوراسیون و طراحی ساختمان", 1000000, 12 },
                    { 71, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5175), null, false, "رفع اتصالی", 1000000, 13 },
                    { 72, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5177), null, false, "نصب و تعمیر آیفون صوتی و تصویری", 1000000, 13 },
                    { 73, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5179), null, false, "نصب لوستر و چراغ", 1000000, 13 },
                    { 74, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5181), null, false, "سیم کشی تلفن و نصب سانترال", 1000000, 13 },
                    { 75, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5183), null, false, "نصب و تعمیر آنتن تلویزیون", 1000000, 13 },
                    { 76, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5184), null, false, "نصب و تعمیر دوربین مداربسته", 1000000, 13 },
                    { 77, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5186), null, false, "کلید و پریز", 1000000, 13 },
                    { 78, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5188), null, false, "تعمیر و سرویس آسانسور", 1000000, 13 },
                    { 79, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5190), null, false, "نصب و تعمیر کرکره برقی", 1000000, 13 },
                    { 80, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5192), null, false, "نصب و تعمیر جک پارکینگ و آرام بند", 1000000, 13 },
                    { 81, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5193), null, false, "هواکش و تهویه مطبوع", 1000000, 13 },
                    { 82, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5195), null, false, "ساخت و تعمیر تابلو روان و چلنیوم", 1000000, 13 },
                    { 83, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5197), null, false, "نصب و تعمیر بالابر", 1000000, 13 },
                    { 84, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5200), null, false, "نصب و تعمیر دزدگیر اماکن", 1000000, 13 },
                    { 85, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5202), null, false, "سیم پیجی", 1000000, 13 },
                    { 86, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5203), null, false, "خدمات برق صنعتی و سه فاز", 1000000, 13 },
                    { 87, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5205), null, false, "نصب سنسور و تایمر", 1000000, 13 },
                    { 88, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5207), null, false, "نصب محافظ برق و استابلایزر", 1000000, 13 },
                    { 89, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5209), null, false, "ساهت و تعمیر تابلو برق", 1000000, 13 },
                    { 90, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5210), null, false, "طراحی و اجرای نور مخفی", 1000000, 13 },
                    { 91, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5212), null, false, "نصب داکت و ترانکینگ", 1000000, 13 },
                    { 92, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5214), null, false, "نصب و تعمیر زنراتور و برق اضطراری", 1000000, 13 },
                    { 93, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5216), null, false, "نصب و تعمیر اگزاست‌فن و سانتریفیوژ", 1000000, 13 },
                    { 94, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5217), null, false, "طراحی و علامت گذاری جعبه فیوز", 1000000, 13 },
                    { 95, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5219), null, false, "سیستم اعلام و اطفاء جریق", 1000000, 13 },
                    { 96, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5221), null, false, "سیم کشی ارت", 1000000, 13 },
                    { 97, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5223), null, false, "هوشمندسازی ساختمان", 1000000, 13 },
                    { 98, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5224), null, false, "طراحی و اجرای فنس الکتریکی", 1000000, 13 },
                    { 99, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5226), null, false, "نصب و تعمیر راه بند", 1000000, 13 },
                    { 100, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5228), null, false, "نصب و سرویس پله برقی", 1000000, 13 },
                    { 101, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5230), null, false, "ساخت ، نصب و تعمیر کابینت", 1000000, 14 },
                    { 102, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5231), null, false, "نجاری", 1000000, 14 },
                    { 103, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5234), null, false, "تعمیرا مبلمان", 1000000, 14 },
                    { 104, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5236), null, false, "خدمات درب چوبی و ضدسرقت", 1000000, 14 },
                    { 105, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5268), null, false, "تعمیر و ساخت کمد دیواری", 1000000, 14 },
                    { 106, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5270), null, false, "شیشه بری و آینه کاری", 1000000, 14 },
                    { 107, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5272), null, false, "ساخت ، رگلاژ درب و پنجره آلمینیومی و UPVC", 1000000, 15 },
                    { 108, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5274), null, false, "شیشه ریلی و جام بالکن", 1000000, 15 },
                    { 109, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5276), null, false, "نصب و تعمیر درب اتوماتیک", 1000000, 15 },
                    { 110, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5278), null, false, "شیشه ریلی اسلاید", 1000000, 15 },
                    { 111, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5280), null, false, "ساخت کابین دوش", 1000000, 15 },
                    { 112, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5282), null, false, "باغبانی", 1000000, 16 },
                    { 113, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5284), null, false, "نگهداری از گیاهان آپارتمانی", 1000000, 16 },
                    { 114, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5286), null, false, "سمپاچی باغچه و فضای سبز", 1000000, 16 },
                    { 115, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5287), null, false, "مشاوره گل و گیاه", 1000000, 16 },
                    { 116, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5289), null, false, "طراحی و اجرای فضای سبز", 1000000, 16 },
                    { 117, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5291), null, false, "روف گاردن", 1000000, 16 },
                    { 118, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5293), null, false, "هرس درختان", 1000000, 16 },
                    { 119, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5295), null, false, "تعمیر و سرویس کولر آبی", 1000000, 4 },
                    { 120, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5297), null, false, "تعمیر کولر گازی و اسپلیت", 1000000, 4 },
                    { 121, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5298), null, false, "تعمیر و سرویس پکیج", 1000000, 4 },
                    { 122, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5301), null, false, "تعمیر و سرویس آبگرمکن", 1000000, 4 },
                    { 123, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5303), null, false, "کانال سازی کولر", 1000000, 4 },
                    { 124, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5305), null, false, "نصب و تعمیر رادیاتور شوفاژ", 1000000, 4 },
                    { 125, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5307), null, false, "تعمیر و نگهداری موتورخانه", 1000000, 4 },
                    { 126, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5308), null, false, "سرویس و تعمیر چیلر", 1000000, 4 },
                    { 127, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5310), null, false, "نصب و سرویس فن کویل", 1000000, 4 },
                    { 128, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5312), null, false, "نصب و تعمیر بخاری و شومینه", 1000000, 4 },
                    { 129, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5314), null, false, "نصب و تعمیر VRF و DVR", 1000000, 4 },
                    { 130, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5316), null, false, "بهبود الاینده‌های موتورخانه با دستگاه آنالیز", 1000000, 4 },
                    { 131, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5317), null, false, "نصب و تعمیر یخچال و فریزر", 1000000, 5 },
                    { 132, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5319), null, false, "نصب و تعمیر ماشین لباسشویی", 1000000, 5 },
                    { 133, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5321), null, false, "نصب و تعمیر اجاق گاز", 1000000, 5 },
                    { 134, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5323), null, false, "نصب و تعمیر ماشین ظرفشویی", 1000000, 5 },
                    { 135, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5325), null, false, "تعمیرات تخصصی تلویزیون", 1000000, 5 },
                    { 136, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5327), null, false, "نصب تلویزیون و لوازم صوتی تصویری", 1000000, 5 },
                    { 137, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5328), null, false, "نصب و تعمیر مایکروویو و سولاردام", 1000000, 5 },
                    { 138, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5330), null, false, "نصب و تعمیر هود آشپزخانه", 1000000, 5 },
                    { 139, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5332), null, false, "نصب و تعمیر جاروبرقی", 1000000, 5 },
                    { 140, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5334), null, false, "نصب و تعمیر چرخ خیاطی", 1000000, 5 },
                    { 141, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5337), null, false, "نصب و تعمیر تردمیل", 1000000, 5 },
                    { 142, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5338), null, false, "تعمیر چایی ساز و قهوه ساز", 1000000, 5 },
                    { 143, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5340), null, false, "تعمیر دستگاه بخور", 1000000, 13 },
                    { 144, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5342), null, false, "تعمیر پنکه", 1000000, 5 },
                    { 145, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5344), null, false, "نصب و تعمیر فر", 1000000, 5 },
                    { 146, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5345), null, false, "تعمیر اتو", 1000000, 5 },
                    { 147, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5347), null, false, "تعمیر آبمیوه گیری و مخلوط کن", 1000000, 5 },
                    { 148, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5349), null, false, "تعمیر ساندبار و اسپیکر", 1000000, 5 },
                    { 149, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5351), null, false, "تعمیر کنسول بازی", 1000000, 5 },
                    { 150, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5353), null, false, "تعمیر بخارشور", 1000000, 5 },
                    { 151, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5355), null, false, "تعمیر غذاساز و خردکن", 1000000, 5 },
                    { 152, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5356), null, false, "تعمیرات ریش تراش و اپلیدی", 1000000, 5 },
                    { 153, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5358), null, false, "تعمیر سینمای خانگی", 1000000, 5 },
                    { 154, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5360), null, false, "تعمیر چرخ گوشت", 1000000, 5 },
                    { 155, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5362), null, false, "تعمیر رادیو و ضبط صوت", 1000000, 5 },
                    { 156, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5364), null, false, "تعمیر صندلی ماساژور", 1000000, 13 },
                    { 157, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5365), null, false, "تعمیر سرخ کن", 1000000, 5 },
                    { 158, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5367), null, false, "تعمیر بخارپز و پلوپز", 1000000, 5 },
                    { 159, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5369), null, false, "تعمیر سشوار", 1000000, 5 },
                    { 160, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5372), null, false, "تعمیر شوفاژ برقی", 1000000, 5 },
                    { 161, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5374), null, false, "ترمیم و بازسازی ظروف آشپزخانه", 1000000, 5 },
                    { 162, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5375), null, false, "تعمیر کامپیوتر و لپ تاپ", 1000000, 7 },
                    { 163, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5377), null, false, "تعمیر ماشین‌های اداری", 1000000, 7 },
                    { 164, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5379), null, false, "پشتیبانی شبکه و سرور", 1000000, 7 },
                    { 165, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5380), null, false, "مودم و اینترنت", 1000000, 7 },
                    { 166, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5382), null, false, "طراحی سایت و لوگو", 1000000, 7 },
                    { 167, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5384), null, false, "نصب و راه‌اندازی VoIP", 1000000, 7 },
                    { 168, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5386), null, false, "تعمیر دستگاه کارتخوان و بارکدخوان", 1000000, 7 },
                    { 169, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5388), null, false, "خدمات تاچ و ال سی دی", 1000000, 8 },
                    { 170, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5390), null, false, "خدمات باتری", 1000000, 8 },
                    { 171, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5391), null, false, "خدمات عیب‌یابی و تعمیر برد", 1000000, 8 },
                    { 172, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5393), null, false, "خدمات نرم افزاری", 1000000, 8 },
                    { 173, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5395), null, false, "مشاوره خرید موبایل و کالاهای دیجیتال", 1000000, 8 },
                    { 174, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5397), null, false, "خدمات اسپیکر", 1000000, 8 },
                    { 175, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5398), null, false, "خدمات فریم و قاب", 1000000, 8 },
                    { 176, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5400), null, false, "خدمات دوربین", 1000000, 8 },
                    { 177, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5402), null, false, "خدمات سنسور", 1000000, 8 },
                    { 178, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5404), null, false, "اسباب کشی با خاور و کامیون", 1000000, 17 },
                    { 179, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5406), null, false, "اسباب کشی و حمل بار بین شهری", 1000000, 17 },
                    { 180, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5408), null, false, "اسباب کشی با وانت و نیسان", 1000000, 17 },
                    { 181, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5410), null, false, "سرویس بسته بندی", 1000000, 17 },
                    { 182, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5412), null, false, "کارگر جا به جایی", 1000000, 17 },
                    { 183, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5413), null, false, "جا به جایی گاو صندوق", 1000000, 17 },
                    { 184, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5415), null, false, "حمل نخاله و ضایعات ساختمانی", 1000000, 17 },
                    { 185, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5417), null, false, "اسباب کشی شرکت ها و سازمان ها", 1000000, 17 },
                    { 186, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5419), null, false, "خرید ملزومات بسته بندی", 1000000, 17 },
                    { 187, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5420), null, false, "شارژ گاز کولر ماشین", 1000000, 18 },
                    { 188, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5422), null, false, "تعویض باتری خودرو", 1000000, 18 },
                    { 189, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5424), null, false, "امداد خودرو", 1000000, 18 },
                    { 190, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5426), null, false, "برق و باتری خودرو", 1000000, 18 },
                    { 191, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5428), null, false, "مکانیگی خودرو", 1000000, 18 },
                    { 192, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5429), null, false, "تست دیاگ و ریمپ ECU خودرو", 1000000, 18 },
                    { 193, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5431), null, false, "حمل خودرو", 1000000, 18 },
                    { 194, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5433), null, false, "تعویض روغن خودرو", 1000000, 18 },
                    { 195, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5435), null, false, "پنچرگیری و تعویض لاستیک", 1000000, 18 },
                    { 196, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5437), null, false, "کارشناسی خودرو", 1000000, 18 },
                    { 197, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5438), null, false, "تعویض لنت خودرو", 1000000, 18 },
                    { 198, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5441), null, false, "تعویض شمع و وایر خودرو", 1000000, 18 },
                    { 199, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5443), null, false, "کاهش مصرف سوخت", 1000000, 18 },
                    { 200, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5445), null, false, "سرویس دوره ای گیربکس اتوماتیک", 1000000, 18 },
                    { 201, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5447), null, false, "نصب GPS خودرو", 1000000, 18 },
                    { 202, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5448), null, false, "نصب دزدگیر خودرو", 1000000, 18 },
                    { 203, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5450), null, false, "سپرسازی و جوش پلاستیک", 1000000, 18 },
                    { 204, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5531), null, false, "تعویض شیشه خودرو", 1000000, 18 },
                    { 205, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5533), null, false, "تعمیر موتورسیکلت", 1000000, 18 },
                    { 206, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5535), null, false, "سوخت رسانی", 1000000, 18 },
                    { 207, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5537), null, false, "ساخت سوئیچ و ریموت خودرو در محل", 1000000, 18 },
                    { 208, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5538), null, false, "تعمیر و تعویض چراغ خودرو", 1000000, 18 },
                    { 209, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5540), null, false, "سرامیک خودرو", 1000000, 19 },
                    { 210, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5542), null, false, "کارواش نانو", 1000000, 19 },
                    { 211, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5544), null, false, "کارواش با آب", 1000000, 19 },
                    { 212, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5546), null, false, "واکس و پولیش خودرو", 1000000, 19 },
                    { 213, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5547), null, false, "صفرشویی خودرو", 1000000, 19 },
                    { 214, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5549), null, false, "موتورشویی خودرو", 1000000, 19 },
                    { 215, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5551), null, false, "پکیج کارواش VIP", 1000000, 19 },
                    { 216, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5553), null, false, "شفاف سازی چراغ خودرو", 1000000, 19 },
                    { 217, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5556), null, false, "احیای رنگ خودرو", 1000000, 19 },
                    { 218, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5558), null, false, "صافکاری و نقاشی خودرو", 1000000, 19 },
                    { 219, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5560), null, false, "نصب شیشه دودی خودرو در محل", 1000000, 19 },
                    { 220, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5562), null, false, "خدمات شرکتی ویژه شرکت ها کوچک و متوسط", 1000000, 20 },
                    { 221, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5564), null, false, "خدمات شرکتی ویژه سازمان های بزرگ", 1000000, 20 },
                    { 222, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5565), null, false, "خدمات ناخن", 1000000, 21 },
                    { 223, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5567), null, false, "خدمات ویژه ناخن", 1000000, 21 },
                    { 224, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5569), null, false, "اصلاح صورت و ابرو بانوان", 1000000, 21 },
                    { 225, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5571), null, false, "اپیلاسیون بانوان در خانه", 1000000, 21 },
                    { 226, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5573), null, false, "براشینگ مو بانوان", 1000000, 21 },
                    { 227, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5575), null, false, "رنگ مو بانوان", 1000000, 21 },
                    { 228, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5576), null, false, "مش ، لایت ، بالیاژ و آمبره بانوان", 1000000, 21 },
                    { 229, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5578), null, false, "لیفت و لمینت مژه و ابرو بانوان", 1000000, 21 },
                    { 230, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5580), null, false, "کاشت و اکستنشن مژه بانوان در خانه", 1000000, 21 },
                    { 231, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5584), null, false, "پاکسازی و لایه برداری پوست بانوان", 1000000, 21 },
                    { 232, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5586), null, false, "شینیون مو بانوان در خانه", 1000000, 21 },
                    { 233, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5588), null, false, "آرایش صورت بانوان در خانه", 1000000, 21 },
                    { 234, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5589), null, false, "بافت مو بانوان در خانه", 1000000, 21 },
                    { 235, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5592), null, false, "اکستنشن مو بانوان در خانه", 1000000, 21 },
                    { 236, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5594), null, false, "میکروپیمنتیشن و میکروبلیدینگ بانوان", 1000000, 21 },
                    { 237, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5596), null, false, "کوتاهی مو بانوان", 1000000, 21 },
                    { 238, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5598), null, false, "درمان سرپایی در محل", 1000000, 23 },
                    { 239, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5599), null, false, "تزریقات در منزل", 1000000, 23 },
                    { 240, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5601), null, false, "پرستاری و مراقبت بیمار", 1000000, 23 },
                    { 241, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5603), null, false, "پرستاری و مراقبت سالمند", 1000000, 23 },
                    { 242, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5605), null, false, "آزمایش و نمونه گیری در منزل", 1000000, 23 },
                    { 243, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5606), null, false, "ICU در منزل", 1000000, 23 },
                    { 244, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5608), null, false, "معاینه پزشکی", 1000000, 23 },
                    { 245, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5610), null, false, "فیزیوتراپی در منزل", 1000000, 23 },
                    { 246, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5612), null, false, "اصلاح سر و صورت آقایان", 1000000, 22 },
                    { 247, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5614), null, false, "سرویس ماهانه پیرایش اقایان", 1000000, 22 },
                    { 248, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5615), null, false, "خدمات ناخن آقایان", 1000000, 22 },
                    { 249, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5617), null, false, "مراقبت و زیبایی اقایان", 1000000, 22 },
                    { 250, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5619), null, false, "گریم داماد", 1000000, 22 },
                    { 251, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5621), null, false, "هتل های حیوانات خانگی", 1000000, 24 },
                    { 252, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5623), null, false, "خدمات دامپزشکی در محل", 1000000, 24 },
                    { 253, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5625), null, false, "خدمات تربیتی حیوانات خانگی", 1000000, 24 },
                    { 254, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5627), null, false, "خدمات شستشو و آرایش حیوانات خانگی", 1000000, 24 },
                    { 255, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5629), null, false, "پت شاپ", 1000000, 24 },
                    { 256, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5631), null, false, "کلاس سی ایکس در خانه", 1000000, 25 },
                    { 257, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5632), null, false, "برنامه ورزشی و تغذیه", 1000000, 25 },
                    { 258, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5634), null, false, "کلاس یوگا در خانه", 1000000, 25 },
                    { 259, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5636), null, false, "کلاس پیلاتس در خانه", 1000000, 25 },
                    { 260, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5638), null, false, "حرکات اصلاحی", 1000000, 25 },
                    { 261, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(5582), null, false, "کراتینه و ویتامینه مو بانوان", 1000000, 21 },
                    { 262, new DateTime(2024, 5, 28, 11, 17, 47, 459, DateTimeKind.Local).AddTicks(4903), null, false, "قالیشویی", 1000000, 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "DoneAt", "ExpertId", "Image", "IsDeleted", "RequesteForTime", "ServiceId", "Status", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(4494), 1, "نظافت خونه صد متری هب طور کامل", new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(4498), 1, null, false, new DateTime(2024, 5, 28, 11, 17, 47, 457, DateTimeKind.Local).AddTicks(4502), 1, 3, "نظافت" });

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
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Experts");

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
