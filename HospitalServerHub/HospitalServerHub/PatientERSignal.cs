using Microsoft.AspNetCore.SignalR;

namespace HospitalServerHub
{
    public class PatientERSignal: Hub
    {
        public async Task SendMessage(string message)
        {
            // It takes the name of the method to be invoked on the client-side
            await Clients.All.SendAsync("RecieveERUpdate", message);
        }
    }
}
