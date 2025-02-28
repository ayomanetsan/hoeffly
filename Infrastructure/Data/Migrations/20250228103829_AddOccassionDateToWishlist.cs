using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOccassionDateToWishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "OccasionDate",
                table: "Wishlists",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("03fa2eec-1633-45be-a451-0e0fc393cb63"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2197), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Fashion", 1 },
                    { new Guid("161d54c4-28f8-4f42-bc97-fa54b8581387"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2088), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Birthday", 0 },
                    { new Guid("223e210e-ea14-45c8-af63-39ff778da06d"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2209), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Wellness", 1 },
                    { new Guid("2e9309e0-8e38-4481-b885-b8a43a399fd1"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2213), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Garden", 1 },
                    { new Guid("32511176-d6b1-457e-8dfd-1b6d0d93f860"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2091), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Anniversary", 0 },
                    { new Guid("3bd8dc06-4415-43ac-b090-2ac1d949e64a"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2203), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Toys", 1 },
                    { new Guid("56a07fbb-d072-404f-a116-84e5c87d64ad"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2104), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Halloween", 0 },
                    { new Guid("571b5b0a-e8a4-4d1d-a6b7-c1a9429395ad"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2214), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Gourmet", 1 },
                    { new Guid("5ddeaae8-ffc8-46bf-874d-c6dd8accc206"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2097), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Graduation", 0 },
                    { new Guid("6b6f4dbb-449f-42cb-91df-3366e8d87056"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2093), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Valentine's Day", 0 },
                    { new Guid("6bafbd75-95c1-4761-8438-76a1e4bb1408"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2208), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Experiences", 1 },
                    { new Guid("73561ebe-f844-44b0-80ca-37fd880755d0"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2194), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Home", 1 },
                    { new Guid("74a1d509-8247-4791-8df4-251406d9e1b7"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2205), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Kitchen", 1 },
                    { new Guid("774e0d1f-fc23-47ed-b2f9-62e107785a7b"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2200), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Books", 1 },
                    { new Guid("7c1b1d80-4bb2-4dd1-b55b-e7a9a921ecc1"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2189), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Thanksgiving", 0 },
                    { new Guid("83ff3e49-aef3-4ea1-9710-de7734291cc3"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2090), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Christmas", 0 },
                    { new Guid("91f00248-f704-4f78-bcfe-43fb77e1b098"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2100), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Housewarming", 0 },
                    { new Guid("9211dc0e-d365-47e6-97fb-a1f6c5803d52"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2191), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Summer Vacation", 0 },
                    { new Guid("995b8f1f-b095-4d4a-a915-833087a1b71a"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2201), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Personal Care", 1 },
                    { new Guid("9bb10b6b-a732-4949-a51c-f086fd54ff9e"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2198), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Electronics", 1 },
                    { new Guid("b6d7f7bf-547d-4c09-a81c-9884d254cd55"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2084), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "New Year", 0 },
                    { new Guid("b84deaee-6ea0-42bc-9e47-2e6c38515e8f"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2190), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Black Friday", 0 },
                    { new Guid("bc28e64e-0e38-403a-abc2-f1e35cbd427d"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2095), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Baby Shower", 0 },
                    { new Guid("d91687d9-aab8-4cc0-bd92-6174d9b87cb9"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2211), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Office", 1 },
                    { new Guid("de2e467f-1a69-4e24-a26a-b19b50d97f9d"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2101), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Retirement", 0 },
                    { new Guid("df73da5b-8cf8-4b20-88fc-8bd832305ca0"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2204), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Jewelry", 1 },
                    { new Guid("e35b0828-e531-4172-9762-bd774342209c"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2103), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Easter", 0 },
                    { new Guid("e7442212-4589-470c-9b4b-72a2f0074038"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2210), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Music", 1 },
                    { new Guid("eed028a0-ec99-4dfc-9ad8-2efec7f9b770"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2202), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Sports", 1 },
                    { new Guid("fdf292f4-419d-4abc-8952-bcf6e322c249"), new DateTimeOffset(new DateTime(2025, 2, 28, 10, 38, 28, 847, DateTimeKind.Unspecified).AddTicks(2094), new TimeSpan(0, 0, 0, 0, 0)), "system", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "system", "Wedding", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("03fa2eec-1633-45be-a451-0e0fc393cb63"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("161d54c4-28f8-4f42-bc97-fa54b8581387"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("223e210e-ea14-45c8-af63-39ff778da06d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2e9309e0-8e38-4481-b885-b8a43a399fd1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("32511176-d6b1-457e-8dfd-1b6d0d93f860"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3bd8dc06-4415-43ac-b090-2ac1d949e64a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("56a07fbb-d072-404f-a116-84e5c87d64ad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("571b5b0a-e8a4-4d1d-a6b7-c1a9429395ad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5ddeaae8-ffc8-46bf-874d-c6dd8accc206"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b6f4dbb-449f-42cb-91df-3366e8d87056"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6bafbd75-95c1-4761-8438-76a1e4bb1408"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("73561ebe-f844-44b0-80ca-37fd880755d0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("74a1d509-8247-4791-8df4-251406d9e1b7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("774e0d1f-fc23-47ed-b2f9-62e107785a7b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7c1b1d80-4bb2-4dd1-b55b-e7a9a921ecc1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("83ff3e49-aef3-4ea1-9710-de7734291cc3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91f00248-f704-4f78-bcfe-43fb77e1b098"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9211dc0e-d365-47e6-97fb-a1f6c5803d52"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("995b8f1f-b095-4d4a-a915-833087a1b71a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9bb10b6b-a732-4949-a51c-f086fd54ff9e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b6d7f7bf-547d-4c09-a81c-9884d254cd55"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b84deaee-6ea0-42bc-9e47-2e6c38515e8f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bc28e64e-0e38-403a-abc2-f1e35cbd427d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d91687d9-aab8-4cc0-bd92-6174d9b87cb9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("de2e467f-1a69-4e24-a26a-b19b50d97f9d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("df73da5b-8cf8-4b20-88fc-8bd832305ca0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e35b0828-e531-4172-9762-bd774342209c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e7442212-4589-470c-9b4b-72a2f0074038"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eed028a0-ec99-4dfc-9ad8-2efec7f9b770"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fdf292f4-419d-4abc-8952-bcf6e322c249"));

            migrationBuilder.DropColumn(
                name: "OccasionDate",
                table: "Wishlists");

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
    }
}
