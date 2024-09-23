using Microsoft.AspNetCore.SignalR;

namespace HospitalServerHub
{
    public class CodeRedAlert: Hub
    {
        public async Task SendCodeRedMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveCodeRedMessage", message);
        }
    }
}
