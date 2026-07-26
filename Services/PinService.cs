using Microsoft.EntityFrameworkCore;
using Pinterest.Api.Data;
using Pinterest.Api.Interfaces;
using Pinterest.Api.Models;

namespace Pinterest.Api.Services;

public class PinService : IPinService
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

    public async Task<Pin> AddAsync(Pin pin)
    {
        _context.Pins.Add(pin);

        await _context.SaveChangesAsync();

        return pin;
    }

    public async Task<Pin?> GetByIdAsync(int id)
    {
        return await _context.Pins.FirstOrDefaultAsync(pin => pin.Id == id);
    }

    public async Task<Pin?> UpdateAsync(int id, Pin updatedPin)
    {
        var pin = await _context.Pins.FirstOrDefaultAsync(p => p.Id == id);

        if (pin == null)
        {
            return null;
        }

        pin.Title = updatedPin.Title;
        pin.Description = updatedPin.Description;
        pin.ImageUrl = updatedPin.ImageUrl;
        pin.Author = updatedPin.Author;

        await _context.SaveChangesAsync();

        return pin;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pin = await _context.Pins.FirstOrDefaultAsync(p => p.Id == id);

        if (pin == null)
        {
            return false;
        }

        _context.Pins.Remove(pin);
        await _context.SaveChangesAsync();

        return true;
    }
}