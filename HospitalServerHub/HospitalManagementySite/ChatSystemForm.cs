using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementySite
{
    // The class implements communiation between all users in the hospital using signalR
    public partial class ChatSystemForm : Form
    {
        private HubConnection connection; // keep track of the connection for chathub channel
        private User currUser;  // keep track of information of the current login user
        public ChatSystemForm(User currUser)
        {
            InitializeComponent();
            InitializeSignalR();
            this.currUser = currUser;
        }

        // helper function to enable signalR for chathub communication channel
        private async void InitializeSignalR()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5041/chathub")
                .Build();

            // receive messages on the chathub port
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Invoke((Action)(() =>
                {

                    string messageText = $"{user}: {message}";

                    listBoxChat.Items.Add(messageText);
                }));
            });

            try
            {
                await connection.StartAsync();
                MessageBox.Show("Connection to the hub was sucessful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Asynconous function to handle send button click. Send the message to other users 
        // within the hospital using signalR
        private async void buttonSend_Click(object sender, EventArgs e)
        {
            // sending messages
            string message = textBoxMessage.Text;

            try
            {
                await connection.InvokeAsync("SendMessage", currUser.Username, message);
                textBoxMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
