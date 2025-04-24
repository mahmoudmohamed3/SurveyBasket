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
        public async Task<IActionResult> GetAll()
        {
            var polls = await _pollService.GetAllAsync();

            var response = polls.Adapt<IEnumerable<PollResponse>>();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var poll = await _pollService.GetAsync(id);

            if (poll == null)
            {
                return NotFound();
            }

            var response = poll.Adapt<PollResponse>();

            return Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] CreatePollRequest request)
        {
            var newPoll = await _pollService.AddAsync(request.Adapt<Poll>());

            return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
        }

        //[HttpPut("{id:int}")]
        //public IActionResult Update([FromRoute] int id, [FromBody] Poll request)
        //{
        //    var isUpdated = _pollService.Update(id, request);

        //    if (!isUpdated)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        //[HttpDelete("{id:int}")]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    var isDeleted = _pollService.Delete(id);

        //    if (!isDeleted)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

    }
}
