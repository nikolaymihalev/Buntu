using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buntu.Data.Migrations
{
    /// <inheritdoc />
    public partial class PostContentConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Post content",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Post content");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Post content",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Post content");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68106d58-f54a-409c-92da-9184a75d55f7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6c28fd6-a70d-42c1-a75b-6d7407add52b", "AQAAAAIAAYagAAAAEFhmxPlB/4KXJxJaJTrDKJRMveW3JeGvLSumRDolxg6k5fgWffxBiTIX2VJR9HukUw==", "46f9566c-e0a1-4d77-8e39-8da58ae22e59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd4b588-917f-4634-8142-08f54ee760a1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a1a7663-5a7f-4dec-a088-67220a6616ef", "AQAAAAIAAYagAAAAEMyDnkBMwFObegFQDBNSYcwc1SVZDRL+BZ+W4oFjeoXJzAr7mFtgZQC7ZbKcB4uTfA==", "1dae8aed-179c-4d30-acf1-66532cb2e21d" });
        }
    }
}
