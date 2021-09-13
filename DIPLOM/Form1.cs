using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DIPLOM.Conection;

namespace DIPLOM
{
   public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         private void Form1_Load(object sender, EventArgs e)
        {
            usernameTextBox.Select();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(usernameTextBox.Text) && !string.IsNullOrEmpty(passwordTextBox.Text))
            {
                string SQL = string.Empty;
                SQL += "SELECT idLogin, NameUser, Posada FROM LoginPassword ";
                SQL += "WHERE Login='" + usernameTextBox.Text + "' ";
                SQL += "AND Password='" + passwordTextBox.Text + "'";

                DataTable userData = ServerConection.executeSQL(SQL);

                if(userData.Rows.Count > 0)
                {
                    usernameTextBox.Clear();
                    passwordTextBox.Clear();
                    this.Hide();

                    MainForm formMain = new MainForm(userData.Rows[0][0].ToString(), userData.Rows[0][1].ToString(), userData.Rows[0][2].ToString());
                    formMain.ShowDialog();

                    this.Show();
                    this.usernameTextBox.Select();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error login ");
                    usernameTextBox.Focus();
                    usernameTextBox.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Error");
                usernameTextBox.Select();
            }
            }
        private void usernameTextBox_Click(object sender, EventArgs e)
        {
            if(usernameTextBox.Text == "User name")
            {
                usernameTextBox.Text = "";
            }
            if(passwordTextBox.Text.Length == 0)
                passwordTextBox.Text = "Password";
        }
        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "Password")
            {
                passwordTextBox.Text = "";
            }
            if (usernameTextBox.Text.Length == 0)
                usernameTextBox.Text = "User name";
        }
        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = checkBox1.Checked ? '*' : '\0';
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
