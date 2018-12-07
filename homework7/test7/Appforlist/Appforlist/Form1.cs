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

    public partial class Form1 : Form
    {
        Form2 b = null;
        Form3 c = null;
        Form4 d = null;
        Form5 f = null;

        public Form1()
        {
            InitializeComponent();
            b = new Form2();
            c = new Form3();
            d = new Form4();
            f = new Form5();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int ch = int.Parse(textBox1.Text);
            switch (ch)
            {
                case 1:
                    b.ShowDialog();
                    break;
                case 2:
                    c.ShowDialog();
                    break;
                case 3:
                    d.ShowDialog();
                    break;
                case 4:
                    f.ShowDialog();
                    break;
                default:
                    label8.Text = "输入错误！请重新输入！";
                    break;
            }

        }
    }
}
