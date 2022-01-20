using System;

namespace DesignPatterns.SOLID
{
    public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public new int Width  // Violation use override instead of new and make parent property virtual
        { 
            set { base.Width = base.Height = value; } 
        }
        
        public new int Height
        {
            set { base.Height = base.Width = value; }    
        }
    }

    public class LiskovSubstitutionViolation
    {
        public static int Area(Rectangle rectangle) => rectangle.Width * rectangle.Height;
        public void DriverMethod()
        {
            Rectangle rc = new Rectangle(2,5);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            Rectangle sq = new Square(); // Violation:Should be able to use Parent class reference and work perfectly fine.
            sq.Width = 5;
            Console.WriteLine($"{sq} has area {Area(sq)}");

        }
    }
}
