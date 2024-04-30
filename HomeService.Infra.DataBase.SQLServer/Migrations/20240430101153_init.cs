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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackUpPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false),
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
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceSubCategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
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
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: true),
                    ServiceSubCategoryId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_ServiceSubCategories_ServiceSubCategoryId",
                        column: x => x.ServiceSubCategoryId,
                        principalTable: "ServiceSubCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Services_ServiceId",
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "Password", "PhoneNumber" },
                values: new object[] { 1, new DateTime(2024, 4, 30, 13, 41, 48, 819, DateTimeKind.Local).AddTicks(7847), "zahrasarmadi17@gmail.com", "زهرا", 1, false, "سرمدی", "zahrasarmadi", "09927848276" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4537), "آذربایجان شرقی" },
                    { 2, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4540), "آذربایجان غربی" },
                    { 3, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4542), "اردبیل" },
                    { 4, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4544), "اصفهان" },
                    { 5, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4546), "البرز" },
                    { 6, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4548), "ایلام" },
                    { 7, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4550), "بوشهر" },
                    { 8, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4551), "تهران" },
                    { 9, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4553), "چهارمحال و بختیاری" },
                    { 10, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4555), "خراسان جنوبی" },
                    { 11, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4557), "خراسان رضوی" },
                    { 12, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4559), "خراسان شمالی" },
                    { 13, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4561), "خوزستان" },
                    { 14, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4563), "زنجان" },
                    { 15, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4565), "سمنان" },
                    { 16, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4567), "سیستان و بلوچستان" },
                    { 17, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4569), "فارس" },
                    { 18, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4572), "قزوین" },
                    { 19, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4574), "قم" },
                    { 20, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4576), "کردستان" },
                    { 21, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4578), "کرمان" },
                    { 22, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4580), "کرمانشاه" },
                    { 23, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4583), "کهگیلویه و بویراحمد" },
                    { 24, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4585), "گلستان" },
                    { 25, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4587), "گیلان" },
                    { 26, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4589), "لرستان" },
                    { 27, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4591), "مازندران" },
                    { 28, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4593), "مرکزی" },
                    { 29, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4596), "هرمزگان" },
                    { 30, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4598), "همدان" },
                    { 31, new DateTime(2024, 4, 30, 13, 41, 48, 821, DateTimeKind.Local).AddTicks(4600), "یزد" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BackUpPhoneNumber", "BankCardNumber", "CreatedAt", "FirstName", "Gender", "IsDeleted", "LastName", "LastUpdatedAt", "PhoneNumber", "RegisteredAt" },
                values: new object[,]
                {
                    { 1, "09123669858", "1234123412341234", new DateTime(2024, 4, 30, 13, 41, 48, 822, DateTimeKind.Local).AddTicks(5407), "سارا", 1, false, "محمودی", new DateTime(2024, 4, 30, 13, 41, 48, 822, DateTimeKind.Local).AddTicks(5400), "09192365988", new DateTime(2024, 4, 30, 13, 41, 48, 822, DateTimeKind.Local).AddTicks(5408) },
                    { 2, "09123623258", "1239684412341234", new DateTime(2024, 4, 30, 13, 41, 48, 822, DateTimeKind.Local).AddTicks(5414), "محمد", 2, false, "اصغری", new DateTime(2024, 4, 30, 13, 41, 48, 822, DateTimeKind.Local).AddTicks(5411), "09199655988", new DateTime(2024, 4, 30, 13, 41, 48, 822, DateTimeKind.Local).AddTicks(5415) }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(4509), false, "ساختمان" },
                    { 2, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(4512), false, "تعمیرات اشیاء" },
                    { 3, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(4514), false, "اسباب کشی و حمل بار" },
                    { 4, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(4515), false, "خودرو" },
                    { 5, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(4518), false, "سازمان ها و مجتمع ها" },
                    { 6, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(4520), false, "سلامت و زیبایی" },
                    { 7, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(4522), false, "کشکول" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Price", "ServiceSubCategoryId", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(2341), false, "سرویس عادی نظافت", 700000, null, 1 },
                    { 2, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(2344), false, "سرویس لوکسن نظافت", 850000, null, 1 },
                    { 3, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(2347), false, "سرویس ویژه نظافت", 1000000, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "CreatedAt", "ExpertId", "ImageAddress", "IsDeleted", "OrderId", "ServiceCategoryId", "ServiceId", "ServiceSubCategoryId" },
                values: new object[,]
                {
                    { 1, "ساختمان", new DateTime(2024, 4, 30, 13, 41, 48, 823, DateTimeKind.Local).AddTicks(8547), null, "..\\HomeService\\HomeService.Endpoint.RazorPages.UI\\wwwroot\\img\\ServiceCategory\\f842e927-824f-49f6-8710-124e7f517ed6-mainCategory-icon.webp", false, null, 1, null, null },
                    { 2, "تعمیرات اشیاء", new DateTime(2024, 4, 30, 13, 41, 48, 823, DateTimeKind.Local).AddTicks(8552), null, "..\\HomeService\\HomeService.Endpoint.RazorPages.UI\\wwwroot\\img\\ServiceCategory\\08a5087d-cd08-49a2-82dd-4738cb2182bd-mainCategory-icon.webp", false, null, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "ServiceSubCategories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(6012), false, "نظافت و پذیرایی", 1 },
                    { 2, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(6015), false, "شستشو", 1 },
                    { 3, new DateTime(2024, 4, 30, 13, 41, 48, 824, DateTimeKind.Local).AddTicks(6017), false, "کارواش و دیتیلینگ", 1 }
                });

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
                name: "IX_Images_ExpertId",
                table: "Images",
                column: "ExpertId",
                unique: true,
                filter: "[ExpertId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_OrderId",
                table: "Images",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ServiceCategoryId",
                table: "Images",
                column: "ServiceCategoryId",
                unique: true,
                filter: "[ServiceCategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ServiceId",
                table: "Images",
                column: "ServiceId",
                unique: true,
                filter: "[ServiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ServiceSubCategoryId",
                table: "Images",
                column: "ServiceSubCategoryId",
                unique: true,
                filter: "[ServiceSubCategoryId] IS NOT NULL");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ExpertService");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Orders");

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
