using HokmChampions.Data.Entities;
using HokmChampions.Services;
using Microsoft.AspNetCore.SignalR.Client;

namespace HokmChampions.Data
{
    public class infoes
    {
        public HubConnection _hubConnection { get; set; }
        public string _hubUrl { get; set; }
        public string? state { get; set; }
        public long MatchId { get; set; }
        public Match match { get; set; }
        public string? harifname { get; set; }
        public string? harifid { get; set; }
        public int MatchNo { get; set; }
        public int player { get; set; }
        public string? username { get; set; }
        public string? userid { get; set; }
        public string? hokm { get; set; }
        public string? hakem { get; set; }
        public int hakemnumber { get; set; }
        public int hokmnumber { get; set; }
        public int playerbegin { get; set; }
        public bool AddedToJadval { get; set; }
        public bool readyrecived { get; set; } = false;
        public string Modaldisplay { get; set; } = "none";
        public string Msgdisplay { get; set; } = "none";
        public string Msg { get; set; }
        public string dots { get; set; } = "";
        public Cardinstant[]? vasat { get; set; } = new Cardinstant[4]
        {
            null,
            null,
            null,
            null
         };
        public List<List<Cardinstant>> playersCards { get; set; } = new List<List<Cardinstant>>()
    {
        new List<Cardinstant>(),
        new List<Cardinstant>(),
        new List<Cardinstant>(),
        new List<Cardinstant>()
    };
        public  List<string> swapCards { get; set; } = new List<string>();

    }
}
