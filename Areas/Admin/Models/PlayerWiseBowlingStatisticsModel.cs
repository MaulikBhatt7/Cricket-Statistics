namespace cricket_statistics.Areas.Admin.Models
{
    public class PlayerWiseBowlingStatisticsModel
    {
        public int BowlStatID { get; set; }
        public int PlayerID { get; set; }
        public int FormatID { get; set; }
        public int Matches { get; set; }
        public int Innings { get; set; }
        public int Balls { get; set; }
        public int Runs { get; set; }
        public int Wickets { get; set; }
        public string BBI { get; set; }
        public string BBM { get; set; }
        public decimal Economy { get; set; }
        public decimal Average { get; set; }
        public decimal StrikeRate { get; set; }
        public int FiveW { get; set; }
        public int TenW { get; set; }
    }
}
