namespace cricket_statistics.Areas.Admin.Models
{
    public class ScheduleModel
    {
        public int ScheduleID { get; set; }
        public  int Team1ID { get; set; }

        public  int Team2ID { get; set;}

        public DateTime ScheduleDate { get; set;}

        public string Timing { get; set; }

        public int FormatID { get; set;}

        public  int VenueID { get; set;}

        public string Result { get; set;}
    }

    
}
