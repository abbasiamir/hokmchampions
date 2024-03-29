using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HokmChampions.Data.Entities
{
    public class Match
    {
        [Key]
        public long MatchId { get; set; }
        [Required]
        public int seri { get; set; }
        public int round { get; set; }
        public int matchNo { get; set; }
        public string? player1 { get; set; }
        public string? player2 { get; set; }
        public int player1_score { get; set; }
        public int player2_score { get; set; }
        public int player1_top_score { get; set; }
        public int player2_top_score { get; set; }
        public string? winner { get; set; }
        //[ForeignKey("Match")]
        public List<Card>? cards { get; set; }    

    }
}
