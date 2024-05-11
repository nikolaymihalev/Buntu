using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Buntu.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInormations_AspNetUsers_UserId",
                table: "UsersInormations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInormations",
                table: "UsersInormations");

            migrationBuilder.RenameTable(
                name: "UsersInormations",
                newName: "UsersIfnormations");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInormations_UserId",
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

            migrationBuilder.InsertData(
                table: "UsersIfnormations",
                columns: new[] { "Id", "BirthDate", "Gender", "Relationships", "Residence", "School", "University", "UserId", "Work" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "", "", "", "", "bbd4b588-917f-4634-8142-08f54ee760a1", "" },
                    { 2, new DateTime(1996, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "", "", "", "", "68106d58-f54a-409c-92da-9184a75d55f7", "" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersIfnormations_AspNetUsers_UserId",
                table: "UsersIfnormations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersIfnormations_AspNetUsers_UserId",
                table: "UsersIfnormations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersIfnormations",
                table: "UsersIfnormations");

            migrationBuilder.DeleteData(
                table: "UsersIfnormations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UsersIfnormations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "UsersIfnormations",
                newName: "UsersInormations");

            migrationBuilder.RenameIndex(
                name: "IX_UsersIfnormations_UserId",
                table: "UsersInormations",
                newName: "IX_UsersInormations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInormations",
                table: "UsersInormations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68106d58-f54a-409c-92da-9184a75d55f7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1225b29-4190-45e7-9cf9-047219ce2ecb", "AQAAAAIAAYagAAAAEBYtkFar7sGNndOMOj70CPWHXMNIWlcN93KyL1Dvl8HBycdI4Nk9RYfHDSihRdq/Cw==", "28642ffe-82cb-4eda-ab26-5659fe028c37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd4b588-917f-4634-8142-08f54ee760a1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ef578c8-310e-4366-996d-02d41654b82e", "AQAAAAIAAYagAAAAEGfyB0nn54OWMgyQg4RHFTAFoV7TAx4s1RUjlWWxJw++HweBVDMAqZXfDOX6lw+Jjg==", "6660e58d-f28d-4271-9c1b-568d6a746756" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInormations_AspNetUsers_UserId",
                table: "UsersInormations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
