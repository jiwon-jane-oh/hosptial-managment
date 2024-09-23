
using Microsoft.AspNetCore.SignalR;

namespace HospitalServerHub
{
    public class AppointmentHub : Hub
    {

        public async Task SendAppointmentUpdate(int doctorId, int patientId, string message)
        {
            await Clients.All.SendAsync("RecieveAppointmentUpdate", doctorId, patientId, message);
        }
        public async Task SendAppointmentUpdateForCancel(int doctorId, int patientId, string message)
        {
            await Clients.All.SendAsync("RecieveCancelledAppointmentMessage", doctorId, patientId, message);
        }
    }
}
