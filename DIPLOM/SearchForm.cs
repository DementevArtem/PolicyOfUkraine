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
    public partial class SearchForm : Form
    {
        public SearchForm(string passport)
        {
            InitializeComponent();
            LoadData(passport);
        }
        public void LoadData(string passport)
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            string myConnection = "SELECT idOFFENDER,NameOffender,Sex,Passport,Address,Birthday FROM OFFENDER WHERE Passport='" + passport + "';";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlCommand command = new SqlCommand(myConnection, sqlCon);
            SqlDataReader reader = command.ExecuteReader();
            List<OFFENDER> data = new List<OFFENDER>();
            while (reader.Read())
            {
                data.Add(new OFFENDER(
                        Convert.ToInt32(reader["idOFFENDER"]),
                        Convert.ToString(reader["NameOffender"]),
                        Convert.ToString(reader["Sex"]),
                        Convert.ToString(reader["Passport"]),
                        Convert.ToString(reader["Address"]),
                        Convert.ToDateTime(reader["Birthday"]))
                );
            }
            reader.Close();
            sqlCon.Close();
            int i = 0;
            dgv1.Rows.Clear();
            foreach (OFFENDER category in data)
            {
                this.dgv1.Rows.Add();
                this.dgv1.Rows[i].Cells[0].Value = category.getID();
                this.dgv1.Rows[i].Cells[1].Value = category.getNameOffender();
                this.dgv1.Rows[i].Cells[2].Value = category.getSex();
                this.dgv1.Rows[i].Cells[3].Value = category.getPassport();
                this.dgv1.Rows[i].Cells[4].Value = category.getAddress();
                this.dgv1.Rows[i].Cells[5].Value = category.getBirthday();
                ++i;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
