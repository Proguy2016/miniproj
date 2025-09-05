using MediatR;
using Microsoft.AspNetCore.Mvc;
using miniproj.Application.Commands;
using miniproj.Application.Queries;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("book")]
    public async Task<IActionResult> Order(OrderCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var order = await _mediator.Send(new OrderQuery(id));
        if (order == null) return NotFound();
        return Ok(order);
    }
}