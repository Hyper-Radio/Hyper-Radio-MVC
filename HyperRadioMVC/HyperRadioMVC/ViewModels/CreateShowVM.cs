using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HyperRadioMVC.ViewModels
{
    public class CreateShowVM
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public List<int> TrackIds { get; set; } = new();
    }
}