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
using DIPLOM.Classes;

namespace DIPLOM
{
    public partial class ShowReport : Form
    {
        int k1 = 0;
        int flag = 1;
        public ShowReport()
        {
            InitializeComponent();
        }
        // -- МЕТОД ПІДРАХУНКУ К-СТЬ ЛИСТІВ З ДАНИМИ 
        public int CountRow(string nameTable)
        {
            string connectionString = @"Data Source=DESKTOP-IIEFA2F;Initial Catalog=Police;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string myConnectionViolation = "SELECT count(*) FROM " + nameTable + ";";

            sqlCon.Open();
            SqlCommand commandViolation = new SqlCommand(myConnectionViolation, sqlCon);
            int number = (int)commandViolation.ExecuteScalar();
            sqlCon.Close();
            return number;
        }
        private Form activForm1 = null;
        private Form activForm2 = null;
        // -- МЕТОДИ ВИВОДУ ПАНЕЛЕЙ 
        private void openChildForm(Form ChildForm)
        {
            if (activForm1 != null) activForm1.Close();
            activForm1 = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelData.Controls.Add(ChildForm);
            panelData.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        private void openChildForm2(Form ChildForm)
        {
            if (activForm2 != null) activForm2.Close();
            activForm2 = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelShowReport.Controls.Add(ChildForm);
            panelShowReport.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        // -- МЕТОДИ ПОДІЙ НА КНОПКАХ КЕРУВАННЯ ВІДОБРАЖЕННЯМ ТАБЛИЦЬ
        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            k1 = 0;
            int numberOPERATIONS = CountRow("OPERATIONS");
            double numberConvertOPERATIONS = (double)numberOPERATIONS / 15; // 1.6
            numberOPERATIONS = numberOPERATIONS / 15; // 1
            if (numberConvertOPERATIONS > numberOPERATIONS) numberOPERATIONS = numberOPERATIONS + 1;
            else if (numberOPERATIONS < 1) numberOPERATIONS = numberOPERATIONS + 1;
            labelPage.Text = "1/" + numberOPERATIONS;
            openChildForm(new ShowOperation(0, 15));
            flag = 2;
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            k1 = 0;
            int number = CountRow("PUNISHMENT");
            int numberPUNISHMENT = CountRow("PUNISHMENT");
            double numberConvertPUNISHMENT = (double)numberPUNISHMENT / 15; // 1.6
            numberPUNISHMENT = numberPUNISHMENT / 15; // 1
            if (numberConvertPUNISHMENT > numberPUNISHMENT) numberPUNISHMENT = numberPUNISHMENT + 1;
            else if (numberPUNISHMENT < 1) numberPUNISHMENT = numberPUNISHMENT + 1;
            labelPage.Text = "1/" + numberPUNISHMENT;
            openChildForm(new ShowPunishment(0, 15));
            flag = 3;
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            k1 = 0;
            int numberOFFENDER = CountRow("OFFENDER");
            double numberConvertOFFENDER = (double)numberOFFENDER / 15; // 1.6
            numberOFFENDER = numberOFFENDER / 15; // 1
            if (numberConvertOFFENDER > numberOFFENDER) numberOFFENDER = numberOFFENDER + 1;
            else if (numberOFFENDER < 1) numberOFFENDER = numberOFFENDER + 1;
            labelPage.Text = "1/" + numberOFFENDER;
            openChildForm(new ShowOffender(0, 15));
            flag = 1;
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            k1 = 0;
            int numberVIOLATION = CountRow("VIOLATION");
            double numberConvertVIOLATION = (double)numberVIOLATION / 15; // 1.6
            numberVIOLATION = numberVIOLATION / 15; // 1
            if (numberConvertVIOLATION > numberVIOLATION) numberVIOLATION = numberVIOLATION + 1;
            else if (numberVIOLATION < 1) numberVIOLATION = numberVIOLATION + 1;
            labelPage.Text = "1/" + numberVIOLATION;
            openChildForm(new ShowViolattion(0, 15));
            flag = 4;
        }

        private void ShowReport_Load(object sender, EventArgs e)
        {
            k1 = 0;
            int numberOFFENDER = CountRow("OFFENDER");
            double numberConvertOFFENDER = (double)numberOFFENDER / 15; // 1.6
            numberOFFENDER = numberOFFENDER / 15; // 1
            if (numberConvertOFFENDER > numberOFFENDER) numberOFFENDER = numberOFFENDER + 1;
            else if (numberOFFENDER < 1) numberOFFENDER = numberOFFENDER + 1;
            labelPage.Text = "1/" + numberOFFENDER;
            openChildForm(new ShowOffender(0, 15));
        }
        // -- МЕТОД ПОДІЇ КНОПКИ ДОДАВАННЯ
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            openChildForm2(new WriteReport());
        }
        // -- МЕТОДИ ПОДІЇ КОНОПОК КЕРУВАННЯМ ПЕРЕЛИСТУВАННЯМ СТОРІНОК
        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            int k = 15;
            switch (flag)
            {
                case 1:
                    int numberOFFENDER = CountRow("OFFENDER");
                    double numberConvertOFFENDER = (double)numberOFFENDER / 15; // 1.6
                    numberOFFENDER = numberOFFENDER / 15; // 1
                    if (numberConvertOFFENDER > numberOFFENDER) numberOFFENDER = numberOFFENDER + 1;
                    else if (numberOFFENDER < 1) numberOFFENDER = numberOFFENDER + 1;
                    labelPage.Text = "1/" + numberOFFENDER;
                    k1++;
                    if (k1 >= 1) {
                        openChildForm(new ShowOffender(k*k1, k));
                        labelPage.Text = Convert.ToString((k1+1)) + "/" + numberOFFENDER;
                    }
                    if (k1 == numberOFFENDER)
                    {
                        k1 = 0;
                        MessageBox.Show("На даний момент даних більше немає!!!","Помилка пошуку");
                        CountRow("OFFENDER");
                        openChildForm(new ShowOffender(k * k1, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberOFFENDER;
                    }
                    break;
                case 2:
                    int numberOPERATIONS = CountRow("OPERATIONS");
                    double numberConvertOPERATIONS = (double)numberOPERATIONS / 15; // 1.6
                    numberOPERATIONS = numberOPERATIONS / 15; // 1
                    if (numberConvertOPERATIONS > numberOPERATIONS) numberOPERATIONS = numberOPERATIONS + 1;
                    else if (numberOPERATIONS < 1) numberOPERATIONS = numberOPERATIONS + 1;
                    labelPage.Text = "1/" + numberOPERATIONS;
                    k1++;
                    if (k1 >= 1)
                    {
                        openChildForm(new ShowOperation(k * k1, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberOPERATIONS;
                    }
                    if (k1 == numberOPERATIONS)
                    {
                        k1 = 0;
                        MessageBox.Show("На даний момент даних більше немає!!!", "Помилка пошуку");
                        openChildForm(new ShowOperation(k * k1, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberOPERATIONS;
                    }
                    break;
                case 3:
                    int numberPUNISHMENT = CountRow("PUNISHMENT");
                    double numberConvertPUNISHMENT = (double)numberPUNISHMENT / 15; // 1.6
                    numberPUNISHMENT = numberPUNISHMENT / 15; // 1
                    if (numberConvertPUNISHMENT > numberPUNISHMENT) numberPUNISHMENT = numberPUNISHMENT + 1;
                    else if (numberPUNISHMENT < 1) numberPUNISHMENT = numberPUNISHMENT + 1;
                    labelPage.Text = "1/" + numberPUNISHMENT;
                    k1++;
                    if (k1 >= 1)
                    {
                        openChildForm(new ShowPunishment(k * k1, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberPUNISHMENT;
                    }
                    if (k1 == numberPUNISHMENT)
                    {
                        k1 = 0;
                        MessageBox.Show("На даний момент даних більше немає!!!", "Помилка пошуку");
                        openChildForm(new ShowPunishment(k * k1, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberPUNISHMENT;
                    }
                    break;
                case 4:
                    int numberVIOLATION = CountRow("VIOLATION");
                    double numberConvertVIOLATION = (double)numberVIOLATION / 15; // 1.6
                    numberVIOLATION = numberVIOLATION / 15; // 1
                    if (numberConvertVIOLATION > numberVIOLATION) numberVIOLATION = numberVIOLATION + 1;
                    else if (numberVIOLATION < 1) numberVIOLATION = numberVIOLATION + 1;
                    k1++;
                    if (k1 >= 1)
                    {
                        openChildForm(new ShowViolattion(k * k1, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberVIOLATION;
                    }
                    if (k1 == numberVIOLATION)
                    {
                        k1 = 0;
                        MessageBox.Show("На даний момент даних більше немає!!!", "Помилка пошуку");
                        openChildForm(new ShowViolattion(k * k1, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberVIOLATION;
                    }
                    break;
                default:
                    break;
            }
        }
        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            int k = 15;
            switch (flag)
            {
                case 1:
                    int number = CountRow("OFFENDER") / 15 + 1;
                    if (k1 == 0)
                    {
                        k1 = 0;
                        MessageBox.Show("На даний момент даних більше немає!!!", "Помилка пошуку");
                        CountRow("OFFENDER");
                        openChildForm(new ShowOffender(0, k));
                        labelPage.Text = Convert.ToString((k1+1)) + "/" + number;
                    }
                    else if(k1==1)
                    {
                        k1--;
                        openChildForm(new ShowOffender(0, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + number;
                    }
                    else
                    {
                        k1--;
                        openChildForm(new ShowOffender(k / (k1), k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + number;
                    }
                    break;
                case 2:
                    int numberOPERATIONS = CountRow("OPERATIONS") / 15 + 1;
                    if (k1 == 0)
                    {
                        k1 = 0;
                        MessageBox.Show("На даний момент даних більше немає!!!", "Помилка пошуку");
                        CountRow("OFFENDER");
                        openChildForm(new ShowOperation(0, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberOPERATIONS;
                    }
                    else if (k1 == 1)
                    {
                        k1--;
                        openChildForm(new ShowOperation(0, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberOPERATIONS;
                    }
                    else
                    {
                        k1--;
                        openChildForm(new ShowOffender(k / (k1), k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberOPERATIONS;
                    }
                    break;
                case 3:
                    int numberPUNISHMENT = CountRow("PUNISHMENT") / 15 + 1;
                    if (k1 == 0)
                    {
                        k1 = 0;
                        MessageBox.Show("На даний момент даних більше немає!!!", "Помилка пошуку");
                        CountRow("OFFENDER");
                        openChildForm(new ShowPunishment(0, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberPUNISHMENT;
                    }
                    else if (k1 == 1)
                    {
                        k1--;
                        openChildForm(new ShowPunishment(0, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberPUNISHMENT;
                    }
                    else
                    {
                        k1--;
                        openChildForm(new ShowPunishment(k / (k1), k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberPUNISHMENT;
                    }
                    break;
                case 4:
                    int numberVIOLATION = CountRow("VIOLATION") / 15 + 1;
                    if (k1 == 0)
                    {
                        k1 = 0;
                        MessageBox.Show("На даний момент даних більше немає!!!", "Помилка пошуку");
                        CountRow("OFFENDER");
                        openChildForm(new ShowViolattion(0, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberVIOLATION;
                    }
                    else if (k1 == 1)
                    {
                        k1--;
                        openChildForm(new ShowViolattion(0, k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberVIOLATION;
                    }
                    else
                    {
                        k1--;
                        openChildForm(new ShowViolattion(k / (k1), k));
                        labelPage.Text = Convert.ToString((k1 + 1)) + "/" + numberVIOLATION;
                    }
                    break;
                default:
                    break;
            }
        }
        // -- МЕТОД ПОДІЇ ВИВОДУ КОМЕНТАРЯ ВИДАЛЕННЯМ ДАНИХ
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для того, щоб видалити дані з таблиці і БД, потрібно: \n1: Виділити потрібне поле.\n2: Натиснути на кнопку 'Del'. ", "Інструкція до очищення даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // -- МЕТОД ПОДІЇ ВИВОДУ КОМЕНТАРЯ РЕДАГУВАННЯ ДАНИХ
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для того, щоб редагувати дані у таблиці і БД, потрібно: \n1: Виділити потрібне поле.\n2: Натиснути на кнопку 'F2'.\n3: Відредагувати дані, закрити режим редагування і обрати поле яке було відредаговане.\n4: Натиснути на кнопку 'F7', для зберігання відредагованих даних.", "Інструкція для редагування даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
