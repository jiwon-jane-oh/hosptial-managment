using Microsoft.AspNetCore.SignalR;

namespace HospitalServerHub
{
    public class SupplierContact : Hub
    {
        public async Task SendInventoryMessage(string message)
        {
            // It takes the name of the method to be invoked on the client-side
            await Clients.All.SendAsync("ReceiveInventoryMessage", message);
        }
    }
}
