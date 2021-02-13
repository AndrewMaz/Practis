using System;

namespace Bridge.Coding.Exercise
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }
    public abstract class Shape
    { 
        public string Name { get; set; }

        protected IRenderer renderer;
        protected Shape (IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs { get { return "lines"; } }
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs { get { return "pixels"; } }
    }
    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) :base(renderer)
        {
            Name = "Square";
        }
    }

/*    public class VectorSquare : Square
    {
        public override string ToString() => "Drawing {Name} as lines";
    }

    public class RasterSquare : Square
    {
        public override string ToString() => "Drawing {Name} as pixels";
    }*/

    // imagine VectorTriangle and RasterTriangle are here too
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Square(new RasterRenderer()).ToString());  // "Drawing Square as pixels"
            Console.WriteLine(new Triangle(new VectorRenderer()).ToString()); // "Drawing Triangle as lines"
        }
    }
}
