using Microsoft.AspNetCore.SignalR;

namespace HokmChampions.Hubs
{
    public class simpleHub:Hub
    {
        public async Task Broadcast(string username, string key,List<string> content)
        {
            await Clients.All.SendAsync("Broadcast", username, key,content);
        }
        
        public async Task Broadcasttouser(string userid, string state,string content)
        {
            await Clients.User(userid).SendAsync("Broadcasttouser",userid, state,content);
        }
    }
}
