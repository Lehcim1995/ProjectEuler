using System;
using adventofcode2019.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2019.Days
{
    public class Day16 : IProblem
    {
        private string _input =
            "59704176224151213770484189932636989396016853707543672704688031159981571127975101449262562108536062222616286393177775420275833561490214618092338108958319534766917790598728831388012618201701341130599267905059417956666371111749252733037090364984971914108277005170417001289652084308389839318318592713462923155468396822247189750655575623017333088246364350280299985979331660143758996484413769438651303748536351772868104792161361952505811489060546839032499706132682563962136170941039904873411038529684473891392104152677551989278815089949043159200373061921992851799948057507078358356630228490883482290389217471790233756775862302710944760078623023456856105493";

        public List<int> FFT(List<int> input)
        {
            var output = new List<int>(input.Capacity);
            var iteration = 1;
            var pattern = this.pattern(iteration);

            foreach (var far in input)
            {

                int i = 1;
                var num = 0;
                foreach (var x in input)
                {
                    var pat = pattern[i++%pattern.Count];
                    num += x * pat;
                }
                // take only first number;

                output.Add(Math.Abs(num % 10));
                
                pattern = this.pattern(++iteration);
            }

            return output;
        }

        public List<int> pattern(int n)
        {
            
            var output = new List<int>();
            int first = 0;
            int second = 1;
            int thirth = 0;
            int forth = -1;

            for (int i = 0; i < n; i++)
            {
                output.Add(first);
            }

            for (int i = 0; i < n; i++)
            {
                output.Add(second);
            }

            for (int i = 0; i < n; i++)
            {
                output.Add(thirth);
            }

            for (int i = 0; i < n; i++)
            {
                output.Add(forth);
            }

            return output;
        }

        public long Answer(params long[] arguments)
        {
            var firstIn = _input.ToCharArray().ToList().ConvertAll(c => (int)char.GetNumericValue(c));

            for (int i = 0; i < 100; i++)
            {
                firstIn = FFT(firstIn);
            }

            String awnser = "";

            // var test= FFT(new List<int>() { 1,2,3,4,5,6,7,8 });
            firstIn.GetRange(0, 8).ForEach(x => awnser += x);
            return Int64.Parse(awnser);
        }
    }
}