using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Metafar.ATM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TransactionType",
                columns: new[] { "Id", "TransactionType" },
                values: new object[,]
                {
                    { new Guid("4142de52-7053-478b-804b-b6bfa4217f1e"), "DEPOSIT" },
                    { new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b"), "WITHDRAW" },
                    { new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18"), "CHECKBALANCE" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { new Guid("4c7c5b69-d92e-44c4-8524-abe0a229779a"), "Denzel Washington" },
                    { new Guid("774b7fa6-50fd-4abc-80f7-b2000b349c23"), "Johnny Depp" },
                    { new Guid("b3b6f399-4993-42de-8772-9ae8a732504d"), "John Smith" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountNumber", "Balance", "Blocked", "CardNumber", "FailedLoginAttempts", "MaxLoginAttempts", "Pin", "UserId" },
                values: new object[,]
                {
                    { "33294946862678791686", 1000m, false, "3716774812566768", (byte)0, (byte)4, "1111", new Guid("b3b6f399-4993-42de-8772-9ae8a732504d") },
                    { "57580242539941657006", 50000m, false, "3716745896852693", (byte)0, (byte)4, "5555", new Guid("774b7fa6-50fd-4abc-80f7-b2000b349c23") },
                    { "68983408175964235159", 100000m, false, "3716485698515478", (byte)0, (byte)4, "9999", new Guid("4c7c5b69-d92e-44c4-8524-abe0a229779a") }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "AccountNumber", "Amount", "TransactionDate", "TransactionTypeId" },
                values: new object[,]
                {
                    { new Guid("00dfb276-131f-4698-ea69-08dcc294f655"), "57580242539941657006", 1000m, new DateTime(2024, 8, 3, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3154), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("05334834-9da0-48c5-8fae-406d030e2bbd"), "68983408175964235159", 150m, new DateTime(2024, 8, 13, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3214), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("0cf6bf42-cc5b-48ab-dfde-08dcc2959449"), "57580242539941657006", 150m, new DateTime(2024, 8, 2, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3148), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("0da4c8ab-9b1f-4856-a168-7f7299c50bb9"), "57580242539941657006", 600m, new DateTime(2024, 8, 8, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3169), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("0eacca6e-2b4c-4291-a4d0-3bba1a8c5813"), "57580242539941657006", 0m, new DateTime(2024, 8, 10, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3175), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("122cb712-1867-4ac6-9e83-daef582e7f3f"), "57580242539941657006", 0m, new DateTime(2024, 8, 6, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3165), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("132c5914-10bf-46de-b1fe-6ec966759442"), "33294946862678791686", 100m, new DateTime(2024, 8, 3, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3131), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("18b39627-c344-4b86-87a5-9d19b105426c"), "57580242539941657006", 6000m, new DateTime(2024, 8, 9, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3173), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("1ba6b48d-d481-49e0-9d7e-605ec6a7914a"), "57580242539941657006", 500m, new DateTime(2024, 8, 5, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3162), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("28257e7c-4b50-4f57-ea6a-08dcc294f655"), "57580242539941657006", 0m, new DateTime(2024, 8, 3, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3152), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("2ac726dd-ef3a-4e78-893d-e142b2d8f3d8"), "57580242539941657006", 10000m, new DateTime(2024, 8, 13, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3185), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("2bd503e2-692d-4506-8b47-3452822b986b"), "68983408175964235159", 0m, new DateTime(2024, 8, 6, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3194), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("2cc64ccd-78fa-47da-a0cc-bca20b3d803c"), "68983408175964235159", 0m, new DateTime(2024, 8, 2, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3189), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("2d32e29e-d95f-4a34-9498-369c6b0353e5"), "68983408175964235159", 150m, new DateTime(2024, 8, 8, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3202), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("346ba847-196a-4952-a169-7d45e48ca3ae"), "57580242539941657006", 0m, new DateTime(2024, 8, 11, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3181), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("4aed7169-34eb-42d4-9af9-5891dfa23d1a"), "57580242539941657006", 0m, new DateTime(2024, 8, 7, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3167), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("4dc2abee-71b1-4b56-84e5-b0bb71a87ea9"), "33294946862678791686", 750m, new DateTime(2024, 8, 5, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3137), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("4f89cc9e-ac64-4f02-b661-d801702c3e00"), "57580242539941657006", 1000m, new DateTime(2024, 8, 10, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3177), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("52945988-3e34-440f-a8ce-add7265feb3f"), "68983408175964235159", 500m, new DateTime(2024, 8, 14, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3217), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("54442d6f-80f0-4e19-90d5-e6ca1198c891"), "57580242539941657006", 2100m, new DateTime(2024, 8, 5, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3160), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("5cbe5a42-2914-4a4d-9895-77ad9ee3c409"), "57580242539941657006", 0m, new DateTime(2024, 8, 14, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3187), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("652d4f5f-c122-4630-a14c-7cce1855949c"), "57580242539941657006", 10000m, new DateTime(2024, 8, 6, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3163), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("65760a63-26b8-4b6c-9368-dc3f29e5fb98"), "33294946862678791686", 0m, new DateTime(2024, 8, 4, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3134), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("677ae7d1-f93c-412f-b944-0aaad2580f3a"), "68983408175964235159", 5700m, new DateTime(2024, 8, 9, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3206), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("6883834d-a4df-414c-a8bd-ea658079d4c8"), "57580242539941657006", 5000m, new DateTime(2024, 8, 12, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3183), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("6a4da6ac-8cd6-4c53-a96a-af1525fddfb0"), "68983408175964235159", 150m, new DateTime(2024, 8, 11, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3210), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("7bc2ab9f-b47f-4fb1-ac0b-c905accbfef6"), "68983408175964235159", 100m, new DateTime(2024, 8, 3, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3190), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("7d0e15c9-de77-4a61-8294-d4eb23d2cd7c"), "33294946862678791686", 500m, new DateTime(2024, 8, 7, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3144), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("8def9510-88b2-4ebf-ba85-6b73cd2a2356"), "68983408175964235159", 150m, new DateTime(2024, 8, 4, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3192), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("99891c4a-d4b1-4dca-b865-7ae0b81927cc"), "68983408175964235159", 0m, new DateTime(2024, 8, 11, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3212), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("9b32cebc-6e82-4481-9719-8fb989dbc89f"), "57580242539941657006", 0m, new DateTime(2024, 8, 5, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3158), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("a199af2c-0d5b-4bdd-b74e-1ceba5afd680"), "68983408175964235159", 100m, new DateTime(2024, 8, 10, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3208), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("a19e51bb-d427-4911-bb00-a16bddcf7ed1"), "33294946862678791686", 100m, new DateTime(2024, 8, 2, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3129), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("a8701937-e4ff-4330-8e09-eb93ee884a3f"), "33294946862678791686", 0m, new DateTime(2024, 8, 8, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3146), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("b98c3d44-d31b-4dd4-a90b-b4f7a94f55d6"), "33294946862678791686", 50m, new DateTime(2024, 8, 2, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3111), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("c1634965-4447-4caf-b2fb-77d4a461a139"), "57580242539941657006", 500m, new DateTime(2024, 8, 4, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3156), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("c4179123-bedd-4f8e-9c78-b4e30b2d4cbe"), "57580242539941657006", 0m, new DateTime(2024, 8, 8, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3171), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("c660d4f4-539d-442e-acdb-4ac5e33611bf"), "33294946862678791686", 2000m, new DateTime(2024, 8, 5, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3140), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("c8937602-d923-47a4-dfdd-08dcc2959449"), "57580242539941657006", 0m, new DateTime(2024, 8, 2, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3150), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("d0e74669-040d-4f99-8e71-f58db535803d"), "68983408175964235159", 7000m, new DateTime(2024, 8, 13, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3215), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("d74f7fa1-fbf4-4516-9cf8-05215487a55a"), "68983408175964235159", 150m, new DateTime(2024, 8, 9, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3204), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("d7b96d01-fdaf-43f6-97d5-fd0bba0941dc"), "68983408175964235159", 100m, new DateTime(2024, 8, 8, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3200), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("d8e52a48-70ea-44a2-b8a8-325d5120aed9"), "68983408175964235159", 5700m, new DateTime(2024, 8, 7, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3196), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("db10b31f-3641-473c-b238-0bd6d3a883a5"), "33294946862678791686", 0m, new DateTime(2024, 8, 6, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3142), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("dfc616d7-dd3e-4a79-99b8-fce3c4afd480"), "68983408175964235159", 0m, new DateTime(2024, 8, 8, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3198), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("f45e00c6-7d24-48d1-9451-8d82d4a33079"), "68983408175964235159", 150m, new DateTime(2024, 8, 15, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3219), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("f4e41662-9661-40a8-93ab-54c921b050b5"), "68983408175964235159", 5700m, new DateTime(2024, 8, 21, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3225), new Guid("4142de52-7053-478b-804b-b6bfa4217f1e") },
                    { new Guid("f53b4c16-6e95-4cb7-b921-18b1e99e6d79"), "68983408175964235159", 150m, new DateTime(2024, 8, 16, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3221), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") },
                    { new Guid("f9ae8ced-fe3e-45fe-b871-ede0d75a2c5f"), "68983408175964235159", 0m, new DateTime(2024, 8, 18, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3223), new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18") },
                    { new Guid("fa36a108-245d-4602-9b97-886354e2971e"), "57580242539941657006", 21000m, new DateTime(2024, 8, 11, 9, 8, 8, 419, DateTimeKind.Local).AddTicks(3179), new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("00dfb276-131f-4698-ea69-08dcc294f655"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("05334834-9da0-48c5-8fae-406d030e2bbd"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("0cf6bf42-cc5b-48ab-dfde-08dcc2959449"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("0da4c8ab-9b1f-4856-a168-7f7299c50bb9"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("0eacca6e-2b4c-4291-a4d0-3bba1a8c5813"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("122cb712-1867-4ac6-9e83-daef582e7f3f"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("132c5914-10bf-46de-b1fe-6ec966759442"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("18b39627-c344-4b86-87a5-9d19b105426c"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("1ba6b48d-d481-49e0-9d7e-605ec6a7914a"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("28257e7c-4b50-4f57-ea6a-08dcc294f655"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("2ac726dd-ef3a-4e78-893d-e142b2d8f3d8"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("2bd503e2-692d-4506-8b47-3452822b986b"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("2cc64ccd-78fa-47da-a0cc-bca20b3d803c"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("2d32e29e-d95f-4a34-9498-369c6b0353e5"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("346ba847-196a-4952-a169-7d45e48ca3ae"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("4aed7169-34eb-42d4-9af9-5891dfa23d1a"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("4dc2abee-71b1-4b56-84e5-b0bb71a87ea9"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("4f89cc9e-ac64-4f02-b661-d801702c3e00"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("52945988-3e34-440f-a8ce-add7265feb3f"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("54442d6f-80f0-4e19-90d5-e6ca1198c891"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("5cbe5a42-2914-4a4d-9895-77ad9ee3c409"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("652d4f5f-c122-4630-a14c-7cce1855949c"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("65760a63-26b8-4b6c-9368-dc3f29e5fb98"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("677ae7d1-f93c-412f-b944-0aaad2580f3a"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("6883834d-a4df-414c-a8bd-ea658079d4c8"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("6a4da6ac-8cd6-4c53-a96a-af1525fddfb0"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("7bc2ab9f-b47f-4fb1-ac0b-c905accbfef6"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("7d0e15c9-de77-4a61-8294-d4eb23d2cd7c"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("8def9510-88b2-4ebf-ba85-6b73cd2a2356"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("99891c4a-d4b1-4dca-b865-7ae0b81927cc"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("9b32cebc-6e82-4481-9719-8fb989dbc89f"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("a199af2c-0d5b-4bdd-b74e-1ceba5afd680"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("a19e51bb-d427-4911-bb00-a16bddcf7ed1"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("a8701937-e4ff-4330-8e09-eb93ee884a3f"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("b98c3d44-d31b-4dd4-a90b-b4f7a94f55d6"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("c1634965-4447-4caf-b2fb-77d4a461a139"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("c4179123-bedd-4f8e-9c78-b4e30b2d4cbe"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("c660d4f4-539d-442e-acdb-4ac5e33611bf"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("c8937602-d923-47a4-dfdd-08dcc2959449"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("d0e74669-040d-4f99-8e71-f58db535803d"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("d74f7fa1-fbf4-4516-9cf8-05215487a55a"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("d7b96d01-fdaf-43f6-97d5-fd0bba0941dc"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("d8e52a48-70ea-44a2-b8a8-325d5120aed9"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("db10b31f-3641-473c-b238-0bd6d3a883a5"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("dfc616d7-dd3e-4a79-99b8-fce3c4afd480"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("f45e00c6-7d24-48d1-9451-8d82d4a33079"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("f4e41662-9661-40a8-93ab-54c921b050b5"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("f53b4c16-6e95-4cb7-b921-18b1e99e6d79"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("f9ae8ced-fe3e-45fe-b871-ede0d75a2c5f"));

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("fa36a108-245d-4602-9b97-886354e2971e"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountNumber",
                keyValue: "33294946862678791686");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountNumber",
                keyValue: "57580242539941657006");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountNumber",
                keyValue: "68983408175964235159");

            migrationBuilder.DeleteData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: new Guid("4142de52-7053-478b-804b-b6bfa4217f1e"));

            migrationBuilder.DeleteData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: new Guid("9ec43875-4446-4f52-8daa-967c2d938c7b"));

            migrationBuilder.DeleteData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: new Guid("f79ca38a-d81e-4c51-9b5f-741626a6ba18"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4c7c5b69-d92e-44c4-8524-abe0a229779a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("774b7fa6-50fd-4abc-80f7-b2000b349c23"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b3b6f399-4993-42de-8772-9ae8a732504d"));
        }
    }
}
