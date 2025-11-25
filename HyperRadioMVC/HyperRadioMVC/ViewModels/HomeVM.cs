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

    
    //Show details view model including parse of scheduled time into a rounded cleaner start time
    public class ShowDetailsVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledStart { get; set; }

        // Round start to nearest 15 minutes
        private DateTime RoundedStart
        {
            get
            {
                int minutes = ScheduledStart.Minute;
                int rounded = (int)(Math.Round(minutes / 15.0) * 15) % 60;
                return new DateTime(
                    ScheduledStart.Year,
                    ScheduledStart.Month,
                    ScheduledStart.Day,
                    ScheduledStart.Hour + (rounded == 60 ? 1 : 0),
                    rounded == 60 ? 0 : rounded,
                    0
                );
            }
        }

        public string FormattedDate =>
            RoundedStart.ToString("dddd, MMMM dd, yyyy");

        public string FormattedTimeRange
        {
            get
            {
                var start = RoundedStart;
                var end = start.AddHours(2); // default 2-hour show

                return $"{start:HH\\.mm} - {end:HH\\.mm}";
            }
        }
    }
}