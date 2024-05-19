using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buntu.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyInNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherUserId",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Other user identifier");

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

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "OtherUserId",
                value: "68106d58-f54a-409c-92da-9184a75d55f7");

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "OtherUserId",
                value: "bbd4b588-917f-4634-8142-08f54ee760a1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherUserId",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68106d58-f54a-409c-92da-9184a75d55f7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d0f7074-5df4-42ba-9208-d1aebedce033", "AQAAAAIAAYagAAAAEMcLWmpLsCBkc9YQscG/bHw44x108NbwWi31hoNmUAA067ZDqBzKnTQYKW1zK6BTKw==", "ec62bc4b-0aa9-448d-841a-3f4f518d2f03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd4b588-917f-4634-8142-08f54ee760a1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac623aa1-da67-43e7-b9b0-e0ff2f1355df", "AQAAAAIAAYagAAAAELGoWpq5/q9tEUwZ4hn4PPrVHH6crPlDCwgs2m6z09+Pe9v8vng0T4prQmz4I628CQ==", "9a1b0133-fa7c-4810-99c0-2671e0626f3b" });
        }
    }
}
