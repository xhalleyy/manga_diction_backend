using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstackbackend.Migrations
{
    /// <inheritdoc />
    public partial class fixModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostInfo_ClubInfo_ClubId",
                table: "PostInfo");

            migrationBuilder.DropIndex(
                name: "IX_PostInfo_ClubId",
                table: "PostInfo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PostInfo_ClubId",
                table: "PostInfo",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostInfo_ClubInfo_ClubId",
                table: "PostInfo",
                column: "ClubId",
                principalTable: "ClubInfo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
