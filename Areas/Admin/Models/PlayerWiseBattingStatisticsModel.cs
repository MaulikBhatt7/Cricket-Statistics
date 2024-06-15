namespace cricket_statistics.Areas.Admin.Models
{
    public class PlayerWiseBattingStatisticsModel
    {
        public int BatStatID { get; set; }
        public int PlayerID { get; set; }
        public int FormatID { get; set; }
        public int Matches { get; set; }
        public int Innings { get; set; }
        public int NotOuts { get; set; }
        public int Runs { get; set; }
        public int HighestScore { get; set; }
        public decimal BattingAverage { get; set; }
        public int BallsFaced { get; set; }
        public decimal StrikeRate { get; set; }
        public int Centuries { get; set; }
        public int HalfCenturies { get; set; }
        public int Fours { get; set; }
        public int Sixes { get; set; }
        public int Catches { get; set; }
        public int Stumpings { get; set; }
    }
}
