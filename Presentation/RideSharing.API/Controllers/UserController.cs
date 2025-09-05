using MediatR;
using Microsoft.AspNetCore.Mvc;
using miniproj.Application.Commands;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand cmd)
    {
        await _mediator.Send(cmd); 
        return Ok();
    }
}