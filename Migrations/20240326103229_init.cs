using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstackbackend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentInfo_CommentInfo_CommentModelID",
                        column: x => x.CommentModelID,
                        principalTable: "CommentInfo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FriendList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClubInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaderId = table.Column<int>(type: "int", nullable: true),
                    ClubName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    Members = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClubInfo_UserInfo_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "UserInfo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FavoritesInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MangaId = table.Column<int>(type: "int", nullable: false),
                    InProgress = table.Column<bool>(type: "bit", nullable: false),
                    UserModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritesInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FavoritesInfo_UserInfo_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "UserInfo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PostInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ClubModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PostInfo_ClubInfo_ClubModelID",
                        column: x => x.ClubModelID,
                        principalTable: "ClubInfo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubInfo_UserModelID",
                table: "ClubInfo",
                column: "UserModelID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentInfo_CommentModelID",
                table: "CommentInfo",
                column: "CommentModelID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritesInfo_UserModelID",
                table: "FavoritesInfo",
                column: "UserModelID");

            migrationBuilder.CreateIndex(
                name: "IX_PostInfo_ClubModelID",
                table: "PostInfo",
                column: "ClubModelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentInfo");

            migrationBuilder.DropTable(
                name: "FavoritesInfo");

            migrationBuilder.DropTable(
                name: "PostInfo");

            migrationBuilder.DropTable(
                name: "ClubInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
