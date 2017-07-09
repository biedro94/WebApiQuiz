using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiClubQuiz.Models;

namespace WebApiClubQuiz.Controllers
{
    public class ValuesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/Quizs")]
        public IQueryable<Quiz> Quizs()
        {
            //string json = JsonConvert.SerializeObject(db.Quizs.ToList(), Formatting.Indented);
            //return json;
            return db.Quizs;
        }

        [HttpGet]
        [Route("api/Scores")]
        public IEnumerable<Scores> Scores()
        {
            //string json = JsonConvert.SerializeObject(db.Scores.ToList().OrderByDescending(u => u.score).Take(10), Formatting.Indented);
            //return json;
            return db.Scores.ToList().OrderByDescending(u => u.score).Take(10);
        }

        [HttpPost]
        [Route("Scores/Create")]
        public int Create(string name, int score)
        {
            Scores scores = new Scores();
            scores.name = name;
            scores.score = score;

            try
            {
                db.Scores.Add(scores);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }
    }
}
