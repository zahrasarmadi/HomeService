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
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
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
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
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
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "Password", "PhoneNumber" },
                values: new object[] { 1, new DateTime(2024, 5, 13, 22, 26, 8, 248, DateTimeKind.Local).AddTicks(1985), "zahrasarmadi17@gmail.com", "زهرا", 1, false, "سرمدی", "zahrasarmadi", "09927848276" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6004), "آذربایجان شرقی" },
                    { 2, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6008), "آذربایجان غربی" },
                    { 3, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6010), "اردبیل" },
                    { 4, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6012), "اصفهان" },
                    { 5, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6014), "البرز" },
                    { 6, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6090), "ایلام" },
                    { 7, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6092), "بوشهر" },
                    { 8, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6095), "تهران" },
                    { 9, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6097), "چهارمحال و بختیاری" },
                    { 10, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6099), "خراسان جنوبی" },
                    { 11, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6102), "خراسان رضوی" },
                    { 12, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6104), "خراسان شمالی" },
                    { 13, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6106), "خوزستان" },
                    { 14, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6109), "زنجان" },
                    { 15, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6111), "سمنان" },
                    { 16, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6113), "سیستان و بلوچستان" },
                    { 17, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6116), "فارس" },
                    { 18, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6118), "قزوین" },
                    { 19, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6120), "قم" },
                    { 20, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6122), "کردستان" },
                    { 21, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6125), "کرمان" },
                    { 22, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6127), "کرمانشاه" },
                    { 23, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6130), "کهگیلویه و بویراحمد" },
                    { 24, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6132), "گلستان" },
                    { 25, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6134), "گیلان" },
                    { 26, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6136), "لرستان" },
                    { 27, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6138), "مازندران" },
                    { 28, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6140), "مرکزی" },
                    { 29, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6142), "هرمزگان" },
                    { 30, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6144), "همدان" },
                    { 31, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(6146), "یزد" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BackUpPhoneNumber", "BankCardNumber", "CreatedAt", "FirstName", "Gender", "IsDeleted", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "09123669858", "1234123412341234", new DateTime(2024, 5, 13, 22, 26, 8, 250, DateTimeKind.Local).AddTicks(5090), "سارا", 1, false, "محمودی", "09192365988" },
                    { 2, "09123623258", "1239684412341234", new DateTime(2024, 5, 13, 22, 26, 8, 250, DateTimeKind.Local).AddTicks(5096), "محمد", 2, false, "اصغری", "09199655988" }
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "BankCardNumber", "BirthDate", "CreatedAt", "FirstName", "Gender", "IsConfrim", "IsDeleted", "LastName", "PhoneNumber", "ProfileImage" },
                values: new object[] { 1, "1234123412341234", new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(937), "منصور", 2, true, false, "آموزگار", "09362356998", null });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(6621), null, false, "تمیزکاری" },
                    { 2, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(6625), null, false, "ساختمان" },
                    { 3, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(6629), null, false, "تعمیرات اشیاء" },
                    { 4, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(6631), null, false, "اسباب کشی و حمل بار" },
                    { 5, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(6634), null, false, "خودرو" },
                    { 6, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(6637), null, false, "سازمان ها و مجتمع ها" },
                    { 7, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(6639), null, false, "سلامت و زیبایی" },
                    { 8, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(6642), null, false, "کشکول" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "ExpertId", "IsAccept", "IsDeleted", "Score", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 13, 22, 26, 8, 250, DateTimeKind.Local).AddTicks(818), 1, "کارش عالی بود", 1, false, false, 4, "عالی" });

            migrationBuilder.InsertData(
                table: "ServiceSubCategories",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name", "ServiceCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8505), null, false, "نظافت و پذیرایی", 1 },
                    { 2, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8509), null, false, "شستشو", 1 },
                    { 3, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8512), null, false, "کارواش و دیتیلینگ", 1 },
                    { 4, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8514), null, false, "سرمایش و گرمایش", 3 },
                    { 5, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8517), null, false, "نصب وتعمیر لوازم خانگی", 3 },
                    { 6, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8520), null, false, "کارواش و دیتیلینگ", 3 },
                    { 7, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8522), null, false, "خذمات کامپیوتری", 3 },
                    { 8, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8525), null, false, "تعمیرات موبایل", 3 },
                    { 9, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8527), null, false, "سرمایش و گرمایش", 2 },
                    { 10, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8530), null, false, "تعمیرا ساختمان", 2 },
                    { 11, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8532), null, false, "لوله کشی", 2 },
                    { 12, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8534), null, false, "طراحی و بازسازی ساختمان", 2 },
                    { 13, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8536), null, false, "برق کاری", 2 },
                    { 14, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8539), null, false, "چوب و کابینت", 2 },
                    { 15, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8541), null, false, "خدمات شیشه ای ساختمان", 2 },
                    { 16, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8544), null, false, "باغبانی و فضای سبز", 2 },
                    { 17, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8546), null, false, "باربری و جا به جایی", 4 },
                    { 18, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8549), null, false, "خدمات و تعمیرات خودرو", 5 },
                    { 19, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8551), null, false, "کارواش و دیتیلینگ", 5 },
                    { 20, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8554), null, false, "خدمات شرکتی", 6 },
                    { 21, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8557), null, false, "زیبایی بانوان", 7 },
                    { 22, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8559), null, false, "پیرایش و زیبایی آقایان", 7 },
                    { 23, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8562), null, false, "پزشکی و پرستاری", 7 },
                    { 24, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(8564), null, false, "حیوانات خانگی", 7 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "Image", "IsDeleted", "Name", "Price", "ServiceSubCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(3870), null, false, "سرویس عادی نظافت", 700000, 1 },
                    { 2, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(3874), null, false, "سرویس لوکسن نظافت", 850000, 1 },
                    { 3, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(3876), null, false, "سرویس ویژه نظافت", 1000000, 1 },
                    { 4, new DateTime(2024, 5, 13, 22, 26, 8, 251, DateTimeKind.Local).AddTicks(3879), null, false, "تعمیر و سرویس کولر آبی", 200000, 4 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "DoneAt", "ExpertId", "Image", "IsDeleted", "RequestedAt", "ServiceId", "Status", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(2614), 1, "نظافت خونه صد متری هب طور کامل", new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(2619), 1, null, false, new DateTime(2024, 5, 13, 22, 26, 8, 249, DateTimeKind.Local).AddTicks(2623), 1, 6, "نظافت" });

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
