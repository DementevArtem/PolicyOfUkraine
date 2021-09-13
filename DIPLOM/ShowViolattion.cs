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
    public partial class ShowViolattion : Form
    {
        int arr;
        public ShowViolattion(int numberListMin, int numberListMax)
        {
            InitializeComponent();
            LoadData(numberListMin, numberListMax);
        }
        public void EditData(int indexRow, string place, string dateViolation, string motive, string withness, string code, string phone, string city)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
                SqlConnection sqlCon = new SqlConnection(connectionString);
                string myConnectionOPERATIONSedit = "UPDATE VIOLATION SET Place='" + place + "', Date_violation='" + dateViolation + "', Motive='" + motive + "', Witnesses='" + withness + "', Phone_Witnesses='" + phone + "', City='" + city + "' WHERE idVIOLATION=" + indexRow;

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
        public void DeleteData(int indexRow)
        {

            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string myConnectionViolation = "DELETE FROM VIOLATION WHERE idVIOLATION=" + indexRow + " DELETE FROM PUNISHMENT WHERE idPUNISHMENT=" + indexRow + " DELETE FROM OFFENDER WHERE idOFFENDER=" + indexRow + " DELETE FROM OPERATIONS WHERE idOPERATIONS=" + indexRow;
            sqlCon.Open();
            SqlCommand commandViolation = new SqlCommand(myConnectionViolation, sqlCon);
            SqlDataReader readerViolation = commandViolation.ExecuteReader();

            readerViolation.Close();
            sqlCon.Close();
        }
        public void LoadData(int numberListMin, int numberListMax)
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            string myConnection = "SELECT idVIOLATION,Place,Date_violation,Motive,Witnesses,CodeName,Phone_Witnesses,City FROM VIOLATION ORDER BY idVIOLATION ASC OFFSET " + numberListMin + " ROWS FETCH NEXT " + numberListMax + " ROWS ONLY;";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlCommand command = new SqlCommand(myConnection, sqlCon);
            SqlDataReader reader = command.ExecuteReader();
            List<VIOLATION> data = new List<VIOLATION>();
            while (reader.Read())
            {
                data.Add(new VIOLATION(
                        Convert.ToInt32(reader["idVIOLATION"]),
                        Convert.ToString(reader["Place"]),
                        Convert.ToDateTime(reader["Date_violation"]),
                        Convert.ToString(reader["Motive"]),
                        Convert.ToString(reader["Witnesses"]),
                        Convert.ToString(reader["CodeName"]),
                        Convert.ToString(reader["Phone_Witnesses"]),
                        Convert.ToString(reader["City"]))
                );
            }
            reader.Close();
            sqlCon.Close();
            int i = 0;
            dgv.Rows.Clear();
            foreach (VIOLATION category in data)
            {
                this.dgv.Rows.Add();
                this.dgv.Rows[i].Cells[0].Value = category.getID();
                this.dgv.Rows[i].Cells[1].Value = category.getPlace();
                this.dgv.Rows[i].Cells[2].Value = category.getDateViolation();
                this.dgv.Rows[i].Cells[3].Value = category.getMotive();
                this.dgv.Rows[i].Cells[4].Value = category.getWitnesses();
                this.dgv.Rows[i].Cells[5].Value = category.getCode();
                this.dgv.Rows[i].Cells[6].Value = category.getPhone();
                this.dgv.Rows[i].Cells[7].Value = category.getCity();
                ++i;
            }
        }
        private void ShowViolattion_Load(object sender, EventArgs e)
        {
            panelShowViolattion.Visible = false;
            bunifuTransition1.Show(panelShowViolattion);
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult dr = MessageBox.Show("Ви дійсно хочете видалити виділені записи?", "Очіщення даних", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr.ToString() == "Yes")
                {
                    try
                    {
                        int selectedIndex = dgv.SelectedRows[0].Index;
                        int rowID = int.Parse(dgv[0, selectedIndex].Value.ToString());
                        dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
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
                        this.dgv.EditMode = DataGridViewEditMode.EditOnEnter;
                        arr = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ви обрали неправильне поле!", "Редагування даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (e.KeyCode == Keys.F7)
            {
                DialogResult dr = MessageBox.Show("Ви дійсно хочете змінити виділені записи?", "Редагування даних", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr.ToString() == "Yes")
                {
                    dgv.ReadOnly = true;

                    int selectedIndex = dgv.SelectedRows[0].Index;
                    int rowID = int.Parse(dgv[0, selectedIndex].Value.ToString());
                    int rowindex = dgv.CurrentCell.RowIndex;
                    int columnindex = dgv.CurrentCell.ColumnIndex;

                    string place = dgv.Rows[rowindex].Cells[columnindex].Value.ToString();
                    string dateViolation = dgv.Rows[rowindex].Cells[columnindex + 1].Value.ToString();
                    string motive = dgv.Rows[rowindex].Cells[columnindex + 2].Value.ToString();
                    string withness = dgv.Rows[rowindex].Cells[columnindex + 3].Value.ToString();
                    string code = dgv.Rows[rowindex].Cells[columnindex + 4].Value.ToString();
                    string phone = dgv.Rows[rowindex].Cells[columnindex + 5].Value.ToString();
                    string city = dgv.Rows[rowindex].Cells[columnindex + 6].Value.ToString();

                    EditData(rowID, place, dateViolation, motive, withness, code, phone, city);
                    arr = 0;
                }
            }
        }
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv.ReadOnly = true;
        }
        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (arr == 1)
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1) { dgv.ReadOnly = false; }
            }
        }
    }
}
