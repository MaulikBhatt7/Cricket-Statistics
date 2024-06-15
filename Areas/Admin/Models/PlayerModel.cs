namespace cricket_statistics.Areas.Admin.Models
{
    public class PlayerModel
    {
        public int PlayerID { get; set; }   
        public string PlayerName { get; set; } = String.Empty;

        public string PlayerImage { get; set; } = String.Empty;

        public DateTime BirthDate { get; set; }

        public int? Age { get; set; }

        public int CityID { get; set; }
            
        public string Role { get; set; } = String.Empty;

        public string BattingStyle { get; set; }  =  String.Empty;

        public string BowlingStyle { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;
    }
}
