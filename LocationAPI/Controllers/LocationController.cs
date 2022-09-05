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
        // GET: api/<LocationController>
        [HttpGet]
        public async Task<IActionResult> GetCountryById(int id)
        {
            
            var response = await _httpClient.GetAsync($"/country/id/{id}");
            response.EnsureSuccessStatusCode();

            var message = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<ApiResponseModel>(message);
            return Ok(responseObj);
        }

        // GET api/<LocationController>/5
       /* [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<LocationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
