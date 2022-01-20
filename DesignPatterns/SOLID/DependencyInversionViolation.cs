using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    public enum Relationship
    {
        Child, Parent, Siblings
    }

    public class Person
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// Low level class
    /// </summary>
    public class Relationships
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public List<(Person, Relationship, Person)> Relations => relations;
    }

    /// <summary>
    /// High level module consuming low level module
    /// </summary>
    public class DependencyInversionViolation
    {
        // Violation: It should depend upon abstraction, meaning define an interface and expose members which can be used by high level modules
        public DependencyInversionViolation(Relationships relationships) 
        {
            var relations = relationships.Relations;
            foreach(var r in relations.Where(x => x.Item1.Name== "John" && x.Item2 == Relationship.Parent))
            {
                Console.WriteLine($"John has a child: {r.Item3.Name}");
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
