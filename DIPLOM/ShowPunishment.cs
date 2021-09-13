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
    public partial class ShowPunishment : Form
    {
        int arr;
        public ShowPunishment(int numberListMin, int numberListMax)
        {
            InitializeComponent();
            LoadData(numberListMin, numberListMax);
        }
        public void EditData(int indexRow, string nameCourt, string nameJudge, string punish, string nameOffender)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
                SqlConnection sqlCon = new SqlConnection(connectionString);
                string myConnectionOPERATIONSedit = "UPDATE PUNISHMENT SET Punishment='" + punish + "', NameJudge='" + nameJudge + "', NameCourt='" + nameCourt + "' WHERE idPUNISHMENT=" + indexRow + " UPDATE OFFENDER SET NameOffender ='" + nameOffender + "' WHERE idOFFENDER=" + indexRow;

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
            try
            {
                string myConnectionViolation = "DELETE FROM PUNISHMENT WHERE idPUNISHMENT=" + indexRow + "DELETE FROM VIOLATION WHERE idVIOLATION=" + indexRow + " DELETE FROM OPERATIONS WHERE idOPERATIONS=" + indexRow + " DELETE FROM OFFENDER WHERE idOFFENDER=" + indexRow;
                sqlCon.Open();
                SqlCommand commandViolation = new SqlCommand(myConnectionViolation, sqlCon);
                SqlDataReader readerViolation = commandViolation.ExecuteReader();
                readerViolation.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ви ввели неправильні дані!", "Очіщення даних", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            sqlCon.Close();
        }
        public void LoadData(int numberListMin, int numberListMax)
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            string myConnection = "SELECT idPUNISHMENT,NameCourt,NameJudge,Punishment,NameOffender FROM PUNISHMENT JOIN OFFENDER ON FKidOffender=idOFFENDER ORDER BY idPUNISHMENT ASC OFFSET " + numberListMin + " ROWS FETCH NEXT " + numberListMax + " ROWS ONLY";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlCommand command = new SqlCommand(myConnection, sqlCon);
            SqlDataReader reader = command.ExecuteReader();
            List<PUNISHMENT> data = new List<PUNISHMENT>();
            while (reader.Read())
            {
                data.Add(new PUNISHMENT(
                        Convert.ToInt32(reader["idPUNISHMENT"]),
                        Convert.ToString(reader["NameCourt"]),
                        Convert.ToString(reader["NameJudge"]),
                        Convert.ToString(reader["Punishment"]),
                        Convert.ToString(reader["NameOffender"]))
                );
            }
            reader.Close();
            sqlCon.Close();
            int i = 0;
            dgv.Rows.Clear();
            foreach (PUNISHMENT category in data)
            {
                this.dgv.Rows.Add();
                this.dgv.Rows[i].Cells[0].Value = category.getID();
                this.dgv.Rows[i].Cells[1].Value = category.getNameCourt();
                this.dgv.Rows[i].Cells[2].Value = category.getNameJudge();
                this.dgv.Rows[i].Cells[3].Value = category.getPunishment();
                this.dgv.Rows[i].Cells[4].Value = category.getNameOffender();
                ++i;
            }
        }
        private void ShowPunishment_Load(object sender, EventArgs e)
        {
            panelShowPunishment.Visible = false;
            bunifuTransition1.Show(panelShowPunishment);
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

                    string nameSyd = dgv.Rows[rowindex].Cells[columnindex].Value.ToString();
                    string syd = dgv.Rows[rowindex].Cells[columnindex + 1].Value.ToString();
                    string punishment = dgv.Rows[rowindex].Cells[columnindex + 2].Value.ToString();
                    string offender = dgv.Rows[rowindex].Cells[columnindex + 3].Value.ToString();

                    EditData(rowID, nameSyd, syd, punishment, offender);
                    arr = 0;
                }
            }
        }
        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (arr == 1)
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1) { dgv.ReadOnly = false; }
            }
        }
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv.ReadOnly = true;
        }
    }
}
