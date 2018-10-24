using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork5._2
{
    public partial class Form1 : Form
    {
        CayleyTree myTree = new CayleyTree();
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (myTree.Cayley == null)
                myTree.Cayley = this.CreateGraphics();
            else myTree.Cayley.Clear(this.BackColor);
            try
            {
                if (textLength.Text != "") myTree.Length = double.Parse(textLength.Text);
                if (textThLeft.Text != "") myTree.thLeft = double.Parse(textThLeft.Text);
                if (textThRight.Text != "") myTree.thRight = double.Parse(textThRight.Text);
                if (Num.Text != "") myTree.nLine = int.Parse(Num.Text) + 1;
                if (PreL.Text != "") myTree.preLeft = double.Parse(PreL.Text);
                if (PreR.Text != "") myTree.preRight = double.Parse(PreR.Text);
            }
            catch (System.FormatException fe)
            {
                Feedback.Text += "输入数据有误，请重新输入";
            }
            myTree.Draw();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
    public class CayleyTree
    {
        //根长度
        private double length = 100.0;
        public double Length
        {
            set
            {
                if (value > 0 && value < 450) length = value;
            }
            get { return length; }
        }
        //左偏角
        private double th1 = 30 * Math.PI / 180;
        public double thLeft
        {
            set
            {
                if (value > 0 && value < 90) th1 = value * Math.PI / 180;
            }
            get { return th1; }
        }
        //右偏角
        private double th2 = 35 * Math.PI / 180;
        public double thRight
        {
            set
            {
                if (value > 0 && value < 90) th2 = value * Math.PI / 180;
            }
            get { return th2; }
        }
        //左侧比例
        private double pre1 = 0.6;
        public double preLeft
        {
            set
            {
                if (value > 0 && value < 1) pre1 = value;
            }
            get { return pre1; }
        }
        //右侧比例
        private double pre2 = 0.7;
        public double preRight
        {
            set
            {
                if (value > 0 && value < 1) pre2 = value;
            }
            get { return pre2; }
        }
        //分叉数
        private int nline = 8;
        public int nLine
        {
            set
            {
                if (value > 0 && value < 15) nline = value;
            }
            get { return nline; }
        }
        public Graphics Cayley;
        //绘制主函数
        public void Draw()
        {
            DrawCayleyTree(nLine, 400, 550, Length, -Math.PI / 2);
        }
        //绘制线条
        private void DrawLine(double x1, double y1, double x2, double y2)
        {
            Point p1 = new Point((int)x1, (int)y1);
            Point p2 = new Point((int)x2, (int)y2);
            Cayley.DrawLine(Pens.Black, p1, p2);
        }
        //递归函数
        private void DrawCayleyTree(int n,
            double x, double y, double length, double th)
        {
            if (n == 0) return;
            double x1 = x + length * Math.Cos(th);
            double y1 = y + length * Math.Sin(th);
            DrawLine(x, y, x1, y1);
            DrawCayleyTree(n - 1, x1, y1, preLeft * length, th - thLeft);
            DrawCayleyTree(n - 1, x1, y1, preRight * length, th + thRight);
        }
    }
}