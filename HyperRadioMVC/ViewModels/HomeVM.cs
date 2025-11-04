namespace HyperRadioMVC.ViewModels
{
    public class HomeVM
    {
        public ArtistProfileVM ArtistProfile { get; set; }
        public ShowDetailsVM ShowDetails { get; set; }
    }

    public class ArtistProfileVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public class ShowDetailsVM
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime ScheduledStart { get; set; }
    }
}