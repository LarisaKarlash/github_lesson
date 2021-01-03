using Microsoft.EntityFrameworkCore.Migrations;

namespace ObjDistrict.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: false),
                    SickCount = table.Column<int>(type: "int", nullable: false),
                    DeadCount = table.Column<int>(type: "int", nullable: false),
                    RecoveredCount = table.Column<int>(type: "int", nullable: false),
                    Vaccine = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsSick = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humans_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Humans_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "DeadCount", "Name", "Population", "RecoveredCount", "SickCount", "Vaccine" },
                values: new object[,]
                {
                    { 1, 317729, "US", 328200000, 16800450, 17860634, false },
                    { 2, 145810, "India", 1353150536, 9606111, 10055560, false },
                    { 3, 186764, "Brazil", 209500000, 6409986, 7238600, false },
                    { 4, 176764, "UK", 509500000, 8409986, 9238600, false }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CountryId", "Name", "Population" },
                values: new object[,]
                {
                    { 1, 1, "Nevada", 10000000 },
                    { 2, 1, "Florida", 17000000 },
                    { 3, 1, "Montana", 10000000 },
                    { 4, 3, "San_Paulu", 14000000 },
                    { 5, 3, "Parana", 5000000 },
                    { 6, 4, "Scotland", 30000000 }
                });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "Age", "CountryId", "DistrictId", "FirstName", "Gender", "IsSick", "LastName" },
                values: new object[,]
                {
                    { 1, 38, 1, 1, "Obi-wan", "Male", false, "Kenobi" },
                    { 2, 54, 1, 2, "Sanwise", "Male", false, "Gamgee" },
                    { 6, 84, 1, 3, "Thomas", "Male", true, "Edison" },
                    { 3, 30, 3, 4, "Hose", "Male", true, "Rodriges" },
                    { 4, 43, 3, 4, "Consuela", "Female", false, "Tridana" },
                    { 5, 25, 3, 5, "Ana", "Female", true, "Cormelia" },
                    { 7, 56, 4, 6, "Mikle", "Male", true, "Smitt" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CountryId",
                table: "Districts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Humans_CountryId",
                table: "Humans",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Humans_DistrictId",
                table: "Humans",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humans");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
