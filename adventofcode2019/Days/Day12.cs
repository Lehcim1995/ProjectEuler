using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventofcode2019.Interfaces;

namespace adventofcode2019.Days
{
    public class Day12 : IProblem
    {
        internal class Moon
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public int XVelocity { get; set; } = 0;
            public int YVelocity { get; set; } = 0;
            public int ZVelocity { get; set; } = 0;

            public Moon(int x, int y, int z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }

            public void AddVelocity()
            {
                X += XVelocity;
                Y += YVelocity;
                Z += ZVelocity;
            }

            public int Potential()
            {
                return Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
            }

            public int Kinetic()
            {
                return Math.Abs(XVelocity) + Math.Abs(YVelocity) + Math.Abs(ZVelocity);
            }

            public override string ToString()
            {
                return $"pos = <{X},{Y},{Z}> vel = <{XVelocity},{YVelocity},{ZVelocity}>";
            }
        }

        //<x=5, y=-1, z=5>
        // <x=0, y=-14, z=2>
        // <x=16, y=4, z=0>
        // <x=18, y=1, z=16>
        
        private Moon a = new Moon(5, -1, 5);
        private Moon b = new Moon(0, -14, 2);
        private Moon c = new Moon(16, 4, 0);
        private Moon d = new Moon(18, 1, 16);

//        <x=-1, y=0, z=2>
//        <x=2, y=-10, z=-7>
//        <x=4, y=-8, z=8>
//        <x=3, y=5, z=-1>
//        private Moon a = new Moon(-1, 0, 2);
//        private Moon b = new Moon(2, -10, -7);
//        private Moon c = new Moon(4, -8, 8);
//        private Moon d = new Moon(3, 5, -1);

        private (int, int, int) Gravity(Moon moon, Moon[] others)
        {
            int changeX = 0;
            int changeY = 0;
            int changeZ = 0;

            foreach (var other in others)
            {
                int x = other.X - moon.X;
                int y = other.Y - moon.Y;
                int z = other.Z - moon.Z;

                changeX += x < 0 ? -1 : x > 0 ? 1 : 0;
                changeY += y < 0 ? -1 : y > 0 ? 1 : 0;
                changeZ += z < 0 ? -1 : z > 0 ? 1 : 0;
            }

            return (changeX + moon.XVelocity, changeY + moon.YVelocity, changeZ + moon.ZVelocity);
        }

        public long Answer(params long[] arguments)
        {
            for (int step = 0; step < 1000; step++)
            {
                // calculate gravity between moons
                Console.WriteLine($"Step {step}");
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine(c);
                Console.WriteLine(d);
                Console.WriteLine();

                (a.XVelocity, a.YVelocity, a.ZVelocity) = Gravity(a, new[] {b, c, d});
                (b.XVelocity, b.YVelocity, b.ZVelocity) = Gravity(b, new[] {a, c, d});
                (c.XVelocity, c.YVelocity, c.ZVelocity) = Gravity(c, new[] {a, b, d});
                (d.XVelocity, d.YVelocity, d.ZVelocity) = Gravity(d, new[] {a, b, c});

                // add the gravity to the velocity
                a.AddVelocity();
                b.AddVelocity();
                c.AddVelocity();
                d.AddVelocity();
            }

            // calculate potential and kinetic energy

            return (a.Kinetic() * a.Potential()) + (b.Kinetic() * b.Potential()) + (c.Kinetic() * c.Potential()) + (d.Kinetic() * d.Potential());
        }
    }
}
