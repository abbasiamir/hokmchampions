using HokmChampions.Data;
using HokmChampions.Data.Entities;

namespace HokmChampions.Services
{
    public class MatchesCrudService
    {
        private readonly ApplicationDbContext _context;
        public MatchesCrudService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Match> GetSeriMatches(int seri)
        {
            return _context.Matches.Where(x=>x.seri == seri).ToList();
        }
        public Match getMatch(int seri, int round, int matchNo)
        {
            return ((Match)(_context.Matches.FirstOrDefault(x => x.seri == seri && x.round == round && x.matchNo == matchNo)));
        }
        public Match GetMatch(string username)
        {
            
             return _context.Matches.FirstOrDefault(x=>x.player1==username||x.player2==username&&x.winner==null);
           
        }
        public Match GetMatch(long matchid)
        {
            return _context.Matches.FirstOrDefault(x=>x.MatchId==matchid);
        }
        public string GetUserId(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == username).Id;
        }
        public Match AddOrUpdateMatch(string username)
        {
            for(int i = 1; i < 8; i++)
            {
                for(int j = 1; j < 9; j++)
                {
                    Match match = _context.Matches.FirstOrDefault(x => x.seri == i && x.round == 1 && x.matchNo == j);
                    if (match==null)
                    {
                        match = new()
                        {

                            seri = i,
                            round = 1,
                            matchNo = j,
                            player1 = username
                        };
                        _context.Matches.Add(match);
                        _context.SaveChanges();
                        //fillinfoes(match);
                        return match;
                    }
                    else if (match.player2 == null)
                    {
                        match.player2 = username;
                        _context.SaveChanges();
                       // fillinfoes(match);
                        return match;
                    }
                }
            }
            for(int i = 1; i < 8; i++)
            {
                if(_context.Matches.FirstOrDefault(x=>x.seri == i && x.round == 4 && x.winner != null)!=null)
                {
                    var result = _context.Matches.Select(x => x.seri == i).ToList();
                    if (result != null && result.Count != 0)
                    {
                        _context.Matches.RemoveRange(_context.Matches.Where(x=>x.seri==i));
                        _context.SaveChanges();
                        Match match = AddOrUpdateMatch(username);
                        return match;
                    }
                }
            }
            return null;
        }
        //public void fillinfoes(Match match)
        //{
        //    infoes.seri= match.seri;
        //    infoes.MatchId= match.MatchId;
        //    infoes.round= match.round;
        //    infoes.MatchNo=match.matchNo;
        //    infoes.AddedToJadval = true;
        //    if (match.player1 == infoes.username)
        //        infoes.player = 1;
        //    else
        //        infoes.player = 2;
        //}
        public long AddMatch(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
            return (match.MatchId);
        }
        public bool setPlayer2(int matchid, string player2)
        {
            var result = _context.Matches.FirstOrDefault(x => x.MatchId == matchid);
            if (result != null)
            {
                result.player2 = player2;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool setScoreP1(int matchid, int score)
        {

            var result = _context.Matches.FirstOrDefault(x => x.MatchId == matchid);
            if (result != null)
            {
                result.player1_score = score;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool setScoreP2(int matchid, int score)
        {

            var result = _context.Matches.FirstOrDefault(x => x.MatchId == matchid);
            if (result != null)
            {
                result.player2_score = score;
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public bool setTopScoreP1(int matchid, int score)
        {

            var result = _context.Matches.FirstOrDefault(x => x.MatchId == matchid);
            if (result != null)
            {
                result.player1_top_score = score;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool setTopScoreP2(int matchid, int score)
        {

            var result = _context.Matches.FirstOrDefault(x => x.MatchId == matchid);
            if (result != null)
            {
                result.player2_top_score = score;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool setWinner(int matchid, string player)
        {

            var result = _context.Matches.FirstOrDefault(x => x.MatchId == matchid);
            if (result != null)
            {
                result.winner= player;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool RemoveMatch(int matchid)
        {

            var result = _context.Matches.FirstOrDefault(x => x.MatchId == matchid);
            if (result != null)
            {
                _context.Matches.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Card> GetMyCards(Match match,int player)
        {
            return _context.Cards.Where(x=>x.playerNo==player&&x.MatcheIdFK==match.MatchId).OrderBy(c=>c.cardType).ThenByDescending(c=>c.cardNo).ToList();
        }
        public List<Card> GetMyCards(Match match, int player,int count)
        {
            return _context.Cards.Where(x => x.playerNo == player && x.MatcheIdFK == match.MatchId).Take(count).OrderBy(c => c.cardType).ThenByDescending(c => c.cardNo).ToList();
        }
        public async Task addCard(Card card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
        }
        public void RemoveMatchCards(long matchid)
        {
            var result = _context.Cards.Select(x => x.MatcheIdFK == matchid).ToList();
            if (result != null&&result.Count!=0)
            {
                _context.Cards.RemoveRange(_context.Cards.Where(x => x.MatcheIdFK == matchid));
                _context.SaveChanges();
            }
        }
    }
}