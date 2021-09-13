using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPLOM.Classes
{
    class OFFENDER
    {
        int idOffender;
        string nameOffender;
        string sex;
        string passport;
        string address;
        DateTime birthday;
        public OFFENDER() {}
        public OFFENDER(int idOFFENDER, string NameOffender, string Sex, string Passport, string Address, DateTime Birthday) 
        {
            this.idOffender = idOFFENDER;
            this.nameOffender = NameOffender;
            this.sex = Sex;
            this.passport = Passport;
            this.address = Address;
            this.birthday = Birthday;
        }
        public void setNameOffender(String NameOffender)
        {
            this.nameOffender = NameOffender;
        }
        public String getNameOffender()
        {
            return this.nameOffender;
        }
        public void setSex(String Sex)
        {
            this.sex = Sex;
        }
        public String getSex()
        {
            return this.sex;
        }
        public void setPassport(String Passport)
        {
            this.passport = Passport;
        }
        public String getPassport()
        {
            return this.passport;
        }
        public void setAddress(String Address)
        {
            this.address = Address;
        }
        public String getAddress()
        {
            return this.address;
        }
        public void setBirthday(DateTime Birthday)
        {
            this.birthday = Birthday;
        }
        public String getBirthday()
        {
            String frmdt = birthday.ToString("dd-MM-yyyy");
            return frmdt;
        }
        public void setID(int idOFFENDER)
        {
            this.idOffender = idOFFENDER;
        }
        public int getID()
        {
            return this.idOffender;
        }
    }
}
