using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGiftTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("27e3d323-0353-426c-a116-65be1f79dee6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2871e0e6-eb5d-4847-b5c9-f5497af2da4a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3f277d59-89d1-4ccd-9f47-b2b147595389"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4ae1f5e4-2bdd-4d60-8eb7-b076588499c7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("52d1e842-48d3-4d19-86fb-fd2e39c8438e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5dc8868f-0c19-4a63-8010-95ea62fb7f69"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ecc1262-f1df-4cc6-b413-67e39670e1f3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("75f26310-6e32-44ca-a437-9f3a12496dd3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("85f200a8-c008-4e04-ae4e-bbd4b2339788"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("90d84833-f12d-49f6-9e4d-c0b57c33cdf0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b2bc1de1-10ee-4aad-ade6-49f7551aa38d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e37866c6-b4c2-40b1-9f40-c32565987ece"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ec21237a-5eef-4782-947d-e02af7579fab"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ed27b314-032d-48d1-af7d-7280523d1246"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f1a9a3aa-d3af-41b4-8b57-e89000ec80fd"));

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Gifts");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "Gifts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Gifts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Gifts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopLink",
                table: "Gifts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailLink",
                table: "Gifts",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("11abb94f-7daf-49dc-8ee1-332ae3db2489"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Sports" },
                    { new Guid("1c8439dd-abe8-4ab6-8c30-accc75e83300"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3137), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Toys" },
                    { new Guid("290ac46e-9ee3-4482-a5cf-18bbc8846c88"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3177), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Music" },
                    { new Guid("35b37033-aa3c-4367-9312-388391b257cd"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3179), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Gourmet" },
                    { new Guid("47559050-de82-4fed-a0f7-11d1348cbfdd"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3174), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Experiences" },
                    { new Guid("4c5a06ba-fd46-44cf-9eb2-8dcdd1f0f81a"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3128), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Home" },
                    { new Guid("540af344-d1b6-454c-bb9b-c2c860b4d7c4"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3173), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Kitchen" },
                    { new Guid("60b96379-c642-4e24-ac95-5c9e345eb800"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3178), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Garden" },
                    { new Guid("a1f4e9f1-0fa1-454e-8548-7183ceb4cd15"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Jewelery" },
                    { new Guid("a65f5779-4add-439c-bc4b-448093198bf8"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3176), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Wellness" },
                    { new Guid("b022bbbf-e7c7-4ce5-9e12-d74f54b98066"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3178), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Office" },
                    { new Guid("bc8da7c8-d441-4c8f-9ef2-4a64580f45a4"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3135), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Personal care" },
                    { new Guid("e164e7ae-74c9-483c-a2cb-43315b8e9f91"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3134), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Books" },
                    { new Guid("e73b20b8-99c0-46c8-a533-d90d0f4a27b8"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3133), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Electronics" },
                    { new Guid("f53aa0b6-5524-4338-8457-1f66afd64cb8"), new DateTimeOffset(new DateTime(2024, 10, 2, 18, 24, 11, 46, DateTimeKind.Unspecified).AddTicks(3131), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Fashion" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11abb94f-7daf-49dc-8ee1-332ae3db2489"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c8439dd-abe8-4ab6-8c30-accc75e83300"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("290ac46e-9ee3-4482-a5cf-18bbc8846c88"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("35b37033-aa3c-4367-9312-388391b257cd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47559050-de82-4fed-a0f7-11d1348cbfdd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4c5a06ba-fd46-44cf-9eb2-8dcdd1f0f81a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("540af344-d1b6-454c-bb9b-c2c860b4d7c4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("60b96379-c642-4e24-ac95-5c9e345eb800"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a1f4e9f1-0fa1-454e-8548-7183ceb4cd15"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a65f5779-4add-439c-bc4b-448093198bf8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b022bbbf-e7c7-4ce5-9e12-d74f54b98066"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bc8da7c8-d441-4c8f-9ef2-4a64580f45a4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e164e7ae-74c9-483c-a2cb-43315b8e9f91"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e73b20b8-99c0-46c8-a533-d90d0f4a27b8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f53aa0b6-5524-4338-8457-1f66afd64cb8"));

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "ShopLink",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "ThumbnailLink",
                table: "Gifts");

            migrationBuilder.AlterColumn<byte>(
                name: "Priority",
                table: "Gifts",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Gifts",
                type: "bytea",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("27e3d323-0353-426c-a116-65be1f79dee6"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9177), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Music" },
                    { new Guid("2871e0e6-eb5d-4847-b5c9-f5497af2da4a"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9172), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Kitchen" },
                    { new Guid("3f277d59-89d1-4ccd-9f47-b2b147595389"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9169), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Sports" },
                    { new Guid("4ae1f5e4-2bdd-4d60-8eb7-b076588499c7"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9179), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Garden" },
                    { new Guid("52d1e842-48d3-4d19-86fb-fd2e39c8438e"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9173), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Experiences" },
                    { new Guid("5dc8868f-0c19-4a63-8010-95ea62fb7f69"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9167), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Books" },
                    { new Guid("6ecc1262-f1df-4cc6-b413-67e39670e1f3"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9171), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Jewelery" },
                    { new Guid("75f26310-6e32-44ca-a437-9f3a12496dd3"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9174), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Wellness" },
                    { new Guid("85f200a8-c008-4e04-ae4e-bbd4b2339788"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9168), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Personal care" },
                    { new Guid("90d84833-f12d-49f6-9e4d-c0b57c33cdf0"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9159), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Electronics" },
                    { new Guid("b2bc1de1-10ee-4aad-ade6-49f7551aa38d"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9178), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Office" },
                    { new Guid("e37866c6-b4c2-40b1-9f40-c32565987ece"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9154), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Home" },
                    { new Guid("ec21237a-5eef-4782-947d-e02af7579fab"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9158), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Fashion" },
                    { new Guid("ed27b314-032d-48d1-af7d-7280523d1246"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9180), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Gourmet" },
                    { new Guid("f1a9a3aa-d3af-41b4-8b57-e89000ec80fd"), new DateTimeOffset(new DateTime(2024, 10, 1, 9, 30, 12, 390, DateTimeKind.Unspecified).AddTicks(9170), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Toys" }
                });
        }
    }
}
