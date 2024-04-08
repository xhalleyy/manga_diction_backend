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
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CommentInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FavoritesInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MangaId = table.Column<int>(type: "int", nullable: false),
                    InProgress = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritesInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FriendInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FriendId = table.Column<int>(type: "int", nullable: false)
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
                    ClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberInfo", x => x.Id);
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
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.InsertData(
                table: "ClubInfo",
                columns: new[] { "ID", "ClubName", "DateCreated", "Description", "Image", "IsDeleted", "IsPublic", "LeaderId" },
                values: new object[,]
                {
                    { 1, "Jujutsu Lovers<3", "2024-04-08", "Gege Akutami hates his readers!", "https://p325k7wa.twic.pics/high/jujutsu-kaisen/jujutsu-kaisen-cursed-clash/00-page-setup/JJK-header-mobile2.jpg?twic=v1/resize=760/step=10/quality=80", false, true, 1 },
                    { 2, "Villainess Arc", "2024-04-07", "strong and evil FLs lol", "https://static.animecorner.me/2022/09/villainess-manhwa-manga-novel-1024x576.png", false, true, 1 }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubInfo");

            migrationBuilder.DropTable(
                name: "CommentInfo");

            migrationBuilder.DropTable(
                name: "FavoritesInfo");

            migrationBuilder.DropTable(
                name: "FriendInfo");

            migrationBuilder.DropTable(
                name: "MemberInfo");

            migrationBuilder.DropTable(
                name: "PostInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
