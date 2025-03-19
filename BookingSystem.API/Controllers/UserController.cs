using BookingSystem.Application.Services;
using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers;

public class UserController : BaseController
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // GET: api/<UserController>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var result = await _userService.GetAll(ct);

        if(result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);

    }
    // </snippet_GetByID>

    // GET: api/<UserController>/<guid>
    // <snippet_Update>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid? id, CancellationToken ct)
    {
        var result = await _userService.GetById(id, ct);
        if(result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    // </snippet_Update>

    // POST: api/<UserController>
    // <snippet_Create>

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDTO request, CancellationToken ct)
    {
        var result = await _userService.Create(request, ct);
        if(result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    // </snippet_Create>

}
