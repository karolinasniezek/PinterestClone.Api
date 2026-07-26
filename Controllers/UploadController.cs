using Microsoft.AspNetCore.Mvc;
using Pinterest.Api.Interfaces;

namespace Pinterest.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    private readonly IUploadService _uploadService;

    public UploadController(IUploadService uploadService)
    {
        _uploadService = uploadService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var imageUrl = await _uploadService.UploadAsync(file);

        return Ok(new
        {
            ImageUrl = imageUrl
        });
    }
}