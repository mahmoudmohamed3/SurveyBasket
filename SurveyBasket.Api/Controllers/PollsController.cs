﻿using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using SurveyBasket.Api.Contracts.Poll;
using System.Threading;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/[controller]")] // api/polls
    [ApiController]

    public class PollsController (IPollService pollService): ControllerBase
    {
        
        private readonly IPollService _pollService = pollService;


        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var polls = await _pollService.GetAllAsync();

            var response = polls.Adapt<IEnumerable<PollResponse>>();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id , CancellationToken cancellationToken = default)
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
        public async Task<IActionResult> Add([FromBody] PollRequest request , CancellationToken cancellationToken)
        {
            var newPoll = await _pollService.AddAsync(request.Adapt<Poll>() , cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
        }

        [HttpPut("{id:int}")]
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] PollRequest request , CancellationToken cancellationToken)
        {
            var isUpdated = await _pollService.UpdateAsync(id, request.Adapt<Poll>(), cancellationToken);

            if (!isUpdated)
            {
                return NotFound();
            } 

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task <IActionResult> Delete([FromRoute] int id , CancellationToken cancellationToken)
        {
            var isDeleted = await _pollService.DeleteAsync(id , cancellationToken);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id:int}/togglePublish")]
        public async Task<IActionResult> TogglePublish([FromRoute] int id, CancellationToken cancellationToken)
        {
            var isUpdated = await _pollService.TogglePublishStatusAsync(id, cancellationToken);

            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
