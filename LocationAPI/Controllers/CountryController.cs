using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LocationAPI.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace LocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly AppSettings _appSetting;
        private readonly HttpClient _httpClient;
        public CountryController(IOptions<AppSettings> appSetting)
        {
            _appSetting = appSetting.Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_appSetting.LocationApiUrl);
        }

        [HttpGet]
        public async Task<ActionResult<List<CountryApiResponseModel>>> GetAll(int page, int size)
        {
            var countries = await _httpClient.GetAsync($"country?page={page}&size={size}");
            countries.EnsureSuccessStatusCode();

            var message = await countries.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<CountryListApiResponseModel>(message);
            return Ok(responseObj);
        }

        [HttpGet("country/id/{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var country = await _httpClient.GetAsync($"country/id/{id}");
            country.EnsureSuccessStatusCode();
            var message = await country.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<CountryApiResponseModel>(message);
            return Ok(responseObj);
        }
    }
}
