using adventofcode2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Days
{
    public class Day14 : IProblem
    {

        private string _ore = "ORE";
        private string _fuel = "FUEL";

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


                throw new ArgumentException("Reaction is not in correct thingy");
            }
        }

        Dictionary<String, Reaction> Reactions;
        Dictionary<String, long> Resources;

        private void parseInput()
        {

        }

        public long Answer(params long[] arguments)
        {
            // 

            var r = Reactions[_ore];
            // loop though all the reactions til all reactions have reaced the ore


            throw new NotImplementedException();
        }
    }
}
