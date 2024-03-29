using HokmChampions.Data;
using HokmChampions.Data.Entities;

namespace HokmChampions.Services
{
    public  class HokmGame
    {
        private readonly MatchesCrudService _MatchesCrudService;
        //private readonly ApplicationDbContext _context;
         string[] cardNames = { "02اسپیک", "03اسپیک", "04اسپیک", "05اسپیک", "06اسپیک", "07اسپیک", "08اسپیک", "09اسپیک", "10اسپیک", "11اسپیک", "12اسپیک", "13اسپیک", "14اسپیک",
            "02دل", "03دل", "04دل","05دل","06دل","07دل","08دل","09دل","10دل","11دل","12دل","13دل","14دل" ,
        "02گیشنیز", "03گیشنیز", "04گیشنیز", "05گیشنیز", "06گیشنیز", "07گیشنیز", "08گیشنیز", "09گیشنیز", "10گیشنیز", "11گیشنیز", "12گیشنیز", "13گیشنیز", "14گیشنیز",
        "02خشت","03خشت","04خشت","05خشت","06خشت","07خشت","08خشت","09خشت","10خشت","11خشت","12خشت","13خشت","14خشت" };
        //string imgUrl = "/Images/Cards/" + cardNames[0] + ".png";
        public HokmGame(MatchesCrudService matchesCrudService)
        {
           _MatchesCrudService = matchesCrudService;
        }

        public  async Task dist(int count, Match match)
        {
            int begin = 0;
            if (count == 13)
                begin = 5;
            List<string> swapCards = new List<string>();
            swapCards.AddRange(cardNames);
            for (int i = 1; i < 5; i++)
            {
                for (int j = begin; j < count; j++)
                {


                    Random rand = new Random();
                    int index = rand.Next(swapCards.Count);
                    Cardinstant card = new Cardinstant((string)swapCards[index]);
                    swapCards.RemoveAt(index);
                    Card c = new Card
                    {
                        cardNo = card.no,
                        cardType = card.type,
                        playerNo = i,
                        Match = match
                    };
                    await _MatchesCrudService.addCard(c);

                }
            }
            
        }
    }


    public enum CardType
    {
        اسپیک = 1,
        دل = 2,
        گیشنیز = 3,
        خشت = 4

    }
    public class Cardinstant
    {
        public string name;
        public int type;
        public int no;
        public Cardinstant(string cardname)
        {
            name = cardname;
            no = Convert.ToInt32(cardname.Substring(0, 2));
            string t = cardname.Substring(2);
            type = CardsActions.getCardTypeno(t);
        }
    }
    public static class CardsActions
    {
        public static int getCardTypeno(string type)
        {
            switch (type)
            {
                case "اسپیک":
                    {
                        return 1;
                        break;
                    }
                case "دل":
                    {
                        return 2;
                        break;
                    }
                case "گیشنیز":
                    {
                        return 3;
                        break;
                    }
                case "خشت":
                    {
                        return 4;
                        break;
                    }
            }
            return 0;
        }
        public static string GetCardTypeName(int type)
        {
            switch (type)
            {
                case 1:
                    return "اسپیک";
                case 2:
                    return "دل";
                case 3:
                    return "گیشنیز";
                case 4:
                    return "خشت";
            }
            return null;
        }
        public static string getTypeName(int typeNumber)
        {
            switch (typeNumber)
            {
                case 1:
                    return "اسپیک";
                case 2:
                    return "دل";
                case 3:
                    return "گیشنیز";
                case 4:
                    return "خشت";

            }
            return null;
        }
        public static string getCardName(Card card)
        {
            return card.cardNo.ToString("00") + GetCardTypeName(card.cardType);

        }
        public static List<Cardinstant> Card2instant(List<Card> cards)
        {
            List<Cardinstant> ci = new List<Cardinstant>();
            foreach (Card c in cards)
            {
                ci.Add(new Cardinstant(c.cardNo.ToString("00") + CardsActions.GetCardTypeName(c.cardType)));
            }
            return ci;
        }
    }
}
