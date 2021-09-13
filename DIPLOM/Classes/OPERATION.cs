using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPLOM.Classes
{
    class OPERATION
    {
        int idOperation;
        string nameOperation;
        DateTime dateOperation;
        string nameOffender;
        string nameGroup;
        public OPERATION() { }
        public OPERATION(int ID, string NameOperation, DateTime DateOperation, string NameOffender, string NameGroup)
        {
            this.idOperation = ID;
            this.nameOperation = NameOperation;
            this.dateOperation = DateOperation;
            this.nameOffender = NameOffender;
            this.nameGroup = NameGroup;
        }
        public void setNameOperation(String NameOperation)
        {
            this.nameOperation = NameOperation;
        }
        public String getNameOperation()
        {
            return this.nameOperation;
        }
        public void setDateOperation(DateTime DateOperation)
        {
            this.dateOperation = DateOperation;
        }
        public String getDateOperation()
        {
            String frmdt = dateOperation.ToString("dd-MM-yyyy");
            return frmdt;
        }
        public void setNameOffender(String NameOffender)
        {
            this.nameOffender = NameOffender;
        }
        public String getNameOffender()
        {
            return this.nameOffender;
        }
        public void setNameGroup(String NameGroup)
        {
            this.nameGroup = NameGroup;
        }
        public String getNameGroup()
        {
            return this.nameGroup;
        }
        public void setID(int ID)
        {
            this.idOperation = ID;
        }
        public int getID()
        {
            return this.idOperation;
        }
    }
}
