using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DesignPatterns.SOLID
{
    public class Journal1
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

    }

    public class Persistence
    {
        public void SaveToFile(Journal1 j,string filename,bool overwrite = false)
        {
            if(overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }

    public class SingleResposibility
    {
        public void DriverMethod()
        {
            var j = new Journal1();
            j.AddEntry("This is a new Journal");
            j.AddEntry("New entry here");
            Console.WriteLine(j);

            var p = new Persistence();
            string filepath = @"C:\Users\fenil\Desktop\temp\journal.txt";
            p.SaveToFile(j, filepath, true);
            Process.Start("notepad.exe",filepath);
        }
    }
}
