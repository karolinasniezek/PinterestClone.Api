using Microsoft.AspNetCore.Mvc;
using Pinterest.Api.Services;

namespace Pinterest.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PinsController : ControllerBase
{
    private readonly PinService _pinService;

    public PinsController(PinService pinService)
    {
        _pinService = pinService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPins()
    {
        var pins = await _pinService.GetAllAsync();

        return Ok(pins);
    }
}