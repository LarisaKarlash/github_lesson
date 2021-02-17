using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Models
{
    public class ObjCountryDBContext : IdentityDbContext<ApplicationUser> //DbContext
    {
        // Наборы для отбора из таблиц
        public DbSet<CountryNsi> CountriesNsi { get; set; }
        public DbSet<CountryZp> CountriesZp { get; set; }
        public DbSet<PlaceZp> PlacesZp { get; set; }

        public ObjCountryDBContext( DbContextOptions options) : base(options)
        {
        }

        //Заполняем данными
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CountryNsi>().HasData(
               new CountryNsi { Id = 1, Country = "Andorra", Code = "AD", ExampleURL = "api.zippopotam.us/AD/AD100", Range = "AD100:AD700" },
               new CountryNsi { Id = 2, Country = "Argentina", Code = "AR", ExampleURL = "api.zippopotam.us/AR/1601", Range = "1601:9431" },     
               new CountryNsi { Id = 3, Country = "American Samoa", Code = "AS", ExampleURL = "api.zippopotam.us/AS/96799", Range = "96799:96799" },
               new CountryNsi { Id = 4, Country = "Austria", Code = "AT", ExampleURL = "api.zippopotam.us/AT/1010", Range = "1010:9992" },
               new CountryNsi { Id = 5, Country = "Australia", Code = "AU", ExampleURL = " api.zippopotam.us/AU/0200", Range = "0200:9726" },      
               new CountryNsi { Id = 6, Country = "Bangladesh", Code = "BD", ExampleURL = "api.zippopotam.us/BD/1000", Range = "1000:9461" },
               new CountryNsi { Id = 7, Country = "Belgium", Code = "BE", ExampleURL = "api.zippopotam.us/BE/1000", Range = "1000:9992" },   
               new CountryNsi { Id = 8, Country = "Bulgaria", Code = "BG", ExampleURL = "api.zippopotam.us/BG/1000", Range = "1000:9974" },  
               new CountryNsi { Id = 9, Country = "Brazil", Code = "BR", ExampleURL = "api.zippopotam.us/BR/01000-000", Range = "01000-000:99990-000" },
               new CountryNsi { Id = 10, Country = "Canada", Code = "CA", ExampleURL = "api.zippopotam.us/CA/A0A", Range = "A0A:Y1A" },   
               new CountryNsi { Id = 11, Country = "Switzerland", Code = "CH", ExampleURL = "api.zippopotam.us/CH/1000", Range = "1000:9658" },
               new CountryNsi { Id = 12, Country = "Czech Republic", Code = "CZ", ExampleURL = "api.zippopotam.us/CZ/10000", Range = "10000:79862" },
               new CountryNsi { Id = 13, Country = "Germany", Code = "DE", ExampleURL = "api.zippopotam.us/DE/01067", Range = "01067:99998" },
               new CountryNsi { Id = 14, Country = "Denmark", Code = "DK", ExampleURL = "api.zippopotam.us/DK/0800", Range = "0800:9990" },
               new CountryNsi { Id = 15, Country = "Dominican Republic", Code = "DO", ExampleURL = "api.zippopotam.us/DO/10101", Range = "10101:11906" },
               new CountryNsi { Id = 16, Country = "Spain", Code = "ES", ExampleURL = "api.zippopotam.us/ES/01001", Range = "01001:52080" },
               new CountryNsi { Id = 17, Country = "Finland", Code = "FI", ExampleURL = "api.zippopotam.us/FI/00002", Range = "00002:99999" },
               new CountryNsi { Id = 18, Country = "Faroe Islands", Code = "FO", ExampleURL = "api.zippopotam.us/FO/100", Range = "100:970" },
               new CountryNsi { Id = 19, Country = "France", Code = "FR", ExampleURL = "api.zippopotam.us/FR/01000", Range = "01000:98799" },
               new CountryNsi { Id = 20, Country = "Great Britain", Code = "GB", ExampleURL = "api.zippopotam.us/GB/AB1", Range = "AB1:ZE3" },
               new CountryNsi { Id = 21, Country = "French Guyana", Code = "GF", ExampleURL = "api.zippopotam.us/GF/97300", Range = "97300:97390" },
               new CountryNsi { Id = 22, Country = "Guernsey", Code = "GG", ExampleURL = "api.zippopotam.us/GG/GY1", Range = "GY1:GY9" },
               new CountryNsi { Id = 23, Country = "Greenland", Code = "GL", ExampleURL = "api.zippopotam.us/GL/2412", Range = "2412:3992" },
               new CountryNsi { Id = 24, Country = "Guadeloupe", Code = "GP", ExampleURL = "api.zippopotam.us/GP/97100", Range = "97100:97190" },
               new CountryNsi { Id = 25, Country = "Guatemala", Code = "GT", ExampleURL = "api.zippopotam.us/GT/01001", Range = "01001:22027" },
               new CountryNsi { Id = 26, Country = "Guam", Code = "GU", ExampleURL = "api.zippopotam.us/GU/96910", Range = "96910:96932" },
               new CountryNsi { Id = 27, Country = "Guyana", Code = "GY", ExampleURL = "api.zippopotam.us/GY/97312", Range = "97312:97360" },
               new CountryNsi { Id = 28, Country = "Croatia", Code = "HR", ExampleURL = "api.zippopotam.us/HR/10000", Range = "10000:53296" },
               new CountryNsi { Id = 29, Country = "Hungary", Code = "HU", ExampleURL = "api.zippopotam.us/HU/1011", Range = "1011:9985" },
               new CountryNsi { Id = 30, Country = "Isle of Man", Code = "IM", ExampleURL = "api.zippopotam.us/IM/IM1", Range = "IM1:IM9" },
               new CountryNsi { Id = 31, Country = "India", Code = "IN", ExampleURL = "api.zippopotam.us/IN/110001", Range = "110001:855126" },
               new CountryNsi { Id = 32, Country = "Iceland", Code = "IS", ExampleURL = "api.zippopotam.us/IS/101", Range = "101:902" },
               new CountryNsi { Id = 33, Country = "Italy", Code = "IT", ExampleURL = "api.zippopotam.us/IT/00010", Range = "00010:98168" },
               new CountryNsi { Id = 34, Country = "Jersey", Code = "JE", ExampleURL = "api.zippopotam.us/JE/JE1", Range = "JE1:JE3" },
               new CountryNsi { Id = 35, Country = "Japan", Code = "JP", ExampleURL = "api.zippopotam.us/JP/100-0001", Range = "100-0001:999-8531" },
               new CountryNsi { Id = 36, Country = "Liechtenstein", Code = "LI", ExampleURL = "api.zippopotam.us/LI/9485", Range = "9485:9498" },
               new CountryNsi { Id = 37, Country = "Sri Lanka", Code = "LK", ExampleURL = "api.zippopotam.us/LK/*", Range = "*:96167" },
               new CountryNsi { Id = 38, Country = "Lithuania", Code = "LT", ExampleURL = "api.zippopotam.us/LT/00001", Range = "00001:99069" },
               new CountryNsi { Id = 39, Country = "Luxembourg", Code = "LU", ExampleURL = "api.zippopotam.us/LU/L-1009", Range = "L-1009:L-9999" },
               new CountryNsi { Id = 40, Country = "Monaco", Code = "MC", ExampleURL = "api.zippopotam.us/MC/98000", Range = "98000:98000" },
               new CountryNsi { Id = 41, Country = "Moldavia", Code = "MD", ExampleURL = "api.zippopotam.us/MD/MD-2000", Range = "MD-2000:MD-7731" },
               new CountryNsi { Id = 42, Country = "Marshall Islands", Code = "MH", ExampleURL = "api.zippopotam.us/MH/96960", Range = "96960:96970" },
               new CountryNsi { Id = 43, Country = "Macedonia", Code = "MK", ExampleURL = "api.zippopotam.us/MK/1000", Range = "1000:7550" },
               new CountryNsi { Id = 44, Country = "Northern Mariana Islands", Code = "MP", ExampleURL = "api.zippopotam.us/MP/96950", Range = "96950:96952" },
               new CountryNsi { Id = 45, Country = "Martinique", Code = "MQ", ExampleURL = "api.zippopotam.us/MQ/97200", Range = "97200:97290" },
               new CountryNsi { Id = 46, Country = "Mexico", Code = "MX", ExampleURL = "api.zippopotam.us/MX/01000", Range = "01000:99998" },
               new CountryNsi { Id = 47, Country = "Malaysia", Code = "MY", ExampleURL = "api.zippopotam.us/MY/01000", Range = "01000:98859" },
               new CountryNsi { Id = 48, Country = "Holland", Code = "NL", ExampleURL = "api.zippopotam.us/NL/1000", Range = "1000:9999" },
               new CountryNsi { Id = 49, Country = "Norway", Code = "NO", ExampleURL = "api.zippopotam.us/NO/0001", Range = "0001:9991" },
               new CountryNsi { Id = 50, Country = "New Zealand", Code = "NZ", ExampleURL = "api.zippopotam.us/NZ/0110", Range = "0110:9893" },
               new CountryNsi { Id = 51, Country = "Phillippines", Code = "PH", ExampleURL = "api.zippopotam.us/PH/0400", Range = "0400:9811" },
               new CountryNsi { Id = 52, Country = "Pakistan", Code = "PK", ExampleURL = "api.zippopotam.us/PK/10010", Range = "10010:97320" },
               new CountryNsi { Id = 53, Country = "Poland", Code = "PL", ExampleURL = "api.zippopotam.us/PL/00-001", Range = "00-001:99-440" },
               new CountryNsi { Id = 54, Country = "Saint Pierre and Miquelon", Code = "PM", ExampleURL = "api.zippopotam.us/PM/97500", Range = "97500:97500" },
               new CountryNsi { Id = 55, Country = "Puerto Rico", Code = "PR", ExampleURL = "api.zippopotam.us/PR/00601", Range = "00601:00988" },
               new CountryNsi { Id = 56, Country = "Portugal", Code = "PT", ExampleURL = "api.zippopotam.us/PT/1000-001", Range = "1000-001:9980-999" },
               new CountryNsi { Id = 57, Country = "French Reunion", Code = "RE", ExampleURL = "api.zippopotam.us/RE/97400", Range = "97400:97490" },
               new CountryNsi { Id = 58, Country = "Russia", Code = "RU", ExampleURL = "api.zippopotam.us/RU/101000", Range = "101000:901993" },
               new CountryNsi { Id = 59, Country = "Sweden", Code = "SE", ExampleURL = "api.zippopotam.us/SE/10005", Range = "10005:98499" },
               new CountryNsi { Id = 60, Country = "Slovenia", Code = "SI", ExampleURL = "api.zippopotam.us/SI/1000", Range = "1000:9600" },
               new CountryNsi { Id = 61, Country = "Svalbard & Jan Mayen Islands", Code = "SJ", ExampleURL = "api.zippopotam.us/SJ/8099", Range = "8099:9178" },
                new CountryNsi { Id = 62, Country = "Slovak Republic", Code = "SK", ExampleURL = "api.zippopotam.us/SK/01001", Range = "01001:99201" },
               new CountryNsi { Id = 63, Country = "San Marino", Code = "SM", ExampleURL = "api.zippopotam.us/SM/47890", Range = "47890:47899" },
               new CountryNsi { Id = 64, Country = "Thailand", Code = "TH", ExampleURL = "api.zippopotam.us/TH/10100", Range = "10100:96220" },
               new CountryNsi { Id = 65, Country = "Turkey", Code = "TR", ExampleURL = "api.zippopotam.us/TR/01000", Range = "01000:81950" },
               new CountryNsi { Id = 66, Country = "United States", Code = "US", ExampleURL = "api.zippopotam.us/US/00210", Range = "00210:99950" },
               new CountryNsi { Id = 67, Country = "Vatican", Code = "VA", ExampleURL = "api.zippopotam.us/VA/00120", Range = "00120:00120" },
               new CountryNsi { Id = 68, Country = "Virgin Islands", Code = "VI", ExampleURL = "api.zippopotam.us/VI/00801", Range = "00801:00851" },
               new CountryNsi { Id = 69, Country = "Mayotte", Code = "YT", ExampleURL = "api.zippopotam.us/YT/97600", Range = "97600:97680" },
               new CountryNsi { Id = 70, Country = "South Africa", Code = "ZA", ExampleURL = "api.zippopotam.us/ZA/0002", Range = "0002:9992" } );

            modelBuilder.Entity<CountryZp>().HasData(
                new CountryZp { Id = 1, PostCode = "90210", Country = "United States", CountryAbbreviation = "56", CountryNsiId = 66 });

            modelBuilder.Entity<PlaceZp>().HasData(
                new PlaceZp { Id = 1, PlaceName = "Beverly Hills", Longitude = "-118.4065", State = "California", StateAbbreviation = "CA", Latitude = "34.0901", CountryZpId = 1 });
        }
    }
}
