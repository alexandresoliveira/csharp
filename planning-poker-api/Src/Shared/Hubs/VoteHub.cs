using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace PlanningPokerApi.Src.Shared.Hubs
{
  public class VoteHub : Hub
  {
    public async Task SendMessage(string user, string message)
    {
      await Clients.All.SendAsync("VoteRegister", user, message);
    }
  }
}