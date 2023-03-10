using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter.Application.Commands.CreateComment;
using Twitter.Application.Commands.CreateTweet;
using Twitter.Application.Commands.DeleteTweet;
using Twitter.Application.Commands.LikeTweet;
using Twitter.Application.Commands.RetweetTweet;
using Twitter.Application.Commands.UpdateTweet;
using Twitter.Application.Queries.GetAllTweets;
using Twitter.Application.Queries.GetTweetById;

namespace Twitter.API.Controllers
{
    [Route("api/tweets")]
    public class TweetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TweetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllTweetsQuery();

            var tweets = await _mediator.Send(command);

            if (tweets == null)
            {
                return NotFound();
            }

            return Ok(tweets);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetTweetByIdQuery(id);

            var tweet = await _mediator.Send(command);  

            if (tweet == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Post([FromBody] CreateTweetCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {id = id}, command);
        }

        [HttpPost("{id}/comments")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Put([FromBody] UpdateTweetCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/Like")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Like(int id)
        {
            var command = new LikeTweetCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/Retweet")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Retweet(int id)
        {
            var command = new RetweetTweetCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTweetCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
