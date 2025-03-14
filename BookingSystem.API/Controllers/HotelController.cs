﻿using BookingSystem.Application.Services;
using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingSystem.API.Controllers;
[Route("[controller]")]
public class HotelController : ControllerBase
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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] HotelRequest request,CancellationToken ct)
    {
        var result = await _hotelService.Create(request, ct);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}
