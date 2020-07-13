using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTesting.Data;
using ApiTesting.Data.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameKeysController : ControllerBase
    {
        public ApplicationDbContext db;
        private readonly ILogger<GameKeysController> logger;

        public GameKeysController(ApplicationDbContext db, ILogger<GameKeysController> logger)
        {
            
            this.db = db;
            this.logger = logger;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<Key>> Get()
        {
            return db.Keys.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Key>> Get(string id)
        {
            var gameKeys = this.db.Keys.Where(k => k.GameId == id).ToList();
            if (gameKeys == null)
            {
                return this.NotFound();
            }

            return gameKeys;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<Key> Post(Key keys)
        {
            var key = new Key
            {
                GameId = keys.GameId,
                CreatedOn = DateTime.Now,
                IsUsed = false,
            };
            this.db.Add(key);
            this.db.SaveChanges();
            return this.Created($"/api/GameKey/{key.Id}", key);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var key = new Key()
            {
                Id = id,
            };
            db.Keys.Attach(key);
            db.Keys.Remove(key);
            db.SaveChanges();
        }
    }
}
