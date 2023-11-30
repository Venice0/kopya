using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp7
{
    public partial class logIn : Form
    {
        public logIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredEmail = textBox2.Text;
            string enteredPassword = textBox3.Text;

            if (string.IsNullOrEmpty(enteredEmail) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please fill in both fields.");
                return;
            }

            if (ValidateLogin(enteredEmail, enteredPassword))
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid login credentials. Please try again.");
            }
        }

        private bool ValidateLogin(string enteredEmail, string enteredPassword)
        {
            string filePath = "user_info.json";
            List<global::User> userList = LoadUserData(filePath);
            return userList.Any(user => user.Email == enteredEmail && user.Password == enteredPassword);
        }

        private List<global::User> LoadUserData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<global::User>();
            }

            string jsonData = File.ReadAllText(filePath);

            List<global::User> userList = JsonConvert.DeserializeObject<List<global::User>>(jsonData);

            return userList;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signUp signUp = new signUp();
            signUp.Show();
            this.Hide();
        }
    }
}
