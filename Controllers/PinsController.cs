using Microsoft.AspNetCore.Mvc;
using Pinterest.Api.DTOs;
using Pinterest.Api.Interfaces;
using Pinterest.Api.Models;

namespace Pinterest.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PinsController : ControllerBase
{
    private readonly IPinService _pinService;

    public PinsController(IPinService pinService)
    {
        _pinService = pinService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPins()
    {
        var pins = await _pinService.GetAllAsync();

        return Ok(pins);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePin(CreatePinDto createPinDto)
    {
        var pin = new Pin
        {
            Title = createPinDto.Title,
            Description = createPinDto.Description,
            ImageUrl = createPinDto.ImageUrl,
            Author = createPinDto.Author
        };

        var createdPin = await _pinService.AddAsync(pin);

        return CreatedAtAction(nameof(GetPinById), new { id = createdPin.Id }, createdPin);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPinById(int id)
    {
        var pin = await _pinService.GetByIdAsync(id);

        if (pin == null)
        {
            return NotFound();
        }

        return Ok(pin);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePin(int id, UpdatePinDto updatePinDto)
    {
        var pin = new Pin
        {
            Title = updatePinDto.Title,
            Description = updatePinDto.Description,
            ImageUrl = updatePinDto.ImageUrl,
            Author = updatePinDto.Author
        };

        var updatedPin = await _pinService.UpdateAsync(id, pin);

        if (updatedPin == null)
        {
            return NotFound();
        }

        return Ok(updatedPin);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePin(int id)
    {
        var deletedPin = await _pinService.DeleteAsync(id);

        if (!deletedPin)
        {
            return NotFound();
        }

        return NoContent();
    }
}