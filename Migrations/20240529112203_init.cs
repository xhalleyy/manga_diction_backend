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
                    { 1, "Spoilers", 1, "2024-04-05", "2024-04-06", "I can't believe that happened! And off-screened too... TT", null, false, "CH.223", "What happed to Gojo can't be real, right!?", 1 },
                    { 2, "Discussion", 1, "2024-04-06", "2024-04-07", null, null, false, null, "Who is your guys' favorite character that is currently ALIVE!?", 1 },
                    { 3, "Discussion", 1, "2024-04-08", null, "Why is Gege Akutami killing off EVERYBODY?????", null, true, null, "I got some words to say to Gege...", 2 }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "ID", "Age", "FirstName", "Hash", "LastName", "ProfilePic", "Salt", "Username" },
                values: new object[,]
                {
                    { 1, 24, "halley", "MYGwrD+IpxAU3sAsMzYkB824c72f6q3qqZ6DVeLn+XNhilTuCwCyPD2L8bOd/m3Mwa4dW/PVPGXhgN86wpYlEeWTfC3GFKLY4qgY5URSxQ6Sp+5N0I+Z+wNu9OmUj8gM3RDH27Cx6EP37+EAD9vZ34LWuXfDcMSB8oERSTGTnzel2yzbiOE4Mfd03ExP+7Njp2dKtemAT7y7U0Rj+A0UfcVsma1IPhdZTCK4eXu8CTp052IwKR3ngP8VGFnjMgV8I9RMFb2wlihz1o7jXWwVJql3Js1sCUNguVd/yftd+iyCMRjmbzM5qKaSyEVO0bOj8LGyPXSG81xsSzlq7KtLYw==", "pham", null, "/30Q+tbEfHNYV+VcY1x7a31f4XmOVA2yzroBOtjmH7wrp7YmdfL0NDEuVHgGi4P4IkpsVuG9EWJd2urVNqmbzw==", "halley" },
                    { 2, 26, "sinatha", "fT+cOf3xNyRCVGcPJEQxJPHail6WHIOuIiWZeMIfxoI/nogga3T/c5/ICdXTaWvksz8IztKx3sdZaMp0NvWuNRs9F40ThehO5eJjzvjvwaOa0JAY041iNykhv7iAF4WTTzouXjIogKrB3ytMsSQKcsQw+nVk5w0HMp485HF0Vgio+5kK107RafTXW84VJ0/9lh+mFoWRk/N+owXbVC6QIKo0E/9N3Au97IY7lDbKdHgkzyOt+QK/KTmKLevK85ZD2rqeJ5+CPrgOUHJHbhgmaqepxRec0Z0v6vKossEvh64pMAl+VDKCibUHCCQSTIIvv3/ZBNOJEYCkH7o0CpdisA==", "chin", null, "CRAotl001YDT/5efujzfPNZgRgsHrMX245qm4UdYEAywoKS7Q/50TjGqtagexEvicAMG6aesvktSh9Ockjo2KA==", "sinatha" },
                    { 3, 22, "avery", "NiYV4qFQHnsPgQCkcQLNujA0y1lOP7ak0PEqkhjUdpvDMQGWVcntx0QBPpuW8QFF0wOz4ugE8qacLUHCMsfYcCEqTd1Trhg29/LzcnIXHsIcyx+MVH+0UXTL4X8KFUSQ1dfdnVdlWx3/BoVrX6ue1Nm1AW00wFkr/Uku+IAzphr/yl2J6eXf9ZUdOODS2YOumOWrrl1PYWs+se9PrzGsZUnnNXYdnw8DlxuM+kkPUx+M2w0du++B9B6y/hsI32l3GBsj7QSA89DS+962hk0MOlinQgv3KO+892xD0hGeTSg/1M2/IS5s7J8yaoFbh0VJsanrke8pEua55VFzFgeodQ==", "hillstrom", null, "vYsW/2t4uzl5B4xJif8NR1jsDjOOg81fuRALEWnr5ZDRxSJGHe0P0j2940TX0sEbm/IRu48o4DByngNVhhmRjQ==", "avery" }
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
