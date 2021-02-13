using System;

namespace Prototype.Coding.Exercise
{
    class Program
    {
        public class Point
        {
            public int X, Y;
        }

        public class Line
        {
            public Point Start, End;

            public Line DeepCopy()
            {
                var newStart = new Point { X = Start.X, Y = Start.Y };
                var newEnd = new Point { X = End.X, Y = End.Y };
                return new Line { Start = newStart, End = newEnd };
            }
        }

        static void Main(string[] args)
        {
            var line1 = new Line { Start = new Point { X = 1, Y = 1 }, End = new Point { X = 5, Y = 5 } };

            var line2 = line1.DeepCopy();
            line2.Start.X = 6;
            line2.Start.Y = 6;
            line2.End.X = 10;
            line2.End.Y = 10;

            Console.WriteLine("{0} {1} {2} {3}", line1.Start.X, line1.Start.Y, line1.End.X, line1.End.Y);
            Console.WriteLine("{0} {1} {2} {3}", line2.Start.X, line2.Start.Y, line2.End.X, line2.End.Y);
        }
    }
}
