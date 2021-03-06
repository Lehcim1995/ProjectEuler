﻿using adventofcode2019.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Days
{
    public class Day6_2 : IProblem
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

        private int findShortestRoute()
        {
            List<string> FromYou = new List<string>();
            List<string> FromSan = new List<string>();

            var you = orbits["YOU"];
            FromYou.Add(you);
            while (you != "COM")
            {
                you = orbits[you];
                FromYou.Add(you);
            }

            var san = orbits["SAN"];
            FromSan.Add(san);
            while (san != "COM")
            {
                san = orbits[san];
                FromSan.Add(san);
            }

            for (int i = 0; i < FromYou.Count; i++)
            {
                string y = FromYou[i];
                int index = FromSan.IndexOf(y);

                if (index > 0)
                {
                    return i + index;
                }
            }

            return 0;
        }

        private void debugMap()
        {
            foreach (var orbit in orbits)
            {
                if (orbit.Key == "YOU" || orbit.Value == "YOU" )
                {
                    Console.WriteLine($"{orbit.Value} <- {orbit.Key} ");
                }

                if (orbit.Key == "SAN" || orbit.Value == "SAN")
                {
                    Console.WriteLine($"{orbit.Value} <- {orbit.Key} ");
                }
            }
        }

        public long Answer(params long[] arguments)
        {
            fillData();

            return findShortestRoute();
        }
    }
}
