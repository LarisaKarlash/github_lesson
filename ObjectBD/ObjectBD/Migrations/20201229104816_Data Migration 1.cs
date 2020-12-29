using Microsoft.EntityFrameworkCore.Migrations;

namespace ObjectBD.Migrations
{
    public partial class DataMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "DeadCount", "Name", "Population", "RecoveredCount", "SickCount", "Vaccine" },
                values: new object[] { 4, 176764, "UK", 509500000, 8409986, 9238600, false });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "Age", "CountryId", "FirstName", "Gender", "IsSick", "LastName" },
                values: new object[] { 7, 56, 4, "Mikle", "Male", true, "Smitt" });
        }
    }
}
