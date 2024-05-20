using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fullstackbackend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isMature = table.Column<bool>(type: "bit", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FavoritedInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritedInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FriendInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FriendId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MemberInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    ClubId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PostInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CommentInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentInfo_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikesInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LikedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikesInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikesInfo_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClubInfo",
                columns: new[] { "ID", "ClubName", "DateCreated", "Description", "Image", "IsDeleted", "IsPublic", "LeaderId", "isMature" },
                values: new object[,]
                {
                    { 1, "Jujutsu Lovers<3", "2024-04-05 09:10:11", "Gege Akutami hates his readers!", "https://p325k7wa.twic.pics/high/jujutsu-kaisen/jujutsu-kaisen-cursed-clash/00-page-setup/JJK-header-mobile2.jpg?twic=v1/resize=760/step=10/quality=80", false, true, 1, false },
                    { 2, "Villainess Arc", "2024-04-06 09:10:11", "strong and evil FLs lol", "https://static.animecorner.me/2022/09/villainess-manhwa-manga-novel-1024x576.png", false, true, 1, false },
                    { 3, "Psychological Manhwas", "2024-04-10 09:10:11", "scared but i cant stop reading...", "https://static1.srcdn.com/wordpress/wp-content/uploads/2023/10/best-horror-manhwa-featured-image.jpg", false, true, 3, true },
                    { 4, "Best Webtoons", "2024-04-11 09:10:11", "Talk about Webtoons!", "https://academychronicle.com/wp-content/uploads/2021/03/Webtoons-900x472.jpg", false, true, 3, false },
                    { 5, "Solo Leveling!", "2024-04-11 08:10:11", "Rave about Solo Leveling!!!", "https://static1.srcdn.com/wordpress/wp-content/uploads/2023/12/solo-leveling.jpg", false, true, 3, false },
                    { 6, "Shoujo 4ever ", "2024-04-09 10:10:11", "Shoujo debatably has the best mangas!", "https://static1.cbrimages.com/wordpress/wp-content/uploads/2022/09/shoujo-male-leads.jpg", false, true, 2, false }
                });

            migrationBuilder.InsertData(
                table: "PostInfo",
                columns: new[] { "ID", "Category", "ClubId", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "Tags", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Spoilers", 1, "2024-04-05", "2024-04-06", "I can't believe that happened! And off-screened too... TT", null, false, "CH.223,", "What happed to Gojo can't be real, right!?", 1 },
                    { 2, "Discussion", 1, "2024-04-06", "2024-04-07", null, null, false, null, "Who is your guys' favorite character that is currently ALIVE!?", 1 },
                    { 3, "Discussion", 1, "2024-04-08", null, "Why is Gege Akutami killing off EVERYBODY?????", null, true, null, "I got some words to say to Gege...", 2 }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "ID", "Age", "FirstName", "Hash", "LastName", "ProfilePic", "Salt", "Username" },
                values: new object[,]
                {
                    { 1, 24, "halley", "PSFlappnv8ftPMmBorSedBnGjELhA2h5ikV9PAWCYYAa50jVrpoQXpHXJbftdCY6NwA7U0HxCtBhHFVnDFZxsyR8TTrd8oGEdBkruklbdptSNvowrpq2qpugljyJVOXbBafuSicn3GA62uRIUa5CSaEpjRd1gG+puZmTse/nYAyjCmFI5cOhuz1aaQe3/uHdtuKppuR3uJOcQrUlv1dVNzsBt1Y59YIVX3dzMx3BGSuGnnjJq6wTAFxl/Z20pD7xI3GmpvMZ3yjvA2MOTDaBifakzGZ8bnrkM3GPjXyO5juBiYsZqbXRLIYX/V+BHPXcjK6DCp9Hqaqpjz5Vs8WT4w==", "pham", null, "NFYMofXzkPjSPPBVSiV2o2YfemXRK5gXO5D6qpq3Q4omSN2QWRZ9okLKHFEI5x5/HehWFpVa3IB6Se2rTXFz5w==", "halley" },
                    { 2, 26, "sinatha", "5W7eYQVwy46nN1Kbw1xD6Joia04j9fKQ34xmp/HXMl9ecr7LZKLdnbabRbhKjmivAGKS3MFgY+63+z3jwyCvmrpzGFLW2r/e2EAlA3KJQyiCksMQOqGHTqEyRmLTbERhR4OctvM3ayoIgrCPssbZY39Ul0sJ3/9L8YxWoQL8IWGGjk4elh0L44fLy66O6yAN5FTZ7yXVUYK78Zj1dDAc8t/UPL3WZQFGBQvKXjWg+bNUlDAOQ9cvSL7DaIE9iLUQyobabQXNvGR610ECuq6PhQB2exC+dgKp9NPYuDLBrZvQNAunjBARm0Uce4w60xiam3HVeZqsEhZBhkqgxEEMDQ==", "chin", null, "NxLWGIL6vGU220txp/GXGs144iMqXkQkRSuNX/ORZHGC/cxVcMEDNOuK+7w/3lxP6mAUFFXCD+cVdypK2TmY4g==", "sinatha" },
                    { 3, 22, "avery", "xBp/Z30KHEtPWYcgo7MrufRCSvgrtKBZ5xQqSTIn5ghTG5o+vj2bnrwalRpI3SbLIgT1XlGzRPOtjx4Aka7E8NPPtreqDLrcz0dc4OS4e4BGZ1SDhByokm0I3SOUJX3KKwbW3m4zGgkD6ctUGLqcrrmHnDsm3WN+tmGaW5xnFadlr+InxME4BdgVmB8jreLyMx60sFUXvNdmGKPC/jHA270YusRCGH2CljHKsL2moZWI/xDABUm7WaBKorrO2B22hkcH3tHNJcdkKjhHG5OzFTSj074wT7EaB5Spprqq2Cu7hRfZSfNe8Igc0ySAMojxk0jRYm+3nADHz2/GsFlwJQ==", "hillstrom", null, "2cwSsNNBcTbUB9ut3H4KOQLNCsXIgD79BHozo5sYBfi0PUJd4TozcI8UM+xkT3TDIxrP/SwJFzBSqKQbR2RZYA==", "avery" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentInfo_UserId",
                table: "CommentInfo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikesInfo_UserId",
                table: "LikesInfo",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubInfo");

            migrationBuilder.DropTable(
                name: "CommentInfo");

            migrationBuilder.DropTable(
                name: "FavoritedInfo");

            migrationBuilder.DropTable(
                name: "FriendInfo");

            migrationBuilder.DropTable(
                name: "LikesInfo");

            migrationBuilder.DropTable(
                name: "MemberInfo");

            migrationBuilder.DropTable(
                name: "NotificationInfo");

            migrationBuilder.DropTable(
                name: "PostInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
