namespace cricket_statistics.Areas.Admin.Models
{
    public class WeatherModel
    {
        public int WeatherID { get; set; }
        public string WeatherTemperature { get; set; }
        public DateTime Date { get; set; }
        public int CityID { get; set; }
    }
}
