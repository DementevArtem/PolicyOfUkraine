using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPLOM.Classes
{
    class VIOLATION
    {
        int idVIOLLATION;
        string place;
        DateTime dateViolation;
        string motive;
        string witnesses;
        string code;
        string phone;
        string city;

        public VIOLATION() { }
        public VIOLATION(int Violation, string Place, DateTime DateViolation, string Motive, string Witnesses, string Code, string Phone, string City)
        {
            this.idVIOLLATION = Violation;
            this.place = Place;
            this.dateViolation = DateViolation;
            this.motive = Motive;
            this.witnesses = Witnesses;
            this.code = Code;
            this.phone = Phone;
            this.city = City;
        }
        public void setCity(string City)
        {
            this.city = City;
        }
        public string getCity()
        {
            return this.city;
        }
        public void setID(int Violation)
        {
            this.idVIOLLATION = Violation;
        }
        public int getID()
        {
            return this.idVIOLLATION;
        }
        public void setPlace(String Place)
        {
            this.place = Place;
        }
        public String getPlace()
        {
            return this.place;
        }
        public void setDateViolation(DateTime DateViolation)
        {
            this.dateViolation = DateViolation;
        }
        public String getDateViolation()
        {
            String frmdt = dateViolation.ToString("dd-MM-yyyy");
            return frmdt;
        }
        public void setMotive(String Motive)
        {
            this.motive = Motive;
        }
        public String getMotive()
        {
            return this.motive;
        }
        public void setWitnesses(String Witnesses)
        {
            this.witnesses = Witnesses;
        }
        public String getWitnesses()
        {
            return this.witnesses;
        }
        public void setCode(String Code)
        {
            this.code = Code;
        }
        public String getCode()
        {
            return this.code;
        }
        public void setPhone(String Phone)
        {
            this.phone = Phone;
        }
        public String getPhone()
        {
            return this.phone;
        }
    }
}
