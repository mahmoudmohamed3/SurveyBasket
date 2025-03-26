﻿namespace SurveyBasket.Api.Controllers
{
    [Route("api/[controller]")] // api/polls
    [ApiController]

    public class PollsController (IPollService pollService): ControllerBase
    {
        
        private readonly IPollService _pollService = pollService;


        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_pollService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var poll = _pollService.Get(id);

            return poll is null ? NotFound() : Ok(poll);
        }
        

    }
}
