using Backend.Models;
using SchoolDataLayer;
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
        MyContext db = new MyContext();
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
        public void UpdateLongTermPoints(string id)
        {
            User user = db.users.First(x => x.UserID == id);
            if(user.Points<=4)
            {
                user.Points -= 4;
            }
            else
            {
                user.Points = 0;
            }
            db.SaveChangesAsync();
        }
        public void UpdatePoints(string id)
        {
            User user =  db.users.First(x => x.UserID == id);
            if(true) {
                AddPoints(user);
            }
            else
            {
                DecPoints(user);
            }
        }
        private void AddPoints(User user)
        {
            user.Points += 2; 
            db.SaveChangesAsync();
        }
        private void DecPoints(User user)
        {
            user.Points -= 2;
            db.SaveChangesAsync();
        }
    }
}
