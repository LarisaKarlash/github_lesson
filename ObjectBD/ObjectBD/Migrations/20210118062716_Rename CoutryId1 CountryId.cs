using Microsoft.EntityFrameworkCore.Migrations;

namespace ObjectBD.Migrations
{
    public partial class RenameCoutryId1CountryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                UPDATE Humans
                SET CountryId1 =
                    CASE CountryId
                        WHEN 1 THEN 1
                        WHEN 2 THEN 2
                        WHEN 3 THEN 3
                        WHEN 4 THEN 4
                        WHEN 8 THEN 8
                        ELSE 0
                    END
                ");

            migrationBuilder.DropColumn(name: "CountryId", table: "Humans");

            migrationBuilder.DropForeignKey(
                 name: "FK_Humans_Countries_CountryId1",
                 table: "Humans");

            migrationBuilder.DropIndex(
                name: "IX_Humans_CountryId1",
                table: "Humans");

            migrationBuilder.RenameColumn(
                name: "CountryId1",
                table: "Humans",
                newName: "CountryId");

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
