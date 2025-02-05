using LocationTracking_WebHook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationTracking_WebHook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebHookController : ControllerBase
    {
        private static List<LocationUpdate> _locationUpdates = new List<LocationUpdate>();

        [HttpPost]
        public async Task<IActionResult> ReciveLocationUpdate([FromBody] LocationUpdate locationUpdate)
        {
            if (locationUpdate == null)
                return BadRequest("Invalid Webhook Data Location.");

            _locationUpdates.Add(locationUpdate);// Store the location Update
            Console.WriteLine($"Location Update : {locationUpdate.UserId} -Lat : {locationUpdate.Latitude}, Lang : {locationUpdate.Longitude}");

            return Ok(new {message=" Location  recived  successfully !"});

        }

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            return Ok(_locationUpdates);
        }

    }
}
