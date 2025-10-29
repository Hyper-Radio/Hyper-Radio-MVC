namespace HyperRadioMVC.ViewModels;

public class CreatePitchVM
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public string TrackURL { get; set; }
    public string? ImageURL { get; set; }
}