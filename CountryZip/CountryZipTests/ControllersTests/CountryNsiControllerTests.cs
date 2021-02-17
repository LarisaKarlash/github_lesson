using CountryZip.Controllers;
using CountryZip.Models;
using CountryZip.Models.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CountryZipTests.ControllersTests
{
    public class CountryNsiControllerTests
    {
        [Fact]
        public void CountryNsi_Index_RepositoriesCalled()
        {
            //Arrange
            Mock<ICountryNsiRepositories> countryNsi = new Mock<ICountryNsiRepositories>();

            int countrynid = 7;

            var countryn = new List<CountryNsi> {new CountryNsi
            {
             Id =7,
             Country = "Belgium",
             Code = "BE",
             ExampleURL ="api.zippopotam.us/BE/1000",
             Range = "1000:9992"
            } };

            countryNsi.Setup(x=>x.GetCountriesNsi(countrynid)).Returns(countryn);

            CountryNsiController controller = new CountryNsiController(countryNsi.Object);

            //Act
            controller.ViewIndex(countrynid);

            //Assert
            countryNsi.Verify(x => x.GetCountriesNsi(countrynid),Times.Once);


        }

    }
}
