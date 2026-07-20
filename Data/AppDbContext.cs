using Microsoft.EntityFrameworkCore;
using Pinterest.Api.Models;

namespace Pinterest.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pin> Pins { get; set; }
}