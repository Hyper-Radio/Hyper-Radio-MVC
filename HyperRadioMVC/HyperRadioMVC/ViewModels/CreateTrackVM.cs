using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HyperRadioMVC.ViewModels
{
    public class CreateTrackVM
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Genre { get; set; } = string.Empty;

        [Required]
        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }

        [Required]
        public IFormFile File { get; set; } = default!;

        public string? ImageURL { get; set; }
    }
}