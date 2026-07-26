using Pinterest.Api.Models;

namespace Pinterest.Api.Interfaces;

public interface IPinService
{
    Task<List<Pin>> GetAllAsync();

    Task<Pin?> GetByIdAsync(int id);

    Task<Pin> AddAsync(Pin pin);

    Task<Pin?> UpdateAsync(int id, Pin updatedPin);

    Task<bool> DeleteAsync(int id);
}