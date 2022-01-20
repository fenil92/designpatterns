using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecifictaion : ISpecification<Product>
    {
        private Color color;

        public ColorSpecifictaion(Color color)
        { 
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class SizeSpecifictaion : ISpecification<Product>
    {
        private Size size;

        public SizeSpecifictaion(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;
        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }
        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                    yield return i;
            }
        }
    }

    public class OpenClose
    {
        public void DriverMethod()
        {
            Product apple = new Product("Apple", Color.Red, Size.Small);
            Product tree = new Product("Tree", Color.Green, Size.XLarge);
            Product house = new Product("House", Color.Blue, Size.XLarge);

            Product[] products = { apple, tree, house };
            var bf = new BetterFilter();
            Console.WriteLine("Green products (new): ");

            foreach (var p in bf.Filter(products, new ColorSpecifictaion(Color.Green)))
            {
                Console.WriteLine($"{p.Name} - is green");
            }

            Console.WriteLine("Red products and small size (new): ");
            foreach (var p in bf.Filter(
                products, 
                new AndSpecification<Product>(new ColorSpecifictaion(Color.Red), new SizeSpecifictaion(Size.Small))))
            {
                Console.WriteLine($"{p.Name} - is red and small");
            }
        }
    }
}
