using Application.ChatAI.Commands;
using Application.ChatAI.Queries;
using Application.Common.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatBotAI_Prototype.Server.Controllers;

//TODO
//[Authorize]
[ApiController]
[Route("[controller]")]
public class ChatAIController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetMessagesByUser(int userId, CancellationToken cancellationToken)
    {
        var messages = await _mediator.Send(new GetChatMessagesByUserQuery(userId), cancellationToken);

        return Ok(messages);
    }

    [HttpPost("createMessage")]
    public async Task<IActionResult> CreateMessage([FromBody] CreateChatMessageDto message, CancellationToken cancellationToken)
    {
        if (message is null)
            return NotFound();

        var result = await _mediator.Send(new CreateChatMessageCommand(message), cancellationToken);
        return Ok(result);
    }

    [HttpPut("updateRespone")]
    public async Task<IActionResult> UpdateResponse([FromBody] UpdateChatResponseDto response, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateChatResponseCommand(response), cancellationToken);
        return Ok(result);
    }

    [HttpPut("updateRatingResponse")]
    public async Task<IActionResult> UpdateRatingResponse([FromBody] UpdateRatingChatResponseDto response, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateRatingChatResponseCommand(response), cancellationToken);
        return Ok(result);
    }
}
