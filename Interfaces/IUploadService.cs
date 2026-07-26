using Microsoft.AspNetCore.Http;

namespace Pinterest.Api.Interfaces;

public interface IUploadService
{
    Task<string> UploadAsync(IFormFile file);
}