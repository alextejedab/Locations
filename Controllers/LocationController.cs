using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Locations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public List<Location> Summaries = new List<Location>();

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return Summaries[id].location;
        }

        // POST api/<LocationController>
        [HttpPost()]
        public IActionResult Post(string locationName)
        {
            TimeSpan startTime = new TimeSpan(10, 0 , 0);
            TimeSpan endTime = new TimeSpan(13, 0, 0);

            if (DateTime.Now.TimeOfDay < endTime && DateTime.Now.TimeOfDay > startTime) {
                Summaries.Add(new Location
                {
                    location = locationName
                });
                string message = Summaries[Summaries.Count - 1].location + " was added";
                return Ok(message);
            }
            return Unauthorized("Access hours are from 10am to 1pm");
        }

        // PUT api/<LocationController>/5
        [HttpPut("{locationName}")]
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
