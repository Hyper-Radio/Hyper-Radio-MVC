using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HyperRadioMVC.Models;

public class Track
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public string TrackURL { get; set; }
    public string? ImageURL { get; set; }
}