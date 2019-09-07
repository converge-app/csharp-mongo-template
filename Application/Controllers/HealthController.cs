using Application.Database;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : Controller
    {
        private readonly IDatabaseContext dbContext;

        public HealthController(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET api/health/ping
        [Produces("application/json")]
        [HttpGet("ping")]
        public ActionResult Ping()
        {
            if (dbContext.IsConnectionOpen())
            {
                return Ok(new { Message = "pong!" });
            }
            else
            {
                return BadRequest("Cannot connect to db");
            }

        }
    }
}