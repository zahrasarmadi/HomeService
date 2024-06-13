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
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    { 1, 0, "5e0c2203-b431-4232-87a3-79ee57596fc2", "Zahrasarmadi17@gmail.com", false, false, null, "ZAHRASARMADI17@GMAIL.COM", "ZAHRASARMADI17@GMAIL.COM", "AQAAAAIAAYagAAAAEN+McVXljt07Dr2txuWltxHCnPPen3eYnblttBPSWTo734WYGPfE3GbAXxLD2Tl7lA==", "09927848276", false, "fdb417b4-ef26-4693-8d63-8c6161b2b363", false, "Zahrasarmadi17@gmail.com" },
                    { 2, 0, "95e417a7-4dba-424f-8665-ddbff9de6e94", "Ali@gmail.com", false, false, null, "ALI@GMAIL.COM", "ALI@GMAIL.COM", "AQAAAAIAAYagAAAAEI4DnS3YUEAzACLXfUlWO+dRCG3OH54LkMYbvK8YfEh02ID6intbR7hq5Coj4Mvjmg==", "09377507920", false, "d142f3fd-906d-452e-8f61-b7246de85039", false, "Ali@gmail.com" },
                    { 3, 0, "696279f5-7d22-4910-b3bb-494932bbc002", "Sahar@gmail.com", false, false, null, "SAHAR@GMAIL.COM", "SAHAR@GMAIL.COM", "AQAAAAIAAYagAAAAEO2P1ODsZoTHph34BIaTIMM0iEmUUsAIzpVFLc73bPSyLbB7fpulP36oF/xWnK4qXQ==", "09377507920", false, "28c1f7f7-bc02-4d4c-ba9b-fd5793abc3f0", false, "Sahar@gmail.com" },
                    { 4, 0, "2d8d4b89-c429-4245-b762-5a83e10ebbc2", "Sara@gmail.com", false, false, null, "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAELU7S8GhuHrXQjhsUJ3LN4HKd0iK/IQ0VDqrrFvMBpew5qd3QJuyrLvSJaAMkAyPXw==", "09377507920", false, "a53cc90a-45d3-4a3b-920a-fd5b5f7d455d", false, "Sara@gmail.com" },
                    { 5, 0, "4a7b4397-6479-4e1a-8f21-7e3891a86e56", "Mohammad@gmail.com", false, false, null, "MOHAMMAD@GMAIL.COM", "MOHAMMAD@GMAIL.COM", "AQAAAAIAAYagAAAAEJ8cCKckLi1QvTtqonx43r8+0kDxXjsCHk3qiXeB9slu5aMRMvglyPeY1R2VpIEUfw==", "09377507920", false, "a21db275-0aee-4b93-87ac-a64c43443e65", false, "Mohammad@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1621), "آذربایجان شرقی" },
                    { 2, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1624), "آذربایجان غربی" },
                    { 3, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1626), "اردبیل" },
                    { 4, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1627), "اصفهان" },
                    { 5, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1629), "البرز" },
                    { 6, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1631), "ایلام" },
                    { 7, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1632), "بوشهر" },
                    { 8, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1634), "تهران" },
                    { 9, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1635), "چهارمحال و بختیاری" },
                    { 10, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1646), "خراسان جنوبی" },
                    { 11, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1648), "خراسان رضوی" },
                    { 12, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1668), "خراسان شمالی" },
                    { 13, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1669), "خوزستان" },
                    { 14, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1671), "زنجان" },
                    { 15, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1672), "سمنان" },
                    { 16, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1674), "سیستان و بلوچستان" },
                    { 17, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1675), "فارس" },
                    { 18, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1677), "قزوین" },
                    { 19, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1678), "قم" },
                    { 20, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1680), "کردستان" },
                    { 21, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1681), "کرمان" },
                    { 22, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1683), "کرمانشاه" },
                    { 23, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1684), "کهگیلویه و بویراحمد" },
                    { 24, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1686), "گلستان" },
                    { 25, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1687), "گیلان" },
                    { 26, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1689), "لرستان" },
                    { 27, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1690), "مازندران" },
                    { 28, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1692), "مرکزی" },
                    { 29, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1693), "هرمزگان" },
                    { 30, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1695), "همدان" },
                    { 31, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(1697), "یزد" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(9149), "\\assets\\img\\category\\broom-solid.svg", false, "تمیزکاری" },
                    { 2, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(9154), "\\assets\\img\\category\\building-solid.svg", false, "ساختمان" },
                    { 3, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(9156), "\\assets\\img\\category\\screwdriver-wrench-solid.svg", false, "تعمیرات اشیاء" },
                    { 4, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(9158), "\\assets\\img\\category\\truck-moving-solid.svg", false, "اسباب‌کشی و حمل بار" },
                    { 5, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(9160), "\\assets\\img\\category\\car-solid.svg", false, "خودرو" },
                    { 6, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(9162), "\\assets\\img\\category\\building-flag-solid.svg", false, "سازمان‌ها و مجتمع‌ها" },
                    { 7, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(9164), "\\assets\\img\\category\\suitcase-medical-solid.svg", false, "سلامت و زیبایی" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "FirstName", "Gender", "IsDeleted", "LastName" },
                values: new object[] { 1, 1, new DateTime(2024, 6, 12, 22, 47, 42, 966, DateTimeKind.Local).AddTicks(1265), "زهرا", 1, false, "سرمدی" });

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
                    { 1, 3, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(7551), "سحر", 1, false, "محمودی", "09123669858" },
                    { 2, 5, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(7554), "محمد", 2, false, "اصغری", "09123623258" }
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "ApplicationUserId", "BirthDate", "CreatedAt", "FirstName", "Gender", "IsConfrim", "IsDeleted", "LastName", "PhoneNumber", "ProfileImage" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(3188), "علی", 2, true, false, "آموزگار", "09362356998", null },
                    { 2, 4, new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(3193), "سارا", 2, true, false, "همتی", "09362357998", null }
                });

            migrationBuilder.InsertData(
                table: "ServiceSubCategories",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(882), "\\assets\\img\\sub-category\\tamiz-kari\\nezafat-pazirayi.webp", false, "نظافت و پذیرایی", 1 },
                    { 2, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(888), "\\assets\\img\\sub-category\\tamiz-kari\\shosteshu.webp", false, "شستشو", 1 },
                    { 3, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(890), "\\assets\\img\\sub-category\\tamiz-kari\\carwash.webp", false, "کارواش و دیتیلینگ", 1 },
                    { 4, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(892), "\\assets\\img\\sub-category\\tamirat\\sarmayesh-garmayesh.webp", false, "سرمایش و گرمایش", 3 },
                    { 5, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(894), "\\assets\\img\\sub-category\\tamirat\\tamir-lavazem-khanegi.webp", false, "نصب وتعمیر لوازم خانگی", 3 },
                    { 7, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(896), "\\assets\\img\\sub-category\\tamirat\\khadamat-computer.webp", false, "خذمات کامپیوتری", 3 },
                    { 8, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(898), "\\assets\\img\\sub-category\\tamirat\\tamirat-mobile.webp", false, "تعمیرات موبایل", 3 },
                    { 9, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(900), "\\assets\\img\\sub-category\\sakhtemen\\sarmayesh-garmayesh.webp", false, "سرمایش و گرمایش", 2 },
                    { 10, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(902), "\\assets\\img\\sub-category\\sakhtemen\\tamirat-sakhteman.webp", false, "تعمیرا ساختمان", 2 },
                    { 11, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(905), "\\assets\\img\\sub-category\\sakhtemen\\lule-keshi.webp", false, "لوله کشی", 2 },
                    { 12, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(907), "\\assets\\img\\sub-category\\sakhtemen\\tarahi-sakhtemen.webp", false, "طراحی و بازسازی ساختمان", 2 },
                    { 13, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(909), "\\assets\\img\\sub-category\\sakhtemen\\bargh-kari.webp", false, "برق کاری", 2 },
                    { 14, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(911), "\\assets\\img\\sub-category\\sakhtemen\\chub-cabinet.webp", false, "چوب و کابینت", 2 },
                    { 15, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(913), "\\assets\\img\\sub-category\\sakhtemen\\khadamat-shishei.webp", false, "خدمات شیشه ای ساختمان", 2 },
                    { 16, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(915), "\\assets\\img\\sub-category\\sakhtemen\\baghbani.webp", false, "باغبانی و فضای سبز", 2 },
                    { 17, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(916), "\\assets\\img\\sub-category\\barbari.webp", false, "باربری و جا به جایی", 4 },
                    { 18, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(918), "\\assets\\img\\sub-category\\khodro\\khdamet-khodro.webp", false, "خدمات و تعمیرات خودرو", 5 },
                    { 19, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(920), "\\assets\\img\\sub-category\\khodro\\carwash.webp", false, "کارواش و دیتیلینگ", 5 },
                    { 20, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(922), "\\assets\\img\\sub-category\\khadamat-sherkati.webp", false, "خدمات شرکتی", 6 },
                    { 21, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(924), "\\assets\\img\\sub-category\\salamat-zibayi\\zibayi-banovan.webp", false, "زیبایی بانوان", 7 },
                    { 22, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(926), "\\assets\\img\\sub-category\\salamat-zibayi\\zibayi-aghayan.webp", false, "پیرایش و زیبایی آقایان", 7 },
                    { 23, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(928), "\\assets\\img\\sub-category\\salamat-zibayi\\pezeshki.webp", false, "پزشکی و پرستاری", 7 },
                    { 24, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(930), "\\assets\\img\\sub-category\\salamat-zibayi\\pet.webp", false, "حیوانات خانگی", 7 },
                    { 25, new DateTime(2024, 6, 12, 22, 47, 42, 969, DateTimeKind.Local).AddTicks(932), "\\assets\\img\\sub-category\\salamat-zibayi\\varzesh.webp", false, "تندرستی و ورزش", 7 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "ExpertId", "IsAccept", "IsDeleted", "Score", "Title" },
                values: new object[] { 1, new DateTime(2024, 6, 12, 22, 47, 42, 967, DateTimeKind.Local).AddTicks(6289), 1, "کارش عالی بود", 1, false, false, 4, "عالی" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name", "Price", "ServiceSubCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(5931), null, false, "سرویس عادی نظافت", 700000, 1 },
                    { 2, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(5934), null, false, "سرویس لوکس نظافت", 850000, 1 },
                    { 3, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(5936), null, false, "سرویس ویژه نظافت", 1000000, 1 },
                    { 5, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(5938), null, false, "نظافت راه‌پله", 1000000, 1 },
                    { 6, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(5995), null, false, "سرویس نظافت فوری", 1000000, 1 },
                    { 7, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(5998), null, false, "پذیرایی", 1000000, 1 },
                    { 8, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6000), null, false, "کارگر ساده", 1000000, 1 },
                    { 9, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6002), null, false, "سمپاشی فضای داخلی", 1000000, 1 },
                    { 10, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6004), null, false, "ضدعفونی منزل و محل کار", 1000000, 1 },
                    { 11, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6005), null, false, "شستشوی مبل ،فرش و موکت در محل", 1000000, 2 },
                    { 12, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6009), null, false, "خشکشویی", 1000000, 2 },
                    { 13, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6011), null, false, "پرده شویی", 1000000, 2 },
                    { 25, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6013), null, false, "تعمیر و سرویس کولر آبی", 1000000, 9 },
                    { 26, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6015), null, false, "تعمیر کولر گازی و داکت اسپلیت", 1000000, 9 },
                    { 27, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6017), null, false, "تعمیر و سرویس پکیج", 1000000, 9 },
                    { 28, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6018), null, false, "تعمیر و سرویس ابگرمکن", 1000000, 9 },
                    { 29, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6022), null, false, "کانال سازی کولر", 1000000, 9 },
                    { 32, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6024), null, false, "سرویس و تعمیر چیلر", 1000000, 9 },
                    { 33, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6026), null, false, "تعمیر و سرویس فن کویل", 1000000, 9 },
                    { 34, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6028), null, false, "نصب و تعمیر بخاری گازی و شومینه", 1000000, 9 },
                    { 36, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6029), null, false, "بهبود آلاینده‌های موتورخانه با دستگاه آنالیز", 1000000, 9 },
                    { 37, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6031), null, false, "ساخت و نصب توری", 1000000, 10 },
                    { 38, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6033), null, false, "جوشکاری و آهنگری ، درب و پنجره آهنی", 1000000, 10 },
                    { 39, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6035), null, false, "دوخت و نصب پرده", 1000000, 10 },
                    { 40, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6037), null, false, "کاشی کاری و سرامیک", 1000000, 10 },
                    { 41, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6039), null, false, "بنایی", 1000000, 10 },
                    { 42, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6040), null, false, "کلید سازی", 1000000, 10 },
                    { 43, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6042), null, false, "نصب و تعمیر انواع کفپوش و دیوارپوش", 1000000, 10 },
                    { 44, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6044), null, false, "کچ کاری و رابیتس کاری", 1000000, 10 },
                    { 45, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6046), null, false, "آچار فرانسه", 1000000, 10 },
                    { 46, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6048), null, false, "دریل کاری", 1000000, 10 },
                    { 47, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6049), null, false, "نصب ایزوگام ، قیرگونی و آسفالت", 1000000, 10 },
                    { 48, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6051), null, false, "تعمیرات نما و نماشویی", 1000000, 10 },
                    { 49, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6053), null, false, "کفسابی", 1000000, 10 },
                    { 50, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6055), null, false, "تخریب", 1000000, 10 },
                    { 51, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6059), null, false, "سقف و دیوار PVC و اسمان مجازی", 1000000, 10 },
                    { 52, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6061), null, false, "شیروانی و ایرانیت", 1000000, 10 },
                    { 53, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6063), null, false, "تعمیر و نگهداری استخر", 1000000, 10 },
                    { 54, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6065), null, false, "کپسول آتش‌ نشانی", 1000000, 10 },
                    { 55, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6066), null, false, "کناف کاری", 1000000, 10 },
                    { 56, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6068), null, false, "نصب و تعمیر شیرآلات", 1000000, 11 },
                    { 57, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6070), null, false, "تخلیه چاه و لوله بازکنی", 1000000, 11 },
                    { 58, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6072), null, false, "لوله کشی آب و فاضلاب", 1000000, 11 },
                    { 59, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6074), null, false, "نصب و سرویس توالت فرنگی و ایرانی", 1000000, 11 },
                    { 60, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6075), null, false, "تشخیص و ترمیم ترکیدگی لوله", 1000000, 11 },
                    { 61, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6077), null, false, "پمپ و منبع آب", 1000000, 11 },
                    { 62, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6079), null, false, "نصب و تعمیر دستگاه تصفیه آب", 1000000, 11 },
                    { 63, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6081), null, false, "نصب و تعمیر فلاش تانک و سیفون", 1000000, 11 },
                    { 64, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6083), null, false, "لوله کشی گاز", 1000000, 11 },
                    { 65, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6085), null, false, "نصب سینک ظرفشویی", 1000000, 11 },
                    { 66, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6086), null, false, "نصب روشویی", 1000000, 11 },
                    { 67, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6088), null, false, "نصب و تعمیر وال هنگ", 1000000, 11 },
                    { 68, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6090), null, false, "اتصال به شبکه فاضلاب شهری", 1000000, 11 },
                    { 69, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6092), null, false, "مشاوره و بازسازی ساختمان", 1000000, 12 },
                    { 70, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6095), null, false, "دکوراسیون و طراحی ساختمان", 1000000, 12 },
                    { 71, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6096), null, false, "رفع اتصالی", 1000000, 13 },
                    { 72, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6098), null, false, "نصب و تعمیر آیفون صوتی و تصویری", 1000000, 13 },
                    { 73, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6100), null, false, "نصب لوستر و چراغ", 1000000, 13 },
                    { 74, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6102), null, false, "سیم کشی تلفن و نصب سانترال", 1000000, 13 },
                    { 75, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6104), null, false, "نصب و تعمیر آنتن تلویزیون", 1000000, 13 },
                    { 76, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6106), null, false, "نصب و تعمیر دوربین مداربسته", 1000000, 13 },
                    { 77, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6107), null, false, "کلید و پریز", 1000000, 13 },
                    { 78, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6109), null, false, "تعمیر و سرویس آسانسور", 1000000, 13 },
                    { 79, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6111), null, false, "نصب و تعمیر کرکره برقی", 1000000, 13 },
                    { 80, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6113), null, false, "نصب و تعمیر جک پارکینگ و آرام بند", 1000000, 13 },
                    { 81, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6115), null, false, "هواکش و تهویه مطبوع", 1000000, 13 },
                    { 82, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6117), null, false, "ساخت و تعمیر تابلو روان و چلنیوم", 1000000, 13 },
                    { 83, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6118), null, false, "نصب و تعمیر بالابر", 1000000, 13 },
                    { 84, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6120), null, false, "نصب و تعمیر دزدگیر اماکن", 1000000, 13 },
                    { 85, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6122), null, false, "سیم پیجی", 1000000, 13 },
                    { 86, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6124), null, false, "خدمات برق صنعتی و سه فاز", 1000000, 13 },
                    { 87, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6126), null, false, "نصب سنسور و تایمر", 1000000, 13 },
                    { 88, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6128), null, false, "نصب محافظ برق و استابلایزر", 1000000, 13 },
                    { 89, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6130), null, false, "ساهت و تعمیر تابلو برق", 1000000, 13 },
                    { 90, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6132), null, false, "طراحی و اجرای نور مخفی", 1000000, 13 },
                    { 91, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6134), null, false, "نصب داکت و ترانکینگ", 1000000, 13 },
                    { 92, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6136), null, false, "نصب و تعمیر زنراتور و برق اضطراری", 1000000, 13 },
                    { 93, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6138), null, false, "نصب و تعمیر اگزاست‌فن و سانتریفیوژ", 1000000, 13 },
                    { 94, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6140), null, false, "طراحی و علامت گذاری جعبه فیوز", 1000000, 13 },
                    { 95, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6142), null, false, "سیستم اعلام و اطفاء جریق", 1000000, 13 },
                    { 96, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6144), null, false, "سیم کشی ارت", 1000000, 13 },
                    { 97, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6146), null, false, "هوشمندسازی ساختمان", 1000000, 13 },
                    { 98, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6148), null, false, "طراحی و اجرای فنس الکتریکی", 1000000, 13 },
                    { 99, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6149), null, false, "نصب و تعمیر راه بند", 1000000, 13 },
                    { 100, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6151), null, false, "نصب و سرویس پله برقی", 1000000, 13 },
                    { 101, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6153), null, false, "ساخت ، نصب و تعمیر کابینت", 1000000, 14 },
                    { 102, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6155), null, false, "نجاری", 1000000, 14 },
                    { 103, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6157), null, false, "تعمیرا مبلمان", 1000000, 14 },
                    { 104, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6159), null, false, "خدمات درب چوبی و ضدسرقت", 1000000, 14 },
                    { 105, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6161), null, false, "تعمیر و ساخت کمد دیواری", 1000000, 14 },
                    { 106, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6163), null, false, "شیشه بری و آینه کاری", 1000000, 14 },
                    { 107, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6164), null, false, "ساخت ، رگلاژ درب و پنجره آلمینیومی و UPVC", 1000000, 15 },
                    { 108, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6167), null, false, "شیشه ریلی و جام بالکن", 1000000, 15 },
                    { 109, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6169), null, false, "نصب و تعمیر درب اتوماتیک", 1000000, 15 },
                    { 110, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6171), null, false, "شیشه ریلی اسلاید", 1000000, 15 },
                    { 111, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6173), null, false, "ساخت کابین دوش", 1000000, 15 },
                    { 112, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6175), null, false, "باغبانی", 1000000, 16 },
                    { 113, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6177), null, false, "نگهداری از گیاهان آپارتمانی", 1000000, 16 },
                    { 114, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6178), null, false, "سمپاچی باغچه و فضای سبز", 1000000, 16 },
                    { 115, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6180), null, false, "مشاوره گل و گیاه", 1000000, 16 },
                    { 116, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6182), null, false, "طراحی و اجرای فضای سبز", 1000000, 16 },
                    { 117, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6184), null, false, "روف گاردن", 1000000, 16 },
                    { 118, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6186), null, false, "هرس درختان", 1000000, 16 },
                    { 120, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6188), null, false, "تعمیر کولر گازی و اسپلیت", 1000000, 4 },
                    { 122, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6190), null, false, "تعمیر و سرویس آبگرمکن", 1000000, 4 },
                    { 124, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6238), null, false, "نصب و تعمیر رادیاتور شوفاژ", 1000000, 4 },
                    { 125, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6240), null, false, "تعمیر و نگهداری موتورخانه", 1000000, 4 },
                    { 127, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6242), null, false, "نصب و سرویس فن کویل", 1000000, 4 },
                    { 128, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6244), null, false, "نصب و تعمیر بخاری و شومینه", 1000000, 4 },
                    { 129, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6246), null, false, "نصب و تعمیر VRF و DVR", 1000000, 4 },
                    { 130, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6248), null, false, "بهبود الاینده‌های موتورخانه با دستگاه آنالیز", 1000000, 4 },
                    { 131, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6251), null, false, "نصب و تعمیر یخچال و فریزر", 1000000, 5 },
                    { 132, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6252), null, false, "نصب و تعمیر ماشین لباسشویی", 1000000, 5 },
                    { 133, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6254), null, false, "نصب و تعمیر اجاق گاز", 1000000, 5 },
                    { 134, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6256), null, false, "نصب و تعمیر ماشین ظرفشویی", 1000000, 5 },
                    { 135, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6258), null, false, "تعمیرات تخصصی تلویزیون", 1000000, 5 },
                    { 136, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6260), null, false, "نصب تلویزیون و لوازم صوتی تصویری", 1000000, 5 },
                    { 137, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6262), null, false, "نصب و تعمیر مایکروویو و سولاردام", 1000000, 5 },
                    { 138, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6263), null, false, "نصب و تعمیر هود آشپزخانه", 1000000, 5 },
                    { 139, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6265), null, false, "نصب و تعمیر جاروبرقی", 1000000, 5 },
                    { 140, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6267), null, false, "نصب و تعمیر چرخ خیاطی", 1000000, 5 },
                    { 141, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6269), null, false, "نصب و تعمیر تردمیل", 1000000, 5 },
                    { 142, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6271), null, false, "تعمیر چایی ساز و قهوه ساز", 1000000, 5 },
                    { 143, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6273), null, false, "تعمیر دستگاه بخور", 1000000, 13 },
                    { 144, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6274), null, false, "تعمیر پنکه", 1000000, 5 },
                    { 145, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6276), null, false, "نصب و تعمیر فر", 1000000, 5 },
                    { 146, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6278), null, false, "تعمیر اتو", 1000000, 5 },
                    { 147, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6280), null, false, "تعمیر آبمیوه گیری و مخلوط کن", 1000000, 5 },
                    { 148, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6282), null, false, "تعمیر ساندبار و اسپیکر", 1000000, 5 },
                    { 149, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6284), null, false, "تعمیر کنسول بازی", 1000000, 5 },
                    { 150, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6286), null, false, "تعمیر بخارشور", 1000000, 5 },
                    { 151, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6288), null, false, "تعمیر غذاساز و خردکن", 1000000, 5 },
                    { 152, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6290), null, false, "تعمیرات ریش تراش و اپلیدی", 1000000, 5 },
                    { 153, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6291), null, false, "تعمیر سینمای خانگی", 1000000, 5 },
                    { 154, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6293), null, false, "تعمیر چرخ گوشت", 1000000, 5 },
                    { 155, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6295), null, false, "تعمیر رادیو و ضبط صوت", 1000000, 5 },
                    { 156, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6297), null, false, "تعمیر صندلی ماساژور", 1000000, 13 },
                    { 157, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6299), null, false, "تعمیر سرخ کن", 1000000, 5 },
                    { 158, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6300), null, false, "تعمیر بخارپز و پلوپز", 1000000, 5 },
                    { 159, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6302), null, false, "تعمیر سشوار", 1000000, 5 },
                    { 160, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6304), null, false, "تعمیر شوفاژ برقی", 1000000, 5 },
                    { 161, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6306), null, false, "ترمیم و بازسازی ظروف آشپزخانه", 1000000, 5 },
                    { 162, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6308), null, false, "تعمیر کامپیوتر و لپ تاپ", 1000000, 7 },
                    { 163, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6310), null, false, "تعمیر ماشین‌های اداری", 1000000, 7 },
                    { 164, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6311), null, false, "پشتیبانی شبکه و سرور", 1000000, 7 },
                    { 165, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6313), null, false, "مودم و اینترنت", 1000000, 7 },
                    { 166, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6315), null, false, "طراحی سایت و لوگو", 1000000, 7 },
                    { 167, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6317), null, false, "نصب و راه‌اندازی VoIP", 1000000, 7 },
                    { 168, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6319), null, false, "تعمیر دستگاه کارتخوان و بارکدخوان", 1000000, 7 },
                    { 169, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6321), null, false, "خدمات تاچ و ال سی دی", 1000000, 8 },
                    { 170, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6323), null, false, "خدمات باتری", 1000000, 8 },
                    { 171, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6325), null, false, "خدمات عیب‌یابی و تعمیر برد", 1000000, 8 },
                    { 172, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6327), null, false, "خدمات نرم افزاری", 1000000, 8 },
                    { 173, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6329), null, false, "مشاوره خرید موبایل و کالاهای دیجیتال", 1000000, 8 },
                    { 174, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6331), null, false, "خدمات اسپیکر", 1000000, 8 },
                    { 175, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6333), null, false, "خدمات فریم و قاب", 1000000, 8 },
                    { 176, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6335), null, false, "خدمات دوربین", 1000000, 8 },
                    { 177, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6337), null, false, "خدمات سنسور", 1000000, 8 },
                    { 178, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6338), null, false, "اسباب کشی با خاور و کامیون", 1000000, 17 },
                    { 179, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6340), null, false, "اسباب کشی و حمل بار بین شهری", 1000000, 17 },
                    { 180, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6342), null, false, "اسباب کشی با وانت و نیسان", 1000000, 17 },
                    { 181, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6344), null, false, "سرویس بسته بندی", 1000000, 17 },
                    { 182, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6346), null, false, "کارگر جا به جایی", 1000000, 17 },
                    { 183, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6348), null, false, "جا به جایی گاو صندوق", 1000000, 17 },
                    { 184, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6349), null, false, "حمل نخاله و ضایعات ساختمانی", 1000000, 17 },
                    { 185, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6351), null, false, "اسباب کشی شرکت ها و سازمان ها", 1000000, 17 },
                    { 186, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6353), null, false, "خرید ملزومات بسته بندی", 1000000, 17 },
                    { 187, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6356), null, false, "شارژ گاز کولر ماشین", 1000000, 18 },
                    { 188, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6358), null, false, "تعویض باتری خودرو", 1000000, 18 },
                    { 189, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6359), null, false, "امداد خودرو", 1000000, 18 },
                    { 190, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6361), null, false, "برق و باتری خودرو", 1000000, 18 },
                    { 191, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6363), null, false, "مکانیگی خودرو", 1000000, 18 },
                    { 192, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6365), null, false, "تست دیاگ و ریمپ ECU خودرو", 1000000, 18 },
                    { 193, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6367), null, false, "حمل خودرو", 1000000, 18 },
                    { 194, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6368), null, false, "تعویض روغن خودرو", 1000000, 18 },
                    { 195, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6370), null, false, "پنچرگیری و تعویض لاستیک", 1000000, 18 },
                    { 196, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6372), null, false, "کارشناسی خودرو", 1000000, 18 },
                    { 197, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6374), null, false, "تعویض لنت خودرو", 1000000, 18 },
                    { 198, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6376), null, false, "تعویض شمع و وایر خودرو", 1000000, 18 },
                    { 199, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6378), null, false, "کاهش مصرف سوخت", 1000000, 18 },
                    { 200, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6379), null, false, "سرویس دوره ای گیربکس اتوماتیک", 1000000, 18 },
                    { 201, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6381), null, false, "نصب GPS خودرو", 1000000, 18 },
                    { 202, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6383), null, false, "نصب دزدگیر خودرو", 1000000, 18 },
                    { 203, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6385), null, false, "سپرسازی و جوش پلاستیک", 1000000, 18 },
                    { 204, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6387), null, false, "تعویض شیشه خودرو", 1000000, 18 },
                    { 205, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6388), null, false, "تعمیر موتورسیکلت", 1000000, 18 },
                    { 206, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6391), null, false, "سوخت رسانی", 1000000, 18 },
                    { 207, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6393), null, false, "ساخت سوئیچ و ریموت خودرو در محل", 1000000, 18 },
                    { 208, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6395), null, false, "تعمیر و تعویض چراغ خودرو", 1000000, 18 },
                    { 209, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6397), null, false, "سرامیک خودرو", 1000000, 19 },
                    { 210, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6398), null, false, "کارواش نانو", 1000000, 19 },
                    { 211, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6400), null, false, "کارواش با آب", 1000000, 19 },
                    { 212, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6402), null, false, "واکس و پولیش خودرو", 1000000, 19 },
                    { 213, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6404), null, false, "صفرشویی خودرو", 1000000, 19 },
                    { 214, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6406), null, false, "موتورشویی خودرو", 1000000, 19 },
                    { 215, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6407), null, false, "پکیج کارواش VIP", 1000000, 19 },
                    { 216, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6409), null, false, "شفاف سازی چراغ خودرو", 1000000, 19 },
                    { 217, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6411), null, false, "احیای رنگ خودرو", 1000000, 19 },
                    { 218, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6413), null, false, "صافکاری و نقاشی خودرو", 1000000, 19 },
                    { 219, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6415), null, false, "نصب شیشه دودی خودرو در محل", 1000000, 19 },
                    { 220, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6416), null, false, "خدمات شرکتی ویژه شرکت ها کوچک و متوسط", 1000000, 20 },
                    { 221, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6418), null, false, "خدمات شرکتی ویژه سازمان های بزرگ", 1000000, 20 },
                    { 222, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6420), null, false, "خدمات ناخن", 1000000, 21 },
                    { 223, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6422), null, false, "خدمات ویژه ناخن", 1000000, 21 },
                    { 224, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6423), null, false, "اصلاح صورت و ابرو بانوان", 1000000, 21 },
                    { 225, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6426), null, false, "اپیلاسیون بانوان در خانه", 1000000, 21 },
                    { 226, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6428), null, false, "براشینگ مو بانوان", 1000000, 21 },
                    { 227, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6430), null, false, "رنگ مو بانوان", 1000000, 21 },
                    { 228, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6477), null, false, "مش ، لایت ، بالیاژ و آمبره بانوان", 1000000, 21 },
                    { 229, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6479), null, false, "لیفت و لمینت مژه و ابرو بانوان", 1000000, 21 },
                    { 230, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6481), null, false, "کاشت و اکستنشن مژه بانوان در خانه", 1000000, 21 },
                    { 231, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6485), null, false, "پاکسازی و لایه برداری پوست بانوان", 1000000, 21 },
                    { 232, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6487), null, false, "شینیون مو بانوان در خانه", 1000000, 21 },
                    { 233, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6488), null, false, "آرایش صورت بانوان در خانه", 1000000, 21 },
                    { 234, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6490), null, false, "بافت مو بانوان در خانه", 1000000, 21 },
                    { 235, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6492), null, false, "اکستنشن مو بانوان در خانه", 1000000, 21 },
                    { 236, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6494), null, false, "میکروپیمنتیشن و میکروبلیدینگ بانوان", 1000000, 21 },
                    { 237, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6496), null, false, "کوتاهی مو بانوان", 1000000, 21 },
                    { 238, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6498), null, false, "درمان سرپایی در محل", 1000000, 23 },
                    { 239, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6500), null, false, "تزریقات در منزل", 1000000, 23 },
                    { 240, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6501), null, false, "پرستاری و مراقبت بیمار", 1000000, 23 },
                    { 241, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6503), null, false, "پرستاری و مراقبت سالمند", 1000000, 23 },
                    { 242, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6505), null, false, "آزمایش و نمونه گیری در منزل", 1000000, 23 },
                    { 243, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6507), null, false, "ICU در منزل", 1000000, 23 },
                    { 244, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6509), null, false, "معاینه پزشکی", 1000000, 23 },
                    { 245, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6511), null, false, "فیزیوتراپی در منزل", 1000000, 23 },
                    { 246, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6512), null, false, "اصلاح سر و صورت آقایان", 1000000, 22 },
                    { 247, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6514), null, false, "سرویس ماهانه پیرایش اقایان", 1000000, 22 },
                    { 248, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6516), null, false, "خدمات ناخن آقایان", 1000000, 22 },
                    { 249, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6518), null, false, "مراقبت و زیبایی اقایان", 1000000, 22 },
                    { 250, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6520), null, false, "گریم داماد", 1000000, 22 },
                    { 251, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6522), null, false, "هتل های حیوانات خانگی", 1000000, 24 },
                    { 252, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6523), null, false, "خدمات دامپزشکی در محل", 1000000, 24 },
                    { 253, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6525), null, false, "خدمات تربیتی حیوانات خانگی", 1000000, 24 },
                    { 254, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6527), null, false, "خدمات شستشو و آرایش حیوانات خانگی", 1000000, 24 },
                    { 255, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6529), null, false, "پت شاپ", 1000000, 24 },
                    { 256, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6531), null, false, "کلاس سی ایکس در خانه", 1000000, 25 },
                    { 257, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6532), null, false, "برنامه ورزشی و تغذیه", 1000000, 25 },
                    { 258, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6534), null, false, "کلاس یوگا در خانه", 1000000, 25 },
                    { 259, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6536), null, false, "کلاس پیلاتس در خانه", 1000000, 25 },
                    { 260, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6538), null, false, "حرکات اصلاحی", 1000000, 25 },
                    { 261, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6483), null, false, "کراتینه و ویتامینه مو بانوان", 1000000, 21 },
                    { 262, new DateTime(2024, 6, 12, 22, 47, 42, 968, DateTimeKind.Local).AddTicks(6007), null, false, "قالیشویی", 1000000, 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "DoneAt", "Image", "IsDeleted", "RequesteForTime", "ServiceId", "Status", "Title" },
                values: new object[] { 1, new DateTime(2024, 6, 12, 22, 47, 42, 966, DateTimeKind.Local).AddTicks(8019), 1, "نظافت خونه صد متری هب طور کامل", new DateTime(2024, 6, 12, 22, 47, 42, 966, DateTimeKind.Local).AddTicks(8024), null, false, new DateTime(2024, 6, 12, 22, 47, 42, 966, DateTimeKind.Local).AddTicks(8027), 1, 3, "نظافت" });

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
