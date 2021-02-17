using Microsoft.EntityFrameworkCore.Migrations;

namespace CountryZip.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountriesNsi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExampleURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesNsi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountriesZp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryNsiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesZp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountriesZp_CountriesNsi_CountryNsiId",
                        column: x => x.CountryNsiId,
                        principalTable: "CountriesNsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlacesZp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    CountryZpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesZp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacesZp_CountriesZp_CountryZpId",
                        column: x => x.CountryZpId,
                        principalTable: "CountriesZp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CountriesNsi",
                columns: new[] { "Id", "Code", "Country", "ExampleURL", "Range" },
                values: new object[,]
                {
                    { 1, "AD", "Andorra", "api.zippopotam.us/AD/AD100", "AD100:AD700" },
                    { 38, "LT", "Lithuania", "api.zippopotam.us/LT/00001", "00001:99069" },
                    { 39, "LU", "Luxembourg", "api.zippopotam.us/LU/L-1009", "L-1009:L-9999" },
                    { 40, "MC", "Monaco", "api.zippopotam.us/MC/98000", "98000:98000" },
                    { 41, "MD", "Moldavia", "api.zippopotam.us/MD/MD-2000", "MD-2000:MD-7731" },
                    { 42, "MH", "Marshall Islands", "api.zippopotam.us/MH/96960", "96960:96970" },
                    { 43, "MK", "Macedonia", "api.zippopotam.us/MK/1000", "1000:7550" },
                    { 44, "MP", "Northern Mariana Islands", "api.zippopotam.us/MP/96950", "96950:96952" },
                    { 45, "MQ", "Martinique", "api.zippopotam.us/MQ/97200", "97200:97290" },
                    { 46, "MX", "Mexico", "api.zippopotam.us/MX/01000", "01000:99998" },
                    { 47, "MY", "Malaysia", "api.zippopotam.us/MY/01000", "01000:98859" },
                    { 48, "NL", "Holland", "api.zippopotam.us/NL/1000", "1000:9999" },
                    { 49, "NO", "Norway", "api.zippopotam.us/NO/0001", "0001:9991" },
                    { 50, "NZ", "New Zealand", "api.zippopotam.us/NZ/0110", "0110:9893" },
                    { 51, "PH", "Phillippines", "api.zippopotam.us/PH/0400", "0400:9811" },
                    { 52, "PK", "Pakistan", "api.zippopotam.us/PK/10010", "10010:97320" },
                    { 53, "PL", "Poland", "api.zippopotam.us/PL/00-001", "00-001:99-440" },
                    { 54, "PM", "Saint Pierre and Miquelon", "api.zippopotam.us/PM/97500", "97500:97500" },
                    { 68, "VI", "Virgin Islands", "api.zippopotam.us/VI/00801", "00801:00851" },
                    { 67, "VA", "Vatican", "api.zippopotam.us/VA/00120", "00120:00120" },
                    { 66, "US", "United States", "api.zippopotam.us/US/00210", "00210:99950" },
                    { 65, "TR", "Turkey", "api.zippopotam.us/TR/01000", "01000:81950" },
                    { 64, "TH", "Thailand", "api.zippopotam.us/TH/10100", "10100:96220" },
                    { 63, "SM", "San Marino", "api.zippopotam.us/SM/47890", "47890:47899" },
                    { 37, "LK", "Sri Lanka", "api.zippopotam.us/LK/*", "*:96167" },
                    { 62, "SK", "Slovak Republic", "api.zippopotam.us/SK/01001", "01001:99201" },
                    { 60, "SI", "Slovenia", "api.zippopotam.us/SI/1000", "1000:9600" },
                    { 59, "SE", "Sweden", "api.zippopotam.us/SE/10005", "10005:98499" },
                    { 58, "RU", "Russia", "api.zippopotam.us/RU/101000", "101000:901993" },
                    { 57, "RE", "French Reunion", "api.zippopotam.us/RE/97400", "97400:97490" },
                    { 56, "PT", "Portugal", "api.zippopotam.us/PT/1000-001", "1000-001:9980-999" },
                    { 55, "PR", "Puerto Rico", "api.zippopotam.us/PR/00601", "00601:00988" },
                    { 61, "SJ", "Svalbard & Jan Mayen Islands", "api.zippopotam.us/SJ/8099", "8099:9178" },
                    { 36, "LI", "Liechtenstein", "api.zippopotam.us/LI/9485", "9485:9498" },
                    { 35, "JP", "Japan", "api.zippopotam.us/JP/100-0001", "100-0001:999-8531" },
                    { 34, "JE", "Jersey", "api.zippopotam.us/JE/JE1", "JE1:JE3" },
                    { 15, "DO", "Dominican Republic", "api.zippopotam.us/DO/10101", "10101:11906" },
                    { 14, "DK", "Denmark", "api.zippopotam.us/DK/0800", "0800:9990" },
                    { 13, "DE", "Germany", "api.zippopotam.us/DE/01067", "01067:99998" },
                    { 12, "CZ", "Czech Republic", "api.zippopotam.us/CZ/10000", "10000:79862" },
                    { 11, "CH", "Switzerland", "api.zippopotam.us/CH/1000", "1000:9658" },
                    { 10, "CA", "Canada", "api.zippopotam.us/CA/A0A", "A0A:Y1A" }
                });

            migrationBuilder.InsertData(
                table: "CountriesNsi",
                columns: new[] { "Id", "Code", "Country", "ExampleURL", "Range" },
                values: new object[,]
                {
                    { 16, "ES", "Spain", "api.zippopotam.us/ES/01001", "01001:52080" },
                    { 9, "BR", "Brazil", "api.zippopotam.us/BR/01000-000", "01000-000:99990-000" },
                    { 7, "BE", "Belgium", "api.zippopotam.us/BE/1000", "1000:9992" },
                    { 6, "BD", "Bangladesh", "api.zippopotam.us/BD/1000", "1000:9461" },
                    { 5, "AU", "Australia", " api.zippopotam.us/AU/0200", "0200:9726" },
                    { 4, "AT", "Austria", "api.zippopotam.us/AT/1010", "1010:9992" },
                    { 3, "AS", "American Samoa", "api.zippopotam.us/AS/96799", "96799:96799" },
                    { 2, "AR", "Argentina", "api.zippopotam.us/AR/1601", "1601:9431" },
                    { 8, "BG", "Bulgaria", "api.zippopotam.us/BG/1000", "1000:9974" },
                    { 69, "YT", "Mayotte", "api.zippopotam.us/YT/97600", "97600:97680" },
                    { 17, "FI", "Finland", "api.zippopotam.us/FI/00002", "00002:99999" },
                    { 19, "FR", "France", "api.zippopotam.us/FR/01000", "01000:98799" },
                    { 33, "IT", "Italy", "api.zippopotam.us/IT/00010", "00010:98168" },
                    { 32, "IS", "Iceland", "api.zippopotam.us/IS/101", "101:902" },
                    { 31, "IN", "India", "api.zippopotam.us/IN/110001", "110001:855126" },
                    { 30, "IM", "Isle of Man", "api.zippopotam.us/IM/IM1", "IM1:IM9" },
                    { 29, "HU", "Hungary", "api.zippopotam.us/HU/1011", "1011:9985" },
                    { 28, "HR", "Croatia", "api.zippopotam.us/HR/10000", "10000:53296" },
                    { 18, "FO", "Faroe Islands", "api.zippopotam.us/FO/100", "100:970" },
                    { 27, "GY", "Guyana", "api.zippopotam.us/GY/97312", "97312:97360" },
                    { 25, "GT", "Guatemala", "api.zippopotam.us/GT/01001", "01001:22027" },
                    { 24, "GP", "Guadeloupe", "api.zippopotam.us/GP/97100", "97100:97190" },
                    { 23, "GL", "Greenland", "api.zippopotam.us/GL/2412", "2412:3992" },
                    { 22, "GG", "Guernsey", "api.zippopotam.us/GG/GY1", "GY1:GY9" },
                    { 21, "GF", "French Guyana", "api.zippopotam.us/GF/97300", "97300:97390" },
                    { 20, "GB", "Great Britain", "api.zippopotam.us/GB/AB1", "AB1:ZE3" },
                    { 26, "GU", "Guam", "api.zippopotam.us/GU/96910", "96910:96932" },
                    { 70, "ZA", "South Africa", "api.zippopotam.us/ZA/0002", "0002:9992" }
                });

            migrationBuilder.InsertData(
                table: "CountriesZp",
                columns: new[] { "Id", "Country", "CountryAbbreviation", "CountryNsiId", "PostCode" },
                values: new object[] { 1, "United States", "56", 66, "90210" });

            migrationBuilder.InsertData(
                table: "PlacesZp",
                columns: new[] { "Id", "CountryZpId", "Latitude", "Longitude", "PlaceName", "State", "StateAbbreviation" },
                values: new object[] { 1, 1, 34.0901, -118.40649999999999, "Beverly Hills", "California", "CA" });

            migrationBuilder.CreateIndex(
                name: "IX_CountriesZp_CountryNsiId",
                table: "CountriesZp",
                column: "CountryNsiId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacesZp_CountryZpId",
                table: "PlacesZp",
                column: "CountryZpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlacesZp");

            migrationBuilder.DropTable(
                name: "CountriesZp");

            migrationBuilder.DropTable(
                name: "CountriesNsi");
        }
    }
}
