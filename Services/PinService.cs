using Microsoft.EntityFrameworkCore;
using Pinterest.Api.Data;
using Pinterest.Api.Models;

namespace Pinterest.Api.Services;

public class PinService
{
    private readonly AppDbContext _context;

    public PinService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pin>> GetAllAsync()
    {
        return await _context.Pins.ToListAsync();
    }
}