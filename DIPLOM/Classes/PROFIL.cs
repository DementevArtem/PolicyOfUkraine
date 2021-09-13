using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPLOM.Classes
{
    class PROFIL
    {
        string city;
        int numberDepart;
        string phone;
        int numberWorker;
        string nameDirector;
        string rankW;
        string nameW;
        string posadaW;
        string addressW;
        string sex;
        string phoneW;
        string materialS;
        int children;
        string violattion;
        string email;
        DateTime date_of_acceptance;
        string education;
        double salary;
        DateTime date_of_birth;

        public PROFIL() { }
        public PROFIL(string NameW, string PosadaW, string RankW, string AddressW, string Sex, string PhoneW, string MaterialS, int Children, string Violattion, string Email, DateTime Date_of_acceptance, string Education, double Salary, DateTime Date_of_birth, string City, int NumberDepart, string Phone, int NumberWorker, string NameDirector) 
        {
            this.nameW = NameW;
            this.posadaW = PosadaW;
            this.rankW = RankW;
            this.addressW = AddressW;
            this.sex = Sex;
            this.phoneW = PhoneW;
            this.materialS = MaterialS;
            this.children = Children;
            this.violattion = Violattion;
            this.email = Email;
            this.date_of_acceptance = Date_of_acceptance;
            this.education = Education;
            this.salary = Salary;
            this.date_of_birth = Date_of_birth;
            this.city = City;
            this.numberDepart = NumberDepart;
            this.phone = Phone;
            this.numberWorker = NumberWorker;
            this.nameDirector = NameDirector;
        }
        public String getNameDirector()
        {
            return this.nameDirector;
        }
        public void setNameDirector(String NameDirector)
        {
            this.nameDirector = NameDirector;
        }
        public String getPhone()
        {
            return this.phone;
        }
        public void setPhone(String Phone)
        {
            this.phone = Phone;
        }
        public int getNumberWorker()
        {
            return this.numberWorker;
        }
        public void setNumberWorker(int NumberWorker)
        {
            this.numberWorker = NumberWorker;
        }
        public int getNumberDepart()
        {
            return this.numberDepart;
        }
        public void setNumberDepart(int NumberDepart)
        {
            this.numberDepart = NumberDepart;
        }
        public String getCity()
        {
            return this.city;
        }
        public void setCity(String City)
        {
            this.city = City;
        }
        public String getRankW()
        {
            return this.rankW;
        }
        public void setRankW(String RankW)
        {
            this.rankW = RankW;
        }
        public String getNameW()
        {
            return this.nameW;
        }
        public void setNameW(String NameW)
        {
            this.nameW = NameW;
        }
        public String getPosadaW()
        {
            return this.posadaW;
        }
        public void setPosadaW(String PosadaW)
        {
            this.posadaW = PosadaW;
        }
        public String getAddressW()
        {
            return this.rankW;
        }
        public void setAddressW(String AddressW)
        {
            this.addressW = AddressW;
        }
        public String getSex()
        {
            return this.sex;
        }
        public void setSex(String Sex)
        {
            this.sex = Sex;
        }
        public String getPhoneW()
        {
            return this.phoneW;
        }
        public void setPhoneW(String PhoneW)
        {
            this.phoneW = PhoneW;
        }
        public String getMaterialS()
        {
            return this.materialS;
        }
        public void setMaterialS(String MaterialS)
        {
            this.materialS = MaterialS;
        }
        public String getViolattion()
        {
            return this.violattion;
        }
        public void setViolattion(String Violattion)
        {
            this.violattion = Violattion;
        }
        public String getEmail()
        {
            return this.email;
        }
        public void setEmail(String Email)
        {
            this.email = Email;
        }
        public String getEducation()
        {
            return this.education;
        }
        public void setEducation(String Education)
        {
            this.education = Education;
        }
        public int getChildren()
        {
            return this.children;
        }
        public void setChildren(int Children)
        {
            this.children = Children;
        }
        public double getSalary()
        {
            return this.salary;
        }
        public void setSalary(double Salary)
        {
            this.salary = Salary;
        }
        public void setDate_of_acceptance(DateTime Date_of_acceptance)
        {
            this.date_of_acceptance = Date_of_acceptance;
        }
        public String getDate_of_acceptance()
        {
            String frmdt = date_of_acceptance.ToString("dd-MM-yyyy");
            return frmdt;
        }
        public void setDate_of_birth(DateTime Date_of_acceptance)
        {
            this.date_of_birth = Date_of_acceptance;
        }
        public String getDate_of_birth()
        {
            String frmdt = date_of_birth.ToString("dd-MM-yyyy");
            return frmdt;
        }
    }
}
