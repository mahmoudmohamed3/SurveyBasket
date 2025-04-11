using Mapster;
using MapsterMapper;

namespace SurveyBasket.Api.Controllers
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

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var poll = _pollService.Get(id);

            if (poll == null)
            {
                return NotFound();
            }

            

            var response = poll.Adapt<PollResponse>();


            return Ok(response);
        }

        [HttpPost ("")]
        public IActionResult Add ( Poll request)
        {
            var newPoll = _pollService.Add(request);

            return CreatedAtAction(nameof(Get) , new { id = newPoll.Id } , newPoll);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Poll request)
        {
            var isUpdated = _pollService.Update(id, request);

            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _pollService.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
