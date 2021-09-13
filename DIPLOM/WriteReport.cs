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
using DIPLOM.Classes;

namespace DIPLOM
{
    public partial class WriteReport : Form
    {
        int MaxID;
        int Turn;
        public WriteReport()
        {
            InitializeComponent();

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.Items.AddRange(new string[] { "Чоловік", "Жінка" });
            PrintGroupInComboBox();
            PrintmaxID();
        }
        // Метод пошуку груп працівників поліції
        public void PrintGroupInComboBox()
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            string myConnection = "SELECT * FROM GROUPS_PO";
            SqlCommand command = new SqlCommand(myConnection, sqlCon);
            SqlDataReader dr;
            try
            {
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    String sname = (string)dr["Name_group"];
                    comboBox2.Items.Add(sname);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message, "An error occurred!"); }
            sqlCon.Close();
        }
        // Метод пошуку максимального ключа порушника
        public void PrintmaxID()
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            string myConnectionID = "SELECT MAX(idOFFENDER) from OFFENDER";
            SqlCommand commandID = new SqlCommand(myConnectionID, sqlCon);
            SqlDataReader reader = commandID.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[1]);
                data[data.Count - 1][0] = reader[0].ToString();
            }
            reader.Close();
            sqlCon.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);

            MaxID = int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
        }
        // Метод додавання порушника у БД
        public void InsertDataOFFENDER()
        {
            try
            {
                PrintmaxID();
                string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
                SqlConnection sqlCon = new SqlConnection(connectionString);
                sqlCon.Open();
                string myConnection = "INSERT INTO OFFENDER(NameOffender, Sex, Passport, Address, Birthday) VALUES('" + bunifuTextBoxNameOff.Text + "', '" + comboBox1.Text + "', '" + bunifuTextBoxPassportOff.Text + "', '" + bunifuTextBoxAddressOff.Text + "', '" + dateTimePicker2.Value.ToString() + "');";
                SqlCommand command = new SqlCommand(myConnection, sqlCon);
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Inserted!");
                }
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ви ввели неправильні дані", "Додавання даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Метод додавання операції до БД
        public void InsertDataOPERATIONS()
        {
            try
            {
                PrintmaxID();
                MaxID = MaxID + 1;
                string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
                SqlConnection sqlCon = new SqlConnection(connectionString);
                sqlCon.Open();
                string myConnection = "INSERT INTO OPERATIONS(idOPERATIONS, NameOperation, DateOperation, FKidOFFENDER, NameGroup)" + " VALUES(" + MaxID + ", '" + bunifuTextBox6.Text + "', '" + dateTimePicker1.Value.ToString() + "', '" + MaxID + "', '" + comboBox2.Text + "'); ";
                SqlCommand command = new SqlCommand(myConnection, sqlCon);
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Inserted!");
                }
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ви ввели неправильні дані", "Додавання даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Метод відображення спадкової форми
        private Form activForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (activForm != null) activForm.Close();
            activForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelChildReport.Controls.Add(ChildForm);
            panelChildReport.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        // Метод загрузки анімації
        private void WriteReport_Load(object sender, EventArgs e)
        {
           panelWriteReport.Visible = false;
           bunifuTransition1.Show(panelWriteReport);
        }
        // Метод виклику наступної сторінки заповненя
        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            openChildForm(new WriteReport2(MaxID, Turn));
        }
        // Метод події додавання порушника до БД
        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (bunifuTextBoxNameOff.Text.Length != 0 && bunifuTextBoxPassportOff.Text.Length != 0 &&
                bunifuTextBoxAddressOff.Text.Length != 0 && dateTimePicker2.Text.Length != 0)
            {
                int year1 = dateTimePicker2.Value.Year;
                DateTime dta = DateTime.Today;
                int year2 = dta.Year;
                if (year1 > (year2 - 10))
                {
                    MessageBox.Show("Ви ввели дату народження некоректно!", "Додавання даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuTextBoxNameOff.Text = "";
                    bunifuTextBoxPassportOff.Text = "";
                    bunifuTextBoxAddressOff.Text = "";
                    dateTimePicker2.Text = "";
                }
                else
                {
                    InsertDataOFFENDER();
                    bunifuTextBoxNameOff.Text = "";
                    bunifuTextBoxPassportOff.Text = "";
                    bunifuTextBoxAddressOff.Text = "";
                    dateTimePicker2.Text = "";
                }
                Turn = 1;
            }
        }
        private void bunifuTextBoxPassportOff_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) 
            {
                e.Handled = true;
            }
        }
        private void bunifuTextBoxNameOff_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsLetter(number) && number != 8 && number != 32 && number != 46 && number != 45 && number != 39) 
            {
                e.Handled = true;
            }
        }
        // Метод події додавання операцій до БД
        private void bunifuButton6_Click_1(object sender, EventArgs e)
        {
            if (Turn == 1)
            {
                if (bunifuTextBox6.Text.Length != 0 && comboBox2.Text.Length != 0)
                {
                    InsertDataOPERATIONS();
                    bunifuTextBox6.Text = "";
                    comboBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Заповніть дані коректно!", "Додавання даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bunifuTextBox6.Text = "";
                comboBox2.Text = "";
                MessageBox.Show("Заповніть попередньо іншні таблиці!", "Додавання даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void bunifuTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsLetter(number) && number != 8 && number != 32 && number != 46 && number != 45 && number != 39)
            {
                e.Handled = true;
            }
        }
        // Метод виклику пошуку порушників по паспорту
        private void bunifuButton3_Click(object sender, EventArgs e)
        {   
            string passportName = bunifuTextBoxPassportOff.Text;
            openChildForm(new SearchForm(passportName));
        }
    }
}
