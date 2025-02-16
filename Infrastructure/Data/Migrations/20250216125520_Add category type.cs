using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addcategorytype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Category",
                table: "Gifts");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Gifts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("2d9d79eb-fe08-4172-a744-60c945cd4d0b"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(250), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Sports", 0 },
                    { new Guid("46d28758-2649-4f0a-b1d4-4d8b6eb2f0f5"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(280), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Experiences", 0 },
                    { new Guid("48780c78-521d-4646-ad0c-3c4c0ae97f1d"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(250), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Personal care", 0 },
                    { new Guid("5bbfb35e-06af-41be-8032-bd16eba7522e"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(240), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Electronics", 0 },
                    { new Guid("5d34c8df-e44b-45de-9ffa-32edde84f9d8"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(260), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Toys", 0 },
                    { new Guid("63bddd46-52d5-41ad-903f-61ec2d61e6fd"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(290), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Music", 0 },
                    { new Guid("7b81d838-9548-4914-be25-4e4297114e16"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(230), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Fashion", 0 },
                    { new Guid("7c29d54d-1b2b-4b03-8892-5add110bf7ac"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(270), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Jewelery", 0 },
                    { new Guid("8c8fbe4d-5374-4d0b-9b43-995e0e7546ca"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(230), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Home", 0 },
                    { new Guid("b38a6fcc-583b-43c6-8b7c-ad22f4b35e58"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(290), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Wellness", 0 },
                    { new Guid("b38c5e4d-eaa6-4357-bbce-4fa77402a7c6"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(310), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Gourmet", 0 },
                    { new Guid("bd2399d2-aeb4-4a0d-b198-e0e6da5e6221"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(280), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Kitchen", 0 },
                    { new Guid("c4ff2fa9-59a8-45db-acfd-f79d13eee761"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(300), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Garden", 0 },
                    { new Guid("ccef481f-32d6-46f0-a0dd-cba0d4da11ed"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(240), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Books", 0 },
                    { new Guid("ddef8584-fbec-4da8-abd6-6f58a74c7600"), new DateTimeOffset(new DateTime(2025, 2, 16, 12, 55, 19, 806, DateTimeKind.Unspecified).AddTicks(300), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Office", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_CategoryId",
                table: "Gifts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Categories_CategoryId",
                table: "Gifts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Categories_CategoryId",
                table: "Gifts");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_CategoryId",
                table: "Gifts");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2d9d79eb-fe08-4172-a744-60c945cd4d0b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("46d28758-2649-4f0a-b1d4-4d8b6eb2f0f5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("48780c78-521d-4646-ad0c-3c4c0ae97f1d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5bbfb35e-06af-41be-8032-bd16eba7522e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5d34c8df-e44b-45de-9ffa-32edde84f9d8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63bddd46-52d5-41ad-903f-61ec2d61e6fd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7b81d838-9548-4914-be25-4e4297114e16"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7c29d54d-1b2b-4b03-8892-5add110bf7ac"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8c8fbe4d-5374-4d0b-9b43-995e0e7546ca"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b38a6fcc-583b-43c6-8b7c-ad22f4b35e58"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b38c5e4d-eaa6-4357-bbce-4fa77402a7c6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bd2399d2-aeb4-4a0d-b198-e0e6da5e6221"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c4ff2fa9-59a8-45db-acfd-f79d13eee761"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ccef481f-32d6-46f0-a0dd-cba0d4da11ed"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ddef8584-fbec-4da8-abd6-6f58a74c7600"));

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Gifts",
                type: "text",
                nullable: false,
                defaultValue: "");

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
    }
}
