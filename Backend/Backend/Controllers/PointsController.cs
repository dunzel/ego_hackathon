using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class PointsController : ApiController
    {
        // GET: api/Points
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Points/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Points
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Points/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Points/5
        public void Delete(int id)
        {
        }
        public void UpdatePoints()
        {

        }
        public void AddPoints()
        {

        }
        public void DecPoints()
        {

        }
    }
}
