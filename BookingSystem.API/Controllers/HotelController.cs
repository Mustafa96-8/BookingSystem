using BookingSystem.Application.Services;
using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingSystem.API.Controllers;
public class HotelController : BaseController
{
    private readonly HotelService _hotelService;
    public HotelController(HotelService hotelService)
    {
        _hotelService = hotelService;
    }

    // GET: api/<HotelController>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var result = await _hotelService.GetAll(ct);

        if (result.IsSuccess) 
        {
        return Ok(result.Value);
        }
        return BadRequest(result.Error);

    }
    // </snippet_GetByID>

    // GET: api/<HotelController>/<guid>
    // <snippet_Update>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid? id, CancellationToken ct)
    {
        var result = await _hotelService.GetById(id, ct);
        if(result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    // </snippet_Update>

    // POST: api/TodoItems
    // <snippet_Create>

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] HotelRequest request,CancellationToken ct)
    {
        var result = await _hotelService.Create(request, ct);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    // </snippet_Create>

}
