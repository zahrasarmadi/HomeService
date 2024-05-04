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
                values: new object[] { 1, new DateTime(2024, 4, 30, 18, 0, 18, 83, DateTimeKind.Local).AddTicks(6845), "zahrasarmadi17@gmail.com", "زهرا", 1, false, "سرمدی", "zahrasarmadi", "09927848276" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3532), "آذربایجان شرقی" },
                    { 2, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3535), "آذربایجان غربی" },
                    { 3, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3536), "اردبیل" },
                    { 4, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3538), "اصفهان" },
                    { 5, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3539), "البرز" },
                    { 6, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3541), "ایلام" },
                    { 7, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3543), "بوشهر" },
                    { 8, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3544), "تهران" },
                    { 9, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3545), "چهارمحال و بختیاری" },
                    { 10, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3547), "خراسان جنوبی" },
                    { 11, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3548), "خراسان رضوی" },
                    { 12, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3550), "خراسان شمالی" },
                    { 13, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3551), "خوزستان" },
                    { 14, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3553), "زنجان" },
                    { 15, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3554), "سمنان" },
                    { 16, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3555), "سیستان و بلوچستان" },
                    { 17, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3557), "فارس" },
                    { 18, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3558), "قزوین" },
                    { 19, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3560), "قم" },
                    { 20, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3561), "کردستان" },
                    { 21, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3563), "کرمان" },
                    { 22, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3564), "کرمانشاه" },
                    { 23, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3566), "کهگیلویه و بویراحمد" },
                    { 24, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3567), "گلستان" },
                    { 25, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3569), "گیلان" },
                    { 26, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3570), "لرستان" },
                    { 27, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3572), "مازندران" },
                    { 28, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3573), "مرکزی" },
                    { 29, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3575), "هرمزگان" },
                    { 30, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3576), "همدان" },
                    { 31, new DateTime(2024, 4, 30, 18, 0, 18, 85, DateTimeKind.Local).AddTicks(3579), "یزد" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BackUpPhoneNumber", "BankCardNumber", "CreatedAt", "FirstName", "Gender", "IsDeleted", "LastName", "LastUpdatedAt", "PhoneNumber", "RegisteredAt" },
                values: new object[,]
                {
                    { 1, "09123669858", "1234123412341234", new DateTime(2024, 4, 30, 18, 0, 18, 86, DateTimeKind.Local).AddTicks(8754), "سارا", 1, false, "محمودی", new DateTime(2024, 4, 30, 18, 0, 18, 86, DateTimeKind.Local).AddTicks(8746), "09192365988", new DateTime(2024, 4, 30, 18, 0, 18, 86, DateTimeKind.Local).AddTicks(8754) },
                    { 2, "09123623258", "1239684412341234", new DateTime(2024, 4, 30, 18, 0, 18, 86, DateTimeKind.Local).AddTicks(8759), "محمد", 2, false, "اصغری", new DateTime(2024, 4, 30, 18, 0, 18, 86, DateTimeKind.Local).AddTicks(8757), "09199655988", new DateTime(2024, 4, 30, 18, 0, 18, 86, DateTimeKind.Local).AddTicks(8759) }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(4811), false, "تمیزکاری" },
                    { 2, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(4817), false, "ساختمان" },
                    { 3, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(4819), false, "تعمیرات اشیاء" },
                    { 4, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(4820), false, "اسباب کشی و حمل بار" },
                    { 5, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(4822), false, "خودرو" },
                    { 6, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(4824), false, "سازمان ها و مجتمع ها" },
                    { 7, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(4825), false, "سلامت و زیبایی" },
                    { 8, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(4827), false, "کشکول" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Price", "ServiceSubCategoryId", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(1998), false, "سرویس عادی نظافت", 700000, null, 1 },
                    { 2, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(2001), false, "سرویس لوکسن نظافت", 850000, null, 1 },
                    { 3, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(2003), false, "سرویس ویژه نظافت", 1000000, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "CreatedAt", "ExpertId", "ImageAddress", "IsDeleted", "OrderId", "ServiceCategoryId", "ServiceId", "ServiceSubCategoryId" },
                values: new object[,]
                {
                    { 1, "ساختمان", new DateTime(2024, 4, 30, 18, 0, 18, 87, DateTimeKind.Local).AddTicks(9031), null, "..\\HomeService\\HomeService.Endpoint.RazorPages.UI\\wwwroot\\img\\ServiceCategory\\f842e927-824f-49f6-8710-124e7f517ed6-mainCategory-icon.webp", false, null, 1, null, null },
                    { 2, "تعمیرات اشیاء", new DateTime(2024, 4, 30, 18, 0, 18, 87, DateTimeKind.Local).AddTicks(9034), null, "..\\HomeService\\HomeService.Endpoint.RazorPages.UI\\wwwroot\\img\\ServiceCategory\\08a5087d-cd08-49a2-82dd-4738cb2182bd-mainCategory-icon.webp", false, null, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "ServiceSubCategories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6414), false, "نظافت و پذیرایی", 1 },
                    { 2, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6419), false, "شستشو", 1 },
                    { 3, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6422), false, "کارواش و دیتیلینگ", 1 },
                    { 4, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6423), false, "سرمایش و گرمایش", 3 },
                    { 5, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6425), false, "نصب وتعمیر لوازم خانگی", 3 },
                    { 6, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6427), false, "کارواش و دیتیلینگ", 3 },
                    { 7, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6429), false, "خذمات کامپیوتری", 3 },
                    { 8, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6431), false, "تعمیرات موبایل", 3 },
                    { 9, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6432), false, "سرمایش و گرمایش", 2 },
                    { 10, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6434), false, "تعمیرا ساختمان", 2 },
                    { 11, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6436), false, "لوله کشی", 2 },
                    { 12, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6437), false, "طراحی و بازسازی ساختمان", 2 },
                    { 13, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6439), false, "برق کاری", 2 },
                    { 14, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6441), false, "چوب و کابینت", 2 },
                    { 15, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6443), false, "خدمات شیشه ای ساختمان", 2 },
                    { 16, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6444), false, "باغبانی و فضای سبز", 2 },
                    { 17, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6446), false, "باربری و جا به جایی", 4 },
                    { 18, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6448), false, "خدمات و تعمیرات خودرو", 5 },
                    { 19, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6450), false, "کارواش و دیتیلینگ", 5 },
                    { 20, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6452), false, "خدمات شرکتی", 6 },
                    { 21, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6454), false, "زیبایی بانوان", 7 },
                    { 22, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6455), false, "پیرایش و زیبایی آقایان", 7 },
                    { 23, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6457), false, "پزشکی و پرستاری", 7 },
                    { 24, new DateTime(2024, 4, 30, 18, 0, 18, 88, DateTimeKind.Local).AddTicks(6459), false, "حیوانات خانگی", 7 }
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
