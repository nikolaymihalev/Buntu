using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buntu.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFavoritesPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "FavoritesPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Favorite post identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    PostId = table.Column<int>(type: "int", nullable: false, comment: "Post identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritesPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritesPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritesPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "User favorite post");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68106d58-f54a-409c-92da-9184a75d55f7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be333bfe-812c-42f6-b156-21708f0a5303", "AQAAAAIAAYagAAAAEFD/ydSoXLgYiUjCZtt6musPSc1z4A5fievOpT8gLZ3XzuMvyrfMgouTAzYZvCs9hQ==", "43c22096-a2ee-44a9-bd04-fc321e2d610e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd4b588-917f-4634-8142-08f54ee760a1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84057368-9cd5-40ea-a396-c87f4d8f003b", "AQAAAAIAAYagAAAAENo7qg99ZWgvGSLIx3eFh3LWHHXyZirUL1vir8y9Mrd4ImzyYby6+g7gIwNAJZvB7w==", "90131dd5-195d-4e1a-98e8-f1ea1c8f691d" });

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Variant",
                value: "Love");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritesPosts_PostId",
                table: "FavoritesPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritesPosts_UserId",
                table: "FavoritesPosts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritesPosts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Variant",
                value: "Heart");
        }
    }
}
