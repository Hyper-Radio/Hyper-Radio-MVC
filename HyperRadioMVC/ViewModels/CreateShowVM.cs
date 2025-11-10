using System.ComponentModel.DataAnnotations;

namespace HyperRadioMVC.ViewModels;

public class CreateShowVM
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public DateTime ScheduledStart { get; set; }

    public List<int> TrackIds { get; set; } = new();
}