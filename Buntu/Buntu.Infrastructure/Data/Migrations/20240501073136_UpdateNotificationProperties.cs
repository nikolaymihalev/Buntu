using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buntu.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNotificationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelatedId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Related type identifier (like, comment, follow)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68106d58-f54a-409c-92da-9184a75d55f7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af9e0c47-3909-41f7-a241-60e8f07e72f1", "AQAAAAIAAYagAAAAEKOtlldtF/WzM/1OWuecgJGW+MIw3BjwCnCV39o+kwht42N/LPIfZ+VLexgm9jswcg==", "2c77f634-c826-41bf-b481-ed2ef8d22e2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd4b588-917f-4634-8142-08f54ee760a1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a6d1568-c318-4bfc-ad2a-c64361e82a45", "AQAAAAIAAYagAAAAEF5Gqw6afR8kYoQVoEs+3sxaXUZOiVxGsgWp2ygFgLGYD6mGUeuxri6h7Xzjw0snZA==", "e0026ab7-2c97-4121-88ce-7efda121b71d" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "RelatedId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "RelatedId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedId",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68106d58-f54a-409c-92da-9184a75d55f7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "111aabae-4171-40b2-ad10-c79ac4dc3fa3", "AQAAAAIAAYagAAAAEKzegk56U2pywoqTh4B8so3Id6ME3DDqisFCyx+tFbL/NGLVlb4oYATTyPXGnRi64w==", "a341829a-60b7-4b84-ab2c-61939d9f4f2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd4b588-917f-4634-8142-08f54ee760a1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fa23d2a-d27f-415c-8ea9-ee962c6d9f35", "AQAAAAIAAYagAAAAEJk+Tz2wALyYZynAwJ3QQJoWA4X2wk5+WJUsPun8FTwVH4gODU97/G1FV1toQDekWA==", "8cc192de-2565-4ccf-9ac7-1eadbc82b0a5" });
        }
    }
}
