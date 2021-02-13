using System;

namespace Adapter.Coding.Exercise
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        int side;
        public SquareToRectangleAdapter(Square square)
        {
            side = square.Side;
        }
        int IRectangle.Width { get { return side; } }
        int IRectangle.Height { get { return side; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IRectangle sq = new SquareToRectangleAdapter(new Square { Side = 10 });

            Console.WriteLine(sq.Area());
        }
    }
}
