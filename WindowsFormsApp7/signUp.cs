using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp7
{
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            string confirmPassword = textBox4.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter.");
                return;
            }

            global::User newUser = new global::User
            {
                Name = name,
                Email = email,
                Password = password
            };

            SaveUserData(newUser);

            MessageBox.Show("Sign up successful! Information saved.");
        }

        private void SaveUserData(global::User user)
        {
            string filePath = "user_info.json";
            List<global::User> userList = LoadUserData(filePath);

            userList.Add(user);

            SaveUserDataToFile(userList, filePath);
        }

        private List<global::User> LoadUserData(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);

                return JsonConvert.DeserializeObject<List<global::User>>(jsonData);
            }
            else
            {
                return new List<global::User>();
            }
        }

        private void SaveUserDataToFile(List<global::User> userList, string filePath)
        {
            string jsonData = JsonConvert.SerializeObject(userList, Formatting.Indented);

            File.WriteAllText(filePath, jsonData);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, EventArgs e)
        {
            logIn logIn = new logIn();
            logIn.Show();
            this.Hide();
        }
    }
}
