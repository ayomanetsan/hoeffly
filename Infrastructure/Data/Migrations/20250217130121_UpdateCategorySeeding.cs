using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategorySeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("0b26791d-bc33-43d6-be9e-7e3d2a604035"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8516), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Thanksgiving", 0 },
                    { new Guid("12a20ef1-b470-4ee7-ae35-6a9b9557e171"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8523), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Fashion", 1 },
                    { new Guid("1c9c49ec-0d78-4344-9742-09d4c9cd3b9f"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8505), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Valentine's Day", 0 },
                    { new Guid("22a5bc20-fb4c-47fd-ad6e-141d1b2fa5e5"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8526), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Personal Care", 1 },
                    { new Guid("2d7bcea3-f1f1-484c-99cf-aa6469fa3c94"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8506), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Wedding", 0 },
                    { new Guid("2e2714fd-65cf-4787-acf5-a8827bd181dc"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8527), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Sports", 1 },
                    { new Guid("313fa223-734e-4f13-839d-e48bb1f50fac"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8528), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Toys", 1 },
                    { new Guid("392eb906-399b-466c-83cc-c4e5bf0b9817"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8503), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Anniversary", 0 },
                    { new Guid("3be45b0f-29a4-4a37-aec8-95b05d2d90b0"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8513), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Easter", 0 },
                    { new Guid("4026bb5d-9408-42a9-8ebd-316861a70c3e"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8529), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Jewelry", 1 },
                    { new Guid("432d4160-a5f7-4ae2-b69a-179e238f34fc"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8508), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Graduation", 0 },
                    { new Guid("470a612c-c302-4f55-97e2-0c5f31d28d72"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8518), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Summer Vacation", 0 },
                    { new Guid("50d5c9c3-58b8-49ea-a311-b9b38cfd4a73"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8524), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Electronics", 1 },
                    { new Guid("6085bf63-76fe-4922-8c11-2f58e52b0e83"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8507), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Baby Shower", 0 },
                    { new Guid("61497b4e-d9fb-46c4-8ebe-e2f08b5e38eb"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8531), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Kitchen", 1 },
                    { new Guid("62b2eb49-5804-43f2-a504-8142e92948c2"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8517), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Black Friday", 0 },
                    { new Guid("62f4e9ac-aeb4-4a54-847d-f2183c45a86e"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8538), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Garden", 1 },
                    { new Guid("63209aaa-4d62-4c22-bce4-0e12e0b16351"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8496), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "New Year", 0 },
                    { new Guid("7940f4a4-1dbb-405d-803b-bd8fb9863989"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8520), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Home", 1 },
                    { new Guid("9008dd1f-f802-4dce-94de-700141a222ca"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8511), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Housewarming", 0 },
                    { new Guid("9107c182-c0e0-4c16-a0a6-8a26f935529c"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8500), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Birthday", 0 },
                    { new Guid("a706d1ca-ba11-4983-8502-681dfe8397ef"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8512), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Retirement", 0 },
                    { new Guid("a82dafd3-9ce7-4abc-b661-9b14231c5f73"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8502), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Christmas", 0 },
                    { new Guid("aa288927-5460-434c-aee2-42f34877f69a"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8537), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Office", 1 },
                    { new Guid("ce5365ec-2ebb-4e77-adb0-fb917170e2cb"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8536), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Music", 1 },
                    { new Guid("d0d84232-652b-485c-ace2-999e18c3074b"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8539), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Gourmet", 1 },
                    { new Guid("d1b3a75a-0e79-4cda-bf51-31e2fdb2d738"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8525), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Books", 1 },
                    { new Guid("dbbe114d-6b94-4e85-bded-52a0ffb617e3"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8533), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Experiences", 1 },
                    { new Guid("f608058f-b075-4dea-a452-4a88002ddb55"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8534), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Wellness", 1 },
                    { new Guid("fe5b7096-74e7-4965-a075-c4eeb1c692dc"), new DateTimeOffset(new DateTime(2025, 2, 17, 13, 1, 20, 507, DateTimeKind.Unspecified).AddTicks(8514), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Halloween", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b26791d-bc33-43d6-be9e-7e3d2a604035"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("12a20ef1-b470-4ee7-ae35-6a9b9557e171"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c9c49ec-0d78-4344-9742-09d4c9cd3b9f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22a5bc20-fb4c-47fd-ad6e-141d1b2fa5e5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2d7bcea3-f1f1-484c-99cf-aa6469fa3c94"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2e2714fd-65cf-4787-acf5-a8827bd181dc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("313fa223-734e-4f13-839d-e48bb1f50fac"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("392eb906-399b-466c-83cc-c4e5bf0b9817"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3be45b0f-29a4-4a37-aec8-95b05d2d90b0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4026bb5d-9408-42a9-8ebd-316861a70c3e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("432d4160-a5f7-4ae2-b69a-179e238f34fc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("470a612c-c302-4f55-97e2-0c5f31d28d72"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("50d5c9c3-58b8-49ea-a311-b9b38cfd4a73"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6085bf63-76fe-4922-8c11-2f58e52b0e83"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("61497b4e-d9fb-46c4-8ebe-e2f08b5e38eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("62b2eb49-5804-43f2-a504-8142e92948c2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("62f4e9ac-aeb4-4a54-847d-f2183c45a86e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63209aaa-4d62-4c22-bce4-0e12e0b16351"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7940f4a4-1dbb-405d-803b-bd8fb9863989"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9008dd1f-f802-4dce-94de-700141a222ca"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9107c182-c0e0-4c16-a0a6-8a26f935529c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a706d1ca-ba11-4983-8502-681dfe8397ef"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a82dafd3-9ce7-4abc-b661-9b14231c5f73"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa288927-5460-434c-aee2-42f34877f69a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce5365ec-2ebb-4e77-adb0-fb917170e2cb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d0d84232-652b-485c-ace2-999e18c3074b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d1b3a75a-0e79-4cda-bf51-31e2fdb2d738"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dbbe114d-6b94-4e85-bded-52a0ffb617e3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f608058f-b075-4dea-a452-4a88002ddb55"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe5b7096-74e7-4965-a075-c4eeb1c692dc"));

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
        }
    }
}
