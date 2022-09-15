using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LocationAPI.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace LocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LgaController : Controller
    {
        private readonly AppSettings _appSetting;
        private readonly HttpClient _httpClient;
        public LgaController(IOptions<AppSettings> appSetting)
        {
            _appSetting = appSetting.Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_appSetting.LocationApiUrl);
        }

        [HttpGet]
        public async Task<ActionResult<List<LgaApiResponseModel>>> GetAllStateLga(int id, int page, int size)
        {
            var countries = await _httpClient.GetAsync($"locationLevelTwo/locationLevelOneId/{id}?page={page}&size={size}");
            countries.EnsureSuccessStatusCode();

            var message = await countries.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<LgaListApiResponseModel>(message);
            return Ok(responseObj);
        }
    }
}
