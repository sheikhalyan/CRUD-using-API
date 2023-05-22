using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebApplication3.Models;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    public class ValuesController : ApiController
    {
        private AirportmanagementEntities1 db = new AirportmanagementEntities1();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/airport/5
        public IHttpActionResult Get(int id)
        {
            var airport = db.Airports.Find(id);
            if (airport == null)
            {
                return NotFound();
            }

            return Ok(airport);
        }

        // POST api/airport
        public IHttpActionResult Post([FromBody]Airport airport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Airports.Add(airport);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = airport.AirportID }, airport);
        }

        // PUT api/airport/5
        public void Put(int id, [FromBody]string value)
        {
            // Your implementation to update an airport
        }

        // DELETE api/airport/5
        public void Delete(int id)
        {
            // Your implementation to delete an airport
        }
    }

}
