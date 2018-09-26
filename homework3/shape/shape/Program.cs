using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shape
{
    public abstract class Shape
    {
        private string myId;
        public Shape(String s)
        {
            Id = s;
        }

        public string Id
        {
            get
            {
                return myId;
            }
            set
            {
                myId = value;
            }
        }

        public abstract double Area
        {
            get;
        }

        public virtual void Draw()
        {
            Console.WriteLine("Draw Shape Icon");
        }

        public override string ToString()
        {
            return Id + "Area=" + string.Format("{0:F2}", Area);
        }
    }

    //正方形类
    public class Square : Shape
    {
        private int mySide;

        public Square(int side, string id) : base(id)
        {
            mySide = side;
        }

        public override double Area
        {
            get
            {
                return mySide * mySide;
            }
        }

        public override void Draw()
        {
            Console.WriteLine("Draw 4 side:" + mySide);
        }
    }
//圆形类
public class Circle:Shape
    {
        private int myRadius;
        public Circle (int radius,string id):base(id)
        {
            myRadius = radius;
        }
        public override double Area
        {
            get
            {
                return myRadius * myRadius * System.Math.PI;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw Ciecle:"+myRadius);
        }
    }

//矩形类
public class Rectangle : Shape
    {
        private int myWidth;
        private int myHeight;

        public Rectangle(int width,int height,string id):base(id)
        {
            myWidth = width;
            myHeight = height;
        }
        public override double Area
        {
            get
            {
                return myWidth * myHeight;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw Rectangle");
        }
    }

//三角形类
public class Triangle : Shape
    {
        private int myBottom;
        private int myHeight;
        public Triangle(int bottom, int height, string id) : base(id)
        {
            myBottom = bottom;
            myHeight = height;
        }
        public override double Area
        {
            get
            {
                return myBottom * myHeight * 0.5;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw Triangle");
        }
    }
    public class TestClass
    {
        static void Main(string[] args)
        {
            Shape[] shapes =
            {
                new Square(5,"Square "),
                new Circle(3,"Circle "),
                new Rectangle(4,5,"Rectangle"),
                new Triangle(4,5,"Triangle ")
            };
            System.Console.WriteLine("Shapes Collection");
            foreach (Shape s in shapes)
            {
                System.Console.WriteLine(s);
            }
        }
    }
}

