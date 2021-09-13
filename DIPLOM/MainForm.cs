using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIPLOM.Conection;
using System.Data.SqlClient;
using System.Threading;
using DIPLOM.Classes;

namespace DIPLOM
{
    public partial class MainForm : Form
    {
        string idLOGIN;
        public MainForm(string ID, string FIO, string Posada)
        {
            InitializeComponent();
            Custom();
            idLOGIN = ID;
            labelName.Text = FIO;
            labelPosada.Text = Posada;

            LoadData();
        }
        public void LoadData()
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            string myConnection = "SELECT count(*),CITY FROM VIOLATION GROUP BY CITY ORDER BY count(*) DESC";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlCommand command = new SqlCommand(myConnection, sqlCon);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[3]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }
            reader.Close();
            sqlCon.Close();
            foreach (string[] s in data)
                dgv.Rows.Add(s);

            labelFisrtCity.Text = dgv.Rows[0].Cells[1].Value.ToString();
            labelSecondCity.Text = dgv.Rows[1].Cells[1].Value.ToString();
            labelThirdCity.Text = dgv.Rows[2].Cells[1].Value.ToString();

            int numberFirst = int.Parse(dgv.Rows[0].Cells[0].Value.ToString());
            int numberSecond = int.Parse(dgv.Rows[1].Cells[0].Value.ToString());
            int numberThird = int.Parse(dgv.Rows[2].Cells[0].Value.ToString());

            CustomDiagram(numberFirst, numberSecond, numberThird);
        }
        private void CustomDiagram(int numberFirst, int numberSecond, int numberThird)
        {
            Bunifu.DataViz.WinForms.Canvas Canvas = new Bunifu.DataViz.WinForms.Canvas();
            Bunifu.DataViz.WinForms.DataPoint values = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_splineArea);
            values.addLabely("1", numberFirst);
            values.addLabely("2", numberSecond);
            values.addLabely("3", numberThird);
            Canvas.addData(values);
            bunifuDataViz1.Render(Canvas);
        }
        private void Custom()
        {
            panelLine1.Visible = false;
            panelLine2.Visible = false;
            panelLine3.Visible = false;
            panelLine4.Visible = false;
        }
        private void openChildForm(object Formhijo)
        {
            if (this.panelChildForm.Controls.Count > 0) this.panelChildForm.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelChildForm.Controls.Add(fh);
            this.panelChildForm.Tag = fh;
            fh.Show();
        }
        // Start ButtonMyProfil
        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new MyProfil(idLOGIN));
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            panelLine1.Visible = false;
        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            panelLine1.Visible = true;
        }
        // End ButtonMyProfil

        // Start ButtonWriteReport
        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new WriteReport());
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            panelLine2.Visible = false;
        }
        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            panelLine2.Visible = true;
        }
        // End ButtonWriteReport

        // Start ButtonWriteReport
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            panelLine3.Visible = false;
        }
        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            panelLine3.Visible = true;
        }
        // End ButtonMyProfil

        // Start ButtonWriteReport
        private void button5_MouseLeave(object sender, EventArgs e)
        {
            panelLine4.Visible = false;
        }
        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            panelLine4.Visible = true;
        }
        // End ButtonMyProfil

        private void MainForm_Load(object sender, EventArgs e)
        {
            openChildForm(new MenuProgrammUKR());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new MenuProgrammUKR());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 newForm1 = new Form1();
            newForm1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new ShowReport());
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Map());
        }
    }
}
