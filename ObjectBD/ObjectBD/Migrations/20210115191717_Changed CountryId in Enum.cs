using Microsoft.EntityFrameworkCore.Migrations;

namespace ObjectBD.Migrations
{
    public partial class ChangedCountryIdinEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Humans_Countries_CountryId",
                table: "Humans");

            migrationBuilder.DropIndex(
                name: "IX_Humans_CountryId",
                table: "Humans");

            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                table: "Humans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Humans_CountryId1",
                table: "Humans",
                column: "CountryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Humans_Countries_CountryId1",
                table: "Humans",
                column: "CountryId1",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Humans_Countries_CountryId1",
                table: "Humans");

            migrationBuilder.DropIndex(
                name: "IX_Humans_CountryId1",
                table: "Humans");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "Humans");

            migrationBuilder.CreateIndex(
                name: "IX_Humans_CountryId",
                table: "Humans",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Humans_Countries_CountryId",
                table: "Humans",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
