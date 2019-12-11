using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Classes.Tests
{
    [TestClass()]
    public class IntCodeProcessor2Tests
    {
        private long[] test1 = {109, -1, 4, 1, 99};// outputs -1
        private long[] test2 = {109, -1, 104, 1, 99}; // outputs 1
        private long[] test3 = {109, -1, 204, 1, 99}; // outputs 109
        private long[] test4 = {109, 1, 9, 2, 204, -6, 99};// outputs 204
        private long[] test5 = {109, 1, 109, 9, 204, -6, 99}; // outputs 204
        private long[] test6 = {109, 1, 209, -1, 204, -106, 99}; // outputs 204
        private long[] test7 = {109, 1, 3, 3, 204, 2, 99}; // outputs the input
        private long[] test8 = {109, 1, 203, 2, 204, 2, 99}; // outputs the input

        private IntCodeProcessor2 icp2;

        [TestMethod()]
        public void RunTest()
        {
            icp2 = new IntCodeProcessor2(test1) {Debug = false};
            icp2.Run();

            icp2 = new IntCodeProcessor2(test2) { Debug = false };
            icp2.Run();

            icp2 = new IntCodeProcessor2(test3) { Debug = false };
            icp2.Run();

            icp2 = new IntCodeProcessor2(test4) { Debug = false };
            icp2.Run();

            icp2 = new IntCodeProcessor2(test5) { Debug = false };
            icp2.Run();

            icp2 = new IntCodeProcessor2(test6) { Debug = false };
            icp2.Run();

            icp2 = new IntCodeProcessor2(test7) { Debug = false, InputModeSetting = IntCodeProcessor2.InputMode.Set, InputNumbers = {32}};
            icp2.Run();

            icp2 = new IntCodeProcessor2(test8) { Debug = false, InputModeSetting = IntCodeProcessor2.InputMode.Set, InputNumbers = { 32 } };
            icp2.Run();

            Assert.Fail();
        }
    }
}