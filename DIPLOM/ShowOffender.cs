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
    public partial class ShowOffender : Form
    {
        int arr;
        public ShowOffender(int numberListMin, int numberListMax)
        {
            InitializeComponent();
            LoadData(numberListMin, numberListMax);
        }
        public void DeleteData(int indexrow)
        {
            string connectionstring = @"data source=desktop-iiefa2f;initial catalog=police;integrated security=true";
            SqlConnection sqlCon = new SqlConnection(connectionstring);
            string myConnectionViolation = "delete from violation where idviolation = " + indexrow + "; delete from punishment " +
                "where idpunishment = " + indexrow + "; delete from offender where idoffender = " + indexrow + ";";

            sqlCon.Open();
            SqlCommand commandViolation = new SqlCommand(myConnectionViolation, sqlCon);
            SqlDataReader readerViolation = commandViolation.ExecuteReader();

            readerViolation.Close();
            sqlCon.Close();
        }
        public void EditData(int indexRow, string nameOffender, string sex, string passsport, string address, string bt)
        {
            try
            {
 
                string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
                SqlConnection sqlCon = new SqlConnection(connectionString);
                string myConnectionOPERATIONSedit = "UPDATE OFFENDER SET NameOffender='" + nameOffender + "', Sex='" + sex + "', " + "Passport='" + passsport + "', Address='" + address + "', Birthday='" + bt + "' WHERE idOFFENDER=" + indexRow;
                sqlCon.Open();
                SqlCommand commandEdit = new SqlCommand(myConnectionOPERATIONSedit, sqlCon);
                SqlDataReader readerViolation = commandEdit.ExecuteReader();

                readerViolation.Close();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ви ввели неправильні дані", "Редагуваання", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }
        public void LoadData(int numberListMin, int numberListMax)
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            string myConnection = "SELECT idOFFENDER,NameOffender,Sex,Passport,Address,Birthday FROM OFFENDER ORDER BY" +
                " idOFFENDER ASC OFFSET " + numberListMin + " ROWS FETCH NEXT " + numberListMax + " ROWS ONLY";
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
        private void ShowOffender_Load(object sender, EventArgs e)
        {
            panelShowOffender.Visible = false;
            bunifuTransition1.Show(panelShowOffender);
        }
        private void dgv1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                DialogResult dr = MessageBox.Show("Ви дійсно хочете видалити виділені записи?", "Очіщення даних", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr.ToString() == "Yes")
                {
                    try
                    {
                        int selectedIndex = dgv1.SelectedRows[0].Index;
                        int rowID = int.Parse(dgv1[0, selectedIndex].Value.ToString());
                        dgv1.Rows.RemoveAt(dgv1.SelectedRows[0].Index);
                        DeleteData(rowID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ви обрали неправильне поле!", "Очіщення даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                DialogResult dr = MessageBox.Show("Ви дійсно хочете змінити виділені записи?", "Редагування даних", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr.ToString() == "Yes")
                {
                    try
                    {
                        this.dgv1.EditMode = DataGridViewEditMode.EditOnEnter;
                        arr = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ви обрали неправильне поле!", "Очіщення даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (e.KeyCode == Keys.F7)
            {
                DialogResult dr = MessageBox.Show("Ви дійсно хочете змінити виділені записи?", "Редагування даних", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr.ToString() == "Yes")
                {
                    dgv1.ReadOnly = true;

                    int selectedIndex = dgv1.SelectedRows[0].Index;
                    int rowID = int.Parse(dgv1[0, selectedIndex].Value.ToString());
                    int rowindex = dgv1.CurrentCell.RowIndex;
                    int columnindex = dgv1.CurrentCell.ColumnIndex;

                    string nameOffender = dgv1.Rows[rowindex].Cells[columnindex].Value.ToString();
                    string sex = dgv1.Rows[rowindex].Cells[columnindex + 1].Value.ToString();
                    string passsport = dgv1.Rows[rowindex].Cells[columnindex + 2].Value.ToString();
                    string address = dgv1.Rows[rowindex].Cells[columnindex + 3].Value.ToString();
                    string bt = dgv1.Rows[rowindex].Cells[columnindex + 4].Value.ToString();

                    EditData(rowID, nameOffender, sex, passsport, address, bt);
                    arr = 0;
                }
            }
        }
        private void dgv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (arr == 1)
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1) { dgv1.ReadOnly = false; }
            }
        }
        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv1.ReadOnly = true;
        }
    }
}
