using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocationTracking_WebHook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationSenderController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public LocationSenderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> SendLocationUpdate()
        {
            var webhookUrl = "https://localhost:7272/api/webhook"; // Reciver Url

            var locationData = new
            {
                UserId = "User123",
                Latitude = 37.7749, // Example: San Francisco
                Longitude = -122.4194
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(locationData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(webhookUrl, jsonContent);

            return Ok(await response.Content.ReadAsStringAsync());

        }
    }
}
