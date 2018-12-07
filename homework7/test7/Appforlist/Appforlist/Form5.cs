using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using List;

namespace Appforlist
{
    public partial class Form5 : Form
    {
        Form6 m = null;
        Form7 n = null;
        public Form5()
        {
            InitializeComponent();
            m = new Form6();
            n = new Form7();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            m.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            n.ShowDialog();
        }
    }
}
