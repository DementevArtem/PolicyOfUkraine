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
    public partial class ShowOperation : Form
    {
        // -- КОНСТРУКТОР ДАНОЇ ФОРМИ
        int arr = 0;
        SqlConnection sqlCon;
        public ShowOperation(int numberListMin, int numberListMax)
        {
            InitializeComponent();
            LoadData(numberListMin, numberListMax);
        }
        // -- ФУНКЦІЯ ВИДАЛЕННЯ ДАНИХ З БД
        public void DeleteData(int indexRow)
        {

            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string myConnectionViolation = "DELETE FROM VIOLATION WHERE idVIOLATION="+ indexRow + " DELETE FROM OPERATIONS " +
                "WHERE idOPERATIONS="+ indexRow + " DELETE FROM OFFENDER WHERE idOFFENDER=" + indexRow;
            sqlCon.Open();
            SqlCommand commandViolation = new SqlCommand(myConnectionViolation, sqlCon);
            SqlDataReader readerViolation = commandViolation.ExecuteReader();

            readerViolation.Close();
            sqlCon.Close();
        }
        // -- ФУНКЦІЯ РЕДАГУВАННЯ ДАНИХ З БД
        public void EditData(int indexRow, string nameOper, string DateTime, string NameOFF, string NameG)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
                SqlConnection sqlCon = new SqlConnection(connectionString);
                string myConnectionOPERATIONSedit = "UPDATE OPERATIONS SET NameOperation='" + nameOper + "'," +
                " DateOperation='" + DateTime + "', " + "NameGroup='" + NameG + "' WHERE idOPERATIONS=" + indexRow +
                "UPDATE OFFENDER SET NameOffender = '" + NameOFF + "' WHERE idOFFENDER = " + indexRow;

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
        // -- ВИВІД ДАНИХ З БД У ТАБЛИЦЮ
        public void LoadData(int numberListMin, int numberListMax)
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            sqlCon = new SqlConnection(connectionString);
            string myConnection = "SELECT idOPERATIONS,NameOperation,DateOperation,NameOffender,NameGroup FROM OPERATIONS JOIN OFFENDER ON" +
                " FKidOFFENDER=idOFFENDER ORDER BY idOPERATIONS ASC OFFSET " + numberListMin + " ROWS FETCH NEXT " + numberListMax + " ROWS ONLY";
            sqlCon.Open();
            SqlCommand command = new SqlCommand(myConnection, sqlCon);
            SqlDataReader reader = command.ExecuteReader();
            List<OPERATION> data = new List<OPERATION>();
            while (reader.Read())
            {
                data.Add(new OPERATION(
                        Convert.ToInt32(reader["idOPERATIONS"]),
                        Convert.ToString(reader["NameOperation"]),
                        Convert.ToDateTime(reader["DateOperation"]),
                        Convert.ToString(reader["NameOffender"]),
                        Convert.ToString(reader["NameGroup"]))
                );
            }
            reader.Close();
            sqlCon.Close();
            int i = 0;
            dgv.Rows.Clear();
            foreach (OPERATION category in data)
            {
                this.dgv.Rows.Add();
                this.dgv.Rows[i].Cells[0].Value = category.getID();
                this.dgv.Rows[i].Cells[1].Value = category.getNameOperation();
                this.dgv.Rows[i].Cells[2].Value = category.getDateOperation();
                this.dgv.Rows[i].Cells[3].Value = category.getNameOffender();
                this.dgv.Rows[i].Cells[4].Value = category.getNameGroup();
                ++i;
            }
        }
        // -- ФУНКЦІЯ АНІМАЦІЇ
        private void ShowOperation_Load(object sender, EventArgs e)
        {
            panelShowOperation.Visible = false;
            bunifuTransition1.Show(panelShowOperation);
        }
        // -- ФУНКЦІЯ НАТИСКАННЯ КНОПКИ ДЛЯ ВИДАЛЕННЯ
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
                        MessageBox.Show("Ви обрали неправильне поле!", "Очіщення даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    
                    string nameOper = dgv.Rows[rowindex].Cells[columnindex].Value.ToString();
                    string dateTime = dgv.Rows[rowindex].Cells[columnindex+1].Value.ToString();
                    string nameOFF = dgv.Rows[rowindex].Cells[columnindex + 2].Value.ToString();
                    string nameG = dgv.Rows[rowindex].Cells[columnindex + 3].Value.ToString();

                    EditData(rowID, nameOper, dateTime, nameOFF, nameG);
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
            if(arr==1)
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1) { dgv.ReadOnly = false; }
            }
        }
    }
}
