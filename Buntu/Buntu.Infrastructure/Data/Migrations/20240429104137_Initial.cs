using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buntu.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "User first name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "User last name");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImage",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                comment: "User profile image");

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Follow identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    FollowerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Follower user identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follows_AspNetUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follows_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Follow");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Notification identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Notification type"),
                    IsRead = table.Column<bool>(type: "bit", nullable: false, comment: "Is notification read")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Notification");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Post identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Post content"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Publisher identifier"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false, comment: "Post image"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Post status")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Post");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Comment identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Comment content"),
                    PostId = table.Column<int>(type: "int", nullable: false, comment: "Post identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Publication date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Comment");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Like identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false, comment: "Post identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    Variant = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Like variant")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Like");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowerId",
                table: "Follows",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_UserId",
                table: "Follows",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "AspNetUsers");
        }
    }
}
