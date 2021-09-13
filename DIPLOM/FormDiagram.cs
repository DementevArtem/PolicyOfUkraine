using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM
{
    public partial class FormDiagram : Form
    {
        public FormDiagram()
        {
            InitializeComponent();
            Bunifu.DataViz.WinForms.Canvas Canvas = new Bunifu.DataViz.WinForms.Canvas();
            Bunifu.DataViz.WinForms.DataPoint values = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_splineArea);
            Random R = new Random();
            values.addLabely("JAN", 65);
            values.addLabely("FEB", 15);
            values.addLabely("MART", 45);
            values.addLabely("APRIL", 25);
            values.addLabely("MAY", 5);
            values.addLabely("DEC", 75);
            Canvas.addData(values);
            bunifuDataViz1.Render(Canvas);
        }
    }
}
