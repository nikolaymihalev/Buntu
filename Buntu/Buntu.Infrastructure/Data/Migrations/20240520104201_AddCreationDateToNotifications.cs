using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buntu.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCreationDateToNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Notification creation date");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68106d58-f54a-409c-92da-9184a75d55f7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b834aedb-d516-4c96-b9c1-a286d3259938", "AQAAAAIAAYagAAAAEDUB4HiwBptI2hxJ7MUuv8tvyXOvTNs+h2csgzXzMgyguag9SjsUXtXT2oAdeBY/LA==", "6540983d-f41f-4df5-b74d-04262356d88f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd4b588-917f-4634-8142-08f54ee760a1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06988048-e637-4ed4-9084-e095fd997eb5", "AQAAAAIAAYagAAAAEIP3TyP7aD5MTcNa8KquTucvorlCysHFmc6eym+KjbMRuLivWr6mz6cgcfqt9orDQA==", "14e53d82-9891-46f9-9840-08cbaf684e38" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68106d58-f54a-409c-92da-9184a75d55f7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb35cb26-73be-444d-867f-378ac74987f6", "AQAAAAIAAYagAAAAEGyvLtmCAQVlXY0aMjQm3Il8ZTJ6dT7XgdyeNeUFl07ZCVkkuCpVxvkQLbXvJ7FcWw==", "6c21da43-c17a-49c1-8003-6b8a4f17795f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd4b588-917f-4634-8142-08f54ee760a1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "118a2d13-91f4-486a-83a5-7283b492fc92", "AQAAAAIAAYagAAAAEM9v0H6G1ll/nz16098FKcfZ5pK0uYy1ieFfDGspysEVIWWuSSsGXqDem9M2F/Xnsw==", "8aa09b15-d22b-4b06-bbed-2b571fde6ec6" });
        }
    }
}
