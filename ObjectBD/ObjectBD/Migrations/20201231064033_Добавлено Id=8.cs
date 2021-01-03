using Microsoft.EntityFrameworkCore.Migrations;

namespace ObjectBD.Migrations
{
    public partial class ДобавленоId8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "Age", "CountryId", "FirstName", "Gender", "IsSick", "LastName" },
                values: new object[] { 8, 56, 4, "Mikle", "Male", true, "Smitt" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
