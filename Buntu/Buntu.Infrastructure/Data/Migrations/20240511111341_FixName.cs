using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buntu.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersIfnormations_AspNetUsers_UserId",
                table: "UsersIfnormations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersIfnormations",
                table: "UsersIfnormations");

            migrationBuilder.RenameTable(
                name: "UsersIfnormations",
                newName: "UsersInformations");

            migrationBuilder.RenameIndex(
                name: "IX_UsersIfnormations_UserId",
                table: "UsersInformations",
                newName: "IX_UsersInformations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInformations",
                table: "UsersInformations",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInformations_AspNetUsers_UserId",
                table: "UsersInformations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInformations_AspNetUsers_UserId",
                table: "UsersInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInformations",
                table: "UsersInformations");

            migrationBuilder.RenameTable(
                name: "UsersInformations",
                newName: "UsersIfnormations");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInformations_UserId",
                table: "UsersIfnormations",
                newName: "IX_UsersIfnormations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersIfnormations",
                table: "UsersIfnormations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68106d58-f54a-409c-92da-9184a75d55f7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f65f9cd6-584d-423b-a1a8-68ad4017ec6c", "AQAAAAIAAYagAAAAEHX9fRvY4XKIEx6O560SZHZiQAiMIjY0lxijt5Gh1j8aKAf2lOZlj/1PvFr3azWKpg==", "932a5117-9306-4faa-83da-e5d2977d38ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd4b588-917f-4634-8142-08f54ee760a1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df2b787a-2a17-451e-9b06-7546cf82f4f0", "AQAAAAIAAYagAAAAELo/AETQ2AHM6/bpqNOfpQ79Leb+SXMAi/R33yMGUf9QG0nLYF5UXm8yuX2PN0NfaA==", "a0484b71-3270-4313-add4-f96635004630" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersIfnormations_AspNetUsers_UserId",
                table: "UsersIfnormations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
