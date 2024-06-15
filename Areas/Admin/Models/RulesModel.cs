using System.ComponentModel.DataAnnotations;

namespace cricket_statistics.Areas.Admin.Models
{
    public class RulesModel
    {
        public int RuleID { get; set; }

        [Required]
        public string RuleDetails { get; set; }

        [Required]
        public int FormatID { get; set; }
    }
}
