using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Api.Models;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/[controller]")] // api/polls
    [ApiController]
    public class PollsController : ControllerBase
    {
        private readonly List<Poll> _polls = [
            new Poll
            {
                Id = 1,
                Title = "Poll 1",
                Description = "This is First Poll"
            }
        ];

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_polls);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var poll = _polls.SingleOrDefault(p=> p.Id == id);

            return poll is null ? NotFound() : Ok(poll);
        }
        

    }
}
