using System;

namespace DesignPatterns.SOLID
{
    public class Rectangle1
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle1()
        {

        }

        public Rectangle1(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square1 : Rectangle1
    {
        public override int Width  
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Height = base.Width = value; }
        }
    }


    public class LiskovSubstitution
    {
        public static int Area(Rectangle1 rectangle) => rectangle.Width * rectangle.Height;
        public void DriverMethod()
        {
            Rectangle1 rc = new Rectangle1(2, 5);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            Rectangle1 sq = new Square1(); 
            sq.Width = 5;
            Console.WriteLine($"{sq} has area {Area(sq)}");

        }
    }
}
