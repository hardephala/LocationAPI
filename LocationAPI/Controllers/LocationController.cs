using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LocationAPI.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace LocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AppSettings _appSetting;
        private readonly HttpClient _httpClient;
        public LocationController(IOptions<AppSettings> appSetting)
        {
            _appSetting = appSetting.Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_appSetting.LocationApiUrl);
        }

        [HttpGet("country/id/{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            
            var response = await _httpClient.GetAsync($"country/id/{id}");
            response.EnsureSuccessStatusCode();

            var message = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<ApiResponseModel>(message);
            return Ok(responseObj);
        }

        [HttpGet("states/countryId/{id}")]
        public async Task<IActionResult> GetStatesByCountryId(int id)
        {
            var response = await _httpClient.GetAsync($"locationLevelOne/countryId/{id}");
            response.EnsureSuccessStatusCode();

            var message = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<ApiResponseModel>(message);
            return Ok(responseObj);

        }

        [HttpGet("state/id/{id}")]
        public async Task<IActionResult> GetStateById(int id)
        {
            var response = await _httpClient.GetAsync($"locationLevelOne/id/{id}");
            response.EnsureSuccessStatusCode();

            var message = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<ApiResponseModel>(message);
            return Ok(responseObj);

        }

    }
}
