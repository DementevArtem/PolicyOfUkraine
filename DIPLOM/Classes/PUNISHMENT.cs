using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPLOM.Classes
{
    class PUNISHMENT
    {
        int idPunishment;
        string nameCourt;
        string nameJudge;
        string punishment;
        string nameOffender;
        public PUNISHMENT() { }
        public PUNISHMENT(int ID, string NameCourt, string NameJudge, string Punishment, string NameOffender)
        {
            this.idPunishment = ID;
            this.nameCourt = NameCourt;
            this.nameJudge = NameJudge;
            this.punishment = Punishment;
            this.nameOffender = NameOffender;
        }
        public void setNameCourt(String NameCourt)
        {
            this.nameCourt = NameCourt;
        }
        public String getNameCourt()
        {
            return this.nameCourt;
        }
        public void setID(int ID)
        {
            this.idPunishment = ID;
        }
        public int getID()
        {
            return this.idPunishment;
        }
        public void setNameJudge(String NameJudge)
        {
            this.nameJudge = NameJudge;
        }
        public String getNameJudge()
        {
            return this.nameJudge;
        }
        public void setPunishment(String Punishment)
        {
            this.punishment = Punishment;
        }
        public String getPunishment()
        {
            return this.punishment;
        }
        public void setNameOffender(string NameOffender)
        {
            this.nameOffender = NameOffender;
        }
        public String getNameOffender()
        {
            return this.nameOffender;
        }
    }
}
