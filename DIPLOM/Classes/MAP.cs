using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPLOM.Classes
{
    class MAP
    {
        string nameOffender;
        string city;
        string code;
        DateTime date;
        public MAP() { }

        public MAP(string City, string NameOffender, string Code, DateTime Date) 
        {
            this.nameOffender = NameOffender;
            this.city = City;
            this.code = Code;
            this.date = Date;
        }

        public String getNameOffender()
        {
            return this.nameOffender;
        }
        public void setNameOffender(String NameOffender)
        {
            this.nameOffender = NameOffender;
        }
        public String getCity()
        {
            return this.city;
        }
        public void setCity(String City)
        {
            this.city = City;
        }
        public String getCode()
        {
            return this.code;
        }
        public void setCode(String Code)
        {
            this.code = Code;
        }
        public string getDate()
        {
            String frmdt = date.ToString("dd-MM-yyyy");
            return frmdt;
        }
        public void setDate(DateTime Date)
        {
            this.date = Date;
        }
    }
}
