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
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(new string[] { "Вінниця", "Волинь", "Дніпро", "Донецьк", "Житомир", "Закарпаття", "Запоріжжя", "Івано-Франківськ", "Київ", "Кіровоград", "Луганськ", "Львів", "Миколаїв", "Одеса", "Полтава", "Рівне", "Суми", "Тернопіль", "Харків", "Херсон", "Хмельницьк", "Черкаси", "Чернівці", "Чернігів"});
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        public void LoadDataPrint(string City, DateTime firstDateTime, DateTime secondDateTime)
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            string myConnection = "SELECT City,NameOffender,CodeName,Date_violation " +
                "FROM VIOLATION JOIN OFFENDER ON FKidOFFENDER=idOFFENDER WHERE City ='" + City + "' AND Date_violation BETWEEN '" + firstDateTime + "' AND '" + secondDateTime + "'";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlCommand command = new SqlCommand(myConnection, sqlCon);
            SqlDataReader reader = command.ExecuteReader();
            List<MAP> data = new List<MAP>();
            while (reader.Read())
            {
                data.Add(new MAP(
                        Convert.ToString(reader["City"]),
                        Convert.ToString(reader["NameOffender"]),
                        Convert.ToString(reader["CodeName"]),
                        Convert.ToDateTime(reader["Date_violation"]))
                );
            }
            reader.Close();
            sqlCon.Close();
            int i = 0;
            dgv.Rows.Clear();
            foreach (MAP category in data)
            {
                this.dgv.Rows.Add();
                this.dgv.Rows[i].Cells[0].Value = category.getCity();
                this.dgv.Rows[i].Cells[1].Value = category.getNameOffender();
                this.dgv.Rows[i].Cells[2].Value = category.getCode();
                this.dgv.Rows[i].Cells[3].Value = category.getDate();
                ++i;
            }
        }
        public void LoadData(string City, DateTime firstDateTime, DateTime secondDateTime)
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            string myConnection = "SELECT COUNT(*) FROM VIOLATION WHERE City ='"+City+ "' AND Date_violation BETWEEN '"+ firstDateTime + "' AND '" + secondDateTime + "'";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlCommand command = new SqlCommand(myConnection, sqlCon);
            labelCount.Text = command.ExecuteScalar().ToString();
            if(labelCount.Text == "0")
            {
                MessageBox.Show("Пошук нічого не знайшов!", "Пошук даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            sqlCon.Close();
        }
        private void Map_Load(object sender, EventArgs e)
        {
            panelMap.Visible = false;
            bunifuTransition1.Show(panelMap);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Вінниця":
                    pictureBox1.Image = Properties.Resources.vinnica;
                    break;
                case "Волинь":
                    pictureBox1.Image = Properties.Resources.Lutsk;
                    break;
                case "Дніпро":
                    pictureBox1.Image = Properties.Resources.Dnipro;
                    break;
                case "Донецьк":
                    pictureBox1.Image = Properties.Resources.Donetck;
                    break;
                case "Житомир":
                    pictureBox1.Image = Properties.Resources.Jitomir;
                    break;
                case "Закарпаття":
                    pictureBox1.Image = Properties.Resources.Yjgprod;
                    break;
                case "Запоріжжя":
                    pictureBox1.Image = Properties.Resources.Zaporiza;
                    break;
                case "Івано-Франківськ":
                    pictureBox1.Image = Properties.Resources.IF;
                    break;
                case "Київ":
                    pictureBox1.Image = Properties.Resources.Kyiv;
                    break;
                case "Кіровоград":
                    pictureBox1.Image = Properties.Resources.Kirovograd;
                    break;
                case "Луганськ":
                    pictureBox1.Image = Properties.Resources.Lugansck;
                    break;
                case "Львів":
                    pictureBox1.Image = Properties.Resources.Lviv;
                    break;
                case "Миколаїв":
                    pictureBox1.Image = Properties.Resources.Nicalaev;
                    break;
                case "Одеса":
                    pictureBox1.Image = Properties.Resources.Odesa;
                    break;
                case "Полтава":
                    pictureBox1.Image = Properties.Resources.Poltava;
                    break;
                case "Рівне":
                    pictureBox1.Image = Properties.Resources.Rivne;
                    break;
                case "Суми":
                    pictureBox1.Image = Properties.Resources.Symi;
                    break;
                case "Тернопіль":
                    pictureBox1.Image = Properties.Resources.Ternopil;
                    break;
                case "Харків":
                    pictureBox1.Image = Properties.Resources.Harkiv;
                    break;
                case "Херсон":
                    pictureBox1.Image = Properties.Resources.Herson;
                    break;
                case "Хмельницьк":
                    pictureBox1.Image = Properties.Resources.Hmelnit;
                    break;
                case "Черкаси":
                    pictureBox1.Image = Properties.Resources.Cherkasi;
                    break;
                case "Чернівці":
                    pictureBox1.Image = Properties.Resources.Chernivchi;
                    break;
                case "Чернігів":
                    pictureBox1.Image = Properties.Resources.Chernigov;
                    break;
                default:
                    pictureBox1.Image = Properties.Resources.unnamed11;
                    break;
            }
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            DateTime firstDateTime = bunifuDatepicker1.Value;
            DateTime secondDateTime = bunifuDatepicker2.Value;

            string arr = comboBox1.Text;
            LoadData(arr, firstDateTime, secondDateTime);
            LoadDataPrint(arr, firstDateTime, secondDateTime);
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap objDmp = new Bitmap(this.dgv.Width, this.dgv.Height);
            dgv.DrawToBitmap(objDmp, new Rectangle(0, 0, this.dgv.Width, this.dgv.Height));

            e.Graphics.DrawImage(objDmp, 30, 0);
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
