using System;
using System.Collections.Generic;

namespace DesignPatterns.SOLID
{
    public enum Color
    {
        Red, Green, Yellow, Blue
    }

    public enum Size
    {
        Small, Medium, Large, XLarge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Size = size;
            Color = color;
        }
    }

    /// <summary>
    /// Product filter should be open for extension and closed for modification 
    /// but here for each of the filter condition class is required to modified to add a new method 
    /// which is violation of open close principle.
    /// To solve this we can use inheritance and implement a pattern called specification pattern
    /// </summary>
    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {

            foreach(var p in products)
            {
                if (p.Size == size)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {

            foreach (var p in products)
            {
                if (p.Color == color)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Color color, Size size)
        {

            foreach (var p in products)
            {
                if (p.Color == color && p.Size == size)
                    yield return p;
            }
        }
    }

    public class OpenCloseViolation
    {
        public void DriverMethod()
        {
            Product apple = new Product("Apple", Color.Red, Size.Small);
            Product tree = new Product("Tree", Color.Green, Size.XLarge);
            Product house = new Product("House", Color.Blue, Size.XLarge);

            Product[] products = { apple, tree, house };
            var pf = new ProductFilter();
            Console.WriteLine("Green products (old): ");

            foreach(var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($"{p.Name} - is green");
            }

            Console.WriteLine("Red products and small size (old): ");
            foreach (var p in pf.FilterByColorAndSize(products, Color.Red, Size.Small))
            {
                Console.WriteLine($"{p.Name} - is red and small");
            }
        }
    }
}
