namespace cricket_statistics.Areas.Admin.Models
{
    public class VenueModel
    {
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public int CityID { get; set; }
        public int TotalMatches { get; set; }
        public int WeatherID { get; set; }
    }
}
