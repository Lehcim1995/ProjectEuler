using adventofcode2019.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Days
{
    public class Day6 : IProblem
    {
        class Orbit
        {
            public String name;
            public Orbit orbit;

            public Orbit(String name)
            {
                this.name = name;
            }

            public Orbit(String name, Orbit orbit)
            {
                this.name = name;
                this.orbit = orbit;
            }
        }

        List<Orbit> parsedData;
        Dictionary<string, string> orbits;

        private string[] readLines()
        {
            List<String> lines = new List<string>();
            string line;

            // Read the file and display it line by line.  
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Files\Orbits.txt");

            using (StreamReader file =
                new StreamReader(path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines.ToArray();
        }

        private void fillData()
        {
            // key orbits value.
            orbits = new Dictionary<string, string>();

            foreach (string orbit in readLines())
            {
                // p2 orbits around p1
                string p1 = orbit.Substring(0, 3);
                string p2 = orbit.Substring(4, 3);

                //Console.WriteLine($" p1 {p1} -> p2 {p2} ");
                orbits.Add(p2, p1);
            }
        }

        private int CountdirectOrbits()
        {
            return orbits.Count();
        }

        private int CountIndirectOrbits()
        {
            int count = 0;

            foreach(var orbit in orbits)
            {
                var l = orbits[orbit.Key];
                while (l != "COM")
                {
                    count++;
                    l = orbits[l];
                }
            }

            return count;
        }

        private void debugMap()
        {
            string origin = "COM";

            var s = orbits.First(t => t.Value == "COM");
            Console.WriteLine($"s {s.Key} <- {s.Value}");

            for (int i = 0; i < 500; i++)
            {
                s = orbits.First(t => t.Value == s.Key);
                Console.WriteLine($"s {s.Key} <- {s.Value}");
            }



        }

        public long Answer(params long[] arguments)
        {
            int count = 0;

            fillData();

            count += CountdirectOrbits();
            count += CountIndirectOrbits();

            return count;
        }
    }
}
