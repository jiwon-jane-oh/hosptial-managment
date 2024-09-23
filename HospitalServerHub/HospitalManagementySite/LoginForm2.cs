using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementySite
{
    public partial class LoginForm2 : Form
    {

        IMongoCollection<User> userCollection;
      

    



        public LoginForm2()
        {
            InitializeComponent();
        }

        private void LoginForm2_Load(object sender, EventArgs e)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
                var databaseName = MongoUrl.Create(connectionString).DatabaseName;
                var mongoClient = new MongoClient(connectionString);
                var database = mongoClient.GetDatabase(databaseName);
                userCollection = database.GetCollection<User>("users");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}");
                Application.Exit();
            }
        }

     

        private void button_register_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username = textBox_username.Text;
            string password = textBox_password.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {
                ////2. Create an instance of object User
                var filter = Builders<User>.Filter.Eq("Username", username);
                var user = userCollection.Find(filter).FirstOrDefault();

                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    MessageBox.Show("Login successful!");
                    //LoginData.UserId = user.UserId;
                    //LoginData.UserType = user.AccessLevel;
                    //LoginData.FullName = $"{user.FirstName}, {user.LastName}";
                    LoginData.LoginUser = user;



            
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}");
            }
        }
    }
}
