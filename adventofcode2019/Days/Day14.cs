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
    public class Day14 : IProblem
    {

        private string _ore = "ORE";
        private string _fuel = "FUEL";

        
        class Elemental
        {
            private string Name;
            private Elemental[] requires;


        }

        class Reaction
        {
            private string _output;
            private long _outputAmount;

            private List<string> _inputs;
            private List<long> _inputsValues;


            public Reaction(string reaction)
            {
                // Set values based on shizzle

                // 
                int productLoc = reaction.IndexOf("=>");

                string product = reaction.Substring(productLoc + 3);
                Console.WriteLine(product);

                string[] requirers = reaction.Substring(0, productLoc).Split(',');
                foreach (var req in requirers)
                {
                    Console.WriteLine(" " + req);
                }

                throw new ArgumentException("Reaction is not in correct thingy");
            }
        }

        Dictionary<string, Reaction> Reactions;
        Dictionary<string, long> Resources;

        Dictionary<string, List<string>> EndProducts;


        private void parseInput()
        {
            List<String> lines = new List<string>();
            string line;

            // Read the file and display it line by line.  
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Files\day14_input.txt");

            using (StreamReader file =
                new StreamReader(path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            EndProducts = new Dictionary<string, List<string>>();

            foreach (var reaction in lines)
            {
                int productLoc = reaction.IndexOf("=>");

                string product = reaction.Substring(productLoc + 3);
                Console.WriteLine(product);

                string[] requirers = reaction.Substring(0, productLoc).Split(',');
                foreach(var req in requirers)
                {
                    Console.WriteLine(" " + req);
                }
            }
        }

        public long Answer(params long[] arguments)
        {
            // 

            //var r = Reactions[_ore];
            // loop though all the reactions til all reactions have reaced the ore
            parseInput();

            return 0;
        }
    }
}
