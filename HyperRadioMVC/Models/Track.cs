namespace HyperRadioMVC.Models;

public class Track
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string ImageUrl { get; set; }
    public string TrackUrl { get; set; }
    public string Description { get; set; }
    public string Lyrics { get; set; }
    public int Duration { get; set; }
}