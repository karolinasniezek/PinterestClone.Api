using System.ComponentModel.DataAnnotations;

namespace Pinterest.Api.DTOs;

public class CreatePinDto
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string ImageUrl { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Author { get; set; } = string.Empty;
}