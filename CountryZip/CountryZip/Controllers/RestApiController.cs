using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CountryZip.Models.Repositories;
using Newtonsoft.Json;
using CountryZip.Models;
using System.Linq;

namespace CountryZip.Controllers
{
    [Route("RestApi/v1")]
    [ApiController]
    public class RestApiController : ControllerBase
    {
        private readonly ICountryNsiRepositories _countryNsi;
        private readonly ObjCountryDBContext _context;

        public RestApiController(ICountryNsiRepositories countryNsi,
            ObjCountryDBContext context)
        {
            _countryNsi = countryNsi;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] int? countrynid)
        {
            try
            {
                CountryNsi countryn = new CountryNsi();

                var countrynsi = _countryNsi.GetCountriesNsi(countrynid);
                foreach (var obj in countrynsi)
                {
                    countryn.Id = obj.Id;
                    countryn.Country = obj.Country;
                    countryn.Code = obj.Code;
                    countryn.ExampleURL = obj.ExampleURL;
                    countryn.Range = obj.Range;
                }

                string output = JsonConvert.SerializeObject(countryn);

                return Ok(output);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
