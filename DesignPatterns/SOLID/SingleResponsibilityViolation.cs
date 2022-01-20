using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPatterns.SOLID
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries); 
        }

        // Violation of single responsibility here by adding additional responsibilty of storing and reading a Journal.
        public void SaveToFile(string filename)
        {
            File.WriteAllText(filename, ToString());
        }

        public static Journal Load(string filename)
        {
            return new Journal();
        }
    }
    public class SingleResponsibilityViolation
    {
        public void DriverMethod()
        {
            var j = new Journal();
            j.AddEntry("This is a new Journal");
            j.AddEntry("New entry here");
            Console.WriteLine(j);
        }
    }
}
