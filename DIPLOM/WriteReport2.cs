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
    public partial class WriteReport2 : Form
    {
        int ID;
        int TURN;
        public WriteReport2()
        {
            InitializeComponent();
        }
        public WriteReport2(int MaxID, int turn)
        {
            ID = MaxID;
            TURN = turn;
            InitializeComponent();
            PrintGroupInComboBox();
        }
        public void PrintGroupInComboBox()
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            string myConnection = "SELECT DescriptionCode FROM CODE_OF_UKRAINE";
            SqlCommand command = new SqlCommand(myConnection, sqlCon);
            SqlDataReader dr;
            try
            {
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    String sname = (string)dr["DescriptionCode"];
                    comboBox2.Items.Add(sname);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message, "An error occurred!"); }
            sqlCon.Close();
        }
        public void InsertDataViolation()
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            string myConnection = "INSERT INTO VIOLATION(idVIOLATION, FKidOFFENDER, Place, Date_violation, FKidOPERATIONS, Motive, CodeName,  Witnesses, " +
                "Phone_Witnesses, City) VALUES(" + ID + ", " + ID + ",'" + bunifuTextBoxPlace.Text + "','" + dateTimePickerViolation.Value.ToString() + "'," + ID + ",'" + bunifuTextBoxMotive.Text + "','" + comboBox2.Text + "','" + bunifuTextBoxWitness.Text + "','"+ maskedTextBoxPhoneWitness.Text+"','"+bunifuTextBoxCity.Text+"');";
             SqlCommand command = new SqlCommand(myConnection, sqlCon);
             if (command.ExecuteNonQuery() > 0)
             {
                 MessageBox.Show("Inserted!");
             }
             sqlCon.Close();
        }
        public void InsertDataPunishment()
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            string myConnection = "INSERT INTO PUNISHMENT(idPUNISHMENT, Punishment, NameJudge, NameCourt, FKidOffender) VALUES("+ ID +", '" + bunifuTextBoxNameSyd.Text + "', '" + bunifuTextBoxNameSidii.Text + "', '" + bunifuTextBoxPunishment.Text + "', " + ID + ");";
            SqlCommand command = new SqlCommand(myConnection, sqlCon);
            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Inserted!");
            }
            sqlCon.Close();
        }
        private Form activForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (activForm != null) activForm.Close();
            activForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(ChildForm);
            panelChildForm.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        private void WriteReport2_Load(object sender, EventArgs e)
        {
            panelWriteReport2.Visible = false;
            bunifuTransition1.Show(panelWriteReport2);
        }
        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            openChildForm(new WriteReport());
        }
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            openChildForm(new ShowReport());
        }
        private void bunifuTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsLetter(number) && number != 8 && number != 32 && number != 46)
            {
                e.Handled = true;
            }
        }
        private void bunifuTextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsLetter(number) && number != 8 && number != 32 && number != 46)
            {
                e.Handled = true;
            }
        }
        private void bunifuTextBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsLetter(number) && number != 8 && number != 32)
            {
                e.Handled = true;
            }
        }
        private void bunifuTextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsLetter(number) && number != 8 && number != 32 && number != 46)
            {
                e.Handled = true;
            }
        }
        private void bunifuTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsLetter(number) && number != 8 && number != 32 && number != 46)
            {
                e.Handled = true;
            }
        }
        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (TURN == 1)
            {
                if (bunifuTextBoxPlace.Text != "" && bunifuTextBoxMotive.Text != "" && bunifuTextBoxWitness.Text != "" && maskedTextBoxPhoneWitness.Text != "" && bunifuTextBoxCity.Text != "")
                {
                    InsertDataViolation();
                    bunifuTextBoxPlace.Text = "";
                    bunifuTextBoxMotive.Text = "";
                    bunifuTextBoxWitness.Text = "";
                    maskedTextBoxPhoneWitness.Text = "";
                    bunifuTextBoxCity.Text = "";
                }
                else
                {
                    MessageBox.Show("Заповніть дані коректно!", "Додавання даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bunifuTextBoxPlace.Text = "";
                bunifuTextBoxMotive.Text = "";
                bunifuTextBoxWitness.Text = "";
                maskedTextBoxPhoneWitness.Text = "";
                bunifuTextBoxCity.Text = "";
                MessageBox.Show("Заповніть попередньо іншні таблиці!", "Додавання даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            if(TURN == 1)
            {
                if (bunifuTextBoxNameSyd.Text != "" && bunifuTextBoxNameSidii.Text != "" && bunifuTextBoxPunishment.Text != "")
                {
                    InsertDataPunishment();
                    bunifuTextBoxNameSyd.Text = "";
                    bunifuTextBoxNameSidii.Text = "";
                    bunifuTextBoxPunishment.Text = "";
                }
                else 
                {
                    MessageBox.Show("Заповніть дані коректно!", "Додавання даних", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
            }
            else
            {
                bunifuTextBoxNameSyd.Text = "";
                bunifuTextBoxNameSidii.Text = "";
                bunifuTextBoxPunishment.Text = "";
                MessageBox.Show("Заповніть попередньо іншні таблиці!", "Додавання даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
        }
        private void maskedTextBoxPhoneWitness_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
