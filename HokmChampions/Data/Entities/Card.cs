using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HokmChampions.Data.Entities
{
    public class Card
    {
        [Key]
        public long Id { get; set; }        
        public int playerNo { get; set; }
        public int cardType { get; set; }
        public int cardNo { get; set; }
        public long MatcheIdFK { get; set; }
        public Match Match { get; set; }
    }
}
