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
    public partial class MyProfil : Form
    {
        string idLOGIN;
        public MyProfil(string ID)
        {
            idLOGIN = ID;
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            string connectionString = "Data Source=DESKTOP-IIEFA2F;Initial Catalog=LoginDatabase;Integrated Security=True";
            string myConnection = "SELECT NameUser,Posada,RankW,AddressW,Sex,Children,MaterialS,PhoneW,Violattion,Email,Date_of_acceptance,Education,Salary,Date_of_birth,City,Number_department,Phone,Number_worker,Name_director  FROM WORKERS JOIN LoginPassword ON FKidLogin=" + idLOGIN + "JOIN DEPARTMENT ON FKidDEPARTMENT=idDEPARTMENT";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlCommand command = new SqlCommand(myConnection, sqlCon);
            SqlDataReader reader = command.ExecuteReader();
            List<PROFIL> data = new List<PROFIL>();
            while (reader.Read())
            {
                data.Add(new PROFIL(
                        Convert.ToString(reader["NameUser"]),
                        Convert.ToString(reader["Posada"]),
                        Convert.ToString(reader["RankW"]),
                        Convert.ToString(reader["AddressW"]),
                        Convert.ToString(reader["Sex"]),
                        Convert.ToString(reader["PhoneW"]),
                        Convert.ToString(reader["MaterialS"]),
                        Convert.ToInt32(reader["Children"]),
                        Convert.ToString(reader["Violattion"]),
                        Convert.ToString(reader["Email"]),
                        Convert.ToDateTime(reader["Date_of_acceptance"]),
                        Convert.ToString(reader["Education"]),
                        Convert.ToDouble(reader["Salary"]),
                        Convert.ToDateTime(reader["Date_of_birth"]),
                        Convert.ToString(reader["City"]),
                        Convert.ToInt32(reader["Number_department"]),
                        Convert.ToString(reader["Phone"]),
                        Convert.ToInt32(reader["Number_worker"]),
                        Convert.ToString(reader["Name_director"]))
                );
            }
            reader.Close();
            sqlCon.Close();
            foreach (PROFIL category in data)
            {
                labelName.Text = category.getNameW();
                labelPosada.Text = category.getPosadaW();
                label2.Text=category.getRankW();
                labelAddress.Text = category.getAddressW();
                labelSex.Text = category.getSex();
                labelPhone.Text = category.getPhoneW();
                labelMaterialW.Text = category.getMaterialS();
                labelCountCh.Text = Convert.ToString(category.getChildren());
                labelEducation.Text = category.getEducation();
                labelDateWork.Text = category.getDate_of_acceptance();
                labelBD.Text = category.getDate_of_birth();
                labelAddress.Text = category.getAddressW();
                labelEmail.Text = category.getEmail();
                labelMaterialW.Text = category.getMaterialS();
                labelVilation.Text = category.getViolattion();
                labelSalary.Text = Convert.ToString(category.getSalary());
                label4.Text = Convert.ToString(category.getCity());
                label3.Text = Convert.ToString(category.getNumberDepart());
                label5.Text = Convert.ToString(category.getPhone());
                label6.Text = Convert.ToString(category.getNumberWorker());
                label7.Text = Convert.ToString(category.getNameDirector());
            }
        }
    }
}
