using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LocationAPI.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace LocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : Controller
    {
        private readonly AppSettings _appSetting;
        private readonly HttpClient _httpClient;
        public StateController(IOptions<AppSettings> appSetting)
        {
            _appSetting = appSetting.Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_appSetting.LocationApiUrl);
        }

        [HttpGet]
        public async Task<ActionResult<List<StateApiResponseModel>>> GetAll(int id, int page, int size)
        {
            var countries = await _httpClient.GetAsync($"locationLevelOne/countryId/{id}?page={page}&size={size}");
            countries.EnsureSuccessStatusCode();

            var message = await countries.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<StateListApiResponseModel>(message);
            return Ok(responseObj);
        }

        [HttpGet("locationLevelOne/id/{id}")]
        public async Task<IActionResult> GetStateById(int id)
        {
            var state = await _httpClient.GetAsync($"locationLevelOne/id/{id}");
            state.EnsureSuccessStatusCode();
            var message = await state.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<StateApiResponseModel>(message);
            return Ok(responseObj);
        }
    }
}
