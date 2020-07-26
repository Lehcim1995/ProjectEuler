using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Days.Tests
{
    [TestClass()]
    public class Day16Tests
    {
        private Day16 d16;

        [TestInitialize]
        public void Setup()
        {
            d16 = new Day16();
        }

        [TestMethod()]
        public void patternTest()
        {
            var list = new List<int>() {0, 1, 0, -1};
            
            Assert.AreEqual(list, d16.pattern(1));
        }
    }
}