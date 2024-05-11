using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buntu.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersInormations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Information identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User gender"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "User date of birth"),
                    Work = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User work"),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User university degree"),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User school degree"),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User residence"),
                    Relationships = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User relationships")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInormations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInormations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "General information about user");

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

            migrationBuilder.CreateIndex(
                name: "IX_UsersInormations_UserId",
                table: "UsersInormations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersInormations");

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
        }
    }
}
