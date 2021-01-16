using Microsoft.EntityFrameworkCore.Migrations;

namespace ObjectBD.Migrations
{
    public partial class ChangedGenderintoenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderTmp",
                table: "Humans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(
                @"
                UPDATE Humans
                SET GenderTmp =
                    CASE Gender
                        WHEN 'Undefined' THEN 0
                        WHEN 'Male' THEN 1
                        WHEN 'Female' THEN 2
                        ELSE 0
                    END
                ");

            migrationBuilder.DropColumn(name: "Gender", table: "Humans");
            migrationBuilder.RenameColumn(
                name: "GenderTmp",
                table: "Humans",
                newName: "Gender");

            migrationBuilder.DeleteData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Humans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 4,
                column: "Gender",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 5,
                column: "Gender",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 6,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 7,
                column: "Gender",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Humans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 4,
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 5,
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 6,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 7,
                column: "Gender",
                value: "Male");

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "Age", "CountryId", "FirstName", "Gender", "IsSick", "LastName" },
                values: new object[] { 8, 56, 4, "Mikle", "Male", true, "Smitt" });
        }
    }
}
