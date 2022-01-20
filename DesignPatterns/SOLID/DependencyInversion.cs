using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildOf(string name);
    }

    public class Relationship1 : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }
        public IEnumerable<Person> FindAllChildOf(string name)
        {
            return  relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent)
                .Select(x => x.Item3);
        }
    }

    public class DependencyInversion
    {
        public DependencyInversion(IRelationshipBrowser browser)
        {
            foreach (var r in browser.FindAllChildOf("John"))
            {
                Console.WriteLine($"John has a child: {r.Name}");
            }
        }


        public void DriverMethod()
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };
            Relationships relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);
        }
    }
}
