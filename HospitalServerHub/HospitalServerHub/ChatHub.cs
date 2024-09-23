using Microsoft.AspNetCore.SignalR;

namespace HospitalServerHub
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // It takes the name of the method to be invoked on the client-side
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
