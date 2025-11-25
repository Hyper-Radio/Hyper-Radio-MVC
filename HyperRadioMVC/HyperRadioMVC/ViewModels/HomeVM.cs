using System.Text.Json.Serialization;

namespace HyperRadioMVC.ViewModels
{
    public class HomeVM
    {
        public ArtistProfileVM ArtistProfile { get; set; }
        public ShowDetailsVM ShowDetails { get; set; }
    }

    public class ArtistProfileVM
    {
        [JsonPropertyName("username")]
        public string Name { get; set; }
        public string Description { get; set; }
        
        [JsonPropertyName("profilePictureURL")]
        public string ImageUrl { get; set; }
    }

    public class ShowDetailsVM
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime ScheduledStart { get; set; }
    }
}